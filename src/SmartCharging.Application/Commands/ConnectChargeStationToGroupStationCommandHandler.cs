using SmartCharging.Application.InputModel;
using SmartCharging.Application.Queries;
using SmartCharging.Domain;
using SmartCharging.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCharging.Application.Commands
{
    public class ConnectChargeStationToGroupStationCommandHandler : BaseCommandHandler
    {
        private readonly IGroupRepository _groupRepository;

        public ConnectChargeStationToGroupStationCommandHandler(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<bool> Execute(UpdateChargeStationInputModel chargeStationInput, string groupId)
        {
            var group = await _groupRepository.GetGroupById(groupId);

            if (group == null)
            {
                HandlerMessage = "Can't add this station because the IdGroup doenst exist";
                return false;
            }

            var hasChargeStation = _groupRepository.GetChargeStationById(chargeStationInput.Id);

            if (hasChargeStation != null)
            {
                HandlerMessage = "The charge station already exist.";
                return false;
            }

            var chargeStation = new ChargeStation(chargeStationInput.Name);

            AddConnectors(chargeStationInput, chargeStation);

            group.ChargeStations.Add(chargeStation);

            await _groupRepository.Update(group.Id, group);

            HandlerMessage = "the Connector has created";
            return true;
        }

        private static void AddConnectors(UpdateChargeStationInputModel chargeStationInput, ChargeStation chargeStation)
        {
            if (chargeStationInput.Connectors != null)
            {
                var newConnects = new List<Connector>(chargeStationInput.Connectors.Count);

                newConnects.AddRange(from connect in chargeStationInput.Connectors
                                     select new Connector(chargeStation.Id, connect.MaxCurrentAmps));
            }
        }
    }
}
