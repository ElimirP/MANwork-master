using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MANwork.Data;

namespace Coursework2.Data
{
    public class DbObjects
    {
        public static void updates(AppDbContent content, int idd, bool fg)
        {
            content.SaveChanges();
        }
    }
}
