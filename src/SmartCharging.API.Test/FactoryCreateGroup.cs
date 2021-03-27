using SmartCharging.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCharging.API.Test
{
    public class FactoryCreateGroup
    {
        public GroupStation CreateGroupStation()
        {
            var groupStations = new List<GroupStation>();
            var connector = new List<Connector>();
            var chargeStations = new List<ChargeStation>();

            var group1 = new GroupStation("nameGroupStation1", 3);
            group1.Id = "000";

            var chargeStation1 = new ChargeStation("chargeStation1", connector);
            chargeStation1.Id = "1234";

            var chargeStation2 = new ChargeStation("chargeStation2", connector);
            chargeStation2.Id = "2341";

            var chargeStation3 = new ChargeStation("chargeStation3", connector);
            chargeStation3.Id = "3412";

            var chargeStation4 = new ChargeStation("chargeStation4", connector);
            chargeStation4.Id = "4123";

            chargeStations.Add(chargeStation1);
            chargeStations.Add(chargeStation2);
            chargeStations.Add(chargeStation3);
            chargeStations.Add(chargeStation4);
            connector.Add(new Connector("1234", 1));
            connector.Add(new Connector("2341", 2));
            connector.Add(new Connector("3412", 3));
            connector.Add(new Connector("4123", 4));

            return new GroupStation("nameGroupStation1", 3);

        }
    }
}
