﻿namespace NavalVessels.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Models.Contracts;
    public class VesselRepository : IRepository<IVessel>
    {
        private readonly List<IVessel> vessels;
        public VesselRepository()
        {
            vessels = new List<IVessel>();
        }
        public IReadOnlyCollection<IVessel> Models
            => vessels.AsReadOnly();
        public void Add(IVessel model)
            => vessels.Add(model);
        public IVessel FindByName(string name)
            =>vessels.FirstOrDefault(x => x.Name == name);
        public bool Remove(IVessel model)
            => vessels.Remove(model);
    }
}
