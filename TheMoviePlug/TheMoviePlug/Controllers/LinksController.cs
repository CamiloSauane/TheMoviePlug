using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheMoviePlug.Data;
using TheMoviePlug.Models;

namespace TheMoviePlug.Controllers
{
    public class LinksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LinksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Links
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Links.Include(l => l.Filme).Include(l => l.Utilizador);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Links/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var links = await _context.Links
                .Include(l => l.Filme)
                .Include(l => l.Utilizador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (links == null)
            {
                return NotFound();
            }

            return View(links);
        }

        // GET: Links/Create
        public IActionResult Create()
        {
            ViewData["FilmeFK"] = new SelectList(_context.Filmes, "Id", "Titulo");
            ViewData["UtilizadorFK"] = new SelectList(_context.Utilizadores, "Id", "Email");
            return View();
        }


        // POST: Links/MudaVisivel
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        /// <summary>
        /// Função que mudar a Visibilidade de um Link
        /// </summary>
        /// <param name="linkId">Id do Link que vai sofrer alteração na visibulidade</param>
        /// <returns>A respetiva View</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MudaVisivel(int linkId)
        {
            // Vai buscar o Link a partir do parâmetro recebido (linkId) 
            var link = _context.Links.Where(l => l.Id == linkId).FirstOrDefault();

            // Dependendo da Visibilidade, vai se reverter
            if (link.Visivel == true)
            {
                link.Visivel = false;
            }
            else
            {
                link.Visivel = true;
            }

            // Verifica se o ModelState é válido
            if (ModelState.IsValid)
            {
                try
                {
                    // Atualiza o Link na base de dados
                    _context.Update(link);
                    // Guarda as alterações feitas na base de dados
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    // Apresenta uma mensagem de erro se ocorreu uma excepção nas linhas de código acima
                    ModelState.AddModelError("", "Ocorreu um erro na mudança da visibilidade do Link!");
                }
            }

            // Redireciona para a página do Filme
            return RedirectToAction(nameof(Index));
        }


        // POST: Links/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,URL,Visivel,UtilizadorFK,FilmeFK")] Links links)
        {
            if (ModelState.IsValid)
            {
                _context.Add(links);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FilmeFK"] = new SelectList(_context.Filmes, "Id", "Titulo", links.FilmeFK);
            ViewData["UtilizadorFK"] = new SelectList(_context.Utilizadores, "Id", "Email", links.UtilizadorFK);
            return View(links);
        }

        // GET: Links/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var link = await _context.Links.Include(l => l.Utilizador).FirstOrDefaultAsync(l => l.Id == id);
            if (link == null)
            {
                return NotFound();
            }
            ViewData["FilmeFK"] = new SelectList(_context.Filmes, "Id", "Titulo", link.FilmeFK);
            ViewData["UtilizadorFK"] = new SelectList(_context.Utilizadores, "Id", "Email", link.UtilizadorFK);
            return View(link);
        }

        // POST: Links/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,URL,Visivel,UtilizadorFK,FilmeFK")] Links links)
        {
            if (id != links.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(links);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LinksExists(links.Id))
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
            ViewData["FilmeFK"] = new SelectList(_context.Filmes, "Id", "Titulo", links.FilmeFK);
            ViewData["UtilizadorFK"] = new SelectList(_context.Utilizadores, "Id", "Email", links.UtilizadorFK);
            return View(links);
        }

        // GET: Links/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var links = await _context.Links
                .Include(l => l.Filme)
                .Include(l => l.Utilizador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (links == null)
            {
                return NotFound();
            }

            return View(links);
        }

        // POST: Links/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var links = await _context.Links.FindAsync(id);
            _context.Links.Remove(links);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LinksExists(int id)
        {
            return _context.Links.Any(e => e.Id == id);
        }
    }
}
