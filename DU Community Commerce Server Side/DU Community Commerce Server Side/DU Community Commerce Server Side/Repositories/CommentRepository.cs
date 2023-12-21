using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DU_Community_Commerce_Server_Side.Application_Context;
using DU_Community_Commerce_Server_Side.Models;

namespace DU_Community_Commerce_Server_Side.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationContext _applicationContext;

        public CommentRepository( ApplicationContext applicationContext1)
        {
            _applicationContext = applicationContext1;
        }

        public IEnumerable<Comment> GetAllComments(string productId)
        {
            var query = (from comment in _applicationContext.Comments
                where comment.ProductId == productId
                select comment).ToList();
            return query;
        }

        public void Insert(Comment comment)
        {
            _applicationContext.Comments.Add(comment);
            Save();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}