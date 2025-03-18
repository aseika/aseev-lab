using System.ComponentModel.DataAnnotations;

namespace EnterpriseHR.Domain.Model;

/// <summary>
/// Класс, связывающий членов профсоюза и льготные путевки
/// </summary>
public class BenefitRecord
{
    /// <summary>
    /// Идентификатор записи о льготной путевке
    /// </summary>
    [Key]
    public required int Id { get; set; }

    /// <summary>
    /// Идентификатор члена профсоюза
    /// </summary>
    public required int UnionMemberId { get; set; }

    /// <summary>
    /// Навигационное свойство члена профсоюза
    /// </summary>
    public virtual UnionMember? UnionMember { get; set; }

    /// <summary>
    /// Идентификатор путевки
    /// </summary>
    public required int BenefitId { get; set; }

    /// <summary>
    /// Навигационное свойство льготной путевки
    /// </summary>
    public virtual DateTime? IssueDate { get; set; }

    /// <summary>
    /// Дата выдачи путевки
    /// </summary>
    public DateTime? IssueDate { get; set; }

    /// <summary>
    /// Тип путевки (санаторий, дом отдыха и т.д.)
    /// </summary>
    public string? BenefitType { get; set; }
}

