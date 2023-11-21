using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using hr_webapi.Controllers;
using hr_webapi.Models;

[TestFixture]
public class EmployeeControllerTests
{
    private EmployeeController? _employeeController;
    private Mock<IAppDbContext>? _mockDbContext;


    public class TestAsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> _innerEnumerator;
        public TestAsyncEnumerator(IEnumerator<T> innerEnumerator)
        {
            _innerEnumerator = innerEnumerator;
        }
        public ValueTask<bool> MoveNextAsync() => new ValueTask<bool>(_innerEnumerator.MoveNext());
        public T Current => _innerEnumerator.Current;
        public ValueTask DisposeAsync() => default;
    }

    [SetUp]
    public void Setup()
    {
        _mockDbContext = new Mock<IAppDbContext>();
        _employeeController = new EmployeeController(_mockDbContext.Object);
    }


    [Test]
    public async Task GetEmployee_ShouldReturnAllEmployees()
    {
        // Arrange
        var testData = new List<Employee>
        {
            new() { EmployeeId = Guid.NewGuid(), JobTitle = "Developer" },
            new() { EmployeeId = Guid.NewGuid(), JobTitle = "Designer" },
        }.AsQueryable();

        var mockDbContext = new Mock<IAppDbContext>();
        var mockDbSet = new Mock<DbSet<Employee>>();

        // Inject mockDbContext into your controller for testing
        var employeeController = new EmployeeController(mockDbContext.Object);

        mockDbSet.As<IQueryable<Employee>>().Setup(m => m.Provider).Returns(testData.Provider);
        mockDbSet.As<IQueryable<Employee>>().Setup(m => m.Expression).Returns(testData.Expression);
        mockDbSet.As<IQueryable<Employee>>().Setup(m => m.ElementType).Returns(testData.ElementType);
        mockDbSet.As<IQueryable<Employee>>().Setup(m => m.GetEnumerator()).Returns(testData.GetEnumerator());

        mockDbSet.As<IAsyncEnumerable<Employee>>()
            .Setup(m => m.GetAsyncEnumerator(It.IsAny<CancellationToken>()))
            .Returns(new TestAsyncEnumerator<Employee>(testData.GetEnumerator()));

        mockDbContext.Setup(c => c.Employee).Returns(mockDbSet.Object);

        // Act
        var result = await employeeController!.GetEmployee();

        // Assert
        var okResult = result.Result as OkObjectResult;
        Assert.IsNotNull(okResult);
        Assert.That(okResult!.StatusCode, Is.EqualTo(200));

        var employees = okResult.Value as List<Employee>;
        Assert.IsNotNull(employees);
        Assert.That(employees!.Count, Is.EqualTo(2));

        // Type checks
        Assert.That(employees, Is.TypeOf<List<Employee>>());
        Assert.That(employees[0].JobTitle, Is.TypeOf<string>());
        Assert.That(employees[1].JobTitle, Is.TypeOf<string>());
    }

    // Add similar tests for other controller methods (GetEmployee, PutEmployee, PostEmployee, DeleteEmployee)
}
