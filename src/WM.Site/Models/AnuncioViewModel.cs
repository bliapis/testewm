using System.ComponentModel.DataAnnotations;

namespace WM.Site.Models
{
    public class AnuncioViewModel
    {
        [Key]
        public int? Id { get; set; }
        [Required(ErrorMessage = "É necessário preencher a marca")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "É necessário preencher o modelo")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "É necessário preencher a versao")]
        public string Versao { get; set; }
        [Required(ErrorMessage = "É necessário preencher o ano")]
        public int Ano { get; set; }
        [Required(ErrorMessage = "É necessário preencher o quilometragem")]
        public int Quilometragem { get; set; }
        [Required(ErrorMessage = "É necessário preencher a observação")]
        public string Observacao { get; set; }
    }
}