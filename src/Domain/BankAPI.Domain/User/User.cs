namespace BankAPI.Domain.User;

/// <summary>
/// Модель пользователя
/// </summary>
public class User
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
    /// Пароль
    /// </summary>
    public string Password { get; set; }
    
    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreatedAt { get; set; }
    
    /// <summary>
    /// Дата последней авторизации
    /// </summary>
    public DateTime SignedAt { get; set; }
    
    /// <summary>
    /// Счета
    /// </summary>
    public List<Bill.Bill> Bills { get; set; }
}