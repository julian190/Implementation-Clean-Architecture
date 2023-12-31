﻿using HR.LeaveManagment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagment.Application.Contracts.Presistance
{
    public interface ILeaveAllocationRepository:IGenericRepository<LeaveAllocation>
    {
        Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);
        Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails();
        Task<bool> AllocationExists(string userId, int LeaveTypeId, int Period);
        Task AddAllocation(List<LeaveAllocation> allocations);

        Task<LeaveAllocation> GetLeaveAllocationByUserID(string userId,int LeaveTypeId);
        Task <List<LeaveAllocation>> GetLeaveAllocationsWithDetails(string  userId);
    }
}
