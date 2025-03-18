using System.ComponentModel.DataAnnotations;

namespace EnterpriseHR.Domain.Model;

/// <summary>
/// Класс, связывающий сотрудников и отделы
/// </summary>
public class EmployeeDepartment
{
    /// <summary>
    /// Идентификатор связи
    /// </summary>
    [Key]
    public required int Id { get; set; }

    /// <summary>
    /// Идентификатор сотрудника
    /// </summary>
    public required int EmployeeId { get; set; }

    /// <summary>
    /// Навигационное свойство для сотрудника
    /// </summary>
    public virtual Employee? Employee { get; set; }

    /// <summary>
    /// Идентификатор отдела
    /// </summary>
    public required int DepartmentId { get; set; }

    /// <summary>
    /// Навигационное свойство для отдела
    /// </summary>
    public virtual Department? Department { get; set; }
}

