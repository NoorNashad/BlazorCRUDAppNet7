using Blazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Shared.Services
{
    public interface IStudentServices
    {
        public IEnumerable<StudentEntity> GetAllStudent();
        public void AddStudent(StudentEntity student);
        public void UpdateStudent(StudentEntity student);
        public void DeleteStudent(int? StudentID);

    }
}
