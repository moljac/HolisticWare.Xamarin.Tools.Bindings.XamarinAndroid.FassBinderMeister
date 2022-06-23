using Core.Net.HTTP.IO;

namespace HolisticWare.Xamarin.Tools.ComponentGovernance
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text.Json;

    public partial class Manifest
    {
        public static partial class Defaults
        {
            static Defaults()
            {
                VersionBasedOnFullyQualifiedArtifactIdDelegate = VersionBasedOnFullyQualifiedArtifactIdDefault;
                
                Licenses = new Dictionary<string, string>();
                
                return;
            }

            public static
                Dictionary<string, string>
                                        Licenses;

            public static 
                string 
                                        VersionBasedOnFullyQualifiedArtifactIdDefault
                                        (
                                            string fully_qualified_artifact_id
                                        )
            {
                if 
                    (
                        fully_qualified_artifact_id.StartsWith("androidx")
                        ||
                        fully_qualified_artifact_id.StartsWith("com.google.android.material")
                        ||
                        fully_qualified_artifact_id.StartsWith("com.google.firebase")
                        ||
                        fully_qualified_artifact_id.StartsWith("org.jetbrains.kotlin")
                        ||
                        fully_qualified_artifact_id.StartsWith("org.jetbrains.kotlinx")
                        ||
                        fully_qualified_artifact_id.StartsWith("com.squareup")
                        ||
                        fully_qualified_artifact_id.StartsWith("io.grpc")
                    )
                {
                    const string l = "The Apache Software License, Version 2.0";
                    const string u = "https://www.apache.org/licenses/LICENSE-2.0.txt";

                    if (!Licenses.ContainsKey(l))
                    {
                        Licenses.Add(l, u);
                    }

                    return l;
                }

                if 
                    (
                        fully_qualified_artifact_id.StartsWith("com.google.android.gms")
                        ||
                        fully_qualified_artifact_id.StartsWith("com.google.android.odml")
                        ||
                        fully_qualified_artifact_id.StartsWith("com.google.android.ump")
                    )
                {
                    const string l = "Android Software Development Kit License";
                    const string u = "https://developer.android.com/studio/terms";

                    if (!Licenses.ContainsKey(l))
                    {
                        Licenses.Add(l, u);
                    }

                    return l;
                }

                if 
                    (
                        fully_qualified_artifact_id.StartsWith("org.chromium.net")
                    )
                {
                    const string l = "Chromium and built-in dependencies";
                    const string u = "https://storage.cloud.google.com/chromium-cronet/android/72.0.3626.96/Release/cronet/LICENSE";

                    if (!Licenses.ContainsKey(l))
                    {
                        Licenses.Add(l, u);
                    }

                    return l;
                }

                if 
                    (
                        fully_qualified_artifact_id.StartsWith("com.google.mlkit")
                    )
                {
                    const string l = "ML Kit Terms of Service";
                    const string u = "https://developers.google.com/ml-kit/terms";

                    if (!Licenses.ContainsKey(l))
                    {
                        Licenses.Add(l, u);
                    }

                    return l;
                }

                if
                    (
                        fully_qualified_artifact_id.StartsWith("com.google.android.play")
                    )
                {
                    const string l = "Play Core Software Development Kit Terms of Service";
                    const string u = "https://developer.android.com/guide/playcore#license";

                    if (!Licenses.ContainsKey(l))
                    {
                        Licenses.Add(l, u);
                    }

                    return l;
                }

                if 
                    (
                        fully_qualified_artifact_id.StartsWith("com.google.android.play")
                    )
                {
                    const string l = "Play Core Software Development Kit Terms of Service";
                    const string u = "https://developer.android.com/guide/playcore#license";

                    if (!Licenses.ContainsKey(l))
                    {
                        Licenses.Add(l, u);
                    }

                    return l;
                }

                if 
                    (
                        fully_qualified_artifact_id.StartsWith("com.google.android.play")
                    )
                {
                    const string l = "Play Core Software Development Kit Terms of Service";
                    const string u = "https://developer.android.com/guide/playcore#license";

                    if (!Licenses.ContainsKey(l))
                    {
                        Licenses.Add(l, u);
                    }

                    return l;
                }

                if 
                    (
                        fully_qualified_artifact_id.StartsWith("com.google.protobuf")
                    )
                {
                    const string l = "BSD 2/3 Clause";
                    const string u = "https://opensource.org/licenses/BSD-3-Clause";

                    if (!Licenses.ContainsKey(l))
                    {
                        Licenses.Add(l, u);
                    }

                    return l;
                }

                return null;
            }

            public static
                string
                                        License
            {
                get;
                set;
            }

            public static
                Func<string, string>
                                        VersionBasedOnFullyQualifiedArtifactIdDelegate;

            public static
                long
                                        Version 
            {
                get;
                set;
            }

            public static
                string 
                                        Description 
            {
                get;
                set;
            }

            public static
                string[]                LicenseDetail
            {
                get;
                set;
            }
        }
    }
}
