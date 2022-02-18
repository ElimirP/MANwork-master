using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coursework2.Data.Interfaces;
using Coursework2.Data.Models;
using MANwork.Data;

namespace Coursework2.Data.Repository
{
    public class UsersRepository : IUsers
    {
        private readonly AppDbContent AppDBContent;

        public UsersRepository(AppDbContent AppDBContent)
        {
            this.AppDBContent = AppDBContent;
        }

        public IEnumerable<Users> AllUsers => AppDBContent.Users;
    }
}
