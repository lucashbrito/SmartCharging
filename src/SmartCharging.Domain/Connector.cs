using SmartCharging.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCharging.Domain
{
    public class Connector : ValueObject<Connector>
    {
        public int MaxCurrentAmps { get; private set; }
        public string ChargeStationId { get; private set; }

        protected Connector() { }

        public Connector(string chargeStationId, int maxCurrentAmps)
        {
            if (string.IsNullOrWhiteSpace(chargeStationId))
                throw new DomainException("Connector cannot exist in the domain without charge station.");

            ChargeStationId = chargeStationId;

            SetMaxCurrentApms(maxCurrentAmps);
        }

        public void SetMaxCurrentApms(int maxCurrentAmps)
        {
            if (maxCurrentAmps < 0)
                throw new DomainException("The Max current Amps shoulb be value greater than zero.");

            MaxCurrentAmps = maxCurrentAmps;
        }

        protected override bool EqualsCore(Connector other)
        {
            return other.ChargeStationId == this.ChargeStationId;
        }
    }
}
