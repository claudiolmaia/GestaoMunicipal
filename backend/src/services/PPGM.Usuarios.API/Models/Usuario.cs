using PPGM.Core.DomainObjects;
using System;

namespace PPGM.Usuarios.API.Models
{
    public class Usuario : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public Email Email { get; private set; }
        public Cpf Cpf { get; private set; }
        public bool IsExcluido { get; private set; }

        protected Usuario() { }

        public Usuario(Guid id, string nome, string email, string cpf)
        {
            Id = id;
            Nome = nome;
            Email = new Email(email);
            Cpf = new Cpf(cpf);
            IsExcluido = false;
        }

        public void TrocarEmail(string email)
        {
            Email = new Email(email);
        }
    }


}
