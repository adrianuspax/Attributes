using System;

namespace ASPax.Attributes.Drawer
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class ShowAssetPreviewAttribute : DrawerAttribute
    {
        public const int WIDTH = 64;
        public const int HEIGHT = 64;

        private readonly int _width;
        private readonly int _height;

        public ShowAssetPreviewAttribute(int width = WIDTH, int height = HEIGHT)
        {
            _width = width;
            _height = height;
        }

        public int Width => _width;
        public int Height => _height;
    }
}
