using System;
using System.Collections.Generic;
using System.Linq;

namespace Tools
{
    public static class DictionaryExtensions
    {
        /// <summary>
        ///     Would prefer ContainsValue but Collections already contains a method that can be ambiguous.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool HasValue(this IDictionary<string, string> dictionary, string value)
        {
            return dictionary != null &&
                   dictionary.Values.Any(v => string.Equals(v, value, StringComparison.OrdinalIgnoreCase));
        }

        public static bool HasKeyWithValue(this IDictionary<string, string> dictionary, string key, string value)
        {
            var dicKey = dictionary?.Keys.FirstOrDefault(k => string.Equals(k, key, StringComparison.OrdinalIgnoreCase));

            return dicKey != null && string.Equals(dictionary[dicKey], value, StringComparison.OrdinalIgnoreCase);
        }

        public static bool HasKeyAndContainsValue(this IDictionary<string, string> dictionary, string key, string value, char seperator = ',')
        {
            var dicKey = dictionary?.Keys.FirstOrDefault(k => string.Equals(k, key, StringComparison.OrdinalIgnoreCase));

            if (string.IsNullOrEmpty(dicKey) || dictionary[dicKey] == null) return false;

            var sourceValue = dictionary[dicKey].ToLowerInvariant();
            var compareValue = value.ToLowerInvariant();

            return string.Equals(sourceValue, value) || sourceValue.Split(seperator).Contains(compareValue);
        }
    }
}
