namespace LabSession4_CodeFirst.Services.Abstractions;

public interface IAuthenticationService
{
    public string Login(string username, string password);
}