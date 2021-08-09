using NAMG_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NAMG_Final.Data.Repository
{
    public class GroupRepository : IGroupRepository

    {
        private MySiteContext _context;

        public GroupRepository(MySiteContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ShowGroupViewModel> GetGroupForShowCategories()
        {
           return _context.Categories
               .Select(c => new ShowGroupViewModel()
               {
                   GroupId = c.Id,
                   name = c.Name,
                   ProductCount = _context.CategoryToProducts.Count(g => g.CategoryId == c.Id)
               }).ToList();
        }
    }
}
