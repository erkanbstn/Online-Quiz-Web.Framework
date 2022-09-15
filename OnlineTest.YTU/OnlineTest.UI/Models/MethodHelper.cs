using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTest.UI.Models
{
    public class MethodHelper
    {
        public  bool CorrectControl(int correct, int incorrect)
        {
            if (correct > incorrect)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}