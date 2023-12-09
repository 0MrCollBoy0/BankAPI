using BankAPI.Contracts.Contexts.User;

namespace BankAPI.Contracts.Contexts.Bill;
/// <summary>
/// Модель для создания Счетов
/// </summary>
public class CreateBillDto
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public UserDto User { get; set; }

}