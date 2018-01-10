namespace Mal.XF.Infra.Localisation
{
    public interface ITranslationManager
    {
        void Register(ITranslationProvider provider);
    }
}
