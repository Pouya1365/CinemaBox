using CinemaBox.Domain.Entertainment.Certificates;
using CinemaBox.Service.Interface.Entertainment.Certificates;
using CinemaBox.UnitOfWork.Interface.UOW;

namespace CinemaBox.Service.Entertainment.Certificates;

public class CertificateServices(IUnitOfWork unitOfWork): ICertificateServices
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    public async Task<Certificate?> CreateOrGetCertificateAsync(string? certificateName)
    {
        if (string.IsNullOrWhiteSpace(certificateName))
            return null;
        var certificate = await GetCertificateAsync(certificateName);
        if (certificate == null)
        {
            certificate = new Certificate { CertificateName = certificateName.Trim() };
            await _unitOfWork.Certificates.AddAsync(certificate);
            await _unitOfWork.CompleteAsync();
        }
        return certificate;
    }
    public async Task<Certificate?> GetCertificateAsync(string certificateName)
    {
        if (string.IsNullOrWhiteSpace(certificateName))
            return null;
        return await _unitOfWork.Certificates
            .FindAsync(c => c.CertificateName != null &&
                       c.CertificateName.Equals(certificateName.Trim(), StringComparison.OrdinalIgnoreCase));
    }
}


