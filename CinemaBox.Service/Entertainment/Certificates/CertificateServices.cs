using CinemaBox.Domain.Entertainment.Certificates;
using CinemaBox.Service.Interface.Entertainment.Certificates;
using CinemaBox.UnitOfWork.Interface.UOW;
using CinemaBox.Utilities.Strings;

namespace CinemaBox.Service.Entertainment.Certificates;

public class CertificateServices(IUnitOfWork unitOfWork) : ICertificateServices
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    public async Task<Certificate?> CreateOrGetCertificateAsync(string? certificateName)
    {
        if (string.IsNullOrWhiteSpace(certificateName))
            return null;
        Certificate? certificate = await GetCertificateAsync(certificateName);
        if (certificate == null)
        {
            certificate = new Certificate { CertificateName = certificateName.Trim() };
            await _unitOfWork.Repository<Certificate>().AddAsync(certificate);
            await _unitOfWork.CompleteAsync();
        }
        return certificate;
    }
    public async Task<Certificate?> GetCertificateAsync(string certificateName)
    {
        if (string.IsNullOrWhiteSpace(certificateName))
            return null;
        string? nameToCompare = StringExtensions.NormalizeSafe(certificateName);
        if (string.IsNullOrEmpty(nameToCompare))
            return null;

        return await _unitOfWork.Repository<Certificate>()
            .FindAsync(c => c.CertificateName.ToLower() == nameToCompare);
    
    }
}


