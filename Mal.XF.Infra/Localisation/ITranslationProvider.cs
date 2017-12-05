namespace Mal.XF.Infra.Localisation
{
    public interface ITranslationProvider
    {
        bool CanTranslate(string key);

        string GetTranslation(string key);
    }
}
