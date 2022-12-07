﻿using SR39_2021_pop2022_2.Models;
using SR39_2021_POP2022_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR39_2021_pop2022_2.Repositories
{
    interface IProfessorRepository
    {
        List<Professor> GetAll();
        Professor GetById(string email);
        void Add(Professor professor);
        void Add(List<Professor> professors);
        void Set(List<Professor> professors);
        void Update(string email, Professor professor);
        void Delete(string email);

    }
}
