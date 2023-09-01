using Microsoft.AspNetCore.Authorization;
using System.Threading.Channels;

namespace employeeManagementAPI
{
    public class Employee
    {
        public int empNo { get; set; }
        public string empName { get; set; }
        public string empDesignation { get; set; }
        public double empSalary { get; set; }
        public bool empIsPermenant { get; set; }
        public int empDeptNo { get; set; }

        static List<Employee> empList = new List<Employee>()
        {
            new Employee(){ empNo=101, empName="Nikhil", empDesignation="Consultant", empSalary=5000, empIsPermenant=true, empDeptNo=10},
            new Employee(){ empNo=102, empName="Yash", empDesignation="Sales", empSalary=15000, empIsPermenant=true, empDeptNo=20},
            new Employee(){ empNo=103, empName="Rohan", empDesignation="Consultant", empSalary=25000, empIsPermenant=false, empDeptNo=10},
            new Employee(){ empNo=104, empName="Priti", empDesignation="Sales", empSalary=2000, empIsPermenant=true, empDeptNo=10},
            new Employee(){ empNo=105, empName="Priya", empDesignation="Consultant", empSalary=4000, empIsPermenant=true, empDeptNo=10},
            new Employee(){ empNo=106, empName="Ramesh", empDesignation="Consultant", empSalary=12000, empIsPermenant=true, empDeptNo=30},
            new Employee(){ empNo=107, empName="Suresh", empDesignation="Consultant", empSalary=11000, empIsPermenant=true, empDeptNo=20},
            new Employee(){ empNo=108, empName="Mohan", empDesignation="Sales", empSalary=56000, empIsPermenant=false, empDeptNo=20},
            new Employee(){ empNo=109, empName="Kriti", empDesignation="Consultant", empSalary=11000, empIsPermenant=true, empDeptNo=20},
            new Employee(){ empNo=110, empName="Kiran", empDesignation="Consultant", empSalary=18000, empIsPermenant=false, empDeptNo=30},
        };

        public List<Employee> GetAllEmployee()
        {
            return empList;
        }

        public Employee GetEmpById(int id)
        {
            var emp = empList.Find(e => e.empNo == id);
            if (emp != null)
            {
                return emp;
            }
            throw new Exception("Employee not found");
        }

        public List<Employee> GetEmployeeByDesignation(string desg)
        {
            var emp = empList.FindAll(e => e.empDesignation == desg);
            if (emp.Count > 0)
            {
                return emp;
            }
            throw new Exception("Sorry no employee found working as " + desg);
        }

        public int GetTotalEmployee()
        {
            return empList.Count;
        }

        public double GetTotalSalaryPaid()
        {
            var total = empList.Sum(e => e.empSalary);
            return total;
        }

        public List<Employee> GetEmployeesByDept(int deptNo)
        {
            var empbyDept = empList.FindAll(e => e.empDeptNo == deptNo);
            if (empbyDept.Count > 0)
            {
                return empbyDept;
            }
            throw new Exception("Sorry no one found working in dept no " + deptNo);
        }

        public string AddNewEmployee(Employee newEmp)
        {
            empList.Add(newEmp);
            return "Employee Added Successfully";
        }

        public string UpdateEmployee(Employee changes)
        {
            var emp = empList.Find(e => e.empNo == changes.empNo);
            if (emp != null)
            {
                emp.empName = changes.empName;
                emp.empDeptNo = changes.empDeptNo;
                emp.empDesignation = changes.empDesignation;
                emp.empSalary = changes.empSalary;
                emp.empIsPermenant = changes.empIsPermenant;
                return "Employee Details updated";
            }
            throw new Exception("Employee Not Found");
        }
        public string DeleteEmployee(int empno)
        {
            var emp = empList.Find(e => e.empNo == empno);
            if (emp != null)
            {
                empList.Remove(emp);
                return "Employee Deleted";
            }
            throw new Exception("Employee Not Found");
        }
    }
}





















