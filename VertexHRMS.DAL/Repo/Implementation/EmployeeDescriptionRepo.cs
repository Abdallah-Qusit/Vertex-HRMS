 ﻿namespace VertexHRMS.DAL.Repo.Implementation
{
 public class EmployeeDescriptionRepo : IEmployeeDescriptionRepo
    {
        private readonly VertexHRMSDbContext Db;
        public EmployeeDescriptionRepo(VertexHRMSDbContext db)
        {
             Db = db;
        }
        public Employee GetByEmployeeId(int EmployeeId)
        {
                 var result = Db.Employees.Include(e=> e.Department).Include(e=>e.Payrolls).Include(e=>e.Position) .FirstOrDefault(e => e.EmployeeId == EmployeeId);
                return (result);
           
        }

    }
}

