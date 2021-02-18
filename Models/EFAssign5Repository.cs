﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DallinCollinsAssignment5.Models
{
    public class EFAssign5Repository : Assign5Repository
    {
        private Assignment5DBContext _context;

        //my constructor
        public EFAssign5Repository (Assignment5DBContext context)
        {
            _context = context;
        }

        public IQueryable<Project> Projects => _context.Projects;
    }
}
