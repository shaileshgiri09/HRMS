using HRMS.Domain.Context;
using HRMS.Domain.Entities;
using HRMS.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Infrastructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HRMSDbContext _context;
        public EmployeeRepository(HRMSDbContext context)
        {
            _context = context;
        }
        public async Task<int> LeaveApplication(Leave leave)
        {
            await _context.leaves.AddAsync(leave);
            return await _context.SaveChangesAsync();
        }
    }
}
