using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheMoviePlug.Models
{
    /// <summary>
    /// Descrição de um Utilizador
    /// </summary>
    public class Utilizadores
    {

        public Utilizadores()
        {

            ListaLinks = new HashSet<Links>();
            ListaFavoritos = new HashSet<Favoritos>();

        }

        /// <summary>
        /// Identificador do Utilizador
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome do Utilizador
        /// </summary>
        [Required]
        public string Nome { get; set; }

        /// <summary>
        /// Endereço eletrónico do Utilizador
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Contacto telefónico do Utilizador
        /// </summary>
        public string Telemovel { get; set; }


        // #########################################################################


        /// <summary>
        /// Lista de Links que o Utilizador adicionou
        /// </summary>
        public ICollection<Links> ListaLinks { get; set; }

        /// <summary>
        /// Lista de Favoritos do Utilizador
        /// </summary>
        public ICollection<Favoritos> ListaFavoritos { get; set; }

    }
}
