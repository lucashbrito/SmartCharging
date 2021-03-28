using SmartCharging.Application.InputModel;
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
        public CreateGroupStationInputModel CreateGroupStationInputModel()
        {
            return new CreateGroupStationInputModel()
            {
                CapacityAmps = 123,
                Name = "123",
                ChargeStations = new List<CreateChargeStationInputModel>()
                {
                    new CreateChargeStationInputModel()
                    {
                        Name="ChargeStation",
                        Connectors=new List<CreateConnectorInputModel>
                        {
                            new CreateConnectorInputModel()
                            {
                                MaxCurrentAmps=12
                            }
                        }
                    }
                }
            };
        }
    }
}
