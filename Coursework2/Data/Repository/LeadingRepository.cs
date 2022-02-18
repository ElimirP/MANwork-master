using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coursework2.Data.Interfaces;
using Coursework2.Data.Models;
using MANwork.Data;

namespace Coursework2.Data.Repository
{
    public class LeadingRepository : ILeading
    {

        private readonly AppDbContent AppDBContent;

        public LeadingRepository(AppDbContent AppDBContent)
        {
            this.AppDBContent = AppDBContent;
        }

        public IEnumerable<Leading> AllLeadings => AppDBContent.Leading;
    }
}
