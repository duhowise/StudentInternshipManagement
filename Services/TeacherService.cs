﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Repositories;

namespace Services
{
    public class TeacherService
    {
        private readonly TeacherRepository _repository=new TeacherRepository();

        public Teacher GetById(string id)
        {
            return _repository.GetById(id);
        }

        public bool Add(Teacher teacher)
        {
            return _repository.Add(teacher);
        }

        public bool Update(Teacher teacher)
        {
            return _repository.Update(teacher);
        }

        public bool Delete(Teacher teacher)
        {
            return _repository.Delete(teacher);
        }

    }
}