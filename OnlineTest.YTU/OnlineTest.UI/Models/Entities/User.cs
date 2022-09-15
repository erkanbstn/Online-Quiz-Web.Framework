using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTest.UI.Models.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Status{ get; set; }
        public string Role{ get; set; }
    }
}