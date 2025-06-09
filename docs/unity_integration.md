# Unity Integration

This project targets .NET 8 and can be imported into Unity as a managed plugin. Follow these steps to create a DLL that Unity can reference:

1. Build the library in Release mode:
   ```bash
   dotnet build -c Release src/UltraWorldAI/UltraWorldAI.csproj
   ```
2. Copy the generated `UltraWorldAI.dll` from `src/UltraWorldAI/bin/Release/net8.0/` into your Unity project's `Assets/Plugins` folder.
3. In Unity, create an Assembly Definition file that references `UltraWorldAI.dll` if you plan to compile scripts separately.
4. Ensure your Unity project is set to use the `Mono` scripting backend or a version of `IL2CPP` that supports .NET 8 assemblies.

Because the project uses modern .NET features, older versions of Unity may not load the DLL. Unity 2022.3 and newer is recommended.

### Copying Source Code Without Building

If you prefer to have Unity compile the library directly, run:

```bash
tools/export-to-unity.sh /path/to/your/UnityProject/Assets/UltraWorldAI
```

This script copies all source files under `src/UltraWorldAI` to the specified
destination. Unity will compile these scripts on the next refresh.
