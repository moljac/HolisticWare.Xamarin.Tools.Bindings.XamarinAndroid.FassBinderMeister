//---------------------------------------------------------------------------------------
Task("nuget-pack")
    .IsDependentOn ("nuget-pack-msbuild")
    .IsDependentOn ("nuget-pack-dotnet")
	;
//---------------------------------------------------------------------------------------
Task("nuget-pack-msbuild")
    .IsDependentOn ("libs")
    .Does
    (
        () =>
        {
			MSBuildSettings settings = new MSBuildSettings()
												.WithTarget("Pack")
												.SetConfiguration("Release")
												.EnableBinaryLogger("./output/nuget-pack-msbuild.binlog")
												.WithProperty("NoBuild", "true")
												.WithProperty
													(
														"PackageOutputPath", 
														MakeAbsolute((DirectoryPath)"../../output/").FullPath
													)
												//.WithProperty("PackageVersion", NUGET_VERSION)
												;

			foreach(FilePath sln in LibrarySourceSolutions)
			{
				Information($"Solution: 	{sln}");
			}
			foreach(FilePath prj in LibrarySourceProjects)
			{
				Information($"Project: 		{prj}");
				MSBuild(prj, settings);
			}

            return;
        }
    );
//---------------------------------------------------------------------------------------
Task("nuget-pack-dotnet")
    .IsDependentOn ("libs")
    .Does
    (
        () =>
        {
			DotNetCorePackSettings settings = new DotNetCorePackSettings()
															{
																Configuration = "Release",
																NoBuild = true,
																OutputDirectory = "./output/",
																IncludeSymbols = true
															};

			foreach(FilePath sln in LibrarySourceSolutions)
			{
				Information($"Solution: 	{sln}");
			}
			foreach(FilePath prj in LibrarySourceProjects)
			{
				Information($"Project: 		{prj}");
				DotNetCorePack(prj.GetDirectory().FullPath, settings);
			}

            return;
        }
    );
//---------------------------------------------------------------------------------------
