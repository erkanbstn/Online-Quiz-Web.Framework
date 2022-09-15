using OnlineTest.UI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTest.UI.Models.ViewModels
{
    public class UnitTest
    {
        public User User { get; set; }
        public ICollection<User> Users { get; set; }
        public Ask Ask { get; set; }
        public ICollection<Ask> Asks { get; set; }
        public Answer Answer { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}