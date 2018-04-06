using System.Reflection;
using Mal.XF.Infra.Localisation;

namespace Mal.XF.Infra.DevApp.Localisation
{
    internal class LocalTranslationProvider: LocalTranslationProviderBase
    {
        public LocalTranslationProvider(string resourcePath, Assembly assembly) : base(resourcePath, assembly)
        {
        }

        internal static string LocalPrefix => "Mal.XF.Infra.DevApp.Localisation#";
        public override string Prefix => LocalPrefix;
    }
}
