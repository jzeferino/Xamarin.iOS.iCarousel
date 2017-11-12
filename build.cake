#addin nuget:?package=Cake.SemVer&version=2.0.0
#addin nuget:?package=semver&version=2.0.4

// Enviroment
var isRunningBitrise = Bitrise.IsRunningOnBitrise;

// Arguments.
var target = Argument("target", "Default");
var configuration = "Release";

// Define directories.
var solutionFile = new FilePath("Xamarin.iOS.iCarousel.sln");
var libProject = new FilePath("src/Xamarin.iOS.iCarousel.Binding/Xamarin.iOS.iCarousel.Binding.csproj");
var artifactsDirectory = new DirectoryPath("artifacts");

// Versioning.
var version = CreateSemVer(1, 8, 4);

Setup((context) =>
{
	Information("Bitrise: {0}", isRunningBitrise);
	Information("Configuration: {0}", configuration);
});

Task("Clean")
	.Does(() =>
	{	
		CleanDirectory(artifactsDirectory);

		DotNetBuild(solutionFile, settings => settings
				.SetConfiguration(configuration)
				.WithTarget("Clean")
				.SetVerbosity(Verbosity.Minimal));
	});

Task("Restore")
	.Does(() => 
	{
		NuGetRestore(solutionFile);
	});

Task("Build")
	.IsDependentOn("Clean")
	.IsDependentOn("Restore")
	.Does(() =>  
	{	
		DotNetBuild(libProject, settings => settings
					.SetConfiguration(configuration)
					.WithTarget("Build")
					.SetVerbosity(Verbosity.Minimal));
	});

Task ("NuGet")
	.IsDependentOn ("Build")
	.WithCriteria(isRunningBitrise)
	.Does (() =>
	{
		Information("Nuget version: {0}", version);
		
  		var nugetVersion = Bitrise.Environment.Repository.GitBranch == "master" ? version.ToString() : version.Change(prerelease: "pre" + Bitrise.Environment.Build.BuildNumber).ToString();
		
		NuGetPack ("./nuspec/Xamarin.iOS.iCarousel.nuspec", 
			new NuGetPackSettings 
				{ 
					Version = nugetVersion,
					Verbosity = NuGetVerbosity.Normal,
					OutputDirectory = artifactsDirectory,
					BasePath = "./",
					ArgumentCustomization = args => args.Append("-NoDefaultExcludes")		
				});	
	});

Task("Default")
	.IsDependentOn("NuGet")
	.Does(() => {});

RunTarget(target);