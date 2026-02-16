namespace WebApp.Repository
{
    public class TestService : ITestService
    {
        public string Id { get; set; }
        public TestService()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
