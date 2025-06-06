#!/bin/bash
# Usage: tools/new-test.sh TestName
name=$1
if [ -z "$name" ]; then
  echo "Usage: tools/new-test.sh TestName" >&2
  exit 1
fi
cat > tests/UltraWorldAI.Tests/${name}.cs <<FILE
using Xunit;
using UltraWorldAI;

public class ${name}
{
    [Fact]
    public void Example()
    {
        Assert.True(true);
    }
}
FILE
