using DataLayer.Entities;
using DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class GradeAddDto
    {
        public double Value { get; set; }
        public CourseType Course { get; set; }
        public int StudentId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
