using IlligalParking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IlligalParking.Data
{
    public class EFComplainRepository
    : RepositoryBase<Complain>, IComplainRepository
    {
        public EFComplainRepository(ApplicationDbContext appDbContext)
            : base(appDbContext)
        {
        }
    }
}
