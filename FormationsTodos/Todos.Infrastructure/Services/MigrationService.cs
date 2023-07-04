using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todos.Infrastructure.Data;

namespace Todos.Infrastructure
{
    public interface IMigrationService
    {
        Task StartMigration();
    }
    internal class MigrationService : IMigrationService
    {
        private readonly DataBaseContexte _dataBaseContexte;

        public MigrationService(DataBaseContexte dataBaseContexte)
        {
            _dataBaseContexte = dataBaseContexte;
        }

        public async Task StartMigration()
        {
            var migrations = _dataBaseContexte.Database.GetPendingMigrations();
            if (migrations?.Any()??false)
            {
                // dump de la base
            }
            await _dataBaseContexte.Database.MigrateAsync();
        }
    }
}
