using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IlligalParking.Data
{
    public interface IRepositoryWrapper
    {
        public IParkingRepository Parking { get; }
        public IComplainRepository Complain { get; }
        public IVehicleRepository Vehicle { get; }
    }
}
