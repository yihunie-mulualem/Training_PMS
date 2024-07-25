using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PerMS.DBContext;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PerMS.Models;

namespace PerMS.Model
{
    public class EmployeeEventArgs : EventArgs

    { 

            public int Id { get; set; }

    public int MainID { get; set; }
    public string Employee_FullName { get; set; }
    public string Employee_Gender { get; set; }
    public string Employee_EmploymentType { get; set; }
    public string Employee_EmployeeStatus { get; set; }


    public int Employee_GradeLevel { get; set; }
    public string Employee_Remark { get; set; }
    public string Employee_CreatedBy { get; set; }
    public DateTime Employee_DateCreated { get; set; }
    public bool Employee_Active { get; set; }
    public DateTime Employee_ContractExpiryDate { get; set; }
    public int JobPositionId { get; set; }
    public virtual JobPosition JobPosition { get; set; }
    public int BussinesUnitId { get; set; }
    public virtual BussinesUnit BussinesUnit { get; set; }
    public int DepartmentId { get; set; }
    public virtual Department Department { get; set; }

    [ForeignKey("HierarchyGroup")]
    public int HierarchyGroupId { get; set; }
    public virtual HierarchyGroup HierarchyGroup { get; set; }

}
    public delegate void EmployeeAddedandUpdateEventHandler(object sender, EmployeeEventArgs e);
    public class EmployeeService
    {
        public event EmployeeAddedandUpdateEventHandler EmployeeAdded;
        public event EmployeeAddedandUpdateEventHandler EmployeeUpdate;
        public event EmployeeAddedandUpdateEventHandler EmployeeDelete;
        private PerMSContext _context;
        public EmployeeService(PerMSContext context)
        {
            _context = context;
        }
        public async Task AddEmployeeAsync(Employee employee)
        {
            try
            {
                await _context.Employees.AddAsync(employee);
                await _context.SaveChangesAsync();
              //  OnEmployeeAdded(employee);
                OnEmployeeAdded(employee);

                // return JsonResult("Inserted succssfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("Trainee Added");
            }
        }
        public async Task UpdateEmployeeAync(Employee employee)
        {
            try
            {
                 _context.Employees.Update(employee);
                await _context.SaveChangesAsync();
                OnEmployeeUpdate(employee);
            }
            catch (Exception e)
            {
                Console.WriteLine("Trainee Added");
            }
        }
        public async Task DeleteEmployeeAsync(Employee Employee)
        {

            _context.Employees.Remove(Employee);
           await _context.SaveChangesAsync(true);
            OnEmployeeDelete(Employee);
        }
        public virtual void OnEmployeeDelete(Employee e)
        {
            EmployeeDelete?.Invoke(this, new EmployeeEventArgs
            {
                Employee_FullName=e.Employee_FullName
            });
        }
        protected virtual void OnEmployeeAdded(Employee e)
        {
            EmployeeAdded?.Invoke(this, new EmployeeEventArgs
            {
                Id = e.Id

            });
        }
        protected virtual void OnEmployeeUpdate(Employee e)
        {
            EmployeeUpdate?.Invoke(this, new EmployeeEventArgs
            {
                Id = e.Id

            });
        }
    }
}
