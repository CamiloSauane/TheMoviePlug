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
        // Variável auxiliar que representa a base de dados
        private readonly ApplicationDbContext _context;
        // Variável auxiliar que vai servir para obter o PATH do projeto
        private readonly IWebHostEnvironment _caminho;
        // Variável auxiliar para interagir com o ASP.NET User (ApplicationUser)
        private readonly UserManager<ApplicationUser> _userManager;

        public FilmesController(ApplicationDbContext context, IWebHostEnvironment caminho, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _caminho = caminho;
            _userManager = userManager;
        }

        // GET: Filmes
        /// <summary>
        /// Fornece a página 'Lista de Filmes', com a listagem dos Filmes
        /// </summary>
        /// <returns>View com uma listagem dos Filmes</returns>
        public async Task<IActionResult> Index()
        {
            // Retorna uma View com uma listagem dos Filmes
            return View(await _context.Filmes.ToListAsync());
        }

        // GET: Filmes/Details/5
        /// <summary>
        /// Fornece a página dos detalhes de um Filme a partir do seu Id
        /// </summary>
        /// <param name="id">Id do Filme fornecido no URL</param>
        /// <returns>View com os detalhes do respetivo Filme</returns>
        public async Task<IActionResult> Details(int? id)
        {
            // Se não for fornecido um Id
            if (id == null)
            {
                // Redireciona para Filmes/Index
                return RedirectToAction("Index");
            }

            // Encontra o Filme a partir do ID recebido e "incluí" a Lista de Links + Lista de Favoritos
            var filme = await _context.Filmes
                .Include(f => f.ListaDeLinks)
                .Include(f => f.ListaDeFavoritos)
                .FirstOrDefaultAsync(f => f.Id == id);

            // Se não foi encontrado um Filme
            if (filme == null)
            {
                // Redireciona para Filmes/Index
                return RedirectToAction("Index");
            }

            // Se está autenticado
            if (User.Identity.IsAuthenticated)
            {
                // Esta variável vai guardar o Utilizador que o UserName é igual ao Id do ASP.NET User
                var utilizador = await _context.Utilizadores.Where(u => u.UserName == _userManager.GetUserId(User)).FirstOrDefaultAsync();

                // Esta variável vai guardar o "Favorito", se existir a relação na base de dados entre o Utilizador e o respetivo Filme 
                var favorito = await _context.Favoritos.Where(f => f.FilmeFK == id && f.UtilizadorFK == utilizador.Id).FirstOrDefaultAsync();

                // Se não foi encontrado nenhuma relação "Favorito" entre o Utilizador e o Filme
                if (favorito == null)
                {
                    // Define a variável "Favorito" da ViewBag a false, esta vai ser "transportada"
                    ViewBag.Favorito = false;
                }
                else
                {
                    // Define a variável "Favorito" da ViewBag a true
                    ViewBag.Favorito = true;
                }

            }

            // Se chegou até esta instrução significa que tudo correu bem e retorna a View do Filme
            return View(filme);
        }






        // #####################################################################################################################################################


        // POST: Filmes/MudaVisibilidade
        /// <summary>
        /// Função que inverte o parâmetro "Visibilidade" de um Filme
        /// </summary>
        /// <param name="filmeId">Id do Filme que está a ser alterado</param>
        /// <returns>View da 'Lista de Filmes'</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MudaVisibilidade(int filmeId)
        {
            // Guarda o Filme a partir do parâmetro "filmeId"
            var filme = _context.Filmes.Where(f => f.Id == filmeId).FirstOrDefault();

            // Dependendo do parâmetro "Visibilidade", vai se alterar para o oposto
            if (filme.Visibilidade == true)
            {
                filme.Visibilidade = false;
            }
            else
            {
                filme.Visibilidade = true;
            }

            // Verifica se o ModelState é válido
            if (ModelState.IsValid)
            {
                try
                {
                    // Atualiza o Filme na base de dados
                    _context.Update(filme);
                    // Guarda as alterações feitas na base de dados
                    await _context.SaveChangesAsync();
                    // Redireciona para a página da 'Lista de Filmes'
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    // Apresenta uma mensagem de erro se ocorreu uma excepção nas linhas de código acima
                    ModelState.AddModelError("", "Ocorreu um erro na alteração da 'Visibilidade' do Filme! Pode ter ocorrido um erro na atualização ou ao guardar os dados na Base de Dados.");
                }
            }

            // Redireciona para a página da 'Lista de Filmes'
            return RedirectToAction(nameof(Index));
        }



        // POST: Filmes/CreateLink
        /// <summary>
        /// Adiciona um Link à base de dados com:   URL + Id do Filme + Id do Utilizador
        /// </summary>
        /// <param name="filmeId">Id do Filme que está a ser adicionado aos Favoritos</param>
        /// <param name="url">URL do Link a ser adicionado</param>
        /// <returns>View dos detalhes do respetivo Filme</returns>
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

            // Se o ModelState for válido
            if (ModelState.IsValid)
            {
                try
                {
                    // Adicionar o Link à base de dados
                    _context.Add(link);
                    // Guarda as alterações feitas na base de dados
                    await _context.SaveChangesAsync();
                    // Redireciona para a página dos detalhes do respetivo Filme
                    return RedirectToAction(nameof(Details), new { id = filmeId });
                }
                catch (Exception)
                {
                    // Caso haja uma exepção, apresenta uma mensagem de erro
                    ModelState.AddModelError("", "Ocorreu um erro na adição do Link! Pode ter ocorrido um erro na adição ou ao guardar os dados na Base de Dados.");
                }
            }

            // Redireciona para a página dos detalhes do respetivo Filme
            return RedirectToAction(nameof(Details), new { id = filmeId });
        }


        // POST: Filmes/MudaVisivel
        /// <summary>
        /// Função que inverte o parâmetro "Visivel" de um Link
        /// </summary>
        /// <param name="linkId">Id do Link que vai sofrer alteração no parâmetro "Visivel"</param>
        /// /// <param name="filmeId">Id do Filme à qual o respetivo Link está associado</param>
        /// <returns>View dos detalhes do respetivo Filme</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MudaVisivel(int linkId, int filmeId)
        {
            // Guarda o Link a partir do parâmetro "linkId"
            var link = _context.Links.Where(l => l.Id == linkId).FirstOrDefault();

            // Dependendo do parâmetro "Visivel", vai se alterar para o oposto
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
                    // Redireciona para a página dos detalhes do respetivo Filme
                    return RedirectToAction(nameof(Details), new { id = filmeId });
                }
                catch (Exception)
                {
                    // Apresenta uma mensagem de erro se ocorreu uma excepção nas linhas de código acima
                    ModelState.AddModelError("", "Ocorreu um erro na alteração do 'Visivel' do Link! Pode ter ocorrido um erro na atualização ou ao guardar os dados na Base de Dados.");
                }
            }

            // Redireciona para a página dos detalhes do respetivo Filme
            return RedirectToAction(nameof(Details), new { id = filmeId });
        }



        // POST: Filmes/AddFavorito
        /// <summary>
        /// Função que permite adicionar um Favorito à base de dados com:   Id do Utilizador + Id do Filme
        /// </summary>
        /// <param name="filmeId">Id do Filme que está a ser adicionado aos Favoritos</param>
        /// <returns>View dos detalhes do respetivo Filme</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddFavorito(int filmeId)
        {
            // Guarda o Utilizador que está a adicionar o Favorito para saber o seu Id
            var utilizador = _context.Utilizadores.Where(u => u.UserName == _userManager.GetUserId(User)).FirstOrDefault();

            // Guarda o Filme através do Id que recebeu como parâmetro
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
                    // Redireciona para a página dos detalhes do respetivo Filme
                    return RedirectToAction(nameof(Details), new { id = filmeId });
                }
                catch (Exception)
                {
                    // Apresenta uma mensagem de erro se ocorreu uma excepção nas linhas de código acima
                    ModelState.AddModelError("", "Ocorreu um erro na adição do Favorito!");
                }
            }

            // Redireciona para a página dos detalhes do respetivo Filme
            return RedirectToAction(nameof(Details), new { id = filmeId });
        }


        // POST: Filmes/DeleteFavorito
        /// <summary>
        /// Função que permite remover um Favorito da base de dados a partir do:   Id do Utilizador + Id do Filme
        /// </summary>
        /// <param name="filmeId">Id do Filme que está a removido dos Favoritos</param>
        /// <returns>View dos detalhes do respetivo Filme</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteFavorito(int filmeId)
        {
            // Guarda o Utilizador que está a remover o Favorito 
            var utilizador = _context.Utilizadores.Where(u => u.UserName == _userManager.GetUserId(User)).FirstOrDefault();

            // Guarda o Favorito a partir do Id do Utilizador + Id do Filme
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
                    // Redireciona para a página dos detalhes do respetivo Filme
                    return RedirectToAction(nameof(Details), new { id = filmeId });
                }
                catch (Exception)
                {
                    // Apresenta uma mensagem de erro se ocorreu uma excepção nas linhas de código acima
                    ModelState.AddModelError("", "Ocorreu um erro na remoção do Favorito!");
                }
            }

            // Redireciona para a página dos detalhes do respetivo Filme
            return RedirectToAction(nameof(Details), new { id = filmeId });
        }


        // #####################################################################################################################################################






        // GET: Filmes/Create
        /// <summary>
        /// Fornece a página de criação de um Filme
        /// </summary>
        /// <returns>Página de criação de um Filme</returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: Filmes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Função que cria o Filme adicionando-o à base de dados + upload da capa do Filme
        /// </summary>
        /// <param name="filme">Parâmetros do Filme recebido</param>
        /// <param name="capaFilme">Ficheiro da capa do Filme</param>
        /// <returns>Devolve o controlo à View</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Titulo,Categoria,Lancamento,Classificacao,Realizador,Elenco,Sinopse")] Filmes filme, IFormFile capaFilme)
        {
            // Variável que vai, como o nome indica, guardar o nome/PATH do ficheiro/imagem
            string nomeImagem = "";

            // Por padrão, o parâmetro "Visibilidade" do Filme e definido a true
            filme.Visibilidade = true;

            // Se não for fornecido um ficheiro
            if (capaFilme == null)
            {
                // Apresenta uma mensagem de erro
                ModelState.AddModelError("", "Adicione, por favor, a imagem da capa do filme!");
                // Devolve o controlo à View
                return View(filme);
            }
            else
            {
                // Se foi fornecido um ficheiro
                // Verifica se o ficheiro fornecido é uma imagem
                if (capaFilme.ContentType == "image/jpeg" || capaFilme.ContentType == "image/png")
                {
                    // Definir o novo nome da imagem com o Titulo do Filme     
                    nomeImagem = filme.Titulo;
                    // Determinar a extensão do nome da imagem
                    string extensao = Path.GetExtension(capaFilme.FileName).ToLower();
                    // Concatenar o nome da imagem com a extensão
                    nomeImagem = nomeImagem + extensao;
                     
                    // O parâmetro "Imagem" vai ser igual à string do nome da imagem
                    filme.Imagem = nomeImagem;

                    // Localização do projeto
                    string localizacaoFicheiro = _caminho.WebRootPath;
                    // Localização do projeto com junção da pasta das imagens e o nome da respetiva imagem
                    nomeImagem = Path.Combine(localizacaoFicheiro, "Imagens", nomeImagem);
                }
                else
                {
                    // Se o ficheiro fornecido não é uma imagem, não é válido
                    // Apresenta uma mensagem de erro
                    ModelState.AddModelError("", "Só pode escolher uma imagem para a associar ao filme.");
                    // Devolve o controlo à View
                    return View(filme);
                }
            }

            // Verifica se o ModelState é válido
            if (ModelState.IsValid)
            {
                try
                {
                    // Adiciona o Filme à base de dados
                    _context.Add(filme);
                    // Guarda as alterações feitas à base de dados
                    await _context.SaveChangesAsync();

                    // Adiciona/upload do ficheiro ao servidor
                    using var stream = new FileStream(nomeImagem, FileMode.Create);
                    await capaFilme.CopyToAsync(stream);

                    // Redireciona para a página da 'Lista de Filmes'
                    return RedirectToAction(nameof(Index));
                }
                catch {
                    // Apresenta uma mensagem de erro se ocorreu uma excepção nas linhas de código acima
                    ModelState.AddModelError("", "Ocorreu um erro na adição do Filme! Pode ter ocorrido um erro na adição ou ao guardar os dados na Base de Dados.");
                }
            }

            // Devolve o controlo à View
            return View(filme);
        }

        // GET: Filmes/Edit/5
        /// <summary>
        /// Fornece a página de edição de um Filme
        /// </summary>
        /// <param name="id">Id do respetivo Filme a editar</param>
        /// <returns>Página de edição de um Filme</returns>
        public async Task<IActionResult> Edit(int? id)
        {
            // Se não foi fornecido um Id
            if (id == null)
            {
                // Redireciona para a página da 'Lista de Filmes'
                return RedirectToAction(nameof(Index));
            }

            // "Procura" um Filme com o Id recebido
            var filme = await _context.Filmes.FindAsync(id);

            // Se não foi encontrado nenhum Filme o Id recebido como parâmetro
            if (filme == null)
            {
                // Redireciona para a página da 'Lista de Filmes'
                return RedirectToAction(nameof(Index));
            }

            // Devolve a página pretendida
            return View(filme);
        }

        // POST: Filmes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Função que permite alterar/atualizar um Filme na base de dados
        /// </summary>
        /// <param name="id">Id do Filme a editar</param>
        /// <param name="filme">Parâmetros do Filme recebido</param>
        /// <param name="capaFilme">Ficheiro da capa do Filme</param>
        /// <returns>Devolve controlo à View</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Imagem,Categoria,Lancamento,Classificacao,Realizador,Elenco,Sinopse,Visibilidade")] Filmes filme, IFormFile capaFilme)
        {
            // Se o Id recebido for diferente do Id do Filme a editar
            if (id != filme.Id)
            {
                return RedirectToAction(nameof(Index));
            }

            // Variável que vai, como o nome indica, guardar o nome/PATH do ficheiro/imagem
            string nomeImagem = "";
            // Localização do projeto
            string localizacao = _caminho.WebRootPath;

            // Se foi fornecido um ficheiro para a capa do Filme
            if (capaFilme != null)
            {
                // Verifica se o ficheiro fornecido é uma imagem
                if (capaFilme.ContentType == "image/jpeg" || capaFilme.ContentType == "image/png")
                {
                    // Definir o novo nome da imagem com o Titulo do Filme      
                    nomeImagem = filme.Titulo;
                    // Determinar a extensão do nome da imagem
                    string extensao = Path.GetExtension(capaFilme.FileName).ToLower();
                    // Concatenar o nome da imagem com a extensão
                    nomeImagem = nomeImagem + extensao;

                    // O parâmetro "Imagem" vai ser igual à string do nome da imagem
                    filme.Imagem = nomeImagem;

                    // Localização do projeto com junção da pasta das imagens e o nome da respetiva imagem
                    nomeImagem = Path.Combine(localizacao, "Imagens", nomeImagem);
                }
                else
                {
                    // Se o ficheiro fornecido não é uma imagem
                    // Apresenta uma mensagem de erro
                    ModelState.AddModelError("", "Só pode escolher uma imagem para a associar ao filme.");
                    // Devolve o controlo à View
                    return View(filme);
                }
            }

            // Verifica se o ModelState é válido
            if (ModelState.IsValid)
            {
                try
                {
                    // Atualiza o Filme na base de dados
                    _context.Update(filme);
                    // Guarda as alterações feitas na base de dados
                    await _context.SaveChangesAsync();

                    // Se foi adicionado um ficheiro
                    if (capaFilme != null)
                    {
                        // Localização do projeto com junção da pasta das imagens e o nome da respetiva imagem
                        string localizacaoFicheiro = Path.Combine(localizacao, "Imagens", filme.Imagem);
                        // Se já existir uma imagem vai apagá-la
                        if (System.IO.File.Exists(localizacaoFicheiro))
                        {
                            System.IO.File.Delete(localizacaoFicheiro);
                        }

                        // Adiciona/upload do ficheiro ao servidor
                        using var stream = new FileStream(nomeImagem, FileMode.Create);
                        await capaFilme.CopyToAsync(stream);
                    }

                }
                catch (DbUpdateConcurrencyException)
                {
                    // Se não existir um Filme com o respetivo Id redireciona o utilizador para a página da 'Lista de Filmes'
                    if (!FilmesExists(filme.Id))
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        throw;
                    }
                }
                // Redireciona o utilizador para a página da 'Lista de Filmes'
                return RedirectToAction(nameof(Index));
            }

            // Devolve o controlo à View
            return View(filme);
        }

        // GET: Filmes/Delete/5
        /// <summary>
        /// Fornece a página de remoção de um Filme
        /// </summary>
        /// <param name="id">Id do Filme a ser apagado</param>
        /// <returns>Página de edição de um Filme</returns>
        public async Task<IActionResult> Delete(int? id)
        {
            // Se não foi fornecido um Id
            if (id == null)
            {
                // Redireciona para a página da 'Lista de Filmes'
                return RedirectToAction(nameof(Index));
            }

            // Guarda, se existir, o Filme a partir do Id fornecido
            var filme = await _context.Filmes
                .FirstOrDefaultAsync(m => m.Id == id);

            // Se não existe o Filme
            if (filme == null)
            {
                // Redireciona para a página da 'Lista de Filmes'
                return RedirectToAction(nameof(Index));
            }

            // Devolve o controlo à View
            return View(filme);
        }

        // POST: Filmes/Delete/5
        /// <summary>
        /// Função que permite apagar o Filme da base de dados + ficheiro da capa do Filme
        /// </summary>
        /// <param name="id">Id do Filme a ser apagado</param>
        /// <returns>Página da 'Lista de Filmes'</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Guarda o Filme a partir do Id recebido por parâmetro
            var filme = await _context.Filmes.FindAsync(id);

            try {
                // Remove o Filme da Base de Dados
                _context.Filmes.Remove(filme);
                // Guarda as alterações feitas à base de dados
                await _context.SaveChangesAsync();

                // Localização do projeto
                string localizacao = _caminho.WebRootPath;
                // Localização do projeto com junção da pasta das imagens e o nome da respetiva imagem
                string localizacaoFicheiro = Path.Combine(localizacao, "Imagens", filme.Imagem);
                // Se existir o ficheiro vai apagá-lo
                if (System.IO.File.Exists(localizacaoFicheiro))
                {
                    System.IO.File.Delete(localizacaoFicheiro);
                }

            }
            catch (Exception) {
                // Apresenta uma mensagem de erro se ocorreu uma excepção nas linhas de código acima
                ModelState.AddModelError("", "Ocorreu um erro no processo da eliminação do Filme!");
            }
            
            // Redireciona para a página da 'Lista de Filmes'
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Verifica se o respetivo Filme existe
        /// </summary>
        /// <param name="id">Id do Filme</param>
        /// <returns>Resultado da procura (TRUE ou FALSE)</returns>
        private bool FilmesExists(int id)
        {
            return _context.Filmes.Any(e => e.Id == id);
        }
    }
}
