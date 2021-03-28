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
    public class UpdateGroupSationCommandHandler : BaseCommandHandler
    {
        private readonly IGroupRepository _groupRepository;

        public UpdateGroupSationCommandHandler(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<bool> Execute(GroupStationInputModel groupStationInput, string groupId)
        {
            var group = await _groupRepository.GetGroupById(groupId);

            group.SetName(groupStationInput.Name);
            group.SetCapacityAmps(groupStationInput.CapacityAmps);

            Parallel.ForEach(groupStationInput.ChargeStations, chargeStation =>
            {
                foreach (var connector in chargeStation.Connectors)
                {
                    group.UpdateChargeStation(chargeStation.Name, connector.ChargeStationId, connector.MaxCurrentAmps);
                }
            });

            await _groupRepository.Update(groupId, group);

            HandlerMessage = "the Group has updated";
            return true;            
        }
    }
}
