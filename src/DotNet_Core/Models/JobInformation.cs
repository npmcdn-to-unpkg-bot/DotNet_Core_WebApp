using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bristrong.Official.WebService.Models
{
    public class JobInformation
    {
        public int Id { get; set; }
        public string Job { get; set; }
        public int Count { get; set; }
        public List<string> Duty { get; set; }
        public List<string> Requirements { get; set; }
        public string Salary { get; set; }
    }
}
