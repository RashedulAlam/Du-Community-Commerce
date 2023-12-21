using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DU_Community_Commerce_Server_Side.Application_Context;
using DU_Community_Commerce_Server_Side.Models;

namespace DU_Community_Commerce_Server_Side.Repositories
{
    public class SearchItemRepository : ISearchRepository
    {
        private readonly ApplicationContext _applicationContext;

        public SearchItemRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public void Insert(SearchItem searchItem)
        {
            _applicationContext.SearchItems.Add(searchItem);
            Save();
        }

        public void Save()
        {
            _applicationContext.SaveChanges();
        }
    }
}