using EnterpriseHR.Domain.Model;

namespace EnterpriseHR.Domain.Services.InMemory;

/// <summary>
/// Репозиторий для пользователей, хранящий коллекцию в оперативной памяти
/// </summary>
public class UserInMemoryRepository
{
    private List<Employee> _employees;

    /// <summary>
    /// Конструктор репозитория
    /// </summary>
    public UserInMemoryRepository()
    {
        _employees = DataSeeder.Employees;
    }

    /// <summary>
    /// Добавить нового пользователя (сотрудника)
    /// </summary>
    public Task<Employee> Add(Employee entity)
    {
        _employees.Add(entity);
        return Task.FromResult(entity);
    }

    /// <summary>
    /// Удалить пользователя (сотрудника) по ID
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
    /// Обновить информацию о пользователе (сотруднике)
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
    /// Получить пользователя по ID
    /// </summary>
    public Task<Employee?> Get(int key) =>
        Task.FromResult(_employees.FirstOrDefault(e => e.Id == key));

    /// <summary>
    /// Получить всех пользователей (сотрудников)
    /// </summary>
    public Task<IList<Employee>> GetAll() =>
        Task.FromResult((IList<Employee>)_employees);
    
    /// <summary>
    /// Получить пользователей по отделу
    /// </summary>
    public Task<IList<Employee>> GetByDepartment(int departmentId)
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
}