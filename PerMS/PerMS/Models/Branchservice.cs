using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PerMS.DBContext;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PerMS.Models;
using Microsoft.AspNetCore.Authorization;

namespace PerMS.Model
{
    public class BussinesUnitEventArgs:EventArgs
    {
        
        public int Id { get; set; }
        public string BussinesUnit_Code { get; set; }
        public string BussinesUnit_Name { get; set; }
        public int ClusterId { get; set; }
        public virtual Cluster Clusters { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual Department Departments { get; set; }

    }
    public delegate void BussinUnitAddedandUpdateEventHandler(object sender, BussinesUnitEventArgs e);
    [Authorize]
    public class Branchservice
    {
        public event BussinUnitAddedandUpdateEventHandler BranchAdded;
        public event BussinUnitAddedandUpdateEventHandler BranchUpdate;
        public event BussinUnitAddedandUpdateEventHandler BranchDelete;
        private PerMSContext _context;
        public Branchservice(PerMSContext context)
        {
            _context = context;
        }
        public async Task AddBranchAsync(BussinesUnit bussinessunit)
        {
            try
            {
                await _context.BussinesUnits.AddAsync(bussinessunit);
                await _context.SaveChangesAsync();
                OnBranchAdded(bussinessunit);
            }
            catch (Exception e)
            {
                Console.WriteLine("Branch Added");
            }
        }
        public async Task UpdateBranchAync(BussinesUnit bussinessunit)
        {
            try
            {
                _context.BussinesUnits.Update(bussinessunit);
                await _context.SaveChangesAsync();
                OnBranchUpdate(bussinessunit);
            }
            catch (Exception e)
            {
                Console.WriteLine("Branch updated");
            }
        }
        public async Task DeleteBranchAsync(BussinesUnit bussinesUnit)
        {

            _context.BussinesUnits.Remove(bussinesUnit);
            await _context.SaveChangesAsync(true);
            OnBranchDelete(bussinesUnit);
        }
        public virtual void OnBranchDelete(BussinesUnit e)
        {
            BranchDelete?.Invoke(this, new BussinesUnitEventArgs
            {
                BussinesUnit_Name = e.BussinesUnit_Name
            });
        }
        protected virtual void OnBranchAdded(BussinesUnit e)
        {
            BranchAdded?.Invoke(this, new BussinesUnitEventArgs
            {
                Id = e.Id
               
            });
        }
        protected virtual void OnBranchUpdate(BussinesUnit e)
        {
            BranchUpdate?.Invoke(this, new BussinesUnitEventArgs
            {
                Id = e.Id
            });
        }
    }
}
