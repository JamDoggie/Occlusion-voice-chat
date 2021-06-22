dotnet restore -r osx-x64
dotnet msbuild -t:BundleApp -p:UseAppHost=true -p:RuntimeIdentifier=osx-x64 -property:Configuration=Release
pause