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


        ////TODO Group can be created, update and removed 
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetGroup()
        {
            try
            {
                var groups = await _groupRepository.Get();

                if (groups != null)
                {
                    return Ok(groups);
                }
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Trace, e, "GroupStationController.Get");
                return BadRequest(e);
            }

            return BadRequest();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateGroup(GroupStationInputModel group, string idGroup)
        {
            try
            {
                var result = await new UpdateGroupSationCommandHandler(_groupRepository).Execute(group, idGroup);

                if (result)
                {
                    return Ok();
                }
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Trace, e, "GroupStationController.UpdateGroup");
                return BadRequest(e);
            }

            return BadRequest();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddGroup(GroupStationInputModel group)
        {
            try
            {
                var result = await new CreateGroupStationCommandHandler(_groupRepository).Execute(group);

                if (result)
                {
                    return Ok();
                }
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Trace, e, "GroupStationController.AddGroup");
                return BadRequest(e);
            }

            return BadRequest();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ConnectChargeStationToGroupStation(ChargeStatioUpdateInputModel chargeStationInput, string groupId)
        {
            try
            {
                var result = await new ConnectChargeStationToGroupStationCommandHandler(_groupRepository).Execute(chargeStationInput, groupId);

                if (result)
                {
                    return Ok();
                }
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Trace, e, "GroupStationController.Add");
                return BadRequest(e);
            }

            return BadRequest();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RemoveChargeStationToGroupStationGroupById(string chargeStationId, string groupStationId)
        {
            try
            {
                var result = await new RemoveChargeStationToGroupStationGroupByIdCommandHandler(_groupRepository).Execute(chargeStationId, groupStationId);

                if (result)
                {
                    return Ok();
                }
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Trace, e, "GroupStationController.Add");
                return BadRequest(e);
            }

            return BadRequest();
        }


        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteGroupById(string id)
        {
            try
            {
                await _groupRepository.DeleteById(id);

                return Ok();
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Trace, e, "GroupStationController.DeleteById");
                return BadRequest(e);
            }
        }
    }
}
