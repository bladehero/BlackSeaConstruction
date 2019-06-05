using System.IO;

namespace BlackSeaConstruction.Web.Extensions
{
    public static class ImageExtensions
    {
        public static string ResourceDirectory => Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

        public const string NoImage = "NoImage.png";
        public const string ImageFolder = "images";
        public const string NewsFolder = "news";
        public const string ServicesFolder = "services";

        public static string NewsImage(string source) => ImageForFolder(source, NewsFolder);
        public static string ServicesImage(string source) => ImageForFolder(source, ServicesFolder);

        public static string ImageForFolder(string source, string folder)
        {
            string path = string.Empty;
            if (source != null)
            {
                path = string.Join('/', ImageFolder, folder, source);
            }
            return File.Exists(Path.Combine(ResourceDirectory, path)) ? path : NoImagePath(folder);
        }

        private static string NoImagePath(string folder) => string.Join('/', ImageFolder, folder, NoImage);
    }
}
