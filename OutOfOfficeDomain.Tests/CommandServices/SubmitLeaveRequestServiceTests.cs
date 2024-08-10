using OutOfOfficeDomain.Commands;
using OutOfOfficeDomain.CommandServices;
using OutOfOfficeDomain.Events;
using OutOfOfficeDomain.Tests.Fakes;

namespace OutOfOfficeDomain.Tests.CommandServices
{
    public class SubmitLeaveRequestServiceTests
    {
        [Test]
        public void CreateWithNullRepositoryWillThrow()
        {
            // Act
            TestDelegate action = () => new SubmitLeaveRequestService(
                repository: null,
                handler: new StubEventHandler<LeaveRequestSubmitted>());

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [Test]
        public void LeaveRequestChangeStatusOnSubmit()
        {
            var repository = new StubLeaveRequestRepository();
            var commandService = new SubmitLeaveRequestService(
              repository: repository,
              handler: new StubEventHandler<LeaveRequestSubmitted>());
            LeaveRequest leaveRequest = new LeaveRequest() { Id = Guid.NewGuid() };
            repository.Save(leaveRequest);

            commandService.Execute(new SubmitLeaveRequest()
            {
                LeaveRequestId = leaveRequest.Id
            });

            Assert.IsTrue(leaveRequest.Status == LeaveRequestStatus.SUBMITTED);
        }

        [Test]
        public void Execute_ShouldHandleLeaveRequestSubmittedEvent()
        {
            // Arrange
            var repository = new StubLeaveRequestRepository();

            var handler = new SpyEventHandler<LeaveRequestSubmitted>();
            var commandService = new SubmitLeaveRequestService(
             repository: repository,
             handler: handler
            );

            var leaveRequestId = Guid.NewGuid();
            LeaveRequest leaveRequest = new LeaveRequest() { Id = leaveRequestId };
            repository.Save(leaveRequest);
            var command = new SubmitLeaveRequest { LeaveRequestId = leaveRequestId }; // Create a command with the ID
            var expectedEvent = new { LeaveRequestId = leaveRequestId };

            // Act
            commandService.Execute(command);

            // Assert
            Assert.That(
               new { handler.HandledEvent.LeaveRequestId }, Is.EqualTo(expectedEvent));

        }


    }
}
