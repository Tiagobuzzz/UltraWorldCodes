# Unreal Engine Integration

While UltraWorldAI targets .NET 8 and is primarily used with Unity, it can also integrate with Unreal Engine via a C# plugin such as UnrealCLR.

1. Build the UltraWorldAI library in Release mode:
   ```bash
   dotnet build -c Release src/UltraWorldAI/UltraWorldAI.csproj
   ```
2. Copy the generated `UltraWorldAI.dll` from `src/UltraWorldAI/bin/Release/net8.0/` into your Unreal project's managed plugin folder (e.g. `Plugins/UnrealCLR/Managed`).
3. Ensure your C# plugin references `UltraWorldAI.dll` so Unreal can invoke the library.
4. In your Unreal scripts, you can now call methods under the `UltraWorldAI` namespace.

When updating the library, rebuild the DLL and replace it in your Unreal project. Alternatively, copy the source files from `src/UltraWorldAI` into the plugin's managed folder if you prefer the plugin to compile them directly.
