using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace employeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        Employee empObj = new Employee(); //this is not good, we should use DI instead

        #region Get Methods
        [HttpGet]
        [Route("/employee/list")]
        public IActionResult GetAllEmployees()
        {
            var emp = empObj.GetAllEmployee();
            return Ok(emp);
        }
        [HttpGet]
        [Route("/employee/empno/{id}")]
        public IActionResult GetEmpById(int id)
        {
            try
            {
                var emp = empObj.GetEmpById(id);
                return Ok(emp);
            }
            catch (Exception es)
            {

                return NotFound(es.Message);
            }
        }
        [HttpGet]
        [Route("/employee/deptno/{deptno}")]
        public IActionResult GetEmpByDept(int deptno)
        {
            try
            {
                var emp = empObj.GetEmployeesByDept(deptno);
                return Ok(emp);
            }
            catch (Exception es)
            {

                return NotFound(es.Message);
            }
        }
        [HttpGet]
        [Route("/employee/designation/{designation}")]
        public IActionResult GetEmployeeByDesignation(string designation)
        {
            try
            {
                var emp = empObj.GetEmployeeByDesignation(designation);
                return Ok(emp);
            }
            catch (Exception es)
            {

                return NotFound(es.Message);
            }
        }
        [HttpGet]
        [Route("/employee/total")]
        public IActionResult GetTotalEmployees()
        {
            var emp = empObj.GetTotalEmployee();
            return Ok(emp);
        }
        [HttpGet]
        [Route("/employee/totalsalary")]
        public IActionResult GetTotalSalaryPaid()
        {
            var emp = empObj.GetTotalSalaryPaid();
            return Ok(emp);
        }
        #endregion

        #region Add, update and Delete
        [HttpPost]
        [Route("/employee/add")]
        public IActionResult AddNewEmployee([FromBody]Employee newEmp)
        {
            var addMessage = empObj.AddNewEmployee(newEmp);
            return Created("", addMessage);
        }

        [HttpPut]
        [Route("/employee/edit")]
        public IActionResult UpdateEmployee([FromBody] Employee changes)
        {
            try
            {
                var updatMessage = empObj.UpdateEmployee(changes);
                return Accepted(updatMessage);
            }
            catch (Exception es)
            {

                return NotFound(es.Message);
            }
        }
        [HttpDelete]
        [Route("/employee/delete/{empno}")]
        public IActionResult DeleteEmployee(int empno)
        {
            try
            {
                var deleteMessage = empObj.DeleteEmployee(empno);
                return Accepted(deleteMessage);
            }
            catch (Exception es)
            {

                return NotFound(es.Message);
            }
        }

        #endregion
    }
}






