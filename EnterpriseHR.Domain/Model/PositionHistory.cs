using System.ComponentModel.DataAnnotations;

namespace EnterpriseHR.Domain.Model;

/// <summary>
/// Класс истории позиций сотрудника
/// </summary>
public class PositionHistory
{
    /// <summary>
    /// Идентификатор записи истории позиции
    /// </summary>
    [Key]
    public required int Id { get; set; }

    /// <summary>
    /// Идентификатор сотрудника
    /// </summary>
    public required int EmployeeId { get; set; }

    /// <summary>
    /// Идентификатор должности
    /// </summary>
    public required int PositionId { get; set; }

    /// <summary>
    /// Дата начала работы на должности
    /// </summary>
    public DateTime? StartDate { get; set; }

    /// <summary>
    /// Дата окончания работы на должности (если увольнение)
    /// </summary>
    public DateTime? EndDate { get; set; }

    /// <summary>
    /// Идентификатор отдела, в котором работал сотрудник на данной должности
    /// </summary>
    public required int DepartmentId { get; set; }

    /// <summary>
    /// Навигационное свойство для сотрудника
    /// </summary>
    public virtual Employee? Employee { get; set; }

    /// <summary>
    /// Навигационное свойство для должности
    /// </summary>
    public virtual Position? Position { get; set; }

    /// <summary>
    /// Навигационное свойство для отдела
    /// </summary>
    public virtual Department? Department { get; set; }
}
