using EnterpriseHR.Domain.Model;

namespace EnterpriseHR.Domain.Services.InMemory;

/// <summary>
/// Репозиторий для льготных путевок, хранящий коллекцию в оперативной памяти
/// </summary>
public class BenefitInMemoryRepository
{
    private List<BenefitVoucher> _benefitVouchers;

    /// <summary>
    /// Конструктор репозитория
    /// </summary>
    public BenefitInMemoryRepository()
    {
        _benefitVouchers = DataSeeder.BenefitVouchers;
    }

    /// <summary>
    /// Добавить новую льготную путевку
    /// </summary>
    public Task<BenefitVoucher> Add(BenefitVoucher entity)
    {
        _benefitVouchers.Add(entity);
        return Task.FromResult(entity);
    }

    /// <summary>
    /// Удалить льготную путевку по ID
    /// </summary>
    public async Task<bool> Delete(int key)
    {
        var benefitVoucher = await Get(key);
        if (benefitVoucher != null)
        {
            _benefitVouchers.Remove(benefitVoucher);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Обновить информацию о льготной путевке
    /// </summary>
    public async Task<BenefitVoucher> Update(BenefitVoucher entity)
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
    /// Получить льготную путевку по ID
    /// </summary>
    public Task<BenefitVoucher?> Get(int key) =>
        Task.FromResult(_benefitVouchers.FirstOrDefault(bv => bv.Id == key));

    /// <summary>
    /// Получить все льготные путевки
    /// </summary>
    public Task<IList<BenefitVoucher>> GetAll() =>
        Task.FromResult((IList<BenefitVoucher>)_benefitVouchers);
    
    /// <summary>
    /// Получить льготные путевки для определённого сотрудника
    /// </summary>
    public Task<IList<BenefitVoucher>> GetByEmployeeId(int employeeId)
    {
        var vouchers = _benefitVouchers
            .Where(bv => bv.EmployeeId == employeeId)
            .OrderBy(bv => bv.IssueDate)
            .ToList();
        
        return Task.FromResult<IList<BenefitVoucher>>(vouchers);
    }
}