#!/usr/bin/env bash
# Copies the UltraWorldAI source code into a Unity project so Unity can compile it.
# Usage: tools/export-to-unity.sh [destination]

set -e

dest=${1:-Unity/Source}

mkdir -p "$dest"
# Synchronize source code while removing files no longer present in src
rsync -a --delete src/UltraWorldAI/ "$dest/"

echo "Source code exported to $dest"
