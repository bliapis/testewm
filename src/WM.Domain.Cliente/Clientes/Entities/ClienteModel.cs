using FluentValidation;
using System;
using WM.Domain.Core.Models;

namespace WM.Domain.Cliente.Clientes.Entities
{
    public class ClienteModel : Entity<ClienteModel>
    {
        public string Nome { get; private set; }
        public int Idade { get; private set; }

        public ClienteModel(string nome, int idade)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Idade = idade;
        }

        public ClienteModel() {} //EF Constructor

        public override bool IsValid()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validações
        private void Validar()
        {
            ValidarNome();
            ValidarIdade();
            ValidationResult = Validate(this);
        }

        private void ValidarNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O Nome deve ser informado")
                .Length(2, 100).WithMessage("O nome deve ter entre 2 e 100 caracteres");
        }
        private void ValidarIdade()
        {
            RuleFor(c => c.Idade)
                .NotNull().WithMessage("A idade deve ser informado")
                .Must(x => x >= 1 && x <= 120).WithMessage("Informe uma idade entre 1 e 120 anos");
        }
        #endregion
    }
}