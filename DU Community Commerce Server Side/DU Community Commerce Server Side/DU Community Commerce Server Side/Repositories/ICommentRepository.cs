using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DU_Community_Commerce_Server_Side.Models;

namespace DU_Community_Commerce_Server_Side.Repositories
{
    interface ICommentRepository
    {
        IEnumerable<Comment> GetAllComments(string productId);
        void Insert(Comment comment);
        void Save();
    }
}
