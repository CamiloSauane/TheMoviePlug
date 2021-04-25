using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheMoviePlug.Data.Migrations
{
    public partial class AdiçãodaSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Imagem",
                table: "Filmes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Filmes",
                columns: new[] { "Id", "Categoria", "Classificacao", "Elenco", "Imagem", "Lancamento", "Realizador", "Sinopse", "Titulo", "Visibilidade" },
                values: new object[,]
                {
                    { 1, "Aventura", "8.6", "Harrison Ford, Mark Hamill, Carrie Fisher, Peter Cushing", "StarWars_ANewHope.jpg", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "George Lucas", "Luke Skywalker (Mark Hammil) sonha ir para a Academia como seus amigos, mas se vê envolvido em uma guerra intergalática quando seu tio compra dois robôs e com eles encontra uma mensagem da princesa Leia Organa (Carrie Fisher) para o jedi Obi-Wan Kenobi (Alec Guiness) sobre os planos da construção da Estrela da Morte, uma gigantesca estação espacial com capacidade para destruir um planeta.", "Star Wars IV - A new hope", true },
                    { 21, "Aventura", "8.1", "Daniel Radcliffe, Emma Watson, Rupert Grint", "HarryPotter_AndTheDeathlyHallows_part2.jpg", new DateTime(2011, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "David Yates", "No épico final, a batalha entre as forças do bem e do mal do mundo dos feiticeiros vai originar uma guerra sem precedentes. Os riscos nunca foram tão elevados e ninguém está seguro. Mas é Harry Potter quem terá de fazer o sacrifício final, pois a luta com Lord Voldemort aproxima-se. Tudo acaba.", "Harry Potter and the Deathly Hallows: Part 2", true },
                    { 20, "Ação", "7.7", "Daniel Radcliffe, Emma Watson, Rupert Grint", "HarryPotter_AndTheDeathlyHallows_part1.jpg", new DateTime(2010, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "David Yates", "O mundo dos feiticeiros tornou-se um lugar perigoso para todos os que estão contra Voldemort. E os aliados deste continuam a querer o prémio mais desejado: Harry Potter. Este tem de ser entregue a Voldemort... vivo. A única esperança de Potter é encontrar o Horcruxes antes que Voldemort o encontre a ele. Mas enquanto procura por pistas, ele descobre uma lenda muito antiga – a lenda dos Talismãs da Morte. E se esta for verdadeira, pode dar a Voldemort o poder de que ele precisa...", "Harry Potter and the Deathly Hallows: Part 1", true },
                    { 19, "Aventura", "7.6", "Daniel Radcliffe, Emma Watson, Rupert Grint", "HarryPotter_AndTheHalf-BloodPrince.jpg", new DateTime(2009, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "David Yates", "Voldemort está cada vez mais perigoso, tanto no «Mundo Muggle» quanto no «Mundo Mágico», e Hogwarts deixa de ser um lugar seguro. Harry suspeita de perigos que podem até estar dentro do castelo, mas Dumbledore tem as ideias voltadas para a batalha final, que este sabe que se está a aproximar. Juntos procuram uma forma de acabar com a defesa de Voldemort. Além disso, os estudantes estão sob o ataque de um adversário muito diferente: as hormonas da juventude, que se espalham entre todos.", "Harry Potter and the Half-Blood Prince", true },
                    { 17, "Aventura", "7.7", "Daniel Radcliffe, Emma Watson, Rupert Grint", "HarryPotter_AndTheGobletOfFire.jpg", new DateTime(2005, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mike Newell", "O nome de Harry Potter é extraído do Cálice de Fogo, tornando-se assim num dos concorrentes de Hogwarts que irão disputar a glória e o prestígio no Torneio dos Três Feiticeiros realizado entre as três grandes escolas de feiticeiros e onde terá de enfrentar os alunos mais experientes numa série de desafios. Mas quem inscreveu o nome de Harry, visto que não foi ele?", "Harry Potter and the Goblet of Fire", true },
                    { 16, "Fantasia", "7.9", "Daniel Radcliffe, Emma Watson, Rupert Grint", "HarryPotter_AndThePrisonerOfAzkaban.jpg", new DateTime(2004, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alfonso Cuarón", "Harry Potter, Ron e Hermione entram na adolescência e voltam à Hogwarts para o terceiro ano lectivo na escola de bruxaria. Em Hogwarts procuram resolver o mistério de um fugitivo, o assassino Sirius Black, que foge da prisão de bruxos de Azkaban e representa uma perigosa ameaça para o jovem bruxo.", "Harry Potter and the Prisoner of Azkaban", true },
                    { 15, "Fantasia", "7.4", "Daniel Radcliffe, Emma Watson, Rupert Grint", "HarryPotter_AndTheChamberOfSecrets.jpg", new DateTime(2002, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chris Columbus", "Harry Potter frequenta o segundo ano da «Hogwarts School», uma escola de bruxarias e feitiços. Ele é visitado por um duende doméstico chamado Dobby que o aconselha a não regressar à escola. Harry ignora este aviso e regressa. Ele continua famoso, mas detestado pelos Slytherins, e ainda mais por Snape e Malfoy. De repente, coisas estranhas começam a acontecer: as pessoas começam a ficar petrificadas e ninguém conhece a causa disso. Entretanto Harry continua a ouvir uma voz...", "Harry Potter and the Chamber of Secrets", true },
                    { 14, "Fantasia", "7.6", "Daniel Radcliffe, Rupert Grint, Richard Harris", "HarryPotter_AndTheSorcerersStone.jpg", new DateTime(2001, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chris Columbus", "Harry Potter um órfão que descobre que os seus pais eram feiticeiros e que ele também possui poderes mágicos. Harry Potter passou a maior parte do seu tempo debaixo da escada na casa dos Dursleys, seus tios que não gostam dele. Porém, quando é convidado para estudar na Escola de Feitiços e Magia Hogwart, Harry percebe que existem dois mundos: um é o mundo sem graça dos humanos comuns e o outro é cheio de magia, encanto e fantasia.", "Harry Potter and the Sorcerers Stone", true },
                    { 13, "Aventura", "8.4", "Chris Evans, Robert Downey Jr., Tom Holland, Mark Ruffalo", "Avengers_Endgame.jpg", new DateTime(2019, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anthony Russo, Joe Russo", "Após Thanos eliminar metade das criaturas vivas, os Vingadores têm de lidar com a perda de amigos e entes queridos. Com Tony Stark vagando perdido no espaço sem água e comida, Steve Rogers e Natasha Romanov lideram a resistência contra o titã louco.", "Avengers: Endgame", true },
                    { 12, "Ação", "8.4", "Chris Hemsworth, Robert Downey Jr., Tom Holland, Mark Ruffalo", "Avengers_InfinityWar.jpg", new DateTime(2018, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anthony Russo, Joe Russo", "Homem de Ferro, Thor, Hulk e os Vingadores se reunem para combater o seu inimigo mais poderoso, o maligno Thanos. Em uma missão para obter todas as seis pedras infinitas, Thanos planeia usá-las para infligir a sua vontade maléfica sobre a realidade.", "Avengers: Infinity War", true },
                    { 18, "Aventura", "7.5", "Daniel Radcliffe, Emma Watson, Rupert Grint", "HarryPotter_AndTheOrderOfThePhoenix.jpg", new DateTime(2007, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "David Yates", "Harry regressa para o seu quinto ano de estudos em Hogwarts e descobre que a comunidade de feiticeiros não acredita no seu encontro com Lorde Voldemort. Receando que Albus Dumbledore, o reitor de Hogwarts, esteja a mentir sobre Voldemort de modo a minar o seu poder e usurpar o seu cargo o Ministro da Magia, Cornelius Fudge, nomeia uma nova professora de Defesa contra as Artes Negras, para vigiar Dumbledore e os estudantes de Hogwarts.", "Harry Potter and the Order of the Phoenix", true },
                    { 10, "Ação", "8.0", "Chris Evans, Chris Hemsworth, Robert Downey Jr., Mark Ruffalo", "TheAvengers.jpg", new DateTime(2012, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joss Whedon", "Os mais poderosos heróis da Terra têm de aprender a viver juntos e a lutar como uma equipa, criando os vingadores, impedindo Loki e seu exército alienígena de escravizar a humanidade.", "The Avengers", true },
                    { 9, "Ação", "6.6", "Adam Driver, Carrie Fisher, Mark Hamill", "StarWars_TheRiseOfSkywalker.jpg", new DateTime(2019, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jeffrey Jacob Abrams", "A Lucasfilm e o realizador J.J. Abrams voltam a unir forças para levar os espectadores numa jornada épica para uma galáxia muito, muito distante, com este novo e final capítulo da saga Skywalker, a fascinante conclusão da saga Skywalker, onde vão nascer novas lendas e a batalha final pela liberdade ainda está para chegar.", "Star Wars: The Rise of Skywalker", true },
                    { 8, "Aventura", "7.0", "Adam Driver, Mark Hamill, Carrie Fisher", "StarWars_TheLastJedi.jpg", new DateTime(2017, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rian Johnson", "Após encontrar o mítico e recluso Luke Skywalker (Mark Hammil) numa ilha isolada, a jovem Rey (Daisy Ridley) procura entender o balanço da Força a partir dos ensinamentos do mestre jedi. Paralelamente, o Primeiro Império de Kylo Ren (Adam Driver) reorganiza-se para enfrentar a Aliança Rebelde. A saga de Skywalker continua, enquanto os heróis de O Despertar da Força se juntam às lendas galácticas, para uma aventura épica, que desvenda mistérios antigos!", "Star Wars: The Last Jedi", true },
                    { 7, "Aventura", "7.9", "Adam Driver, Harrison Ford, Sara Maria Forsberg, Mark Hamill, Carrie Fisher", "StarWars_TheForceAwakens.jpg", new DateTime(2015, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jeffrey Jacob Abrams", "Décadas após a queda de Darth Vader e do Império, surge uma nova ameaça: a Primeira Ordem, uma organização sombria que busca minar o poder da República e que tem Kylo Ren (Adam Driver), o General Hux (Domhnall Gleeson) e o Líder Supremo Snoke (Andy Serkis) como principais expoentes. Eles conseguem capturar Poe Dameron (Oscar Isaac), um dos principais pilotos da Resistência, que antes de ser preso envia através do pequeno robô BB-8 o mapa de onde vive o mitológico Luke Skywalker (Mark Hamill).", "Star Wars: The Force Awakens", true },
                    { 6, "Aventura", "7.5", "Ewan McGregor, Natalie Portman, Samuel L. Jackson, Hayden Christensen, Ian McDiarmid", "StarWars_RevengeOfTheSith.jpg", new DateTime(2005, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "George Lucas", "No meio da guerra inciada no episódio dois desta saga, Anakin Skywalker perde a fidelidade aos Jedi. Seduzido pelas promessas de poder e tentações do Lado Negro da Força, transforma-se em Darth Vader. Juntos os Lordes Sith organizam um plano de vingança que começa com a exterminação dos Jedi. No confronto com os Sith, Yoda e Obi-Wan, os dois mestres Jedi, darão uma réplica feroz, com os seus sabres de luz. Nesta batalha final, que colocará Anakin contra Obi-Wan, se decidirá o destino da Galáxia.", "Star Wars: Episode III - Revenge of the Sith", true },
                    { 5, "Aventura", "6.5", "Ewan McGregor, Natalie Portman, Samuel L. Jackson, Hayden Christensen, Christopher Lee", "StarWars_AttackOfTheClones.jpg", new DateTime(2002, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "George Lucas", "Após a tentativa de homicídio da Senadora do planeta Naboo, Padme Amidala, Obi-Wan Kenobi e Anakin Skywalker irão investigar o que sucedeu. No decorrer das investigações, Obi-Wan descobre que há uma ligação entre o atentado e o movimento separatista contra a República, liderado por um ex-jedi. À beira de uma guerra civil, a solução encontrada para a defesa da República Galáctica é a constituição de um exército de clones...", "Star Wars: Episode II - Attack of the Clones", true },
                    { 4, "Aventura", "6.5", "Ewan McGregor, Liam Neeson, Natalie Portman, Samuel L. Jackson, Jake Lloyd", "StarWars_ThePhantomMenace.jpg", new DateTime(1999, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "George Lucas", "A Federação do Comércio, dirigida por Nute Gunray planeia assumir o pacífico mundo de Naboo. O Jedi Qui-Gon Jinn e Obi-Wan Kenobi são enviados para confrontar os líderes. Mas nem tudo corre conforme o plano. Os dois Jedis escapam e, em conjunto com o seu novo amigo Gungan, Jar Jar Binks, avançam para Naboo para advertir a Rainha Amidala, mas droids já começaram a capturar Naboo e a Rainha não está segura aí.", "Star Wars: Episode I - The Phantom Menace", true },
                    { 3, "Aventura", "8.3", "Harrison Ford, Mark Hamill, Carrie Fisher, Billy Dee Williams", "StarWars_ReturnOfTheJedi.jpg", new DateTime(1983, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Richard Marquand", "No espectacular capítulo final da saga Star Wars, Luke Skywalker e a Princesa Leia têm de ir a Tatooine para libertarem Han Solo, infiltrando-se na fortaleza imunda de Jabba the Hutt, o mais temido vilão da galáxia. Novamente unidos, os Rebeldes juntam forças com as tribos de Ewoks para enfrentarem as forças imperiais na lua floresta de Endor. Entretanto o Imperador e Darth Vader conspiram de forma a trazer Luke para o lado negro, mas o jovem Skywalker está determinado em honrar o espírito Jedi.", "Star Wars: Episode VI - Return of the Jedi", true },
                    { 2, "Aventura", "8.7", "Harrison Ford, Mark Hamill, Carrie Fisher, Billy Dee Williams", "StarWars_TheEmpireStrikesBack.jpg", new DateTime(1980, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Irvin Kershner", "São tempos negros para a Rebelião. Após um devastador ataque à sua base no planeta gelado de Hoth, os Rebeldes separam-se devido às perseguições Imperiais. Luke Skywalker vai em busca do misterioso Mestre Jedi Yoda, nos pântanos de Dagobah, enquanto Han Solo e a Princesa Leia despistam a frota Imperial em direcção à linda Cidade das Nuvens de Bespin. Numa tentativa de converter Luke ao lado negro, o maléfico Darth Vader, atrai o jovem Skywalker para uma armadilha.", "Star Wars: Episode V - The Empire Strikes Back", true },
                    { 11, "Aventura", "7.3", "Chris Evans, Chris Hemsworth, Robert Downey Jr., Mark Ruffalo", "Avengers_AgeOfUltron.jpg", new DateTime(2015, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joss Whedon", "Quando Tony Stark e Bruce Banner tentam iniciar um programa de manutenção da paz dormente chamado Ultron, as coisas vão terrivelmente erradas, e cabe a heróis mais poderosos da terra parar o vilão Ultron.", "Avengers: Age of Ultron", true }
                });

            migrationBuilder.InsertData(
                table: "Utilizadores",
                columns: new[] { "Id", "Email", "Nome", "Telemovel" },
                values: new object[,]
                {
                    { 18, "pastelbelem@fakemail.com", "Suzana Lacerda de Belém", "930826337" },
                    { 19, "pazeamor1@fmail.com", "Íris Gonçalves Perreira da Paz", "911710703" },
                    { 20, "robalinho.dario@fmail.com", "Dario Robalinho", "929859102" },
                    { 21, "nic1906@fakemail.com", "Nicolas Caparica Belmiro Antonieta", "924505523" },
                    { 22, "benfas@fakemail.com", "Luís Filipe Vieira", "937064844" },
                    { 23, "varandas.out76@fakemail.com", "Bruno de Carvalho", "926249717" },
                    { 28, "formacao.76@fakemail.com", "Ruben Amorim", "932380726" },
                    { 25, "osdragoes@fakemail.com", "Jorge Pinto da Costa", "922981151" },
                    { 26, "tikitaka@fmail.com", "Pepe Guardiola", "914329411" },
                    { 27, "manesalahfirmino@fmail.com", "Kloop", "935392465" },
                    { 29, "aiphone88@fakemail.com", "Jorge Jesus", "923840017" },
                    { 30, "aziado@fakemail.com", "Sérgio Paulo Marceneiro Conceição", "926249788" },
                    { 17, "mariabb1985@fakemail.com", "Maria Berenguer Barroqueiro", "916387910" },
                    { 24, "bdc.out@coldmail.com", "Varandas", "929112026" },
                    { 16, "carolcatela@fakemail.com", "Carolina Rafaela Lages Catela", "960272329" },
                    { 6, "aleixo.riana@fakemail.com", "Riana Aleixo", "911933053" },
                    { 14, "naylaaa1992@fmail.com", "Nayla Brandão de Mota", "967301205" },
                    { 13, "soniaglx@fakemail.com", "Sónia Maria Gama de Lisboa", "937926385" },
                    { 12, "caneirolas@coldmail.com", "Sandro Roçadas Caneira", "938715651" },
                    { 11, "quinzero@fakemail.com", "Irene Lousã Quinzeiro", "910471369" },
                    { 10, "bella.santanaf@fakemail.com", "Izabella Santana Figueira", "923893150" }
                });

            migrationBuilder.InsertData(
                table: "Utilizadores",
                columns: new[] { "Id", "Email", "Nome", "Telemovel" },
                values: new object[,]
                {
                    { 9, "vitalis1904@fakemail.com", "Kelton Malheiro Vital Junior", "966235761" },
                    { 8, "selmasesimbra90@fmail.com", "Selma Bandeira de Sesimbra", "922293804" },
                    { 7, "stelastratiacela@fmail.com", "Stela Prestes Beiriz Kanté", "961617363" },
                    { 31, "roleta.cabecada@coldmail.com", "Zinadine Zidane Careca", "921122026" },
                    { 5, "melindabb@fakemail.com", "Melinda Berenguer Barroqueiro", "918860367" },
                    { 4, "lage.benfica1904@fakemail.com", "Luis Sardo Lage", "919974088" },
                    { 3, "dinizrv1@coldmail.com", "Diniz Ribas Vieira", "913430471" },
                    { 2, "banhinhas@fmail.com", "Ranya Banha ", "934736786" },
                    { 1, "jen.alvelos12@fakemail.com", "Jénifer Lalanda Alvelos Perreira", "916729407" },
                    { 15, "mansinho69@coldmail.com", "Denzel Manso", "928014257" },
                    { 32, "pino@coldmail.com", "João Miguel Valente Tavares Oliveira", "927777777" }
                });

            migrationBuilder.InsertData(
                table: "Favoritos",
                columns: new[] { "Id", "FilmeFK", "UtilizadorFK" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 53, 8, 28 },
                    { 54, 9, 28 },
                    { 55, 10, 28 },
                    { 32, 21, 15 },
                    { 31, 19, 15 },
                    { 30, 17, 15 },
                    { 29, 9, 14 },
                    { 28, 3, 14 },
                    { 27, 2, 14 },
                    { 56, 11, 28 },
                    { 57, 12, 28 },
                    { 26, 20, 13 },
                    { 25, 19, 13 },
                    { 24, 18, 13 },
                    { 23, 17, 13 },
                    { 52, 7, 28 },
                    { 22, 13, 13 },
                    { 51, 6, 28 },
                    { 33, 2, 18 },
                    { 44, 1, 27 },
                    { 45, 21, 27 },
                    { 42, 21, 21 },
                    { 41, 20, 21 },
                    { 40, 19, 21 },
                    { 39, 18, 21 },
                    { 38, 17, 21 },
                    { 37, 16, 21 },
                    { 36, 15, 21 },
                    { 46, 1, 28 },
                    { 47, 2, 28 },
                    { 35, 14, 20 },
                    { 48, 3, 28 },
                    { 49, 4, 28 },
                    { 34, 14, 19 },
                    { 50, 5, 28 },
                    { 21, 8, 13 },
                    { 20, 7, 13 },
                    { 67, 11, 31 },
                    { 68, 12, 31 },
                    { 13, 5, 3 },
                    { 69, 13, 31 }
                });

            migrationBuilder.InsertData(
                table: "Favoritos",
                columns: new[] { "Id", "FilmeFK", "UtilizadorFK" },
                values: new object[,]
                {
                    { 12, 19, 2 },
                    { 11, 9, 2 },
                    { 10, 4, 2 },
                    { 70, 20, 31 },
                    { 9, 9, 1 },
                    { 8, 8, 1 },
                    { 7, 7, 1 },
                    { 6, 6, 1 },
                    { 5, 5, 1 },
                    { 4, 4, 1 },
                    { 3, 3, 1 },
                    { 2, 2, 1 },
                    { 19, 6, 13 },
                    { 66, 10, 31 },
                    { 43, 1, 26 },
                    { 62, 6, 29 },
                    { 14, 10, 6 },
                    { 15, 11, 6 },
                    { 16, 12, 6 },
                    { 17, 13, 6 },
                    { 64, 8, 30 },
                    { 18, 1, 13 },
                    { 63, 7, 29 },
                    { 58, 13, 28 },
                    { 65, 9, 31 },
                    { 61, 5, 29 },
                    { 60, 4, 29 },
                    { 59, 20, 28 }
                });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "Id", "FilmeFK", "URL", "UtilizadorFK", "Visivel" },
                values: new object[,]
                {
                    { 7, 20, "https://bedroom.example.com/", 27, true },
                    { 27, 20, "http://books.example.com/angle?bead=argument&birth=belief", 30, true },
                    { 41, 18, "https://isitchristmas.com/", 28, true },
                    { 20, 2, "http://argument.example.com/", 31, true },
                    { 4, 1, "https://www.example.com/bee.php", 31, true },
                    { 18, 7, "https://www.example.com/anger.php", 29, true },
                    { 25, 18, "https://example.com/basketball?bat=birthday&acoustics=ants", 28, true },
                    { 19, 1, "http://beginner.example.com/bomb", 26, true },
                    { 38, 4, "http://www.trypap.com/", 17, true },
                    { 13, 13, "http://example.com/aftermath.html", 24, true },
                    { 9, 8, "https://example.com/afternoon.aspx", 10, true },
                    { 8, 17, "http://www.example.com/argument.php", 10, true },
                    { 3, 10, "https://www.example.com/", 10, true },
                    { 45, 8, "http://www.sometimesredsometimesblue.com/", 8, true }
                });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "Id", "FilmeFK", "URL", "UtilizadorFK", "Visivel" },
                values: new object[,]
                {
                    { 33, 12, "http://bag.example.com/brake/boat", 7, true },
                    { 15, 16, "http://attraction.example.com/?bed=agreement", 6, true },
                    { 16, 15, "http://board.example.edu/", 5, true },
                    { 23, 14, "https://www.example.net/airplane.html", 4, true },
                    { 2, 9, "https://www.example.com/breath", 4, true },
                    { 47, 20, "http://www.rock-paper-scissors-game.com/", 3, true },
                    { 6, 20, "http://www.example.com/addition.html#boundary", 3, true },
                    { 10, 3, "http://example.org/actor", 2, true },
                    { 43, 1, "http://www.hasthelargehadroncolliderdestroyedtheworldyet.com/", 1, true },
                    { 26, 9, "https://example.com/#babies", 1, true },
                    { 12, 21, "https://www.example.org/agreement.php?blow=ball&breath=bat#bottle", 1, true },
                    { 30, 21, "https://www.example.net/balance/amount", 11, true },
                    { 46, 11, "http://www.patience-is-a-virtue.org/", 11, true },
                    { 34, 4, "https://baseball.example.org/?believe=balance&account=boat", 12, true },
                    { 36, 12, "http://www.example.com/authority", 12, true },
                    { 31, 3, "http://alarm.example.com/?airport=bath#arithmetic", 23, true },
                    { 5, 11, "https://example.com/", 22, true },
                    { 40, 1, "http://www.cat-bounce.com/", 21, true },
                    { 14, 21, "http://www.example.net/?ball=afterthought", 21, true },
                    { 28, 14, "http://www.example.com/boat/art", 20, true },
                    { 24, 19, "http://www.example.com/airport.aspx", 20, true },
                    { 42, 19, "http://www.randomcolour.com/", 19, true },
                    { 35, 11, "http://example.com/boat/bell#brake", 25, true },
                    { 11, 7, "https://www.example.edu/?arm=action&board=attack", 19, true },
                    { 29, 17, "https://brass.example.com/", 17, true },
                    { 44, 6, "http://www.koalastothemax.com/", 16, true },
                    { 39, 5, "http://www.heeeeeeeey.com/", 16, true },
                    { 32, 9, "https://www.example.com/anger", 15, true },
                    { 17, 12, "http://www.example.com/behavior.aspx", 15, true },
                    { 37, 2, "http://www.staggeringbeauty.com/", 13, true },
                    { 1, 5, "https://www.example.net/", 13, true },
                    { 21, 4, "https://example.org/", 31, true },
                    { 22, 6, "https://argument.example.org/aunt/bone.aspx", 31, true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Favoritos",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "Filmes");
        }
    }
}
