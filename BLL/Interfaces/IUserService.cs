﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        void AddingUser(string email, string password, string firstName, string lastName, string role);
        void DeleteUser(string email);
    }
}
