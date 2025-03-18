using UnityEngine;

namespace ASPax.Attributes.Utility
{
    public enum XColor
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

    public static class XColorExtensions
    {
        public static Color GetColor(this XColor color)
        {
            return color switch
            {
                XColor.Clear => (Color)new Color32(0, 0, 0, 0),
                XColor.White => (Color)new Color32(255, 255, 255, 255),
                XColor.Black => (Color)new Color32(0, 0, 0, 255),
                XColor.Gray => (Color)new Color32(128, 128, 128, 255),
                XColor.Red => (Color)new Color32(255, 0, 63, 255),
                XColor.Pink => (Color)new Color32(255, 152, 203, 255),
                XColor.Orange => (Color)new Color32(255, 128, 0, 255),
                XColor.Yellow => (Color)new Color32(255, 211, 0, 255),
                XColor.Green => (Color)new Color32(98, 200, 79, 255),
                XColor.Blue => (Color)new Color32(0, 135, 189, 255),
                XColor.Indigo => (Color)new Color32(75, 0, 130, 255),
                XColor.Violet => (Color)new Color32(128, 0, 255, 255),
                _ => (Color)new Color32(0, 0, 0, 255),
            };
        }
    }
}
