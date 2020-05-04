using WM.Domain.Core;
using WM.Domain.Core.Interfaces;
using WM.Infra.Data.Anuncio.Context;

namespace WM.Infra.Data.Anuncio.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AnuncioContext _context;

        public UnitOfWork(AnuncioContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}