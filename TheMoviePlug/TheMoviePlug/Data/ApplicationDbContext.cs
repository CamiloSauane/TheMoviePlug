using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TheMoviePlug.Models;

namespace TheMoviePlug.Data
{

	/// <summary>
	/// Classe para recolher os dados dos Utilizadores
	/// </summary>
	public class ApplicationUser : IdentityUser
    {
		/// <summary>
		/// Recolhe a data de registo do respetivo Utilizador
		/// </summary>
        public DateTime DataRegisto { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<IdentityRole>().HasData(
				new IdentityRole { Id = "r", Name = "Registado", NormalizedName = "REGISTADO" },
				new IdentityRole { Id = "g", Name = "Gestor", NormalizedName = "GESTOR" }
			);


			modelBuilder.Entity<Filmes>().HasData(
				new Filmes { Id = 1, Titulo = "Star Wars IV - A new hope", Imagem = "StarWars_ANewHope.jpg", Categoria = "Aventura", Lancamento = new DateTime(1977, 5, 25), Classificacao = "8.6", Realizador = "George Lucas", Elenco = "Harrison Ford, Mark Hamill, Carrie Fisher, Peter Cushing", Sinopse = "Luke Skywalker (Mark Hammil) sonha ir para a Academia como seus amigos, mas se vê envolvido em uma guerra intergalática quando seu tio compra dois robôs e com eles encontra uma mensagem da princesa Leia Organa (Carrie Fisher) para o jedi Obi-Wan Kenobi (Alec Guiness) sobre os planos da construção da Estrela da Morte, uma gigantesca estação espacial com capacidade para destruir um planeta.", Visibilidade = true },
				new Filmes { Id = 2, Titulo = "Star Wars: Episode V - The Empire Strikes Back", Imagem = "StarWars_TheEmpireStrikesBack.jpg", Categoria = "Aventura", Lancamento = new DateTime(1980, 5, 17), Classificacao = "8.7", Realizador = "Irvin Kershner", Elenco = "Harrison Ford, Mark Hamill, Carrie Fisher, Billy Dee Williams", Sinopse = "São tempos negros para a Rebelião. Após um devastador ataque à sua base no planeta gelado de Hoth, os Rebeldes separam-se devido às perseguições Imperiais. Luke Skywalker vai em busca do misterioso Mestre Jedi Yoda, nos pântanos de Dagobah, enquanto Han Solo e a Princesa Leia despistam a frota Imperial em direcção à linda Cidade das Nuvens de Bespin. Numa tentativa de converter Luke ao lado negro, o maléfico Darth Vader, atrai o jovem Skywalker para uma armadilha.", Visibilidade = true },
				new Filmes { Id = 3, Titulo = "Star Wars: Episode VI - Return of the Jedi", Imagem = "StarWars_ReturnOfTheJedi.jpg", Categoria = "Aventura", Lancamento = new DateTime(1983, 5, 25), Classificacao = "8.3", Realizador = "Richard Marquand", Elenco = "Harrison Ford, Mark Hamill, Carrie Fisher, Billy Dee Williams", Sinopse = "No espectacular capítulo final da saga Star Wars, Luke Skywalker e a Princesa Leia têm de ir a Tatooine para libertarem Han Solo, infiltrando-se na fortaleza imunda de Jabba the Hutt, o mais temido vilão da galáxia. Novamente unidos, os Rebeldes juntam forças com as tribos de Ewoks para enfrentarem as forças imperiais na lua floresta de Endor. Entretanto o Imperador e Darth Vader conspiram de forma a trazer Luke para o lado negro, mas o jovem Skywalker está determinado em honrar o espírito Jedi.", Visibilidade = true },
				new Filmes { Id = 4, Titulo = "Star Wars: Episode I - The Phantom Menace", Imagem = "StarWars_ThePhantomMenace.jpg", Categoria = "Aventura", Lancamento = new DateTime(1999, 5, 19), Classificacao = "6.5", Realizador = "George Lucas", Elenco = "Ewan McGregor, Liam Neeson, Natalie Portman, Samuel L. Jackson, Jake Lloyd", Sinopse = "A Federação do Comércio, dirigida por Nute Gunray planeia assumir o pacífico mundo de Naboo. O Jedi Qui-Gon Jinn e Obi-Wan Kenobi são enviados para confrontar os líderes. Mas nem tudo corre conforme o plano. Os dois Jedis escapam e, em conjunto com o seu novo amigo Gungan, Jar Jar Binks, avançam para Naboo para advertir a Rainha Amidala, mas droids já começaram a capturar Naboo e a Rainha não está segura aí.", Visibilidade = true },
				new Filmes { Id = 5, Titulo = "Star Wars: Episode II - Attack of the Clones", Imagem = "StarWars_AttackOfTheClones.jpg", Categoria = "Aventura", Lancamento = new DateTime(2002, 5, 16), Classificacao = "6.5", Realizador = "George Lucas", Elenco = "Ewan McGregor, Natalie Portman, Samuel L. Jackson, Hayden Christensen, Christopher Lee", Sinopse = "Após a tentativa de homicídio da Senadora do planeta Naboo, Padme Amidala, Obi-Wan Kenobi e Anakin Skywalker irão investigar o que sucedeu. No decorrer das investigações, Obi-Wan descobre que há uma ligação entre o atentado e o movimento separatista contra a República, liderado por um ex-jedi. À beira de uma guerra civil, a solução encontrada para a defesa da República Galáctica é a constituição de um exército de clones...", Visibilidade = true },
				new Filmes { Id = 6, Titulo = "Star Wars: Episode III - Revenge of the Sith", Imagem = "StarWars_RevengeOfTheSith.jpg", Categoria = "Aventura", Lancamento = new DateTime(2005, 5, 19), Classificacao = "7.5", Realizador = "George Lucas", Elenco = "Ewan McGregor, Natalie Portman, Samuel L. Jackson, Hayden Christensen, Ian McDiarmid", Sinopse = "No meio da guerra inciada no episódio dois desta saga, Anakin Skywalker perde a fidelidade aos Jedi. Seduzido pelas promessas de poder e tentações do Lado Negro da Força, transforma-se em Darth Vader. Juntos os Lordes Sith organizam um plano de vingança que começa com a exterminação dos Jedi. No confronto com os Sith, Yoda e Obi-Wan, os dois mestres Jedi, darão uma réplica feroz, com os seus sabres de luz. Nesta batalha final, que colocará Anakin contra Obi-Wan, se decidirá o destino da Galáxia.", Visibilidade = true },
				new Filmes { Id = 7, Titulo = "Star Wars: The Force Awakens", Imagem = "StarWars_TheForceAwakens.jpg", Categoria = "Aventura", Lancamento = new DateTime(2015, 12, 14), Classificacao = "7.9", Realizador = "Jeffrey Jacob Abrams", Elenco = "Adam Driver, Harrison Ford, Sara Maria Forsberg, Mark Hamill, Carrie Fisher", Sinopse = "Décadas após a queda de Darth Vader e do Império, surge uma nova ameaça: a Primeira Ordem, uma organização sombria que busca minar o poder da República e que tem Kylo Ren (Adam Driver), o General Hux (Domhnall Gleeson) e o Líder Supremo Snoke (Andy Serkis) como principais expoentes. Eles conseguem capturar Poe Dameron (Oscar Isaac), um dos principais pilotos da Resistência, que antes de ser preso envia através do pequeno robô BB-8 o mapa de onde vive o mitológico Luke Skywalker (Mark Hamill).", Visibilidade = true },
				new Filmes { Id = 8, Titulo = "Star Wars: The Last Jedi", Imagem = "StarWars_TheLastJedi.jpg", Categoria = "Aventura", Lancamento = new DateTime(2017, 12, 9), Classificacao = "7.0", Realizador = "Rian Johnson", Elenco = "Adam Driver, Mark Hamill, Carrie Fisher", Sinopse = "Após encontrar o mítico e recluso Luke Skywalker (Mark Hammil) numa ilha isolada, a jovem Rey (Daisy Ridley) procura entender o balanço da Força a partir dos ensinamentos do mestre jedi. Paralelamente, o Primeiro Império de Kylo Ren (Adam Driver) reorganiza-se para enfrentar a Aliança Rebelde. A saga de Skywalker continua, enquanto os heróis de O Despertar da Força se juntam às lendas galácticas, para uma aventura épica, que desvenda mistérios antigos!", Visibilidade = true },
				new Filmes { Id = 9, Titulo = "Star Wars: The Rise of Skywalker", Imagem = "StarWars_TheRiseOfSkywalker.jpg", Categoria = "Ação", Lancamento = new DateTime(2019, 12, 19), Classificacao = "6.6", Realizador = "Jeffrey Jacob Abrams", Elenco = "Adam Driver, Carrie Fisher, Mark Hamill", Sinopse = "A Lucasfilm e o realizador J.J. Abrams voltam a unir forças para levar os espectadores numa jornada épica para uma galáxia muito, muito distante, com este novo e final capítulo da saga Skywalker, a fascinante conclusão da saga Skywalker, onde vão nascer novas lendas e a batalha final pela liberdade ainda está para chegar.", Visibilidade = true },
				new Filmes { Id = 10, Titulo = "The Avengers", Imagem = "TheAvengers.jpg", Categoria = "Ação", Lancamento = new DateTime(2012, 5, 4), Classificacao = "8.0", Realizador = "Joss Whedon", Elenco = "Chris Evans, Chris Hemsworth, Robert Downey Jr., Mark Ruffalo", Sinopse = "Os mais poderosos heróis da Terra têm de aprender a viver juntos e a lutar como uma equipa, criando os vingadores, impedindo Loki e seu exército alienígena de escravizar a humanidade.", Visibilidade = true },
				new Filmes { Id = 11, Titulo = "Avengers: Age of Ultron", Imagem = "Avengers_AgeOfUltron.jpg", Categoria = "Aventura", Lancamento = new DateTime(2015, 5, 1), Classificacao = "7.3", Realizador = "Joss Whedon", Elenco = "Chris Evans, Chris Hemsworth, Robert Downey Jr., Mark Ruffalo", Sinopse = "Quando Tony Stark e Bruce Banner tentam iniciar um programa de manutenção da paz dormente chamado Ultron, as coisas vão terrivelmente erradas, e cabe a heróis mais poderosos da terra parar o vilão Ultron.", Visibilidade = true },
				new Filmes { Id = 12, Titulo = "Avengers: Infinity War", Imagem = "Avengers_InfinityWar.jpg", Categoria = "Ação", Lancamento = new DateTime(2018, 4, 27), Classificacao = "8.4", Realizador = "Anthony Russo, Joe Russo", Elenco = "Chris Hemsworth, Robert Downey Jr., Tom Holland, Mark Ruffalo", Sinopse = "Homem de Ferro, Thor, Hulk e os Vingadores se reunem para combater o seu inimigo mais poderoso, o maligno Thanos. Em uma missão para obter todas as seis pedras infinitas, Thanos planeia usá-las para infligir a sua vontade maléfica sobre a realidade.", Visibilidade = true },
				new Filmes { Id = 13, Titulo = "Avengers: Endgame", Imagem = "Avengers_Endgame.jpg", Categoria = "Aventura", Lancamento = new DateTime(2019, 4, 26), Classificacao = "8.4", Realizador = "Anthony Russo, Joe Russo", Elenco = "Chris Evans, Robert Downey Jr., Tom Holland, Mark Ruffalo", Sinopse = "Após Thanos eliminar metade das criaturas vivas, os Vingadores têm de lidar com a perda de amigos e entes queridos. Com Tony Stark vagando perdido no espaço sem água e comida, Steve Rogers e Natasha Romanov lideram a resistência contra o titã louco.", Visibilidade = true },
				new Filmes { Id = 14, Titulo = "Harry Potter and the Sorcerers Stone", Imagem = "HarryPotter_AndTheSorcerersStone.jpg", Categoria = "Fantasia", Lancamento = new DateTime(2001, 11, 4), Classificacao = "7.6", Realizador = "Chris Columbus", Elenco = "Daniel Radcliffe, Rupert Grint, Richard Harris", Sinopse = "Harry Potter um órfão que descobre que os seus pais eram feiticeiros e que ele também possui poderes mágicos. Harry Potter passou a maior parte do seu tempo debaixo da escada na casa dos Dursleys, seus tios que não gostam dele. Porém, quando é convidado para estudar na Escola de Feitiços e Magia Hogwart, Harry percebe que existem dois mundos: um é o mundo sem graça dos humanos comuns e o outro é cheio de magia, encanto e fantasia.", Visibilidade = true },
				new Filmes { Id = 15, Titulo = "Harry Potter and the Chamber of Secrets", Imagem = "HarryPotter_AndTheChamberOfSecrets.jpg", Categoria = "Fantasia", Lancamento = new DateTime(2002, 11, 15), Classificacao = "7.4", Realizador = "Chris Columbus", Elenco = "Daniel Radcliffe, Emma Watson, Rupert Grint", Sinopse = "Harry Potter frequenta o segundo ano da «Hogwarts School», uma escola de bruxarias e feitiços. Ele é visitado por um duende doméstico chamado Dobby que o aconselha a não regressar à escola. Harry ignora este aviso e regressa. Ele continua famoso, mas detestado pelos Slytherins, e ainda mais por Snape e Malfoy. De repente, coisas estranhas começam a acontecer: as pessoas começam a ficar petrificadas e ninguém conhece a causa disso. Entretanto Harry continua a ouvir uma voz...", Visibilidade = true },
				new Filmes { Id = 16, Titulo = "Harry Potter and the Prisoner of Azkaban", Imagem = "HarryPotter_AndThePrisonerOfAzkaban.jpg", Categoria = "Fantasia", Lancamento = new DateTime(2004, 5, 31), Classificacao = "7.9", Realizador = "Alfonso Cuarón", Elenco = "Daniel Radcliffe, Emma Watson, Rupert Grint", Sinopse = "Harry Potter, Ron e Hermione entram na adolescência e voltam à Hogwarts para o terceiro ano lectivo na escola de bruxaria. Em Hogwarts procuram resolver o mistério de um fugitivo, o assassino Sirius Black, que foge da prisão de bruxos de Azkaban e representa uma perigosa ameaça para o jovem bruxo.", Visibilidade = true },
				new Filmes { Id = 17, Titulo = "Harry Potter and the Goblet of Fire", Imagem = "HarryPotter_AndTheGobletOfFire.jpg", Categoria = "Aventura", Lancamento = new DateTime(2005, 11, 18), Classificacao = "7.7", Realizador = "Mike Newell", Elenco = "Daniel Radcliffe, Emma Watson, Rupert Grint", Sinopse = "O nome de Harry Potter é extraído do Cálice de Fogo, tornando-se assim num dos concorrentes de Hogwarts que irão disputar a glória e o prestígio no Torneio dos Três Feiticeiros realizado entre as três grandes escolas de feiticeiros e onde terá de enfrentar os alunos mais experientes numa série de desafios. Mas quem inscreveu o nome de Harry, visto que não foi ele?", Visibilidade = true },
				new Filmes { Id = 18, Titulo = "Harry Potter and the Order of the Phoenix", Imagem = "HarryPotter_AndTheOrderOfThePhoenix.jpg", Categoria = "Aventura", Lancamento = new DateTime(2007, 7, 11), Classificacao = "7.5", Realizador = "David Yates", Elenco = "Daniel Radcliffe, Emma Watson, Rupert Grint", Sinopse = "Harry regressa para o seu quinto ano de estudos em Hogwarts e descobre que a comunidade de feiticeiros não acredita no seu encontro com Lorde Voldemort. Receando que Albus Dumbledore, o reitor de Hogwarts, esteja a mentir sobre Voldemort de modo a minar o seu poder e usurpar o seu cargo o Ministro da Magia, Cornelius Fudge, nomeia uma nova professora de Defesa contra as Artes Negras, para vigiar Dumbledore e os estudantes de Hogwarts.", Visibilidade = true },
				new Filmes { Id = 19, Titulo = "Harry Potter and the Half-Blood Prince", Imagem = "HarryPotter_AndTheHalf-BloodPrince.jpg", Categoria = "Aventura", Lancamento = new DateTime(2009, 7, 15), Classificacao = "7.6", Realizador = "David Yates", Elenco = "Daniel Radcliffe, Emma Watson, Rupert Grint", Sinopse = "Voldemort está cada vez mais perigoso, tanto no «Mundo Muggle» quanto no «Mundo Mágico», e Hogwarts deixa de ser um lugar seguro. Harry suspeita de perigos que podem até estar dentro do castelo, mas Dumbledore tem as ideias voltadas para a batalha final, que este sabe que se está a aproximar. Juntos procuram uma forma de acabar com a defesa de Voldemort. Além disso, os estudantes estão sob o ataque de um adversário muito diferente: as hormonas da juventude, que se espalham entre todos.", Visibilidade = true },
				new Filmes { Id = 20, Titulo = "Harry Potter and the Deathly Hallows: Part 1", Imagem = "HarryPotter_AndTheDeathlyHallows_part1.jpg", Categoria = "Ação", Lancamento = new DateTime(2010, 11, 18), Classificacao = "7.7", Realizador = "David Yates", Elenco = "Daniel Radcliffe, Emma Watson, Rupert Grint", Sinopse = "O mundo dos feiticeiros tornou-se um lugar perigoso para todos os que estão contra Voldemort. E os aliados deste continuam a querer o prémio mais desejado: Harry Potter. Este tem de ser entregue a Voldemort... vivo. A única esperança de Potter é encontrar o Horcruxes antes que Voldemort o encontre a ele. Mas enquanto procura por pistas, ele descobre uma lenda muito antiga – a lenda dos Talismãs da Morte. E se esta for verdadeira, pode dar a Voldemort o poder de que ele precisa...", Visibilidade = true },
				new Filmes { Id = 21, Titulo = "Harry Potter and the Deathly Hallows: Part 2", Imagem = "HarryPotter_AndTheDeathlyHallows_part2.jpg", Categoria = "Aventura", Lancamento = new DateTime(2011, 7, 15), Classificacao = "8.1", Realizador = "David Yates", Elenco = "Daniel Radcliffe, Emma Watson, Rupert Grint", Sinopse = "No épico final, a batalha entre as forças do bem e do mal do mundo dos feiticeiros vai originar uma guerra sem precedentes. Os riscos nunca foram tão elevados e ninguém está seguro. Mas é Harry Potter quem terá de fazer o sacrifício final, pois a luta com Lord Voldemort aproxima-se. Tudo acaba.", Visibilidade = true }
			);


			modelBuilder.Entity<Links>().HasData(
				new Links { Id = 1, URL = "https://www.example.net/", Visivel = true, UtilizadorFK = 13, FilmeFK = 5 },
				new Links { Id = 2, URL = "https://www.example.com/breath", Visivel = true, UtilizadorFK = 4, FilmeFK = 9 },
				new Links { Id = 3, URL = "https://www.example.com/", Visivel = true, UtilizadorFK = 10, FilmeFK = 10 },
				new Links { Id = 4, URL = "https://www.example.com/bee.php", Visivel = true, UtilizadorFK = 31, FilmeFK = 1 },
				new Links { Id = 5, URL = "https://example.com/", Visivel = true, UtilizadorFK = 22, FilmeFK = 11 },
				new Links { Id = 6, URL = "http://www.example.com/addition.html#boundary", Visivel = true, UtilizadorFK = 3, FilmeFK = 20 },
				new Links { Id = 7, URL = "https://bedroom.example.com/", Visivel = true, UtilizadorFK = 27, FilmeFK = 20 },
				new Links { Id = 8, URL = "http://www.example.com/argument.php", Visivel = true, UtilizadorFK = 10, FilmeFK = 17 },
				new Links { Id = 9, URL = "https://example.com/afternoon.aspx", Visivel = true, UtilizadorFK = 10, FilmeFK = 8 },
				new Links { Id = 10, URL = "http://example.org/actor", Visivel = true, UtilizadorFK = 2, FilmeFK = 3 },
				new Links { Id = 11, URL = "https://www.example.edu/?arm=action&board=attack", Visivel = true, UtilizadorFK = 19, FilmeFK = 7 },
				new Links { Id = 12, URL = "https://www.example.org/agreement.php?blow=ball&breath=bat#bottle", Visivel = true, UtilizadorFK = 1, FilmeFK = 21 },
				new Links { Id = 13, URL = "http://example.com/aftermath.html", Visivel = true, UtilizadorFK = 24, FilmeFK = 13 },
				new Links { Id = 14, URL = "http://www.example.net/?ball=afterthought", Visivel = true, UtilizadorFK = 21, FilmeFK = 21 },
				new Links { Id = 15, URL = "http://attraction.example.com/?bed=agreement", Visivel = true, UtilizadorFK = 6, FilmeFK = 16 },
				new Links { Id = 16, URL = "http://board.example.edu/", Visivel = true, UtilizadorFK = 5, FilmeFK = 15 },
				new Links { Id = 17, URL = "http://www.example.com/behavior.aspx", Visivel = true, UtilizadorFK = 15, FilmeFK = 12 },
				new Links { Id = 18, URL = "https://www.example.com/anger.php", Visivel = true, UtilizadorFK = 29, FilmeFK = 7 },
				new Links { Id = 19, URL = "http://beginner.example.com/bomb", Visivel = true, UtilizadorFK = 26, FilmeFK = 1 },
				new Links { Id = 20, URL = "http://argument.example.com/", Visivel = true, UtilizadorFK = 31, FilmeFK = 2 },
				new Links { Id = 21, URL = "https://example.org/", Visivel = true, UtilizadorFK = 31, FilmeFK = 4 },
				new Links { Id = 22, URL = "https://argument.example.org/aunt/bone.aspx", Visivel = true, UtilizadorFK = 31, FilmeFK = 6 },
				new Links { Id = 23, URL = "https://www.example.net/airplane.html", Visivel = true, UtilizadorFK = 4, FilmeFK = 14 },
				new Links { Id = 24, URL = "http://www.example.com/airport.aspx", Visivel = true, UtilizadorFK = 20, FilmeFK = 19 },
				new Links { Id = 25, URL = "https://example.com/basketball?bat=birthday&acoustics=ants", Visivel = true, UtilizadorFK = 28, FilmeFK = 18 },
				new Links { Id = 26, URL = "https://example.com/#babies", Visivel = true, UtilizadorFK = 1, FilmeFK = 9 },
				new Links { Id = 27, URL = "http://books.example.com/angle?bead=argument&birth=belief", Visivel = true, UtilizadorFK = 30, FilmeFK = 20 },
				new Links { Id = 28, URL = "http://www.example.com/boat/art", Visivel = true, UtilizadorFK = 20, FilmeFK = 14 },
				new Links { Id = 29, URL = "https://brass.example.com/", Visivel = true, UtilizadorFK = 17, FilmeFK = 17 },
				new Links { Id = 30, URL = "https://www.example.net/balance/amount", Visivel = true, UtilizadorFK = 11, FilmeFK = 21 },
				new Links { Id = 31, URL = "http://alarm.example.com/?airport=bath#arithmetic", Visivel = true, UtilizadorFK = 23, FilmeFK = 3 },
				new Links { Id = 32, URL = "https://www.example.com/anger", Visivel = true, UtilizadorFK = 15, FilmeFK = 9 },
				new Links { Id = 33, URL = "http://bag.example.com/brake/boat", Visivel = true, UtilizadorFK = 7, FilmeFK = 12 },
				new Links { Id = 34, URL = "https://baseball.example.org/?believe=balance&account=boat", Visivel = true, UtilizadorFK = 12, FilmeFK = 4 },
				new Links { Id = 35, URL = "http://example.com/boat/bell#brake", Visivel = true, UtilizadorFK = 25, FilmeFK = 11 },
				new Links { Id = 36, URL = "http://www.example.com/authority", Visivel = true, UtilizadorFK = 12, FilmeFK = 12 },
				new Links { Id = 37, URL = "http://www.staggeringbeauty.com/", Visivel = true, UtilizadorFK = 13, FilmeFK = 2 },
				new Links { Id = 38, URL = "http://www.trypap.com/", Visivel = true, UtilizadorFK = 17, FilmeFK = 4 },
				new Links { Id = 39, URL = "http://www.heeeeeeeey.com/", Visivel = true, UtilizadorFK = 16, FilmeFK = 5 },
				new Links { Id = 40, URL = "http://www.cat-bounce.com/", Visivel = true, UtilizadorFK = 21, FilmeFK = 1 },
				new Links { Id = 41, URL = "https://isitchristmas.com/", Visivel = true, UtilizadorFK = 28, FilmeFK = 18 },
				new Links { Id = 42, URL = "http://www.randomcolour.com/", Visivel = true, UtilizadorFK = 19, FilmeFK = 19 },
				new Links { Id = 43, URL = "http://www.hasthelargehadroncolliderdestroyedtheworldyet.com/", Visivel = true, UtilizadorFK = 1, FilmeFK = 1 },
				new Links { Id = 44, URL = "http://www.koalastothemax.com/", Visivel = true, UtilizadorFK = 16, FilmeFK = 6 },
				new Links { Id = 45, URL = "http://www.sometimesredsometimesblue.com/", Visivel = true, UtilizadorFK = 8, FilmeFK = 8 },
				new Links { Id = 46, URL = "http://www.patience-is-a-virtue.org/", Visivel = true, UtilizadorFK = 11, FilmeFK = 11 },
				new Links { Id = 47, URL = "http://www.rock-paper-scissors-game.com/", Visivel = true, UtilizadorFK = 3, FilmeFK = 20 }
			);


			modelBuilder.Entity<Favoritos>().HasData(

				new Favoritos { Id = 1, UtilizadorFK = 1, FilmeFK = 1 },
				new Favoritos { Id = 2, UtilizadorFK = 1, FilmeFK = 2 },
				new Favoritos { Id = 3, UtilizadorFK = 1, FilmeFK = 3 },
				new Favoritos { Id = 4, UtilizadorFK = 1, FilmeFK = 4 },
				new Favoritos { Id = 5, UtilizadorFK = 1, FilmeFK = 5 },
				new Favoritos { Id = 6, UtilizadorFK = 1, FilmeFK = 6 },
				new Favoritos { Id = 7, UtilizadorFK = 1, FilmeFK = 7 },
				new Favoritos { Id = 8, UtilizadorFK = 1, FilmeFK = 8 },
				new Favoritos { Id = 9, UtilizadorFK = 1, FilmeFK = 9 },
				new Favoritos { Id = 10, UtilizadorFK = 2, FilmeFK = 4 },
				new Favoritos { Id = 11, UtilizadorFK = 2, FilmeFK = 9 },
				new Favoritos { Id = 12, UtilizadorFK = 2, FilmeFK = 19 },
				new Favoritos { Id = 13, UtilizadorFK = 3, FilmeFK = 5 },
				new Favoritos { Id = 14, UtilizadorFK = 6, FilmeFK = 10 },
				new Favoritos { Id = 15, UtilizadorFK = 6, FilmeFK = 11 },
				new Favoritos { Id = 16, UtilizadorFK = 6, FilmeFK = 12 },
				new Favoritos { Id = 17, UtilizadorFK = 6, FilmeFK = 13 },
				new Favoritos { Id = 18, UtilizadorFK = 13, FilmeFK = 1 },
				new Favoritos { Id = 19, UtilizadorFK = 13, FilmeFK = 6 },
				new Favoritos { Id = 20, UtilizadorFK = 13, FilmeFK = 7 },
				new Favoritos { Id = 21, UtilizadorFK = 13, FilmeFK = 8 },
				new Favoritos { Id = 22, UtilizadorFK = 13, FilmeFK = 13 },
				new Favoritos { Id = 23, UtilizadorFK = 13, FilmeFK = 17 },
				new Favoritos { Id = 24, UtilizadorFK = 13, FilmeFK = 18 },
				new Favoritos { Id = 25, UtilizadorFK = 13, FilmeFK = 19 },
				new Favoritos { Id = 26, UtilizadorFK = 13, FilmeFK = 20 },
				new Favoritos { Id = 27, UtilizadorFK = 14, FilmeFK = 2 },
				new Favoritos { Id = 28, UtilizadorFK = 14, FilmeFK = 3 },
				new Favoritos { Id = 29, UtilizadorFK = 14, FilmeFK = 9 },
				new Favoritos { Id = 30, UtilizadorFK = 15, FilmeFK = 17 },
				new Favoritos { Id = 31, UtilizadorFK = 15, FilmeFK = 19 },
				new Favoritos { Id = 32, UtilizadorFK = 15, FilmeFK = 21 },
				new Favoritos { Id = 33, UtilizadorFK = 18, FilmeFK = 2 },
				new Favoritos { Id = 34, UtilizadorFK = 19, FilmeFK = 14 },
				new Favoritos { Id = 35, UtilizadorFK = 20, FilmeFK = 14 },
				new Favoritos { Id = 36, UtilizadorFK = 21, FilmeFK = 15 },
				new Favoritos { Id = 37, UtilizadorFK = 21, FilmeFK = 16 },
				new Favoritos { Id = 38, UtilizadorFK = 21, FilmeFK = 17 },
				new Favoritos { Id = 39, UtilizadorFK = 21, FilmeFK = 18 },
				new Favoritos { Id = 40, UtilizadorFK = 21, FilmeFK = 19 },
				new Favoritos { Id = 41, UtilizadorFK = 21, FilmeFK = 20 },
				new Favoritos { Id = 42, UtilizadorFK = 21, FilmeFK = 21 },
				new Favoritos { Id = 43, UtilizadorFK = 26, FilmeFK = 1 },
				new Favoritos { Id = 44, UtilizadorFK = 27, FilmeFK = 1 },
				new Favoritos { Id = 45, UtilizadorFK = 27, FilmeFK = 21 },
				new Favoritos { Id = 46, UtilizadorFK = 28, FilmeFK = 1 },
				new Favoritos { Id = 47, UtilizadorFK = 28, FilmeFK = 2 },
				new Favoritos { Id = 48, UtilizadorFK = 28, FilmeFK = 3 },
				new Favoritos { Id = 49, UtilizadorFK = 28, FilmeFK = 4 },
				new Favoritos { Id = 50, UtilizadorFK = 28, FilmeFK = 5 },
				new Favoritos { Id = 51, UtilizadorFK = 28, FilmeFK = 6 },
				new Favoritos { Id = 52, UtilizadorFK = 28, FilmeFK = 7 },
				new Favoritos { Id = 53, UtilizadorFK = 28, FilmeFK = 8 },
				new Favoritos { Id = 54, UtilizadorFK = 28, FilmeFK = 9 },
				new Favoritos { Id = 55, UtilizadorFK = 28, FilmeFK = 10 },
				new Favoritos { Id = 56, UtilizadorFK = 28, FilmeFK = 11 },
				new Favoritos { Id = 57, UtilizadorFK = 28, FilmeFK = 12 },
				new Favoritos { Id = 58, UtilizadorFK = 28, FilmeFK = 13 },
				new Favoritos { Id = 59, UtilizadorFK = 28, FilmeFK = 20 },
				new Favoritos { Id = 60, UtilizadorFK = 29, FilmeFK = 4 },
				new Favoritos { Id = 61, UtilizadorFK = 29, FilmeFK = 5 },
				new Favoritos { Id = 62, UtilizadorFK = 29, FilmeFK = 6 },
				new Favoritos { Id = 63, UtilizadorFK = 29, FilmeFK = 7 },
				new Favoritos { Id = 64, UtilizadorFK = 30, FilmeFK = 8 },
				new Favoritos { Id = 65, UtilizadorFK = 31, FilmeFK = 9 },
				new Favoritos { Id = 66, UtilizadorFK = 31, FilmeFK = 10 },
				new Favoritos { Id = 67, UtilizadorFK = 31, FilmeFK = 11 },
				new Favoritos { Id = 68, UtilizadorFK = 31, FilmeFK = 12 },
				new Favoritos { Id = 69, UtilizadorFK = 31, FilmeFK = 13 },
				new Favoritos { Id = 70, UtilizadorFK = 31, FilmeFK = 20 }
			);

		}

		public DbSet<Filmes> Filmes { get; set; }
		public DbSet<Links> Links { get; set; }
		public DbSet<Utilizadores> Utilizadores { get; set; }
		public DbSet<Favoritos> Favoritos { get; set; }

	}
}
