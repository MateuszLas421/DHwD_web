﻿using DHwD_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHwD_web.Data.interfaces
{
    public interface IMysteryRepo
    {
        Task<Mysterys> GetMysteryById(int id);
    }
}
