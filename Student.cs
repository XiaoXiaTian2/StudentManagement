using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StudentManagement
{
    internal class Student : INotifyPropertyChanged
    {
        // HW fody onpropertychanged
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand ToggleCommand { get; set; }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public float Height { get; set; }
        private float _weight;
        public float Weight
        {
            get => _weight;
            set
            {
                _weight = value;
                OnPropertyChange(nameof(Weight));
            }
        }

        private bool _isCompleted;

        public bool IsCompleted
        {
            get => _isCompleted;
            set
            {
                if (_isCompleted != value)
                {
                    _isCompleted = value;
                    OnPropertyChange(nameof(IsCompleted));
                    OnPropertyChange(nameof(IsDeletable));
                }
            }
        }

        public bool IsDeletable
        {
            get => _isCompleted;
        }

        private Visibility _isCollapsed = Visibility.Collapsed;
        public Visibility Collapsed
        {
            get => _isCollapsed;
            set
            {
                //if (_isCollapsed != value)
                //{
                _isCollapsed = value;
                //}
            }
        }

        private bool _isSavable = false;
        public bool IsSavable
        {
            get => _isSavable;
            set
            {
                if (_isSavable != value)
                {
                    _isSavable = value;
                    OnPropertyChange(nameof(IsSavable));
                    OnPropertyChange(nameof(Collapsed));
                }
            }
        }

        private bool _isEditable = true;

        public bool IsEditable
        {
            get => _isEditable;
            set
            {
                if (_isEditable != value)
                {
                    _isEditable = value;
                    OnPropertyChange(nameof(IsEditable));
                    //OnPropertyChange(nameof(Collapsed));
                }
            }
        }

        public Student(string name, int age, float height, float weight)
        {
            Name = name;
            Age = age;
            Height = height;
            Weight = weight;
            this.ToggleCommand = new RelayCommand<Student>(x => x.IsCompleted = !x.IsCompleted);
        }

        private void OnPropertyChange(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
