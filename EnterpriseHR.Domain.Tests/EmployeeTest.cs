using EnterpriseHR.Domain.Model;
using EnterpriseHR.Domain.Services.InMemory;

namespace EnterpriseHR.Domain.Tests;

public class EmployeeRepositoryTests
{
    /// <summary>
    /// Тест проверяет успешное добавление нового сотрудника
    /// </summary>
    [Fact]
    public async Task AddEmployee_Success()
    {
        var repo = new EmployeeInMemoryRepository();
        var newEmployee = new Employee
        {
            Id = 6,
            FirstName = "Дмитрий", // Русское имя
            LastName = "Смирнов", // Русская фамилия
            BirthDate = new DateTime(1992, 11, 11),
            Gender = "М",
            HireDate = new DateTime(2021, 2, 5),
            FamilyStatus = "Женат",
            FamilyMembersCount = 3,
            ChildrenCount = 1
        };

        var addedEmployee = await repo.Add(newEmployee);

        Assert.NotNull(addedEmployee);
        Assert.Equal(6, addedEmployee.Id); // Проверка, что ID нового сотрудника совпадает с переданным
        Assert.Equal("Дмитрий", addedEmployee.FirstName); // Проверка имени
        Assert.Equal("Смирнов", addedEmployee.LastName); // Проверка фамилии
    }

    /// <summary>
    /// Тест проверяет успешное удаление сотрудника
    /// </summary>
    [Fact]
    public async Task DeleteEmployee_Success()
    {
        var repo = new EmployeeInMemoryRepository();
        var employeeToDelete = await repo.Get(1);
        var result = await repo.Delete(1);

        Assert.True(result);
        Assert.Null(await repo.Get(1)); // Проверка, что сотрудник удалён
    }

    /// <summary>
    /// Тест проверяет успешное обновление информации о сотруднике
    /// </summary>
    [Fact]
    public async Task UpdateEmployee_Success()
    {
        var repo = new EmployeeInMemoryRepository();
        var updatedEmployee = new Employee
        {
            Id = 1,
            FirstName = "Иван",
            LastName = "Петров",
            BirthDate = new DateTime(1985, 6, 15),
            Gender = "М",
            HireDate = new DateTime(2010, 4, 1),
            FamilyStatus = "Женат",
            FamilyMembersCount = 4,
            ChildrenCount = 3
        };

        var result = await repo.Update(updatedEmployee);
        var employee = await repo.Get(1);

        Assert.Equal(3, employee?.ChildrenCount); // Проверка обновления количества детей
    }

    /// <summary>
    /// Тест проверяет успешное получение сотрудников по количеству детей
    /// </summary>
    [Fact]
    public async Task GetEmployeesByChildrenCount_Success()
    {
        var repo = new EmployeeInMemoryRepository();
        var employees = await repo.GetEmployeesByChildrenCount(2);

        Assert.NotEmpty(employees);
        Assert.All(employees, e => Assert.True(e.ChildrenCount >= 2));
    }

    /// <summary>
    /// Тест проверяет успешное получение сотрудников по отделу
    /// </summary>
    [Fact]
    public async Task GetEmployeesByDepartment_Success()
    {
        var repo = new EmployeeInMemoryRepository();
        var employees = await repo.GetEmployeesByDepartment(1); // Производственный цех

        Assert.NotEmpty(employees);
    }

    /// <summary>
    /// Тест проверяет успешное получение сотрудников по трудовой позиции
    /// </summary>
    [Fact]
    public async Task GetEmployeesByPosition_Success()
    {
        var repo = new EmployeeInMemoryRepository();
        var employees = await repo.GetEmployeesByPosition("Мастер");

        Assert.NotEmpty(employees);
    }
}