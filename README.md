# HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister

Fast Binding Master/Guru tool for generating binderator `config.json` files for following projects:

* AndroidX

  * https://github.com/xamarin/AndroidX
  
* Google Play Services and Firebase

  * https://github.com/xamarin/GooglePlayServicesComponents


HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister

## GitHub Client API

*   OctoKit was overkill (required API)

*   no need for API Key for few calls for tags


## NuGet Client API

*   https://docs.microsoft.com/en-us/nuget/reference/nuget-client-sdk

*   https://github.com/NuGet/NuGet.Client

*   https://github.com/nuget/home/issues
    
*   https://devblogs.microsoft.com/nuget/improved-search-syntax/

*   search API

    *   https://apisof.net/catalog/NuGet.Protocol.Core.Types.IPackageSearchMetadata

    *   https://apisof.net/catalog/NuGet.Protocol.Core.Types.SearchFilter

    *   https://github.com/NuGet/Home/issues/8719

    *   https://apisof.net/catalog/NuGet.Protocol.Core.Types.PackageSearchResource.SearchAsync(String,SearchFilter,Int32,Int32,ILogger,CancellationToken)

    *   https://scm.mbwarez.dk/tools/nuget-package-overview/blob/3dab8c9ba3d9d65c52d9036d4695e91eb6ee169a/NugetOverview/Program.cs
    
    *   https://128.39.141.180/justworks/playground/blob/168480a22f353c250ed0276af21e9b1993f40032/InternalDevTools/GitHooks/Resharper/NuGet.Protocol.xml
    
    *   https://aakinshin.net/posts/rider-nuget-search/
    
    *   https://devblogs.microsoft.com/nuget/improved-search-syntax/


## Maven 

*   POM

    *   https://maven.apache.org/guides/introduction/introduction-to-the-pom.html

    *   https://maven.apache.org/pom.html

### mavenNET

    *   https://github.com/Redth/MavenNet

    *   Google

        *   Master Index

          *   $"https://dl.google.com/android/maven2/master-index.xml"

            *   XML - no need to deserialize

                *   remove XML markup ("<", ">") and parse

          *   $"https://dl.google.com/android/maven2/{group_id_dots_replaced_with_fwdslash}/group-index.xml"

    *   Maven Central

        *   https://search.maven.org/

        *   Master Index

            *   $"https://search.maven.org/search?q=g:"

                * JSON with groups

    *   MvnRepository

        *   https://mvnrepository.com/repos
        