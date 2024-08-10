namespace OutOfOfficeDomain.Events
{
    public class LeaveRequestSubmitted
    {

        public readonly Guid LeaveRequestId;

        public LeaveRequestSubmitted(Guid leaveRequestId)
        {
            this.LeaveRequestId = leaveRequestId;
        }

    }
}
