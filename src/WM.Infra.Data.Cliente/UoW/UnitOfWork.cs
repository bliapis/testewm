using WM.Domain.Core;
using WM.Domain.Core.Interfaces;
using WM.Infra.Data.Cliente.Context;

namespace WM.Infra.Data.Cliente.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ClienteContext _context;

        public UnitOfWork(ClienteContext context)
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