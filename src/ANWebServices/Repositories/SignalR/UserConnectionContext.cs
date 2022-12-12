﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Amnhac.Interfaces;
using Amnhac.Models;
using System.Linq.Expressions;

namespace Amnhac.Repositories
{
    public class UserConnectionContext : IRepository<UserConnection>
    {
        private readonly DataAccess<UserConnection> _dao = null;
        public UserConnectionContext(IOptions<DbSettings> settings)
        {
            _dao = new DataAccess<UserConnection>(settings);
            _dao.Context = "UserConnection";
        }
        public async Task<List<UserConnection>> Find(Expression<Func<UserConnection, bool>> filter)
        {
            try
            {
                return await _dao.obj.Find(filter).ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<UserConnection>> Find(Expression<Func<UserConnection, bool>> filter, int limit, int offset)
        {
            try
            {
                return await _dao.obj.Find(filter).Skip(offset).Limit(limit).ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        


        public async Task<List<UserConnection>> GetAllAsync()
        {
            try
            {
                return await _dao.obj.Find(_ => true).ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<UserConnection>> GetAll(int limit, int offset)
        {
            try
            {
                return await _dao.obj.Find(_ => true).Skip(offset).Limit(limit).ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<UserConnection> GetById(string id)
        {
            var filter = Builders<UserConnection>.Filter.Eq(x=>x.Id, id);
            try
            {
                return await _dao.obj.Find(filter).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> Insert(UserConnection obj)
        {
            try
            {
                await _dao.obj.InsertOneAsync(obj);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> Update(string id, UserConnection obj)
        {
            var filter = Builders<UserConnection>.Filter.Eq(x=>x.Id, id);
            var target = Builders<UserConnection>.Update
                .Set(s => s.Connections, obj.Connections);
            try
            {
                UpdateResult result = await _dao.obj.UpdateOneAsync(filter, target);
                return result.IsAcknowledged && result.ModifiedCount > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> Delete(string id)
        {
            var filter = Builders<UserConnection>.Filter.Eq(x=>x.Id, id);
            try
            {
                DeleteResult result = await _dao.obj.DeleteOneAsync(filter);
                return result.IsAcknowledged && result.DeletedCount > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<long> CountAll()
        {
            try
            {
                long result = await _dao.obj.CountDocumentsAsync(_ => true);
                return result;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public async Task<long> CountIf(Expression<Func<UserConnection, bool>> filter)
        {
            try
            {
                long result = await _dao.obj.CountDocumentsAsync(filter);
                return result;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
