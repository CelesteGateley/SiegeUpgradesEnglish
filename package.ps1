#Requires -Version 7
# Builds the plugin and packs a Thunderstore zip into dist/.
# The version comes from thunderstore/manifest.json.
#   ./package.ps1                          # uses BepInExCore from Directory.Build.props
#   ./package.ps1 -BepInExCore <core dir>  # any BepInEx 5 core folder
param([string]$BepInExCore)
$ErrorActionPreference = 'Stop'
$root = $PSScriptRoot

$manifest = Get-Content "$root/thunderstore/manifest.json" -Raw | ConvertFrom-Json
$version = $manifest.version_number
if ($manifest.description.Length -gt 250) { throw "manifest.json description is $($manifest.description.Length) characters. Thunderstore allows 250." }
$icon = "$root/thunderstore/icon.png"
if (-not (Test-Path $icon)) { throw "thunderstore/icon.png is missing. Thunderstore needs a 256x256 PNG." }
# PNG header: width and height are big-endian uint32s at bytes 16 and 20.
$head = [System.IO.File]::ReadAllBytes($icon)[0..23]
$w = [System.Buffers.Binary.BinaryPrimitives]::ReadUInt32BigEndian([byte[]]$head[16..19])
$h = [System.Buffers.Binary.BinaryPrimitives]::ReadUInt32BigEndian([byte[]]$head[20..23])
if ($w -ne 256 -or $h -ne 256) { throw "thunderstore/icon.png is ${w}x${h}. Thunderstore needs exactly 256x256." }

# The csproj reads the version from manifest.json itself. DeployToProfile=false keeps a release
# build out of the local Gale profile.
$buildArgs = @('build', "$root/SiegeUpgradesEnglish.csproj", '-c', 'Release', '-p:DeployToProfile=false')
if ($BepInExCore) { $buildArgs += "-p:BepInExCore=$BepInExCore" }
dotnet @buildArgs
if ($LASTEXITCODE) { throw "dotnet build failed" }

$dist = "$root/dist"
$stage = "$dist/stage"
Remove-Item -Recurse -Force $dist -ErrorAction SilentlyContinue
New-Item -ItemType Directory -Force "$stage/plugins" | Out-Null

Copy-Item "$root/thunderstore/manifest.json", $icon, "$root/README.md", "$root/CHANGELOG.md", "$root/LICENSE" $stage
# Mod managers move plugins/* into BepInEx/plugins/<Team>-SiegeUpgradesEnglish/.
Copy-Item "$root/bin/Release/SiegeUpgradesEnglish.dll" "$stage/plugins/"

# ZipFile writes forward-slash entry names, which Thunderstore and the mod managers expect.
Add-Type -AssemblyName System.IO.Compression.FileSystem
$zip = "$dist/$($manifest.name)-$version.zip"
[System.IO.Compression.ZipFile]::CreateFromDirectory($stage, $zip)
Remove-Item -Recurse -Force $stage
Write-Host "Packed $zip"
