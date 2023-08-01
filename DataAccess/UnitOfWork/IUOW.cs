﻿using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public interface IUOW
    {
        IRepository<T> GetRepository<T>() where T : class;
        Task SaveChangesAsync();
    }
}
