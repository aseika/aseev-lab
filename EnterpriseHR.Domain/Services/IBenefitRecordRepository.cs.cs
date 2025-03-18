using EnterpriseHR.Domain.Model;
using EnterpriseHR.Domain.Services;

namespace EnterpriseHR.Domain.Services;
/// <summary>
/// Репозиторий для работы с историей должностей сотрудников.
/// </summary>
public interface IPositionHistoryRepository : IRepository<PositionHistory, int>
{
    /// <summary>
    /// Получить статистику по изменениям должностей для сотрудников.
    /// </summary>
    /// <returns>Список статистических данных по изменениям должностей сотрудников.</returns>
    Task<IList<(Employee employee, int positionChangeCount, DateTime firstPositionChange, DateTime lastPositionChange)>> GetEmployeePositionChangeStatistics();
}
