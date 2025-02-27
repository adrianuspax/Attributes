using UnityEngine;

namespace ASPax.Attributes.Utility
{
    public enum UColor
    {
        Clear = 0,
        White = 1,
        Black = 2,
        Gray = 3,
        Red = 4,
        Pink = 5,
        Orange = 6,
        Yellow = 7,
        Green = 8,
        Blue = 9,
        Indigo = 10,
        Violet = 11
    }

    public static class UColorExtensions
    {
        public static Color GetColor(this UColor color)
        {
            return color switch
            {
                UColor.Clear => (Color)new Color32(0, 0, 0, 0),
                UColor.White => (Color)new Color32(255, 255, 255, 255),
                UColor.Black => (Color)new Color32(0, 0, 0, 255),
                UColor.Gray => (Color)new Color32(128, 128, 128, 255),
                UColor.Red => (Color)new Color32(255, 0, 63, 255),
                UColor.Pink => (Color)new Color32(255, 152, 203, 255),
                UColor.Orange => (Color)new Color32(255, 128, 0, 255),
                UColor.Yellow => (Color)new Color32(255, 211, 0, 255),
                UColor.Green => (Color)new Color32(98, 200, 79, 255),
                UColor.Blue => (Color)new Color32(0, 135, 189, 255),
                UColor.Indigo => (Color)new Color32(75, 0, 130, 255),
                UColor.Violet => (Color)new Color32(128, 0, 255, 255),
                _ => (Color)new Color32(0, 0, 0, 255),
            };
        }
    }
}
