using PropertyChanged;
using StudentManagement.DTOs;
using StudentManagement.Presenters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static StudentManagement.Contracts.StudentContract;

namespace StudentManagement
{
    [AddINotifyPropertyChangedInterface]
    internal class MainViewModel : IStudentView
    {
        //private string _name;

        public string Name { get; set; }
        //private string _age;
        public string Age { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }

        public ObservableCollection<Student> students { get; set; }

        public ICommand AddStudentCommand { get; set; }

        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        public MainViewModel()
        {
            IStudentPresenter presenter = new StudentPresenter(this);
            this.AddStudentCommand = new RelayCommand(() =>
            {
                presenter.AddStudent(Name, Age, Height, Weight);
            });
            this.DeleteCommand = new RelayCommand<Student>(presenter.DeleteStudent);
            this.EditCommand = new RelayCommand<Student>(presenter.EditStudent);
            this.SaveCommand = new RelayCommand<Student>(presenter.SaveStudent);
        }

        public void OnAddStudent(List<StudentDTO> dtos)
        {
            List<Student> students = dtos.Select(d => new Student(d.Name, d.Age, d.Height, d.Height)).ToList();
            this.students = new ObservableCollection<Student>(students);
        }

        public void OnDeleteStudent(List<StudentDTO> dtos)
        {
            List<Student> students = dtos.Select(d => new Student(d.Name, d.Age, d.Height, d.Height)).ToList();
            this.students = new ObservableCollection<Student>(students);
        }

        //private void OnPropertyChange(string propertyName)
        //{
        //    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        public void OnEditStudent(Student std)
        {
            std.IsEditable = false;
            std.IsSavable = true;
            //std.Collapsed = System.Windows.Visibility.Visible;
        }

        public void OnSaveStudent(Student std)
        {
            std.IsEditable = true;
            std.IsSavable = false;
        }
    }
}
