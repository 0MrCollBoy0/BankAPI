namespace BankAPI.Contracts.Contexts.User;
/// <summary>
/// Сокращённая модель пользователя
/// </summary>
public class ShortUserDto
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

}