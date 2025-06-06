#!/usr/bin/env bash
set -e

dotnet test --collect:"XPlat Code Coverage" tests/UltraWorldAI.Tests/UltraWorldAI.Tests.csproj "$@"

