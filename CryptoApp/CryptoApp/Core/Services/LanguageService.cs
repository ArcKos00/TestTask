using CryptoApp.Core.Interfaces;
using CryptoApp.Models;

namespace CryptoApp.Core.Services
{
    public class LanguageService : BaseViewModel, ILangService
    {
        private readonly string _path = @"..\..\Languages\";
        private Language _language = null!;
        public LanguageService()
        {
            SetLanguage("en");
        }

        public Language Lang
        {
            get => _language;
            set
            {
                _language = value;
                OnPropertyChanged();
            }
        }

        public List<string> Languages { get => GetLanguages().Select(s => s.Split('-')[0].ToUpper()).ToList(); }

        public void SetLanguage(string language)
        {
            Lang = JsonConvert.DeserializeObject<Language>(@Path.Combine(_path, GetLanguages().Where(w => w.StartsWith(language.ToLower())).ToArray()[0])) !;
        }

        private List<string> GetLanguages()
        {
            var mak = Directory.GetFiles(_path);
            return mak.ToList();
        }
    }
}
