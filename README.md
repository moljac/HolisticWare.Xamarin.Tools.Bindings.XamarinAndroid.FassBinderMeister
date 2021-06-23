# HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister

Fast Binding Master/Guru tool for 

  * maven artifact discovery

  * nuget detection

  * .Net project creation
  
  * generating binderator `config.json` files for following projects:

## Maven Artifact

### Repository

root

* google

  * https://maven.google.com/web/index.html

  ```csharp
  string url_root = $"https://dl.google.com/android/maven2/";
  ```

* maven central

  * https://search.maven.org/

  * https://search.maven.org/classic/

    * Browse

      * https://repo1.maven.org/maven2/
  
  ```csharp
  string url_root = $"https://repo1.maven.org/maven2/";
  ```

### Master index

* google

  * available

  * list of group_ids in xml


  * https://dl.google.com/android/maven2/master-index.xml

  ```csharp
  string url_master_index = $"{url_root}/master-index.xml";
  ```

* maven central

  * NOT available

    * HTML response must be parsed
  
  ```csharp
  string url_master_index = $"{url_root}/";
  ```


### Group

group metadata discovery

* google

  ```csharp
  string group_id = "androidx.ads";
  string url_group_id = $"{url_root}/{group_id.Replace(".", "/")}/group-index.xml";
  ```

* maven central

  ```csharp
  string group_id = "io.opencensus";
  string url_group_id = $"{url_root}/{group_id.Replace(".", "/"}}";
  ```


### Artifact

* google

  ```
  string group_id = "androidx.ads";
  string url_group_id = $"{url_root}/{group_id.Replace(".", "/"}}/group-index.xml
  ```
https://dl.google.com/android/maven2/androidx/ads/ads-identifier/1.0.0-alpha04/ads-identifier-1.0.0-alpha04.aar

## Xamarin.Android Bindings

### Repos

* AndroidX

  * https://github.com/xamarin/AndroidX

* Google Play Services and Firebase

  * https://github.com/xamarin/GooglePlayServicesComponents


HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister

## GitHub Client API

*   OctoKit was overkill (required API)

*   no need for API Key for few calls for tags

## NuGet Server API (REST)

*   https://docs.microsoft.com/en-us/nuget/api/overview

### REST API

```
GET {@id}/{LOWER_ID}/index.json
```

#### Index

https://api.nuget.org/v3/index.json

#### Service Index

https://api.nuget.org/v3-flatcontainer/owin/index.json

https://api.nuget.org/v3-flatcontainer/xamarin.androidx.car.car/index.json

#### Search

```
GET {@id}?q={QUERY}&skip={SKIP}&take={TAKE}&prerelease={PRERELEASE}&semVerLevel={SEMVERLEVEL}&packageType={PACKAGETYPE}
```

https://azuresearch-usnc.nuget.org/query?q=androidx&prerelease=false&semVerLevel=1.0.0

https://api.nuget.org/v3/registration5-gz-semver1/xamarin.androidx.core/1.3.2.3.json

https://azuresearch-usnc.nuget.org/query?q=androidx&prerelease=false&semVerLevel=1.0.0

https://api.nuget.org/v3/registration5-gz-semver2/xamarin.androidx.core/1.3.2.3.json

```
GET {@id}/{LOWER_ID}/{LOWER_VERSION}/{LOWER_ID}.nuspec
```

https://api.nuget.org/v3-flatcontainer/newtonsoft.json/6.0.4/newtonsoft.json.nuspec

https://api.nuget.org/v3-flatcontainer/xamarin.androidx.car.car/1.0.0-alpha7/xamarin.androidx.car.car.json.nuspec

#### Autocomplete

```
GET {@id}?id={ID}&prerelease={PRERELEASE}&semVerLevel={SEMVERLEVEL}
```

https://api-v2v3search-0.nuget.org/autocomplete?q=androidx&prerelease=true

https://api-v2v3search-0.nuget.org/autocomplete?q=mlkit&prerelease=true

#### Package Details

https://www.nuget.org/packages/{id}/{version}

https://www.nuget.org/packages/newtonsoft.json/9.0.1

https://www.nuget.org/packages/xamarin.androidx.car.car/1.0.0-alpha7

