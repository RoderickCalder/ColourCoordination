using System.Drawing;

namespace ColourCoordination.Models
{
    public class Colors
    {
        public Color[] OutfitColors { get; set; }
        public PositionColor[] ColorPositions { get; set; }
        public bool IsOutfitColorCoordinated { get; set; }
    }
}