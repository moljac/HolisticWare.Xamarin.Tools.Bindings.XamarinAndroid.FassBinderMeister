#load "./../private-protected-sensitive/externals.private.cake"
#load "./../common/nuget-restore.cake"

//---------------------------------------------------------------------------------------
Task ("externals")
    .IsDependentOn ("externals-build")
    .IsDependentOn ("externals-build-submodules")
    // .WithCriteria (!FileExists ("./externals/HolisticWare.Core.Math.Statistics.aar"))
    .Does
    (
        () =>
        {
            return;
        }
    );

Task("externals-build")
    .Does
    (
        () =>
        {
            return;
        }
    );

Task("externals-build-submodules")
    .Does
    (
        () =>
        {
            FilePathCollection files = GetFiles("./external*-submodule*/**/build.cake");
            foreach(FilePath file in files)
            {
                Information("File: {0}", file);
                CakeExecuteScript
                    (
                        file,
                        new CakeSettings
                        {
                            Verbosity = Verbosity.Diagnostic,
                            Arguments = new Dictionary<string, string>()
                            {
                                //{ "verbosity",     "diagnostic"},
                                { "target",          "nuget-pack"},
                            },
                        }
                    );
            }

            return;
        }
    );


public partial class Externals
{
    static partial void ExedcutePrivateSensitive();

    public static void Execute()
    {
    }

    private static ICakeContext context = null;

    public static void Initialize(ICakeContext c)
    {
        context = c;

        return;
    }

}
//---------------------------------------------------------------------------------------
