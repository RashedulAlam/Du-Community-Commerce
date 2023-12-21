using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DU_Community_Commerce_Server_Side.Application_Context;
using DU_Community_Commerce_Server_Side.Models;

namespace DU_Community_Commerce_Server_Side.Repositories
{
    public class UserHistoryRepository : IUserHistoryRepository
    {
        private readonly ApplicationContext _applicationContext;

        public UserHistoryRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public void Insert(UserHistory userHistory)
        {
            _applicationContext.UserHistories.Add(userHistory);
            Save();
        }

        public IEnumerable<UserHistory> GetAllHistory(string userId)
        {
            var query = (from history in _applicationContext.UserHistories
                where history.UserId == userId
                select history).ToList();
            return query;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
        private bool _disposed = false;

        

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _applicationContext.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}