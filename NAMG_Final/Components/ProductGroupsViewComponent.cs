using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NAMG_Final.Data;
using NAMG_Final.Data.Repository;
using NAMG_Final.Models;

namespace NAMG_Final.Components
{
    public class ProductGroupsViewComponent:ViewComponent
    {
        private IGroupRepository _groupRepository;

        public ProductGroupsViewComponent(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Views/Components/ProductGroupsViewComponent.cshtml", _groupRepository.GetGroupForShowCategories());
        }
    }
}
