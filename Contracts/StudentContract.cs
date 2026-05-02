using StudentManagement.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Contracts
{
    internal class StudentContract
    {
        public interface IStudentPresenter
        {
            void AddStudent(string name, string age, string height, string weight);
            void DeleteStudent(Student student);
            void EditStudent(Student student);
            void SaveStudent(Student student);
        }

        public interface IStudentView
        {
            // 取得資料的Callback
            void OnAddStudent(List<StudentDTO> dtos);
            void OnDeleteStudent(List<StudentDTO> dtos);
            void OnEditStudent(Student std);
            void OnSaveStudent(Student std);
        }
    }
}
