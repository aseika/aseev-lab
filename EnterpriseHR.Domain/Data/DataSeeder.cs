using EnterpriseHR.Domain.Model;

namespace EnterpriseHR.Domain.Data;

/// <summary>
/// Класс для заполнения коллекций данными
/// </summary>
public static class DataSeeder
{
    /// <summary>
    /// Коллекция сотрудников для начального наполнения
    /// </summary>
    public static readonly List<Employee> Employees =
    [
        new() { Id = 1, FirstName = "Иван", LastName = "Петров", BirthDate = new DateTime(1985, 6, 15), Gender = "М", HireDate = new DateTime(2010, 4, 1), FamilyStatus = "Женат", FamilyMembersCount = 4, ChildrenCount = 2 },
        new() { Id = 2, FirstName = "Ольга", LastName = "Сидорова", BirthDate = new DateTime(1990, 9, 10), Gender = "Ж", HireDate = new DateTime(2015, 5, 20), FamilyStatus = "Замужем", FamilyMembersCount = 3, ChildrenCount = 1 },
        new() { Id = 3, FirstName = "Алексей", LastName = "Иванов", BirthDate = new DateTime(1980, 3, 5), Gender = "М", HireDate = new DateTime(2008, 11, 15), FamilyStatus = "Холост", FamilyMembersCount = 1, ChildrenCount = 0 },
        new() { Id = 4, FirstName = "Мария", LastName = "Кузнецова", BirthDate = new DateTime(1995, 7, 25), Gender = "Ж", HireDate = new DateTime(2020, 6, 10), FamilyStatus = "Замужем", FamilyMembersCount = 2, ChildrenCount = 0 },
        new() { Id = 5, FirstName = "Сергей", LastName = "Федоров", BirthDate = new DateTime(1988, 12, 30), Gender = "М", HireDate = new DateTime(2012, 8, 5), FamilyStatus = "Женат", FamilyMembersCount = 5, ChildrenCount = 3 }
    ];

    /// <summary>
    /// Коллекция отделов
    /// </summary>
    public static readonly List<Department> Departments =
    [
        new() { Id = 1, Name = "Производственный цех" },
        new() { Id = 2, Name = "Бухгалтерия" },
        new() { Id = 3, Name = "Отдел кадров" },
        new() { Id = 4, Name = "Отдел продаж" },
        new() { Id = 5, Name = "ИТ-отдел" }
    ];

    /// <summary>
    /// Коллекция связей сотрудников и отделов
    /// </summary>
    public static readonly List<EmployeeDepartment> EmployeeDepartments =
    [
        new() { Id = 1, EmployeeId = 1, DepartmentId = 1 },
        new() { Id = 2, EmployeeId = 2, DepartmentId = 2 },
        new() { Id = 3, EmployeeId = 3, DepartmentId = 3 },
        new() { Id = 4, EmployeeId = 4, DepartmentId = 4 },
        new() { Id = 5, EmployeeId = 5, DepartmentId = 5 }
    ];

    /// <summary>
    /// Коллекция архивов трудовой деятельности
    /// </summary>
    public static readonly List<PositionHistory> PositionHistories =
    [
        new() { Id = 1, EmployeeId = 1, Position = "Мастер", HireDate = new DateTime(2010, 4, 1), DismissalDate = null },
        new() { Id = 2, EmployeeId = 2, Position = "Бухгалтер", HireDate = new DateTime(2015, 5, 20), DismissalDate = null },
        new() { Id = 3, EmployeeId = 3, Position = "Менеджер", HireDate = new DateTime(2008, 11, 15), DismissalDate = new DateTime(2015, 10, 1) },
        new() { Id = 4, EmployeeId = 4, Position = "Специалист по продажам", HireDate = new DateTime(2020, 6, 10), DismissalDate = null },
        new() { Id = 5, EmployeeId = 5, Position = "Системный администратор", HireDate = new DateTime(2012, 8, 5), DismissalDate = null }
    ];

    /// <summary>
    /// Коллекция льготных путевок
    /// </summary>
    public static readonly List<BenefitRecord> BenefitRecords =
    [
        new() { Id = 1, EmployeeId = 1, VoucherType = "Санаторий", IssueDate = new DateTime(2023, 5, 15) },
        new() { Id = 2, EmployeeId = 2, VoucherType = "Дом отдыха", IssueDate = new DateTime(2023, 7, 10) },
        new() { Id = 3, EmployeeId = 3, VoucherType = "Пионерский лагерь", IssueDate = new DateTime(2023, 6, 20) },
        new() { Id = 4, EmployeeId = 4, VoucherType = "Санаторий", IssueDate = new DateTime(2023, 8, 5) },
        new() { Id = 5, EmployeeId = 5, VoucherType = "Дом отдыха", IssueDate = new DateTime(2023, 9, 1) }
    ];
}