using System.ComponentModel.DataAnnotations;

namespace EnterpriseHR.Domain.Model;

/// <summary>
/// Класс для описания отдела
/// </summary>
public class Department
{
    /// <summary>
    /// Идентификатор отдела
    /// </summary>
    [Key]
    public required int Id { get; set; }

    /// <summary>
    /// Название отдела
    /// </summary>
    public required string? Name { get; set; }

    /// <summary>
    /// Руководитель отдела
    /// </summary>
    public string? Head { get; set; }

    /// <summary>
    /// Контактный телефон отдела
    /// </summary>
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Местоположение отдела (например, номер кабинета или здания)
    /// </summary>
    public string? Location { get; set; }

    /// <summary>
    /// Количество сотрудников в отделе
    /// </summary>
    public int? EmployeeCount { get; set; }
}