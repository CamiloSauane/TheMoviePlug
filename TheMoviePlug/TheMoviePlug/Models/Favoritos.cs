using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheMoviePlug.Models
{
    /// <summary>
    /// Estado "Favorito" que é atribuido por um Utilizador a um Filme 
    /// </summary>
    public class Favoritos
    {

        /// <summary>
        /// Chave primária para a tabela do relacionamento entre Utilizadores e Filmes
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Chave forasteira para o Utilizador que adicionou o Filme como Favorito
        /// </summary>
        [ForeignKey(nameof(Utilizador))]
        public int UtilizadorFK { get; set; }        // atributo para ser usado no SGBD e no C#. Representa a FK para o Utilizador que adicionou o Filme como Favorito
        public Utilizadores Utilizador { get; set; } // atributo para ser usado no C#. Representa a FK para o Utilizador que adicionou o o Filme como Favorito

        /// <summary>
        /// Chave forasteira para o Filme que foi adicionado como Favorito
        /// </summary>
        [ForeignKey(nameof(Filme))]
        public int FilmeFK { get; set; }             // atributo para ser usado no SGBD e no C#. Representa a FK para o Filme que foi adicionado como Favorito
        public Filmes Filme { get; set; }            // atributo para ser usado no C#. Representa a FK para o Filme que foi adicionado como Favorito

    }
}
