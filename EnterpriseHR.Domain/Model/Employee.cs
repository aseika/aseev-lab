using System.ComponentModel.DataAnnotations;

namespace EnterpriseHR.Domain.Model;

/// <summary>
/// Класс для описания сотрудника
/// </summary>
public class Employee
{
    /// <summary>
    /// Идентификатор сотрудника
    /// </summary>
    [Key]
    public required int Id { get; set; }

    /// <summary>
    /// Фамилия сотрудника
    /// </summary>
    public required string? LastName { get; set; }

    /// <summary>
    /// Имя сотрудника
    /// </summary>
    public required string? FirstName { get; set; }

    /// <summary>
    /// Отчество сотрудника
    /// </summary>
    public string? Patronymic { get; set; }

    /// <summary>
    /// Дата рождения сотрудника
    /// </summary>
    public DateTime? DateOfBirth { get; set; }

    /// <summary>
    /// Пол сотрудника
    /// </summary>
    public string? Gender { get; set; }

    /// <summary>
    /// Дата поступления на работу
    /// </summary>
    public DateTime? HireDate { get; set; }

    /// <summary>
    /// Телефон сотрудника
    /// </summary>
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Домашний адрес сотрудника
    /// </summary>
    public string? HomeAddress { get; set; }

    /// <summary>
    /// Семейное положение сотрудника
    /// </summary>
    public string? MaritalStatus { get; set; }

    /// <summary>
    /// Количество человек в семье
    /// </summary>
    public int? FamilySize { get; set; }

    /// <summary>
    /// Количество детей у сотрудника
    /// </summary>
    public int? ChildrenCount { get; set; }
}