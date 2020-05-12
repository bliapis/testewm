using System;
using System.ComponentModel.DataAnnotations;

namespace WM.API.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Informe o Nome")]
        [MinLength(2, ErrorMessage = "O tamanho minimo do Nome deve ser {2}")]
        [MaxLength(100, ErrorMessage = "O tamanho máximo do Nome deve ser {100}")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a Idade")]
        //[MinLength(1, ErrorMessage = "A Idade minima deve ser {1}")]
        //[MaxLength(120, ErrorMessage = "A Idade máxima deve ser {120}")]
        public int Idade { get; set; }
    }
}