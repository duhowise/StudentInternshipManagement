﻿using System.Threading.Tasks;
using Models;
using Models.Entities;

namespace Services.Interfaces
{
    public interface ISemesterService:IGenericService<Semester>
    {
        Semester GetLatest();
        Task<Semester> GetLatestAsync();
    }
}