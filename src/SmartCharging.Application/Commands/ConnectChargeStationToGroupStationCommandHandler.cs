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
    public class ConnectChargeStationToGroupStationCommandHandler
    {
        private readonly IGroupRepository _groupRepository;

        public ConnectChargeStationToGroupStationCommandHandler(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<bool> Execute(ChargeStatioUpdateInputModel chargeStationInput, string groupId)
        {
            var group = await _groupRepository.GetGroupById(groupId);

            if (group == null)
            {
                throw new DomainException("Can't add this station because the IdGroup doenst exist");
                //or
                //return false;
            }

            var hasChargeStation = _groupRepository.GetChargeStationById(chargeStationInput.Id);

            if (hasChargeStation != null)
            {
                throw new DomainException("The charge station already exist.");
                //    return false;
            }

            var chargeStation = new ChargeStation(chargeStationInput.Name);

            AddConnectors(chargeStationInput, chargeStation);

            group.ChargeStations.Add(chargeStation);

            await _groupRepository.Update(group.Id, group);

            return true;
        }

        private static void AddConnectors(ChargeStatioUpdateInputModel chargeStationInput, ChargeStation chargeStation)
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
