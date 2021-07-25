using System;
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
                .Include(f => f.ListaDeLinks)
                .Include(f => f.ListaDeFavoritos)
                .FirstOrDefaultAsync(f => f.Id == id);

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

            // Redireciona para a página do Filme
            return RedirectToAction(nameof(Details), new { id = filmeId });
        }

        // POST: Filmes/AddFavorito
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        /// <summary>
        /// Função que permite adicionar um Favorito à base de dados com o Id do Utilizador + Id do Filme
        /// </summary>
        /// <param name="filmeId">Id do Filme que está a adicionar aos favoritos</param>
        /// <returns>A respetiva View</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddFavorito(int filmeId)
        {
            // Busca o Utilizador que está a adicionar o Favorito para saber o seu Id
            var utilizador = _context.Utilizadores.Where(u => u.UserName == _userManager.GetUserId(User)).FirstOrDefault();

            // Encontra o Filme através do Id que recebeu como parâmetro
            var filme = _context.Filmes.Where(f => f.Id == filmeId).FirstOrDefault();

            // Cria um novo Favorito com os atributos definidos
            var favorito = new Favoritos
            {
                UtilizadorFK = utilizador.Id,
                FilmeFK = filme.Id
            };

            // Verifica se o ModelState é válido
            if (ModelState.IsValid)
            {
                try
                {
                    // Adicionar o Favorito à base de dados
                    _context.Add(favorito);
                    // Guarda as alterações feitas na base de dados
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Details), new { id = filmeId });
                }
                catch (Exception)
                {
                    // Apresenta uma mensagem de erro se ocorreu uma excepção nas linhas de código acima
                    ModelState.AddModelError("", "Ocorreu um erro na adição do Favorito!");
                }
            }

            // Redireciona para a página do Filme
            return RedirectToAction(nameof(Details), new { id = filmeId });
        }


        // POST: Filmes/DeleteFavorito
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        /// <summary>
        /// Função que permite remover um Favorito da base de dados com o Id do Utilizador + Id do Filme
        /// </summary>
        /// <param name="filmeId">Id do Filme que está a removido aos favoritos</param>
        /// <returns>A respetiva View</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteFavorito(int filmeId)
        {
            // Vai buscar o Utilizador que está a remover o Favorito 
            var utilizador = _context.Utilizadores.Where(u => u.UserName == _userManager.GetUserId(User)).FirstOrDefault();

            // Verifica qual o Favorito através do Id do Utilizador + Id do Filme
            var favorito = _context.Favoritos.Where(f => f.FilmeFK == filmeId && f.UtilizadorFK == utilizador.Id).FirstOrDefault();

            // Verifica se o ModelState é válido
            if (ModelState.IsValid)
            {
                try
                {
                    // Remover o Favorito da base de dados
                    _context.Remove(favorito);
                    // Guarda as alterações feitas na base de dados
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Details), new { id = filmeId });
                }
                catch (Exception)
                {
                    // Apresenta uma mensagem de erro se ocorreu uma excepção nas linhas de código acima
                    ModelState.AddModelError("", "Ocorreu um erro na remoção do Favorito!");
                }
            }

            // Redireciona para a página do Filme
            return RedirectToAction(nameof(Details), new { id = filmeId });
        }


        // POST: Filmes/MudaVisivel
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        /// <summary>
        /// Função que mudar a Visibilidade de um Link
        /// </summary>
        /// <param name="linkId">Id do Link que vai sofrer alteração na visibulidade</param>
        /// <returns>A respetiva View</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MudaVisivel(int linkId, int filmeId)
        {
            // Vai buscar o Link a partir do parâmetro recebido (linkId) 
            var link = _context.Links.Where(l => l.Id == linkId).FirstOrDefault();

            // Dependendo da Visibilidade, vai se reverter
            if(link.Visivel == true)
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
                    return RedirectToAction(nameof(Details), new { id = filmeId });
                }
                catch (Exception)
                {
                    // Apresenta uma mensagem de erro se ocorreu uma excepção nas linhas de código acima
                    ModelState.AddModelError("", "Ocorreu um erro na mudança da visibilidade do Link!");
                }
            }

            // Redireciona para a página do Filme
            return RedirectToAction(nameof(Details), new { id = filmeId });
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
