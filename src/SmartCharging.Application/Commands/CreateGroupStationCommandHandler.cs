using SmartCharging.Application.InputModel;
using SmartCharging.Application.Queries;
using SmartCharging.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCharging.Application.Commands
{
    public class CreateGroupStationCommandHandler : BaseCommandHandler
    {
        private readonly IGroupRepository _groupRepository;

        public CreateGroupStationCommandHandler(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<bool> Execute(CreateGroupStationInputModel groupStationInput)
        {
            var group = new GroupStation(groupStationInput.Name, groupStationInput.CapacityAmps);

            Parallel.ForEach(groupStationInput.ChargeStations, chargeStation =>
            {
                var newChargStation = new ChargeStation(chargeStation.Name);

                var newConnectorList = CreateConnectors(chargeStation, newChargStation);

                newChargStation.Connectors.AddRange(newConnectorList);

                group.AddChargeStation(newChargStation);
            });

            if (group.IsCapacityOfGroup() > group.CapacityAmps)
            {
                var numberOfExcessConnector = group.IsCapacityOfGroup() - group.CapacityAmps;

                HandlerMessage = $"The capactiy of Connector was excessed. You may remove {numberOfExcessConnector} of Connectors";

                return false;
            }

            await _groupRepository.Add(group);

            HandlerMessage = "Group has been added";

            return true;
        }

        private static List<Connector> CreateConnectors(CreateChargeStationInputModel chargeStation, ChargeStation newChargStation)
        {
            var newConnectorList = new List<Connector>(chargeStation.Connectors.Count);

            newConnectorList.AddRange(from connector in chargeStation.Connectors
                                      select new Connector(newChargStation.Id, connector.MaxCurrentAmps));
            return newConnectorList;
        }
    }
}
