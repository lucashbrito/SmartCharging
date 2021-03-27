using SmartCharging.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCharging.Domain
{
    public class ChargeStation : Entity
    {
        public string Name { get; private set; }
        public List<Connector> Connectors { get; private set; }

        protected ChargeStation() { }

        public ChargeStation(string name)
        {
            Id = Guid.NewGuid().ToString();
            SetName(name);
            Connectors = new List<Connector>();
        }

        public ChargeStation(string name, List<Connector> connectors)
        {
            SetName(name);
            SetConnectors(connectors);
        }

        public void AddConnectors(Connector connector)
        {
            if (connector != null)
                Connectors.Add(connector);
        }

        public void SetConnectors(List<Connector> connectors)
        {
            if (connectors != null && connectors.Count > 5)
                throw new DomainException("Connectors can't be not more than 5");

            Connectors = connectors;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return;

            Name = name;
        }
    }
}
