﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Utilities;

namespace Repositories
{
    public class TeacherRepository : IDisposable
    {
        private readonly ApplicationDbContext _context=new ApplicationDbContext();

        public IQueryable<Teacher> GetAll()
        {
            try
            {
                return _context.Teachers;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return null;
            }
        }
        public Teacher GetById(string id)
        {
            try
            {
                return _context.Teachers.FirstOrDefault(s => s.TeacherId.Equals(id));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return null;
            }
        }

        public bool Add(Teacher teacher)
        {
            try
            {
                _context.Teachers.Add(teacher);
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return false;
            }
        }

        public bool Update(Teacher teacher)
        {
            try
            {
                _context.Entry(teacher).State = EntityState.Modified;
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return false;
            }
        }

        public bool Delete(Teacher teacher)
        {
            var curr = GetById(teacher.TeacherId);
            if (curr == null)
                return false;

            try
            {
                _context.Teachers.Remove(curr);
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return false;
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
