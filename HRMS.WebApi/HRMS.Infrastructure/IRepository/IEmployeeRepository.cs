using HRMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Infrastructure.IRepository
{
    public interface IEmployeeRepository
    {
        Task<int> LeaveApplication(Leave leave);
    }
}
