using EnterpriseHR.Domain.Model;
using EnterpriseHR.Domain.Services.InMemory;

namespace EnterpriseHR.Domain.Tests;

public class UserRepositoryTests
{
    /// <summary>
    /// Тест проверяет успешное добавление нового пользователя (сотрудника)
    /// </summary>
    [Fact]
    public async Task AddUser_Success()
    {
        var repo = new UserInMemoryRepository();
        var newUser = new Employee
        {
            Id = 6,
            FirstName = "Александр", // Русское имя
            LastName = "Николаев", // Русская фамилия
            BirthDate = new DateTime(1993, 10, 12),
            Gender = "М",
            HireDate = new DateTime(2021, 6, 10),
            FamilyStatus = "Холост",
            FamilyMembersCount = 1,
            ChildrenCount = 0
        };

        var addedUser = await repo.Add(newUser);

        Assert.NotNull(addedUser);
        Assert.Equal(6, addedUser.Id); // Проверка ID
        Assert.Equal("Александр", addedUser.FirstName); // Проверка имени
        Assert.Equal("Николаев", addedUser.LastName); // Проверка фамилии
    }

    /// <summary>
    /// Тест проверяет успешное удаление пользователя
    /// </summary>
    [Fact]
    public async Task DeleteUser_Success()
    {
        var repo = new UserInMemoryRepository();
        var userToDelete = await repo.Get(1);
        var result = await repo.Delete(1);

        Assert.True(result);
        Assert.Null(await repo.Get(1)); // Проверка, что пользователь удалён
    }

    /// <summary>
    /// Тест проверяет успешное обновление информации о пользователе
    /// </summary>
    [Fact]
    public async Task UpdateUser_Success()
    {
        var repo = new UserInMemoryRepository();
        var updatedUser = new Employee
        {
            Id = 1,
            FirstName = "Иван",
            LastName = "Петров",
            BirthDate = new DateTime(1985, 6, 15),
            Gender = "М",
            HireDate = new DateTime(2010, 4, 1),
            FamilyStatus = "Женат",
            FamilyMembersCount = 4,
            ChildrenCount = 3
        };

        var result = await repo.Update(updatedUser);
        var user = await repo.Get(1);

        Assert.Equal(3, user?.ChildrenCount); // Проверка обновления количества детей
    }
}