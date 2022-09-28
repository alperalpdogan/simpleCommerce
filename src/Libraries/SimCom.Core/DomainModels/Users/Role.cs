﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCom.Core.DomainModels.Users
{
    public class Role : IdentityRole
    {
        public Role(string name) : base(name)
        {

        }
    }
}
