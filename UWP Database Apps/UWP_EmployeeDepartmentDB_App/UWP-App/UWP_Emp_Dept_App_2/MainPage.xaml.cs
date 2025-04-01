using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP_Emp_Dept_App_2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            empListView.ItemsSource = getEmpData((App.Current as App).ConnectionString);
        }

        public ObservableCollection<EmpData> getEmpData(string connectionString)
        {
            const string getEmpDataQuery = "SELECT CONCAT( empFirstName, ' ', empLastName ) AS empName, CONCAT( empCity, ' , ', empCountry ) AS empLocation, empBirthDate, empHireDate, empJobTitle, empEmailId, empSalary, deptName, deptType FROM Employee JOIN Department ON Employee.empDept = Department.deptId ORDER BY empSalary DESC";

            var employees = new ObservableCollection<EmpData>();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = getEmpDataQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var emp = new EmpData();
                                    
                                    emp.empName = reader.GetString(0); ;
                                    emp.empLocation = reader.GetString(1);
                                    emp.empBirthDate = reader.GetDateTime(2);
                                    emp.empHireDate = reader.GetDateTime(3);
                                    emp.empJobTitle = reader.GetString(4);
                                    emp.empEmailId = reader.GetString(5);
                                    emp.empSalary = reader.GetDecimal(6);
                                    emp.deptName = reader.GetString(7);
                                    emp.deptType = reader.GetString(8);

                                    employees.Add(emp);
                                }
                            }
                        }
                    }
                }
                //foreach (var emp in employees)
                //{
                //    Debug.WriteLine($"emp: {emp.empName} {emp.deptName}");
                //}
                return employees;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine($"Exception: {eSql.Message}");
            }
            return null;
        }
    }
}
