﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeDomain
{
    public interface ILeaveRequestRepository
    {
        public IEnumerable<LeaveRequest> GetCurrentLeaveRequests();
        public void CreateLeaveRequest(LeaveRequest leaveRequest);

        public void DeleteById(Guid id);
    }
}
