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
            public static
                string
                                        License
            {
                get;
                set;
            }

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
