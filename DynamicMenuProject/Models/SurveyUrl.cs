using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicMenuProject.Models
{
    public class SurveyUrl
    {
        public int Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Url { get; set; }
        public string EncryptUrl { get; set; }
    }
}
