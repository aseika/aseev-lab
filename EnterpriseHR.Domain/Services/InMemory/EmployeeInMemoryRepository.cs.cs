using EnterpriseHR.Domain.Model;

namespace EnterpriseHR.Domain.Services.InMemory;

/// <summary>
/// Репозиторий для сотрудников, хранящий коллекцию в оперативной памяти
/// </summary>
public class EmployeeInMemoryRepository
{
    private List<Employee> _employees;

    /// <summary>
    /// Конструктор репозитория
    /// </summary>
    public EmployeeInMemoryRepository()
    {
        _employees = DataSeeder.Employees;
    }

    /// <summary>
    /// Добавить нового сотрудника
    /// </summary>
    public Task<Employee> Add(Employee entity)
    {
        _employees.Add(entity);
        return Task.FromResult(entity);
    }

    /// <summary>
    /// Удалить сотрудника по ID
    /// </summary>
    public async Task<bool> Delete(int key)
    {
        var employee = await Get(key);
        if (employee != null)
        {
            _employees.Remove(employee);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Обновить информацию о сотруднике
    /// </summary>
    public async Task<Employee> Update(Employee entity)
    {
        try
        {
            await Delete(entity.Id);
            await Add(entity);
        }
        catch
        {
            return null!;
        }
        return entity;
    }

    /// <summary>
    /// Получить сотрудника по ID
    /// </summary>
    public Task<Employee?> Get(int key) =>
        Task.FromResult(_employees.FirstOrDefault(e => e.Id == key));

    /// <summary>
    /// Получить всех сотрудников
    /// </summary>
    public Task<IList<Employee>> GetAll() =>
        Task.FromResult((IList<Employee>)_employees);

    /// <summary>
    /// Получить список сотрудников по количеству детей
    /// </summary>
    public Task<IList<Employee>> GetEmployeesByChildrenCount(int minChildrenCount)
    {
        var employees = _employees
            .Where(e => e.ChildrenCount >= minChildrenCount)
            .OrderBy(e => e.LastName)
            .ToList();
        return Task.FromResult<IList<Employee>>(employees);
    }

    /// <summary>
    /// Получить сотрудников по отделам
    /// </summary>
    public Task<IList<Employee>> GetEmployeesByDepartment(int departmentId)
    {
        var employeeIds = DataSeeder.EmployeeDepartments
            .Where(ed => ed.DepartmentId == departmentId)
            .Select(ed => ed.EmployeeId)
            .ToList();

        var employeesInDepartment = _employees
            .Where(e => employeeIds.Contains(e.Id))
            .OrderBy(e => e.LastName)
            .ToList();

        return Task.FromResult<IList<Employee>>(employeesInDepartment);
    }

    /// <summary>
    /// Получить список сотрудников по их трудовой позиции
    /// </summary>
    public Task<IList<Employee>> GetEmployeesByPosition(string position)
    {
        var employees = DataSeeder.EmploymentHistories
            .Where(eh => eh.Position == position)
            .Join(_employees, eh => eh.EmployeeId, e => e.Id, (eh, e) => e)
            .OrderBy(e => e.LastName)
            .ToList();

        return Task.FromResult<IList<Employee>>(employees);
    }
}