using System.Collections.Generic;

namespace Mal.XF.Infra.Localisation
{
    internal interface ITranslationManagerReader
    {
        IReadOnlyCollection<ITranslationProvider> GetProviders();
    }
}