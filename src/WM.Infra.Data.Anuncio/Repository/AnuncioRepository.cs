using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Dapper;
using WM.Domain.Anuncio.Repository;
using WM.Domain.Anuncio.Anuncio.Entities;
using WM.Domain.Anuncio.Anuncio.Interfaces;
using WM.Infra.Data.Anuncio.Context;

namespace WM.Infra.Data.Anuncio.Repository
{
    public class AnuncioRepository : Repository<AnuncioModel>, IAnuncioRepository
    {
        public AnuncioRepository(AnuncioContext context) : base(context)
        {
        }

        public override IEnumerable<AnuncioModel> GetAll()
        {
            var sql = "SELECT * FROM tb_AnuncioWebmotors E ";

            return Db.Database.GetDbConnection().Query<AnuncioModel>(sql);
        }

        public override AnuncioModel GetById(int id)
        {
            var sql = @"SELECT * FROM tb_AnuncioWebmotors E " +
                      "WHERE E.Id = @uid";

            var permissao = Db.Database.GetDbConnection().Query<AnuncioModel>(sql, new { uid = id });

            return permissao.SingleOrDefault();
        }
    }
}