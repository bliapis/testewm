using FluentValidation;
using WM.Domain.Core.Models;

namespace WM.Domain.Anuncio.Anuncio.Entities
{
    public class AnuncioModel : Entity<AnuncioModel>
    {
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public string Versao { get; private set; }
        public int Ano { get; private set; }
        public int Quilometragem { get; private set; }
        public string Observacao { get; private set; }

        public AnuncioModel(string marca, string modelo, string versao, int ano, int quilometragem, string obs)
        {
            Marca = marca;
            Modelo = modelo;
            Versao = versao;
            Ano = ano;
            Quilometragem = quilometragem;
            Observacao = obs;
        }

        public AnuncioModel() {} //EF Constructor

        public override bool IsValid()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validações
        private void Validar()
        {
            ValidarMarca();
            ValidarModelo();
            ValidarVersao();
            ValidarAno();
            ValidarQuilometragem();
            ValidarObservacao();
            ValidationResult = Validate(this);
        }

        private void ValidarMarca()
        {
            RuleFor(c => c.Marca)
                .NotEmpty().WithMessage("A marca deve ser informada")
                .Length(2, 45).WithMessage("O nome da marca deve ter entre 2 e 45 caracteres");
        }
        private void ValidarModelo()
        {
            RuleFor(c => c.Modelo)
                .NotEmpty().WithMessage("O modelo deve ser informado")
                .Length(2, 45).WithMessage("O nome do Modelo deve ter entre 2 e 45 caracteres");
        }
        private void ValidarVersao()
        {
            RuleFor(c => c.Versao)
                .NotEmpty().WithMessage("A versao deve ser informada")
                .Length(2, 45).WithMessage("O nome da versao deve ter entre 2 e 45 caracteres");
        }
        private void ValidarAno()
        {
            RuleFor(c => c.Ano)
                .NotNull().WithMessage("O ano deve ser informado")
                .Must(x => x >= 1900 && x <= 2020).WithMessage("O Ano deve estar entre 1900 e 2020");
        }
        private void ValidarQuilometragem()
        {
            RuleFor(c => c.Quilometragem)
                .NotNull().WithMessage("O ano deve ser informado")
                .Must(x => x >= 0 && x <= 5000).WithMessage("A quilometragem deve estar entre 0 e 5000 km");
        }
        private void ValidarObservacao()
        {
            RuleFor(c => c.Observacao)
                .NotEmpty().WithMessage("A Observação deve ser informada");
        }
        #endregion
    }
}