namespace Infrastructure.Authentication;

public class JwtOptions
{
    public string Issuer { get; set; }
    public string Audiencie { get; set; }
    public string SecretKey { get; set; }
}
