using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheMoviePlug.Models
{
    /// <summary>
    /// Link adicionado a um Filme por um Utilizador
    /// </summary>
    public class Links
    {

        /// <summary>
        /// Identificador do Link
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Uniform Resource Locator do Link
        /// </summary>
        [Required]
        [Url]
        public string URL { get; set; }

        /// <summary>
        /// Visibilidade do Link
        /// True - o Link está visível
        /// False - o Link não está visível
        /// </summary>
        public Boolean Visivel { get; set; }


        // ************************************************************************************************************************************************


        /// <summary>
        /// Chave forasteira para o Utilizador que adicionou o Link
        /// </summary>
        [ForeignKey(nameof(Utilizador))]
        public int UtilizadorFK { get; set; }        // atributo para ser usado no SGBD e no C#. Representa a FK para o Utilizador que adicionou o Link
        public Utilizadores Utilizador { get; set; } // atributo para ser usado no C#. Representa a FK para o Utilizador que adicionou o Link

        /// <summary>
        /// Chave forasteira para o Filme ao qual foi adicionado o Link
        /// </summary>
        [ForeignKey(nameof(Filme))]
        public int FilmeFK { get; set; }             // atributo para ser usado no SGBD e no C#. Representa a FK para o Filme ao qual o Link foi adicionado
        public Filmes Filme { get; set; }            // atributo para ser usado no C#. Representa a FK para o Filme ao qual o Link foi adicionado

    }
}
