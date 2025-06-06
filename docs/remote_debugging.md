# Remote Debugging

1. Build the project in Debug configuration and deploy binaries to the target machine.
2. Use `dotnet --listen 0.0.0.0:9229` to start the application with remote debugging enabled.
3. Attach your IDE to the published port and set breakpoints as usual.
