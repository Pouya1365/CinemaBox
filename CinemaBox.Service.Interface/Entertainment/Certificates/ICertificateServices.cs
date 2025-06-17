using CinemaBox.Domain.Entertainment.Certificates;

namespace CinemaBox.Service.Interface.Entertainment.Certificates;

public interface ICertificateServices
{
    Task<Certificate?> CreateOrGetCertificateAsync(string? certificateName);
    Task<Certificate?> GetCertificateAsync(string certificateName);


}
