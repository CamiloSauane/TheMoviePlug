using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheMoviePlug.Data;
using TheMoviePlug.Models;

namespace TheMoviePlug.Controllers
{
    public class FilmesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _caminho;

        public FilmesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Filmes
        public async Task<IActionResult> Index()
        {
            //Filmes filme = await _context.Filmes.FirstOrDefaultAsync(f => f.Id == 1);
            //Utilizadores utilizador = await _context.Utilizadores.FirstOrDefaultAsync(u => u.Id == 1);
            //utilizador.ListaFilmesFav.Add(filme);
            //filme.ListaUtilizadoresFav.Add(utilizador);
            //_context.Utilizadores.Update(utilizador);
            //_context.Filmes.Update(filme);
            //await _context.SaveChangesAsync();
            return View(await _context.Filmes.ToListAsync());
        }

        // GET: Filmes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                // return NotFound();
                return RedirectToAction("Index");
            }

            var filme = await _context.Filmes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filme == null)
            {
                // return NotFound();
                return RedirectToAction("Index");
            }

            return View(filme);
        }

        // GET: Filmes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Filmes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Titulo,Categoria,Lancamento,Classificacao,Realizador,Elenco,Sinopse,Visibilidade")] Filmes filme, IFormFile capaFilme)
        {

            string nomeImagem = "";

            if (capaFilme == null)
            {
                // não há ficheiro
                // adicionar mensagem de erro
                ModelState.AddModelError("", "Adicione, por favor, a imagem da capa do filme!");
                // devolver o controlo à View
                return View(filme);
            }
            else
            {
                // há ficheiro. Mas, será um ficheiro válido?
                // https://developer.mozilla.org/pt-BR/docs/Web/HTTP/Basics_of_HTTP/MIME_types
                if (capaFilme.ContentType == "image/jpeg" || capaFilme.ContentType == "image/png")
                {
                    // definir o novo nome da fotografia     
                    nomeImagem = filme.Titulo;
                    // determinar a extensão do nome da imagem
                    string extensao = Path.GetExtension(capaFilme.FileName).ToLower();
                    // agora, consigo ter o nome final do ficheiro
                    nomeImagem = nomeImagem + extensao;
                     
                    // associar este ficheiro aos dados da Imagem do Filme
                    filme.Imagem = nomeImagem;

                    // localização do armazenamento da imagem
                    string localizacaoFicheiro = _caminho.WebRootPath;
                    nomeImagem = Path.Combine(localizacaoFicheiro, "Imagens", nomeImagem);
                }
                else
                {
                    // ficheiro não é válido
                    // adicionar mensagem de erro
                    ModelState.AddModelError("", "Só pode escolher uma imagem para a associar ao filme.");
                    // devolver o controlo à View
                    return View(filme);
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(filme);
                    await _context.SaveChangesAsync();

                    using var stream = new FileStream(nomeImagem, FileMode.Create);
                    await capaFilme.CopyToAsync(stream);

                    return RedirectToAction(nameof(Index));
                }
                catch {
                    ModelState.AddModelError("", "Ocorreu um erro na adição do Filme!");
                }
                
            }
            return View(filme);
        }

        // GET: Filmes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmes = await _context.Filmes.FindAsync(id);
            if (filmes == null)
            {
                return NotFound();
            }
            return View(filmes);
        }

        // POST: Filmes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Imagem,Categoria,Lancamento,Classificacao,Realizador,Elenco,Sinopse,Visibilidade")] Filmes filmes)
        {
            if (id != filmes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filmes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmesExists(filmes.Id))
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
            return View(filmes);
        }

        // GET: Filmes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmes = await _context.Filmes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filmes == null)
            {
                return NotFound();
            }

            return View(filmes);
        }

        // POST: Filmes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filme = await _context.Filmes.FindAsync(id);

            try {
                _context.Filmes.Remove(filme);
                await _context.SaveChangesAsync();

                // NÃO ESQUECER DE REMOVER O FICHEIRO
                // localização do armazenamento da imagem
                string localizacao = _caminho.WebRootPath;
                string localizacaoFicheiro = Path.Combine(localizacao, "Imagens", filme.Imagem);
                if (System.IO.File.Exists(localizacaoFicheiro))
                {
                    System.IO.File.Delete(localizacaoFicheiro);
                }

            }
            catch (Exception) {
                ModelState.AddModelError("", "Ocorreu um erro no processo da eliminação do Filme!");
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool FilmesExists(int id)
        {
            return _context.Filmes.Any(e => e.Id == id);
        }
    }
}
