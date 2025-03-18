using System.ComponentModel.DataAnnotations;

namespace EnterpriseHR.Domain.Model;

/// <summary>
/// Класс, описывающий члена профсоюза
/// </summary>
public class UnionMember
{
    /// <summary>
    /// Идентификатор члена профсоюза
    /// </summary>
    [Key]
    public required int Id { get; set; }

    /// <summary>
    /// Имя члена профсоюза
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    /// Фамилия члена профсоюза
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// Отчество члена профсоюза
    /// </summary>
    public string? Patronymic { get; set; }

    /// <summary>
    /// Телефон члена профсоюза
    /// </summary>
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Идентификатор сотрудника, который является членом профсоюза
    /// </summary>
    public required int EmployeeId { get; set; }

    /// <summary>
    /// Навигационное свойство для сотрудника
    /// </summary>
    public virtual Employee? Employee { get; set; }

    /// <summary>
    /// Дата вступления в профсоюз
    /// </summary>
    public DateTime? JoinDate { get; set; }

    /// <summary>
    /// Статус членства (активен или нет)
    /// </summary>
    public bool IsActive { get; set; }
}
