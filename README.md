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
        