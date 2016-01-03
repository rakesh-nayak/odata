using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductService.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string WorkLevel { get; set; }
        //public ICollection<Skill> Skills { get; set; }
    }
}