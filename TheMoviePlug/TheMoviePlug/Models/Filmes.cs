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
            // inicializar as listas
            ListaDeLinks = new HashSet<Links>();
            ListaUtilizadoresFav = new HashSet<Utilizadores>();

        }

        /// <summary>
        /// Identificador do Filme
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Título do Filme
        /// </summary>
        [Required]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        /// <summary>
        /// Capa do Filme
        /// </summary>
        [Display(Name = "Capa do filme")]
        public string Imagem { get; set; }

        /// <summary>
        /// Categoria principal a que o Filme pertence
        /// </summary>
        [Required]
        public string Categoria { get; set; }

        /// <summary>
        /// Data de lançamento do Filme
        /// </summary>
        [Display(Name = "Data de lançamento")]
        public DateTime Lancamento { get; set; }

        /// <summary>
        /// Classificação (de 0.0 a 10.0) do Filme
        /// </summary>
        [Required]
        [Display(Name = "Classificação")]
        public string Classificacao { get; set; }

        /// <summary>
        /// Nome do realizador do Filme
        /// </summary>
        [Required(ErrorMessage = "O Nome é de preenchimento obrigatório.")]
        [StringLength(40, ErrorMessage = "O {0} não pode ter mais de {1} carateres.")]
        [RegularExpression("[A-ZÂÓÍÉ][a-záéíóúàèìòùâêîôûãôûäëïöüçñ]+(( | d[oa](s)? | (d)?e |-|'| d')[A-ZÂÓÍÉ][a-záéíóúàèìòùâêîôûãôûäëïöüçñ]+){1,3}",
         ErrorMessage = "Só são aceites letras.<br />A primeira letra de cada nome é uma Maiúscula seguida de letras minúsculas.<br />Deve escrever entre 2 e 4 nomes.")]
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
        /// Lista dos Utilizadores que adicionaram o Filme aos favoritos
        /// </summary>
        public ICollection<Utilizadores> ListaUtilizadoresFav { get; set; }

    }
}
