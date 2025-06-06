#!/usr/bin/env bash
set -e

dotnet test tests/UltraWorldAI.Tests/UltraWorldAI.Tests.csproj "$@"

