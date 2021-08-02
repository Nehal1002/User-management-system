using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DynamicMenuProject.Models
{
    public partial class CMSItems
    {
        [Key]
        public int Id { get; set; }
        public string PageName { get; set; }
        public string PageUrl { get; set; }
        public string Description { get; set; }
        public string BannerImage { get; set; }
    }
}
