using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheMoviePlug.Data;
using TheMoviePlug.Models;

namespace TheMoviePlug.Controllers
{
    public class UtilizadoresController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UtilizadoresController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Utilizadores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Utilizadores.ToListAsync());
        }

        // GET: Utilizadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilizadores = await _context.Utilizadores.Include(u => u.ListaFavoritos)
                .ThenInclude(f => f.Filme)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (utilizadores == null)
            {
                return NotFound();
            }


            return View(utilizadores);
        }


        // POST: Utilizadores/MudaAtivo
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        /// <summary>
        /// Função que mudar o atributo "Ativo" de um Utilizador.
        /// Se mudar para false, bloqueia o utilizador durante o periodo de 1 ano.
        /// </summary>
        /// <param name="utilizadorId">Id do Link que vai sofrer alteração na visibulidade</param>
        /// <returns>A View do Index</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MudaAtivo(int utilizadorId)
        {
            // Vai buscar o Utilizador a partir do parâmetro recebido (utilizadorId) 
            var utilizador = _context.Utilizadores.Where(u => u.Id == utilizadorId).FirstOrDefault();

            // Vai buscar o AspNet User a partir do Email do Utilizador
            var user = _context.Users.Where(u => u.Email == utilizador.Email).FirstOrDefault();

            // Dependendo do atributo "Ativo", vai se reverter
            if (utilizador.Ativo == true)
            {
                utilizador.Ativo = false;
                // Define a data de fim do bloqueio para o fim do ano seguinte
                var dataBloqueio = new DateTime(DateTime.Now.Year + 1, 1, 1);

                user.LockoutEnd = dataBloqueio;
            }
            else
            {
                utilizador.Ativo = true;
                user.LockoutEnd = null;
            }

            // Verifica se o ModelState é válido
            if (ModelState.IsValid)
            {
                try
                {
                    // Atualiza o AspNet User na base de dados
                    _context.Update(user);
                    // Atualiza o Utilizador na base de dados
                    _context.Update(utilizador);
                    // Guarda as alterações feitas na base de dados
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    // Apresenta uma mensagem de erro se ocorreu uma excepção nas linhas de código acima
                    ModelState.AddModelError("", "Ocorreu um erro na mudança do 'Ativo' do Utilizador!");
                }
            }

            // Redireciona para a página do Filme
            return RedirectToAction(nameof(Index));
        }


        // POST: Utilizadores/DeleteFavorito
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        /// <summary>
        /// Função que permite remover um Favorito da base de dados com o Id do Utilizador + Id do Filme
        /// </summary>
        /// <param name="filmeId">Id do Filme que está a removido aos Favoritos</param>
        /// <param name="utilizadorId">Id do Utilizador que está a remover o Filme dos Favoritos</param>
        /// <returns>A respetiva View</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteFavorito(int filmeId, int utilizadorId)
        {

            // Verifica qual o Favorito através do Id do Utilizador + Id do Filme
            var favorito = _context.Favoritos.Where(f => f.FilmeFK == filmeId && f.UtilizadorFK == utilizadorId).FirstOrDefault();

            // Verifica se o ModelState é válido
            if (ModelState.IsValid)
            {
                try
                {
                    // Remover o Favorito da base de dados
                    _context.Remove(favorito);
                    // Guarda as alterações feitas na base de dados
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Details), new { id = utilizadorId });
                }
                catch (Exception)
                {
                    // Apresenta uma mensagem de erro se ocorreu uma excepção nas linhas de código acima
                    ModelState.AddModelError("", "Ocorreu um erro na remoção do Favorito!");
                }
            }

            // Redireciona para a página do Filme
            return RedirectToAction(nameof(Details), new { id = utilizadorId });
        }

            // GET: Utilizadores/Create
            public IActionResult Create()
        {
            return View();
        }

        // POST: Utilizadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Email,Telemovel,Ativo")] Utilizadores utilizadores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(utilizadores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(utilizadores);
        }

        // GET: Utilizadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilizadores = await _context.Utilizadores.FindAsync(id);
            if (utilizadores == null)
            {
                return NotFound();
            }
            return View(utilizadores);
        }

        // POST: Utilizadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Email,Telemovel,Ativo")] Utilizadores utilizadores)
        {
            if (id != utilizadores.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(utilizadores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtilizadoresExists(utilizadores.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(utilizadores);
        }

        // GET: Utilizadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilizadores = await _context.Utilizadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (utilizadores == null)
            {
                return NotFound();
            }

            return View(utilizadores);
        }

        // POST: Utilizadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var utilizador = await _context.Utilizadores.FindAsync(id);
            _context.Utilizadores.Remove(utilizador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtilizadoresExists(int id)
        {
            return _context.Utilizadores.Any(e => e.Id == id);
        }
    }
}
