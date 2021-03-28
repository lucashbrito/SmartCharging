using SmartCharging.Application.Queries;
using SmartCharging.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCharging.Application.Commands
{
    public class RemoveChargeStationToGroupStationGroupByIdCommandHandler : BaseCommandHandler
    {
        private readonly IGroupRepository _groupRepository;

        public RemoveChargeStationToGroupStationGroupByIdCommandHandler(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<bool> Execute(string chargeStationId, string groupStationId)
        {
            var group = await _groupRepository.GetGroupById(chargeStationId);

            if (group == null)
            {
                HandlerMessage = "Cant find the groupStation";
                return false;
            }

            var chargeStationRemoved = group.ChargeStations.FirstOrDefault(x => x.Id == chargeStationId);

            if (chargeStationRemoved == null)
            {
                HandlerMessage = "Cant find the charge station to remove";
                return false;
            }

            group.ChargeStations.Remove(chargeStationRemoved);

            await _groupRepository.Update(groupStationId, group);

            return true;
        }
    }
}
