using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IlligalParking.Data
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationDbContext _appDbContext;
        private IComplainRepository complain;
        private IParkingRepository parking;
        private IVehicleRepository vehicle;

        public RepositoryWrapper(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IComplainRepository Complain
        {
            get
            {
                if (complain == null)
                {
                    complain = new EFComplainRepository(_appDbContext);
                }

                return complain;
            }
        }
        public IParkingRepository Parking
        {
            get
            {
                if (parking == null)
                {
                    parking = new EFParkingRepository(_appDbContext);
                }

                return parking;
            }
        }
        public IVehicleRepository Vehicle
        {
            get
            {
                if (vehicle == null)
                {
                    vehicle = new EFVehicleRepository(_appDbContext);
                }

                return vehicle;
            }
        }



    }
}
