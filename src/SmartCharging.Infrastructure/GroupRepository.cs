using MongoDB.Driver;
using SmartCharging.Application.Queries;
using SmartCharging.Domain;
using SmartCharging.Setup.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartCharging.Infrastructure
{
    public class GroupRepository : IGroupRepository
    {
        private readonly IMongoCollection<GroupStation> _groupCollection;

        public GroupRepository(IGroupStationDatabaseSettings groupStationDatabaseSettings)
        {
            var client = new MongoClient(groupStationDatabaseSettings.ConnectionString);
            var database = client.GetDatabase(groupStationDatabaseSettings.DatabaseName);

            _groupCollection = database.GetCollection<GroupStation>(groupStationDatabaseSettings.OrderCollectionName);
        }

        public async Task Add(GroupStation group) => await _groupCollection.InsertOneAsync(group);

        public async Task<List<GroupStation>> Get() => await _groupCollection.Find(group => true).ToListAsync();

        public async Task<GroupStation> GetGroupById(string id) => await _groupCollection.Find<GroupStation>(group => group.Id == id).FirstOrDefaultAsync();

        public async Task Update(string id, GroupStation groupIn)
        {
            await _groupCollection.ReplaceOneAsync<GroupStation>(g => g.Id == id, groupIn);
        }

        public async Task Delete(GroupStation group)
        {
            await _groupCollection.DeleteOneAsync(order => order.Id == group.Id);
        }

        public async Task DeleteById(string id) => await _groupCollection.DeleteOneAsync(orderIn => orderIn.Id == id);

        public async Task<List<ChargeStation>> GetChargeStationById(string id)
        {
            var filter = Builders<GroupStation>.Filter.ElemMatch(x => x.ChargeStations, d => d.Id == id);

            var group = await _groupCollection.Find<GroupStation>(filter).FirstOrDefaultAsync();

            return group.ChargeStations;
        }
    }
}
