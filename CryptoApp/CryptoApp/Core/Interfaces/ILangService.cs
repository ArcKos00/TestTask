using CryptoApp.Models;

namespace CryptoApp.Core.Interfaces
{
    public interface ILangService
    {
        public Language Lang { get; set; }
        public List<string> Languages { get; }
        public void SetLanguage(string language);
    }
}
