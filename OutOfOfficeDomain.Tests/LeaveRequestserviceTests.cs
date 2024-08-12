namespace OutOfOfficeDomain.Tests
{
    public partial class LeaveRequestServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void GetAllWillReturnInstance()
        {
            // Arrange
            var service = new LeaveRequestService(new StubLeaveRequestRepository());

            // Act
            var result = service.GetAll();

            // Assert
            Assert.NotNull(result);
        }
    }
}
