using SmartCharging.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartCharging.Domain
{
    public class GroupStation : Entity
    {
        public List<ChargeStation> ChargeStations { get; private set; }
        public string Name { get; private set; }
        public int CapacityAmps { get; private set; }

        protected GroupStation() { }

        public GroupStation(string name, int capaticyAmps)
        {
            Id = Guid.NewGuid().ToString();
            SetName(name);
            SetCapacityAmps(capaticyAmps);

            ChargeStations = new List<ChargeStation>();
        }

        public void AddChargeStation(ChargeStation chargeStation)
        {
            ChargeStations.Add(chargeStation);
        }

        public void SetCapacityAmps(int capacityAmps)
        {
            if (capacityAmps < 0)
                throw new DomainException("The Max current Amps shoulb be value greater than zero.");

            CapacityAmps = capacityAmps;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return;

            Name = name;
        }


        public void UpdateChargeStation(string name, string chargeStationId, int maxCurrentAmps)
        {
            var charStation = ChargeStations.FirstOrDefault(c => c.Id == chargeStationId);

            if (chargeStationId == null)
            {
                var newchargeStation = new ChargeStation(name);
                var newConnector = new Connector(newchargeStation.Id, maxCurrentAmps);

                newchargeStation.Connectors.Add(newConnector);

                ChargeStations.Add(newchargeStation);
            }
            else
            {
                charStation.SetName(name);
                var connectors = charStation.Connectors.FirstOrDefault(c => c.ChargeStationId == chargeStationId);
                connectors.SetMaxCurrentApms(maxCurrentAmps);
            }

        }
    }
}
