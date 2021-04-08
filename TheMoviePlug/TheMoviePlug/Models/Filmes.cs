using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheMoviePlug.Models
{
    /// <summary>
    /// Descrição de um Filme
    /// </summary>
    public class Filmes
    {

        public Filmes()
        {

            ListaDeLinks = new HashSet<Links>();
            ListaDeFavoritos = new HashSet<Favoritos>();

        }

        /// <summary>
        /// Identificador do Filme
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Título do Filme
        /// </summary>
        [Required]
        public string Titulo { get; set; }

        /// <summary>
        /// Categoria principal a que o Filme pertence
        /// </summary>
        [Required]
        public string Categoria { get; set; }

        /// <summary>
        /// Data de lançamento do Filme
        /// </summary>
        public DateTime Lancamento { get; set; }

        /// <summary>
        /// Classificação (de 0.0 a 10.0) do Filme
        /// </summary>
        [Required]
        public string Classificacao { get; set; }

        /// <summary>
        /// Nome do realizador do Filme
        /// </summary>
        [Required]
        public string Realizador { get; set; }

        /// <summary>
        /// Elenco do Filme
        /// </summary>
        [Required]
        public string Elenco { get; set; }

        /// <summary>
        /// Sipnose do Filme
        /// </summary>
        [Required]
        public string Sinopse { get; set; }

        /// <summary>
        /// Visibilidade do Filme
        /// True - o Filme está visível
        /// False - o Filme não está visível
        /// </summary>
        public Boolean Visibilidade { get; set; }


        // #########################################################################


        /// <summary>
        /// Lista de Links que foram adicionados ao Filme
        /// </summary>
        public ICollection<Links> ListaDeLinks { get; set; }

        /// <summary>
        /// Lista onde o Filme pertence aos Favoritos
        /// </summary>
        public ICollection<Favoritos> ListaDeFavoritos { get; set; }

    }
}
