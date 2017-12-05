namespace Mal.XF.Infra.Localisation
{
    internal class TranslationService : ITranslationService
    {
        private readonly ITranslationManagerReader translationManager;

        public TranslationService(ITranslationManagerReader translationManager)
        {
            this.translationManager = translationManager;
        }

        public string GetTranslation(string key)
        {
            var providers = this.translationManager.GetProviders();
            foreach (var provider in providers)
            {
                if (provider.CanTranslate(key))
                    return provider.GetTranslation(key);
            }

            return key;
        }
    }
}
