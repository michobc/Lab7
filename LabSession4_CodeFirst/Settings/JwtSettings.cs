namespace LabSession4_CodeFirst.Settings;

public class JwtSettings
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string SigningKey { get; set; }
    public int ExpirationSecond { get; set; }
}