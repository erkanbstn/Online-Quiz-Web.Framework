using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTest.UI.Models.Entities
{
    public class Ask : BaseEntity
    {
        public string Content { get; set; }
        public string Correct { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}