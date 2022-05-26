using System.Collections.Generic;

namespace Domain
{
    public static class Extensions
    {
        public static string SafeGet(this Dictionary<string, string> dictionary, string name)
        {
            var success = dictionary.TryGetValue(name, out var value);
            return success ? value : "";
        }
    }
}