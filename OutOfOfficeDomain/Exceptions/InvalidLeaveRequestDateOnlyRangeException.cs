namespace OutOfOfficeDomain.Exceptions
{
    public class InvalidLeaveRequestDateOnlyRangeException : Exception
    {
        public LeaveRequest LeaveRequest { get; }

        public InvalidLeaveRequestDateOnlyRangeException(LeaveRequest leaveRequest)
        {
            LeaveRequest = leaveRequest;
        }
    }
}
