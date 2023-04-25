using Core.Dtos;
using DataLayer;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class GradeService
    {
        private readonly UnitOfWork unitOfWork;

        public GradeService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;   
        }

        public GradeAddDto AddGrade(GradeAddDto newGrade)
        {


            var grade = new Grade
            {
                Course = newGrade.Course,
                DateCreated = newGrade.DateCreated,
                StudentId = newGrade.StudentId,
                Value=newGrade.Value
            };
            unitOfWork.Grades.Insert(grade);
            unitOfWork.SaveChanges();
            return newGrade;

        }

        public ICollection<Grade> GetStudentGradesOrdered(int studentId)
        {

            var grades=unitOfWork.Grades.GetGradesForStudent(studentId);

            return grades;

        }


    }
}
