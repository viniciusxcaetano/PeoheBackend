using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Peohe.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Peohe.Services
{
    public class InstallmentService
    {
        //private readonly PeoheDbContext dbContext;
        private readonly IServiceScopeFactory _scopeFactory;
        public InstallmentService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public int testeDenovo()
        {
            using (var dbContext = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<PeoheDbContext>())
            {
                //fazer um select por exemplo
            }
            return 1000;
        }
    }
}