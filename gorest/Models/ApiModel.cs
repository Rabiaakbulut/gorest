using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gorest.Models
{
    public class ApiModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string status { get; set; }
    }
}