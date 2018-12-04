using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using ColourCoordination.Models;

namespace ColourCoordination.Processor
{
    public class ColorProcessor : IColorProcessor
    {
        private readonly Dictionary<string, PositionColor> _colorPositions = new Dictionary<string, PositionColor>
        {
            {Color.Orange.Name, new PositionColor{Position = 1, PairingColours = "FA"}}, {Color.DarkOrange.Name, new PositionColor{Position = 2, PairingColours = "A"}}, {Color.OrangeRed.Name, new PositionColor{Position = 3, PairingColours = "AB"}},
            {Color.DarkRed.Name, new PositionColor{Position = 4, PairingColours = "B"}}, {Color.Red.Name, new PositionColor{Position = 5, PairingColours = "B"}}, {Color.PaleVioletRed.Name, new PositionColor{Position = 6, PairingColours = "BC"}},
            {Color.Violet.Name, new PositionColor{Position = 7, PairingColours = "C"}}, {Color.DarkViolet.Name, new PositionColor{Position = 8, PairingColours = "C"}}, {Color.BlueViolet.Name, new PositionColor{Position = 9, PairingColours = "CD"}},
            {Color.DarkBlue.Name, new PositionColor{Position = 10, PairingColours = "D"}}, {Color.Blue.Name, new PositionColor{Position = 11, PairingColours = "D"}}, {Color.SeaGreen.Name, new PositionColor{Position = 12, PairingColours = "DE"}},
            {Color.DarkGreen.Name, new PositionColor{Position = 13, PairingColours = "E"}}, {Color.Green.Name, new PositionColor{Position = 14, PairingColours = "E"}}, {Color.YellowGreen.Name, new PositionColor{Position = 15, PairingColours = "EF"}},
            {Color.Yellow.Name, new PositionColor{Position = 16, PairingColours = "EF"}}
        };


        public bool ProcessOutfit(Outfit outfit)
        {
            var outfitColors = new Colors();
            if (string.IsNullOrWhiteSpace(outfit.ShirtColor))
            {
                outfitColors.OutfitColors[0] = GetColor(outfit.ShirtColor);
            }
            if (string.IsNullOrWhiteSpace(outfit.PantsColor))
            {
                outfitColors.OutfitColors[1] = GetColor(outfit.PantsColor);
            }
            if (string.IsNullOrWhiteSpace(outfit.ShoeColor))
            {
                outfitColors.OutfitColors[2] = GetColor(outfit.ShoeColor);
            }

            var colorPositions = outfitColors.OutfitColors.Select(FindColourPosition).ToList();

            var colorPairingCoordinated = IsColorPairingCoordinated(colorPositions);
            var colorPositionCoordinated = IsColorPostionCoordinated(colorPositions);

            return colorPositionCoordinated || colorPairingCoordinated;
        }

        private PositionColor FindColourPosition(Color color)
        {
            _colorPositions.TryGetValue(color.Name, out var position);
            return position;
        }

        private bool IsColorPairingCoordinated(List<PositionColor> positions)
        {
            if (positions == null) throw new ArgumentNullException(nameof(positions));
            List<bool> coordination = new List<bool>();

            foreach (var position in positions)
            {
                foreach (var comparingPosition in positions)
                {
                    coordination.Add(comparingPosition.PairingColours == position.PairingColours);
                }
            }

            return !coordination.Contains(false);

        }

        private bool IsColorPostionCoordinated(List<PositionColor> positions)
        {
            if (positions == null) throw new ArgumentNullException(nameof(positions));

            var minPosition = 4;
            var maxPosition = 6;
            var coordination = new List<bool>();

            foreach (var position in positions)
            {
                foreach (var comparingPosition in positions)
                {
                    coordination.Add(comparingPosition.Position - position.Position == minPosition && comparingPosition.Position - position.Position == maxPosition
                                     || comparingPosition.Position - position.Position == -minPosition && comparingPosition.Position - position.Position == -maxPosition);
                }
            }

            return !coordination.Contains(false);
        }

        private static Color GetColor(string colorName)
        {
            switch (colorName)
            {
                case "Orange":
                    return Color.Orange;
                case "Dark Orange":
                    return Color.DarkOrange;
                case "Red Orange":
                    return Color.Green;
                case "Dark Red":
                    return Color.DarkRed;
                case "Red":
                    return Color.Red;
                case "Violet Red":
                    return Color.PaleVioletRed;
                case "violet":
                    return Color.Violet;
                case "Dark Violet":
                    return Color.DarkViolet;
                case "Blue Violet":
                    return Color.BlueViolet;
                case "Dark Blue":
                    return Color.DarkBlue;
                case "Blue":
                    return Color.Blue;
                case "Green Blue":
                    return Color.SeaGreen;
                case "Dark Green":
                    return Color.DarkGreen;
                case "Green":
                    return Color.Green;
                case "Yellow Green":
                    return Color.YellowGreen;
                case "Yellow":
                    return Color.Yellow;
                default:
                    throw new Exception();
            }
        }
    }
}