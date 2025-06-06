# Data Compression Considerations

Large save files can be written using the `.gz` extension, which triggers compression in `MemorySystem.SaveMemories`.
Monitor file sizes and enable compression when they exceed several megabytes.
