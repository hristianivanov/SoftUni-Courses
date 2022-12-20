namespace Formula1.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Models.Contracts;
    using Contracts;

    public class PilotRepository : IRepository<IPilot>
    {
        private List<IPilot> models;

        public PilotRepository()
        {
            models = new List<IPilot>();
        }
        public IReadOnlyCollection<IPilot> Models
            => models.AsReadOnly();

        public void Add(IPilot model)
        {
            models.Add(model);
        }

        public IPilot FindByName(string name)
        {
            return models.FirstOrDefault(x => x.FullName == name);
        }

        public bool Remove(IPilot model)
        {
            return models.Remove(model);
        }
    }
}
