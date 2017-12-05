using System.Collections.Generic;

namespace Mal.XF.Infra.Localisation
{
    public interface ITranslationManager
    {
        void Register(ITranslationProvider provider);
    }

    internal interface ITranslationManagerReader
    {
        IReadOnlyCollection<ITranslationProvider> GetProviders();
    }
}
