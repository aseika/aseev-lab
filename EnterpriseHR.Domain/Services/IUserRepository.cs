using EnterpriseHR.Domain.Model;
using EnterpriseHR.Domain.Services;

namespace TaxiParkLabs.Domain.Services;
/// <summary>
/// Репозиторий для работы с членами профсоюза (пользователями).
/// </summary>
public interface IUnionMemberRepository : IRepository<UnionMember, int>
{
    /// <summary>
    /// Получить всех членов профсоюза, которые получили льготы за указанный период, упорядоченных по ФИО.
    /// </summary>
    /// <param name="startDate">Начальная дата периода.</param>
    /// <param name="endDate">Конечная дата периода.</param>
    /// <returns>Список членов профсоюза.</returns>
    Task<IList<UnionMember>> GetUnionMembersByBenefitPeriod(int startDate, int endDate);

    /// <summary>
    /// Получить количество льгот, предоставленных каждому члену профсоюза.
    /// </summary>
    /// <returns>Список членов профсоюза и количества их льгот.</returns>
    Task<IList<(UnionMember unionMember, int benefitCount)>> GetBenefitCountByUnionMember();

    /// <summary>
    /// Получить членов профсоюза, получивших максимальное количество льгот за указанный период.
    /// </summary>
    /// <param name="startDate">Начальная дата периода.</param>
    /// <param name="endDate">Конечная дата периода.</param>
    /// <returns>Список членов профсоюза с максимальным числом льгот.</returns>
    Task<IList<UnionMember>> GetTopUnionMembersByBenefitPeriod(int startDate, int endDate);
}
