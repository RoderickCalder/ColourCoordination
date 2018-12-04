using ColourCoordination.Models;

namespace ColourCoordination.Processor
{
    public interface IColorProcessor
    {
        bool ProcessOutfit(Outfit outfit);
    }
}