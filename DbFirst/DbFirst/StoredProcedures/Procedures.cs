using DbFirst.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbFirst.StoredProcedures
{
    public class Procedures
    {
        private readonly PlutoContext _context;

        public Procedures(PlutoContext context)
        {
            _context = context;
        }

        //calling a store procedures 
        public List<Courses> GetAll()
        {
            return _context.Courses.FromSqlRaw<Courses>("GetCourses")
                .ToList();
        }

        //NE RADI
        public void DeleteCourse(int courseId)
        {          
              _context.Courses.FromSqlRaw<Courses>("DeleteCourse {0}", courseId)
                .AsEnumerable<Courses>()
                .FirstOrDefault();
        }
    }
}
