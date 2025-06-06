#!/bin/bash
# Converts markdown files to PDF using pandoc.
# Usage: tools/md-to-pdf.sh file.md

if [ -z "$1" ]; then
  echo "Usage: tools/md-to-pdf.sh file.md" >&2
  exit 1
fi

if ! command -v pandoc >/dev/null; then
  echo "pandoc not found" >&2
  exit 1
fi

input="$1"
output="${input%.md}.pdf"

pandoc "$input" -o "$output"
