using System;
using System.Text.RegularExpressions;

namespace Core
{
    /// <summary>
    ///
    /// https://semver.org/
    /// </summary>
    /// https://regex101.com/r/Ly7O1x/3/
    /// ^(?P<major>0|[1-9]\d*)\.(?P<minor>0|[1-9]\d*)\.(?P<patch>0|[1-9]\d*)(?:-(?P<prerelease>(?:0|[1-9]\d*|\d*[a-zA-Z-][0-9a-zA-Z-]*)(?:\.(?:0|[1-9]\d*|\d*[a-zA-Z-][0-9a-zA-Z-]*))*))?(?:\+(?P<buildmetadata>[0-9a-zA-Z-]+(?:\.[0-9a-zA-Z-]+)*))?$
    /// https://regex101.com/r/vkijKf/1/
    /// ^(0|[1-9]\d*)\.(0|[1-9]\d*)\.(0|[1-9]\d*)(?:-((?:0|[1-9]\d*|\d*[a-zA-Z-][0-9a-zA-Z-]*)(?:\.(?:0|[1-9]\d*|\d*[a-zA-Z-][0-9a-zA-Z-]*))*))?(?:\+([0-9a-zA-Z-]+(?:\.[0-9a-zA-Z-]+)*))?$
    public partial class VersionSemantic
    {
        static VersionSemantic()
        {
            //re01 = new Regex(@"^(?P<major>0|[1-9]\d*)\.(?P<minor>0|[1-9]\d*)\.(?P<patch>0|[1-9]\d*)(?:-(?P<prerelease>(?:0|[1-9]\d*|\d*[a-zA-Z-][0-9a-zA-Z-]*)(?:\.(?:0|[1-9]\d*|\d*[a-zA-Z-][0-9a-zA-Z-]*))*))?(?:\+(?P<buildmetadata>[0-9a-zA-Z-]+(?:\.[0-9a-zA-Z-]+)*))?$");
            re02 = new Regex(@"^(0|[1-9]\d*)\.(0|[1-9]\d*)\.(0|[1-9]\d*)(?:-((?:0|[1-9]\d*|\d*[a-zA-Z-][0-9a-zA-Z-]*)(?:\.(?:0|[1-9]\d*|\d*[a-zA-Z-][0-9a-zA-Z-]*))*))?(?:\+([0-9a-zA-Z-]+(?:\.[0-9a-zA-Z-]+)*))?$");

            // https://dotnetfiddle.net/tnKTPd
            re03 = new Regex("^(?:\\d+\\.){2}\\d+(?:-(?:0|[1-9]\\d*|\\d*[a-z-][a-z\\d-]*)(?:\\.(?:0|[1-9]\\d*|\\d*[a-z-][a-z\\d-]*))*)?(?:\\+[a-z\\d-]+(?:\\.[a-z\\d-]+)*)?$", RegexOptions.IgnoreCase);
            return;
        }

        static Regex re01 = null;
        static Regex re02 = null;
        static Regex re03 = null;


        public static
            (
                int major,
                int minor,
                int patch,
                string prerelease,
                string build
            )
                                                    Parse
                                                        (
                                                            string text
                                                        )
        {
            /*
                <valid semver> ::= <version core>
                         | <version core> "-" <pre-release>
                         | <version core> "+" <build>
                         | <version core> "-" <pre-release> "+" <build>
            */

            bool contains_minus = text.Contains("-");
            bool contains_plus  = text.Contains("+");
            int idx_minus   = text.IndexOf('-');
            int idx_plus    = text.IndexOf('+');

            int major = -1;
            int minor = -1;
            int patch = -1;
            string prerelease = null;
            string build = null;

            string core = null;

            if ( idx_minus > -1 )
            {
                core = text.Substring(0, idx_minus);
            }
            else
            {
                core = text;
            }

            string[] parts_core = core.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts_core.Length == 3)
            {
                int.TryParse(parts_core[0], out major);
                int.TryParse(parts_core[1], out minor);
                int.TryParse(parts_core[2], out patch);
            }
            else if (parts_core.Length == 2)
            {
                int.TryParse(parts_core[0], out major);
                int.TryParse(parts_core[1], out minor);
            }
            else if (parts_core.Length == 1)
            {
                int.TryParse(parts_core[0], out major);
            }
            else
            {
                throw new InvalidOperationException("Semantic Version not recognized");
            }

            if ( ! contains_minus && ! contains_plus )
            {
                // no op
            }
            else if ( contains_minus && ! contains_plus )
            {
                prerelease = text.Substring(idx_minus + 1, text.Length - idx_minus - 1);
            }
            else if ( ! contains_minus && contains_plus )
            {
                build = text.Substring(idx_plus, text.Length - idx_plus);
            }
            else if ( contains_minus && contains_plus)
            {
                build = text.Substring(idx_plus + 1, text.Length - idx_plus - 1);
                prerelease = text.Substring(idx_minus + 1, text.Length - idx_minus - 1)
                                 .Replace($"+{build}", "");
            }
            else
            {
                throw new InvalidOperationException("Semantic Version not recognized");
            }

            return
                    (
                        major: major,
                        minor: minor,
                        patch: patch,
                        prerelease: prerelease,
                        build: build
                    );
        }

        public static
            void
            Parse01(string text)
        {
            // MatchCollection matches = re01.Matches(text);

            return;
        }

        public static
            void
            Parse02(string text)
        {
            MatchCollection matches = re03.Matches(text);

            return;
        }

        public VersionSemantic()
        {
            return;
        }

        public VersionSemantic(string version)
        {
            (
                int major,
                int minor,
                int patch,
                string prerelease,
                string build
            ) parsed = Parse(version);

            this.Major = parsed.major;
            this.Minor = parsed.minor;
            this.Patch = parsed.patch;
            this.PreRelease = parsed.prerelease;
            this.Build = parsed.build;

            return;
        }

        public int Major
        {
            get;
            set;
        }

        public int Minor
        {
            get;
            set;
        }

        public int Patch
        {
            get;
            set;
        }

        public string PreRelease
        {
            get;
            set;
        }

        public string Build
        {
            get;
            set;
        }
    }
}
