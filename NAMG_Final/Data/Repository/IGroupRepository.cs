using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NAMG_Final.Models;

namespace NAMG_Final.Data.Repository
{
    public interface IGroupRepository
    {
        IEnumerable<Category> GetAllCategories();
        IEnumerable<ShowGroupViewModel> GetGroupForShowCategories();
    }
}
