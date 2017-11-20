using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoMVC.Utils
{
    public static class Utils
    {
        public static int GetInt(int? val) {
            int x = 0;
            int.TryParse("" + val, out x);
            return x;
        }
    }
}