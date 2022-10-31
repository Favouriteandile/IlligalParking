using IlligalParking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IlligalParking.Data
{
    public class EFVehicleRepository
    : RepositoryBase<Vehicle>, IVehicleRepository
    {
        public EFVehicleRepository(ApplicationDbContext appDbContext)
            : base(appDbContext)
        {
        }
    }
}
