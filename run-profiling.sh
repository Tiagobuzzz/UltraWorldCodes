#!/usr/bin/env bash
set -e
# Collect CPU and memory usage while running the application
# Requires dotnet-counters tool

dotnet tool install --global dotnet-counters --version 8.* || true
export PATH="$PATH:$HOME/.dotnet/tools"

dotnet-counters collect --output cpu_mem_report.csv --format csv -- \ 
    dotnet run -c Release
