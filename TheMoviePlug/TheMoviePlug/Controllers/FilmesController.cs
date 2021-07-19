﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager;

        public FilmesController(ApplicationDbContext context, IWebHostEnvironment caminho, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _caminho = caminho;
            _userManager = userManager;
        }

        // GET: Filmes
        public async Task<IActionResult> Index()
        {
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
                .Include(x => x.ListaDeLinks)
                .Include(x => x.ListaDeFavoritos)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (filme == null)
            {
                // return NotFound();
                return RedirectToAction("Index");
            }

            if (User.Identity.IsAuthenticated)
            {
                // esta variável vai ter o valor do username do utilizador
                var utilizador = await _context.Utilizadores.Where(u => u.UserName == _userManager.GetUserId(User)).FirstOrDefaultAsync();

                // vai procurar pelo "Gosto" do User
                var favorito = await _context.Favoritos.Where(f => f.FilmeFK == id && f.UtilizadorFK == utilizador.Id).FirstOrDefaultAsync();

                if (favorito == null)
                {
                    ViewBag.Favorito = false;
                }
                else
                {
                    ViewBag.Favorito = true;
                }
            }

            return View(filme);
        }

        // GET: Filmes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Filmes/CreateLink
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateLink(int filmeId, string url)
        {
            // Guarda o Utilizador que está a adicionar o Link 
            var utilizador = _context.Utilizadores.Where(u => u.UserName == _userManager.GetUserId(User)).FirstOrDefault();

            // Cria um novo Link com os atributos definidos
            var link = new Links
            {
                URL = url,
                Visivel = true,
                UtilizadorFK = utilizador.Id,
                FilmeFK = filmeId
            };

            if (ModelState.IsValid)
            {
                try
                {
                    // Adicionar o Link à base de dados
                    _context.Add(link);
                    // Guarda as alterações feitas na base de dados
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Details), new { id = filmeId });
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Ocorreu um erro na adição do Link!");
                }
            }

            return View();
        }

        // POST: Filmes/CreateLink
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddFavorito(int filmeId)
        {
            // Guarda o Utilizador que está a adicionar o Link 
            var utilizador = _context.Utilizadores.Where(u => u.UserName == _userManager.GetUserId(User)).FirstOrDefault();

            var filme = _context.Filmes.Where(f => f.Id == filmeId).FirstOrDefault();

            // Cria um novo Link com os atributos definidos
            var favorito = new Favoritos
            {
                UtilizadorFK = utilizador.Id,
                FilmeFK = filme.Id
            };

            if (ModelState.IsValid)
            {
                try
                {
                    // Adicionar o Link à base de dados
                    _context.Add(favorito);
                    // Guarda as alterações feitas na base de dados
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Details), new { id = filmeId });
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Ocorreu um erro na adição do Favorito!");
                }
            }

            return View();
        }

        // POST: Filmes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Titulo,Categoria,Lancamento,Classificacao,Realizador,Elenco,Sinopse")] Filmes filme, IFormFile capaFilme)
        {

            string nomeImagem = "";

            filme.Visibilidade = true;

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

            var filme = await _context.Filmes.FindAsync(id);
            if (filme == null)
            {
                return NotFound();
            }
            return View(filme);
        }

        // POST: Filmes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Imagem,Categoria,Lancamento,Classificacao,Realizador,Elenco,Sinopse,Visibilidade")] Filmes filme, IFormFile capaFilme)
        {
            if (id != filme.Id)
            {
                return RedirectToAction(nameof(Index));
            }


            string nomeImagem = "";
            string localizacao = _caminho.WebRootPath;

            if (capaFilme != null)
            {
                if (capaFilme.ContentType == "image/jpeg" || capaFilme.ContentType == "image/png")
                {
                    // definir o novo nome da imagem     
                    nomeImagem = filme.Titulo;
                    // determinar a extensão do nome da imagem
                    string extensao = Path.GetExtension(capaFilme.FileName).ToLower();
                    // agora, consigo ter o nome final do ficheiro
                    nomeImagem = nomeImagem + extensao;

                    // associar este ficheiro aos dados da Imagem do Filme
                    filme.Imagem = nomeImagem;

                    // localização do armazenamento da imagem
                    nomeImagem = Path.Combine(localizacao, "Imagens", nomeImagem);
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
                    _context.Update(filme);
                    await _context.SaveChangesAsync();

                    if (capaFilme != null)
                    {
                        string localizacaoFicheiro = Path.Combine(localizacao, "Imagens", filme.Imagem);
                        if (System.IO.File.Exists(localizacaoFicheiro))
                        {
                            System.IO.File.Delete(localizacaoFicheiro);
                        }

                        using var stream = new FileStream(nomeImagem, FileMode.Create);
                        await capaFilme.CopyToAsync(stream);
                    }

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmesExists(filme.Id))
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(filme);
        }

        // GET: Filmes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var filmes = await _context.Filmes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filmes == null)
            {
                return RedirectToAction(nameof(Index));
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
