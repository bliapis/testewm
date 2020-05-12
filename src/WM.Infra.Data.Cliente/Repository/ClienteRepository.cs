using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Dapper;
using WM.Domain.Cliente.Clientes.Entities;
using WM.Domain.Cliente.Clientes.Interfaces;
using WM.Infra.Data.Cliente.Context;

namespace WM.Infra.Data.Cliente.Repository
{
    public class ClienteRepository : Repository<ClienteModel>, IClienteRepository
    {
        public ClienteRepository(ClienteContext context) : base(context)
        {
        }

        public override IEnumerable<ClienteModel> GetAll()
        {
            var sql = "SELECT * FROM Cliente E ";

            return Db.Database.GetDbConnection().Query<ClienteModel>(sql);
        }

        public override ClienteModel GetById(Guid id)
        {
            var sql = @"SELECT * FROM Cliente E " +
                      "WHERE E.Id = @uid";

            var cliente = Db.Database.GetDbConnection().Query<ClienteModel>(sql, new { uid = id });

            return cliente.SingleOrDefault();
        }
    }
}