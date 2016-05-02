using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ValueProviders;

namespace DeepIn.Common
{
    internal sealed class ElementalValueProvider : IValueProvider
    {
        public ElementalValueProvider(string name, object rawValue, CultureInfo culture)
        {
            Name = name;
            RawValue = rawValue;
            Culture = culture;
        }

        public CultureInfo Culture { get; private set; }

        public string Name { get; private set; }

        public object RawValue { get; private set; }

        public bool ContainsPrefix(string prefix)
        {
            //return PrefixContainer.IsPrefixMatch(prefix, Name);
            if (Name == null)
            {
                return false;
            }

            if (prefix.Length == 0)
            {
                return true; // shortcut - non-null testString matches empty prefix
            }

            if (prefix.Length > Name.Length)
            {
                return false; // not long enough
            }

            if (!Name.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
            {
                return false; // prefix doesn't match
            }

            if (Name.Length == prefix.Length)
            {
                return true; // exact match
            }

            // invariant: testString.Length > prefix.Length
            switch (Name[prefix.Length])
            {
                case '.':
                case '[':
                    return true; // known delimiters
                default:
                    return false; // not known delimiter
            }
        }

        public ValueProviderResult GetValue(string key)
        {
            return String.Equals(key, Name, StringComparison.OrdinalIgnoreCase)
                       ? new ValueProviderResult(RawValue, Convert.ToString(RawValue, Culture), Culture)
                       : null;
        }
    }
}
