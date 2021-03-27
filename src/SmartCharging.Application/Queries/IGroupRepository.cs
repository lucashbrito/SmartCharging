using SmartCharging.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCharging.Application.Queries
{
    public interface IGroupRepository
    {
        Task Add(GroupStation group);
        Task<List<GroupStation>> Get();
        Task<GroupStation> GetGroupById(string id);
        Task Update(string id, GroupStation groupIn);
        Task Delete(GroupStation group);
        Task DeleteById(string id);        
        Task<List<ChargeStation>> GetChargeStationById(string id);
    }
}
