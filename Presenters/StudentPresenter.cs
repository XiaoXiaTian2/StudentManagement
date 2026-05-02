using StudentManagement.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StudentManagement.Contracts.StudentContract;

namespace StudentManagement.Presenters
{
    internal class StudentPresenter : IStudentPresenter
    {
        IStudentView _view = null;

        public List<StudentDTO> students { get; set; } = new List<StudentDTO>();

        public StudentPresenter(IStudentView view)
        {
            _view = view;
        }

        public void AddStudent(string name, string age, string height, string weight)
        {
            StudentDTO dto = new StudentDTO()
            {
                Name = name,
                Age = int.Parse(age),
                Height = float.Parse(height),
                Weight = float.Parse(weight)
            };
            this.students.Add(dto);
            this._view.OnAddStudent(students);
        }

        public void DeleteStudent(Student student)
        {
            this.students.Remove(this.students.First(x => x.Id == student.Id));
            this._view.OnDeleteStudent(students);
        }

        public void EditStudent(Student student)
        {
            this._view.OnEditStudent(student);
        }

        public void SaveStudent(Student student)
        {
            this._view.OnSaveStudent(student);
        }
    }
}
