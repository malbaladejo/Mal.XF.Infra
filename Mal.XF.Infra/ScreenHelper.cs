namespace Mal.XF.Infra
{
    public static class ScreenHelper
    {
        public static double ScaleFactor { get; set; }

        public static double GetDimensionInPixels(double value) => value * ScaleFactor;
    }
}
