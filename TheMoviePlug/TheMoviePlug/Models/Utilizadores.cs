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
            // inicializar as listas
            ListaLinks = new HashSet<Links>();
            ListaFilmesFav = new HashSet<Filmes>();

        }

        /// <summary>
        /// Identificador do Utilizador
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nome do Utilizador
        /// </summary>
        [Required(ErrorMessage = "O Nome é de preenchimento obrigatório.")]
        [StringLength(40, ErrorMessage = "O {0} não pode ter mais de {1} carateres.")]
        [RegularExpression("[A-ZÂÓÍÉ][a-záéíóúàèìòùâêîôûãôûäëïöüçñ]+(( | d[oa](s)? | (d)?e |-|'| d')[A-ZÂÓÍÉ][a-záéíóúàèìòùâêîôûãôûäëïöüçñ]+){1,3}",
         ErrorMessage = "Só são aceites letras.<br />A primeira letra de cada nome é uma Maiúscula seguida de letras minúsculas.<br />Deve escrever entre 2 e 4 nomes.")]
        public string Nome { get; set; }

        /// <summary>
        /// Endereço eletrónico do Utilizador
        /// </summary>
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        /// <summary>
        /// Contacto telefónico do Utilizador
        /// </summary>
        [Display(Name = "Número de telemóvel")]
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório.")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "O {0} deve ter exatamente {1} caracteres.")]
        [RegularExpression("[9][1236][0-9]{7}", ErrorMessage = "Deve escrever exatamente 9 algarismos!<br />Quanto aos dois primeiros algarismos deve: começar por 9 seguido de 1, 2, 3 ou 6.")] // <=> filtro
        public string Telemovel { get; set; }

        /// <summary>
        /// Estado do Utilizador
        /// True - o Utilizador está ativo
        /// False - o admin desativou o Utilizador
        /// </summary>
        public Boolean Ativo { get; set; }


        //******************************************************************************************************************************************
        /// <summary>
        /// Funciona como Chave Forasteira para ligar à tabela de autenticação
        /// </summary>
        public string UserName { get; set; }
        //******************************************************************************************************************************************


        // #########################################################################


        /// <summary>
        /// Lista de Links que o Utilizador adicionou
        /// </summary>
        public ICollection<Links> ListaLinks { get; set; }

        /// <summary>
        /// Lista de Favoritos do Utilizador
        /// </summary>
        public ICollection<Filmes> ListaFilmesFav { get; set; }

    }
}
