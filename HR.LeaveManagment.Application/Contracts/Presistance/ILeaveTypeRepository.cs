﻿using HR.LeaveManagment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagment.Application.Contracts.Presistance
{
    public interface ILeaveTypeRepository:IGenericRepository<LeaveType>
    {
        
    }
}
