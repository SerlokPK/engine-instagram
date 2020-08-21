namespace Common.Extensions
{
    public static class StringExtension
    {
        public static string GetFixedPath(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return path;
            }

            path = path.Replace('/', '\\');
            if (!path.Contains(":"))
            {
                path = path.TrimStart('\\');
            }
            if (!path.EndsWith("\\"))
            {
                path = $"{path}\\";
            }
            return path;
        }
        public static string GetWithLocalPath(this string path, bool trimEndSlash = false)
        {
            if (string.IsNullOrEmpty(path))
            {
                return path;
            }
            path = GetFixedPath(path);

            if (path != null && !path.Contains(":"))
            {
                path = $"{AppSettings.LocalPath}{path}";
            }

            if (trimEndSlash)
            {
                path = path.TrimEnd('\\');
            }

            return path;
        }
    }
}
