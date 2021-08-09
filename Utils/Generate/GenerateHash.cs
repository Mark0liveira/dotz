using System;

namespace Dotz.Utils
{
    public class GenerateHash
    {
        public static string build(int size = 10)
        {
            return Guid.NewGuid()
                .ToString()
                .Replace("-", "")
                .Substring(0, size)
                .ToUpper();
        }
    }
}
