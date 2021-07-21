using System;

namespace HolisticWare.Xamarin.Tools.Maven
{
    public partial class Artifact
    {
        public static partial class Utilities
        {
            public static
                (string id_group, string id_artifact, string version)
                                            ParseArtifactIdFullyQualified
                                                (
                                                    string id_fully_qualified
                                                )
            {
                string[] parts1 = null;

                string id_g = null;
                string id_a = null;
                string version = null;


                parts1 = id_fully_qualified?.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                if (parts1.Length == 2)
                {
                    id_g = parts1[0];
                    id_a = parts1[1];

                    return (id_group: id_g, id_artifact: id_a, version: version);
                }
                else if (parts1.Length == 3)
                {
                    id_g = parts1[0];
                    id_a = parts1[1];
                    version = parts1[2];

                    return (id_group: id_g, id_artifact: id_a, version: version);
                }
                else if (parts1.Length == 1)
                {
                    // No Op - string did not contain ':'
                }
                else
                {
                    throw new InvalidOperationException($"Fully qualified artifact name error");
                }

                int? idx_last = id_fully_qualified?.LastIndexOf('.');

                if (idx_last == null)
                {
                    throw new ArgumentException($"Could not parse fully qualified artifact id: {id_fully_qualified}");
                }
                else
                {
                    id_g = id_fully_qualified?.Substring(0, idx_last.Value);
                    id_a = id_fully_qualified?.Substring(idx_last.Value + 1, id_fully_qualified.Length - idx_last.Value - 1);
                }

                return (id_group: id_g, id_artifact: id_a, version: version);
            }
        }
    }
}
