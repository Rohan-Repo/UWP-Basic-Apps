using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP_Emp_Dept_App_2
{
    public class EmpData : INotifyPropertyChanged
    {
        public string empName { get; set; }

        public string empLocation { get; set; }

        public DateTime empBirthDate { get; set; }

        public String empBirthDateStr { get { return empBirthDate.ToString("yyyy/MM/dd"); }  }
        // public String empBirthDateStr { get { return empBirthDate.ToString("d"); } }

        public DateTime empHireDate { get; set; }

        public String empHireDateStr { get { return empHireDate.ToString("yyyy/MM/dd"); } }

        public string empJobTitle { get; set; }

        public string empEmailId { get; set; }

        public decimal empSalary { get; set; }

        public string deptName { get; set; }

        public string deptType { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