https://api.nuget.org/v3/v3-flatcontainer/xamarin.androidx.car.car/index.json

https://api.nuget.org/v3/registration3/ravendb.client/page/1.0.531/1.0.729-unstable.json



#### Download

GET {@id}/{LOWER_ID}/{LOWER_VERSION}/{LOWER_ID}.{LOWER_VERSION}.nupkg

https://api.nuget.org/v3-flatcontainer/newtonsoft.json/9.0.1/newtonsoft.json.9.0.1.nupkg


## NuGet Client API

*   https://docs.microsoft.com/en-us/nuget/reference/nuget-client-sdk

*   https://github.com/NuGet/NuGet.Client

*   https://github.com/nuget/home/issues

*   https://devblogs.microsoft.com/nuget/improved-search-syntax/

*   samples

    *   https://github.com/NuGet/Samples/blob/main/NuGetProtocolSamples/Program.cs

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


## Serialization

### JSON

*   `System.Text.Json`

    *   https://blog.fractalia.se/blog/keeping-system-text-json-lean/

*   `Newtonsoft.Json`

### Protobuffers

*   https://www.ben-morris.com/protocol-buffers-protobuf-net-vs-protobuf-csharp-port/

### Binary

*   https://docs.microsoft.com/en-us/dotnet/standard/serialization/binary-serialization



# For cleanup

## Bintray


https://bintray.com/bintray/jcenter/com.microsoft.identity%3Acommon/3.0.9

*   https://bintray.com/bintray/jcenter/com.microsoft.identity%3Acommon/3.0.9#files/com/microsoft/identity/common


## Maven Central

com.microsoft.identity:common

https://search.maven.org/artifact/com.microsoft.identity/common

https://search.maven.org/artifact/com.microsoft.identity/common/3.0.9/aar




Apache Maven
maven.apache.org
<dependency>
  <groupId>com.microsoft.identity</groupId>
  <artifactId>common</artifactId>
  <version>3.0.9</version>
  <type>aar</type>
</dependency>
Gradle Groovy DSL
gradle.org
implementation 'com.microsoft.identity:common:3.0.9'
Gradle Kotlin DSL
github.com/gradle/kotlin-dsl
implementation("com.microsoft.identity:common:3.0.9")
Scala SBT
scala-sbt.org
libraryDependencies += "com.microsoft.identity" % "common" % "3.0.9"
Apache Ivy
ant.apache.org/ivy/
<dependency org="com.microsoft.identity" name="common" rev="3.0.9" />
Groovy Grape
groovy-lang.org/grape.html
@Grapes(
  @Grab(group='com.microsoft.identity', module='common', version='3.0.9')
)
Leiningen
leiningen.org
[com.microsoft.identity/common "3.0.9"]
Apache Buildr
buildr.apache.org
'com.microsoft.identity:common:jar:3.0.9'
Maven Central Badge
search.maven.org
[![Maven Central](https://img.shields.io/maven-central/v/com.microsoft.identity/common.svg?label=Maven%20Central)](https://search.maven.org/search?q=g:%22com.microsoft.identity%22%20AND%20a:%22common%22)
PURL
github.com/package-url/purl-spec
pkg:maven/com.microsoft.identity/common@3.0.9
Bazel
bazel.build
maven_jar(
    name = "common",
    artifact = "com.microsoft.identity:common:3.0.9",
    sha1 = "calculating...",
)


## `dotnet tool`

*   NuGet

*   Maven


https://docs.microsoft.com/en-us/dotnet/core/tools/global-tools

https://weblog.west-wind.com/posts/2020/Aug/05/Using-NET-Core-Tools-to-Create-Reusable-and-Shareable-Tools-Apps

https://docs.microsoft.com/en-us/dotnet/core/tools/global-tools-how-to-create


### Samples

*   https://github.com/xamarin/XamarinComponents/tree/master/Util/Xamarin.AndroidBinderator/Xamarin.AndroidBinderator.Tool

*   https://github.com/dotnet/aspnetcore/tree/main/src/Tools

https://docs.microsoft.com/en-us/dotnet/core/diagnostics/#net-core-diagnostic-global-tools