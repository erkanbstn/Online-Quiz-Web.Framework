using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace OnlineTest.UI.Models.Entities
{
    public class Answer : BaseEntity
    {
        public string Content { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public Ask Ask { get; set; }
        public int AskID { get; set; }
    }
}