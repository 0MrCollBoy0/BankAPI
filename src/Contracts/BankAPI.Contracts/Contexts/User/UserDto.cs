using BankAPI.Contracts.Contexts.Bill;

namespace BankAPI.Contracts.Contexts.User;
/// <summary>
/// Модель Пользователь
/// </summary>
public class UserDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Email
    /// </summary>
    public string Email { get; set; }
    
    /// <summary>
    /// Номер телефона
    /// </summary>
    public string Phone { get; set; }
    
    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime Birthday { get; set; }
    

    /// <summary>
    /// Счета
    /// </summary>
    public IEnumerable<BillDto> Bills { get; set; }
}