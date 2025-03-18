using EnterpriseHR.Domain.Model;

namespace EnterpriseHR.Domain.Services;

/// <summary>
/// Репозиторий для работы с сотрудниками.
/// </summary>
public interface IEmployeeRepository : IRepository<Employee, int>
{
    /// <summary>
    /// Получить все сведения о конкретном сотруднике и его отделах.
    /// </summary>
    /// <param name="Id">Идентификатор сотрудника.</param>
    /// <returns>Данные о сотруднике и его отделах.</returns>
    Task<(Employee employee, IList<Department> departments)?> GetEmployeeWithDepartments(int Id);

    /// <summary>
    /// Получить топ 5 сотрудников по стажу работы на предприятии.
    /// </summary>
    /// <returns>Список из 5 сотрудников и их стажа работы.</returns>
    Task<IList<(Employee employee, int yearsOfExperience)>> GetTop5EmployeesByExperience();

    /// <summary>
    /// Получить информацию о количестве трудовых контрактов, среднем и максимальном времени трудовой деятельности для каждого сотрудника.
    /// </summary>
    /// <returns>Список сотрудников с данными по их трудовой деятельности.</returns>
    Task<IList<(Employee employee, int contractCount, double avgWorkDuration, int maxWorkDuration)>> GetEmployeeWorkStatistics();

    /// <summary>
    /// Получить информацию о сотрудниках, получивших льготные путевки в профсоюзе.
    /// </summary>
    /// <returns>Список сотрудников с информацией о льготных путевках.</returns>
    Task<IList<(Employee employee, IList<BenefitRecord> benefits)>> GetEmployeesWithUnionBenefits();
}