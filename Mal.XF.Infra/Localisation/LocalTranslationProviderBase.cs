using System.Reflection;
using System.Resources;

namespace Mal.XF.Infra.Localisation
{
    public abstract class LocalTranslationProviderBase : ITranslationProvider
    {
        public readonly Assembly assembly;
        private readonly string baseName;

        protected LocalTranslationProviderBase(string baseName, Assembly assembly)
        {
            this.assembly = assembly;
            this.baseName = baseName;
        }

        public abstract string Prefix { get; }

        public bool CanTranslate(string key) => key.StartsWith(Prefix);

        public string GetTranslation(string key)
        {
            if (!this.CanTranslate(key))
                return null;

            var rm = new ResourceManager(this.baseName, this.assembly);
            return rm.GetString(key.Replace(Prefix, string.Empty));
        }
    }
}
