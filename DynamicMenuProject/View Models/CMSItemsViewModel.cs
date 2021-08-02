using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicMenuProject.View_Models
{
    public class CMSItemsViewModel
    {
        public int Id { get; set; }
        public string PageName { get; set; }
        public string PageUrl { get; set; }
        public string Description { get; set; }
        public string BannerImage { get; set; }
        public IFormFile BannerImageFile { get; set; }
    }
}
