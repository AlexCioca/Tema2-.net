using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class GradesRepository:RepositoryBase<Grade>
    {
        AppDbContext context;
        public GradesRepository(AppDbContext context):base(context)
        {
            this.context=context;
        }

        public List<Grade> GetGradesForStudent(int studentId)
        {
            var gradesForStudent = context.Grades
                .Where(data => data.StudentId == studentId)
                .OrderBy(data => data.DateCreated)
                .ToList();
            return gradesForStudent;
        }
    }
}
