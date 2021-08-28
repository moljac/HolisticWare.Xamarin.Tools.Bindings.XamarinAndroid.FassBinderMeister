using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Core.Text.Transformations
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class StringPascalCase
    {
        public static
            string
                                    ToPascalCase
                                                (
                                                    this string s,
                                                    string replacement = "#"
                                                )
        {
            string result = null;

            if (string.IsNullOrEmpty(s))
            {
                return result;
            }

            string tmp = string.Join
                                    (
                                        string.Empty,
                                        // leave letters or digits
                                        // lowercase letters
                                        // rest replace with replacement string
                                        s
                                            .Select(c => char.IsLetterOrDigit(c) ? c.ToString().ToLower() : replacement)
                                            .ToArray()
                                    );

            string[] parts = tmp
                                .Split(new[] { replacement }, StringSplitOptions.RemoveEmptyEntries)
                                // loop faster than LINQ?
                                .Select(s => $"{s.Substring(0, 1).ToUpper()}{s.Substring(1)}")
                                .ToArray()
                                ;

            return string.Join(string.Empty, parts);
        }

    }
}
