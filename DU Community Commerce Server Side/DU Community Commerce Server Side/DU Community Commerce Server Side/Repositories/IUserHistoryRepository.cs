using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DU_Community_Commerce_Server_Side.Models;

namespace DU_Community_Commerce_Server_Side.Repositories
{
    interface IUserHistoryRepository
    {
        void Insert(UserHistory userHistory);
        IEnumerable<UserHistory> GetAllHistory(string userId);
        void Save();
    }
}
