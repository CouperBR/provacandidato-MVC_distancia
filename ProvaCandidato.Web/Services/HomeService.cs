using System;
using System.Web.Configuration;

namespace ProvaCandidato.Services
{
    public class HomeService
    {
        public string GetNomeEmpresa()
        {
            try
            {
                return WebConfigurationManager.AppSettings["NomeEmpresa"];
            }
            catch (Exception)
            {
                return string.Empty;
            }
            
        }
    }
}