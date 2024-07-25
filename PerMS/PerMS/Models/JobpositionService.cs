using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PerMS.DBContext;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PerMS.Models;

namespace PerMS.Model
{
    public class JobPositionEventArgs : EventArgs

    {
        public int Id { get; set; }
        public string JobPosition_Code { get; set; }
        public string JobPosition_Title { get; set; }
        public int JobPosition_Grade { get; set; }
        public int JobPosition_Category { get; set; }
        public string JobPosition_CreatedBy { get; set; }
        public string JobPosition_DateCreated { get; set; }
        public ICollection<Employee> Employees { get; set; }


    }
    public delegate void JobPositionAddedandUpdateEventHandler(object sender, JobPositionEventArgs e);
    public class JobpositionService
    {
        public event JobPositionAddedandUpdateEventHandler JobPositionAdded;
        public event JobPositionAddedandUpdateEventHandler JobPositionUpdate;
        public event JobPositionAddedandUpdateEventHandler JobPositionDelete;
        private PerMSContext _context;
        public JobpositionService(PerMSContext context)
        {
            _context = context;
        }
        public async Task AddJobPositionAsync(JobPosition jobposition)
        {
            try
            {
                await _context.JobPositions.AddAsync(jobposition);
                await _context.SaveChangesAsync();
                //  OnEmployeeAdded(employee);
                OnJobPositionAdded(jobposition);

                // return JsonResult("Inserted succssfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("Trainee Added");
            }
        }
        public async Task UpdateJobPositionAync(JobPosition jobPosition)
        {
            try
            {
                _context.JobPositions.Update(jobPosition);
                await _context.SaveChangesAsync();
                OnJobPositionUpdate(jobPosition);
            }
            catch (Exception e)
            {
                Console.WriteLine("Job position Added");
            }
        }
        public async Task DeleteJobPositionAsync(JobPosition jobPosition)
        {
            _context.JobPositions.Remove(jobPosition);
            await _context.SaveChangesAsync(true);
            OnJobPositionDelete(jobPosition);
        }
        public virtual void OnJobPositionDelete(JobPosition e)
        {
            JobPositionDelete?.Invoke(this, new JobPositionEventArgs
            {
               JobPosition_Code = e.JobPosition_Code
            });
        }
        protected virtual void OnJobPositionAdded(JobPosition e)
        {
            JobPositionAdded?.Invoke(this, new JobPositionEventArgs
            {
                Id = e.Id

            });
        }
        protected virtual void OnJobPositionUpdate(JobPosition e)
        {
           JobPositionUpdate?.Invoke(this, new JobPositionEventArgs
            {
                Id = e.Id

            });
        }
    }
}
