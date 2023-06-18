using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceReference;

namespace Nowadays.Services
{
    public class EmployeeServices
    {
        public bool TCKimlikNoDogrula(long TCKimlikNo, string Ad, string Soyad, int DogumYili)
        {
            try
            {
                using (var client = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap))
                {
                    return client.TCKimlikNoDogrulaAsync(TCKimlikNo, Ad.ToUpper(), Soyad.ToUpper(), DogumYili).Result.Body.TCKimlikNoDogrulaResult;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}