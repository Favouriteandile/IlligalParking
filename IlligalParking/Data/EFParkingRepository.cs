using IlligalParking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IlligalParking.Data
{
    public class EFParkingRepository
     : RepositoryBase<Parking>, IParkingRepository
    {
        public EFParkingRepository(ApplicationDbContext appDbContext)
            : base(appDbContext)
        {
        }
    }
}
