using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartCharging.Application.Commands;
using SmartCharging.Application.InputModel;
using SmartCharging.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCharging.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class GroupStationController : ControllerBase
    {
        private readonly ILogger<GroupStationController> _logger;
        private readonly IGroupRepository _groupRepository;

        public GroupStationController(ILogger<GroupStationController> logger, IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
            _logger = logger;
        }



        [HttpGet]
        public async Task<IActionResult> GetGroup()
        {

            var groups = await _groupRepository.Get();

            if (groups != null)
            {
                return Ok(groups);
            }

            return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGroup(UpdateGroupStationInputModel group, string idGroup)
        {
            var commandHandler = new UpdateGroupSationCommandHandler(_groupRepository);
            var result = await commandHandler.Execute(group, idGroup);

            if (result)
            {
                return Ok(commandHandler.HandlerMessage);
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateGroup(CreateGroupStationInputModel group)
        {
            var commandHandler = new CreateGroupStationCommandHandler(_groupRepository);

            var result = await commandHandler.Execute(group);

            if (result)
            {
                return Ok(commandHandler.HandlerMessage);
            }

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteGroupById(string id)
        {
            await _groupRepository.DeleteById(id);

            return Ok();

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ConnectChargeStationToGroupStation(UpdateChargeStationInputModel chargeStationInput, string groupId)
        {
            var commandHandler = new ConnectChargeStationToGroupStationCommandHandler(_groupRepository);

            var result = await commandHandler.Execute(chargeStationInput, groupId);

            if (result)
            {
                return Ok(commandHandler.HandlerMessage);
            }

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveChargeStationToGroupStationGroupById(string chargeStationId, string groupStationId)
        {
            var commandHandler = new RemoveChargeStationToGroupStationGroupByIdCommandHandler(_groupRepository);

            var result = await commandHandler.Execute(chargeStationId, groupStationId);

            if (result)
            {
                return Ok(commandHandler.HandlerMessage);
            }

            return NoContent();
        }
    }
}
