param (
    [string] $MSBUILD = "C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe",
    [string] $GIT = "C:\Program Files (x86)\Git\bin\git.exe"
)

$nugetCachesDirectory = "$env:LOCALAPPDATA\NuGet\Cache"
$buildDirectory = "bin"
$solutionFile = "GildedRoseKata.sln"
$configuration = "Release"
$platform = "Any CPU"

$ErrorActionPreference = "Stop"

function Main() {
    $scriptPath = Split-Path -Parent $PSCommandPath
    Push-Location $scriptPath

    CleanWorkspace
    RestoreNugetPackages
    BuildSolution $solutionFile $configuration $platform

    Pop-Location
}

function LogImportant($message) {
    Write-Host -ForegroundColor Yellow -BackgroundColor Green $message
}

function RestoreNugetPackages() {
    LogImportant "Restoring nuget packages"

    Remove-Item $nugetCachesDirectory -Recurse -Force -ErrorAction SilentlyContinue

    $NUGET = "$env:TEMP\nuget.exe"
    if (-not (Test-Path $NUGET)) {
        Invoke-WebRequest `
            -Uri "https://www.nuget.org/nuget.exe" `
            -OutFile $NUGET
    }
    . $NUGET restore
}

function BuildSolution($solutionFile, $configuration, $platform) {
    LogImportant "Building $solutionFile using configuration = $configuration and platform = $platform"
    . $MSBUILD $solutionFile `
        /nologo `
        /target:Clean `
        /target:Build `
        /property:Configuration=$configuration `
        /property:Platform=$platform
    if (-not $?) { Write-Error "BUILD FAILED for $configuration $platform!" }
    LogImportant "Build for $solutionFile using configuration = $configuration and platform = $platform completed!"
}

function CleanWorkspace() {
    LogImportant "Cleaning workspace"
    . $GIT clean -fdx
}

Main
