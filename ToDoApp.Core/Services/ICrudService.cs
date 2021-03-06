﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Core.Services
{
    public interface ICrudService<TEntity>
    {

        //READ:
        IQueryable<TEntity> GetEntities { get; }


        //CREATE, UPDATE, DELETE:
        Task<bool> CreateAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);


    }
}
