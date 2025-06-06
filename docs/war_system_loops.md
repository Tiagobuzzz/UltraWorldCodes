# Infinite Loop Mitigation in War System

The current war simulation iterates over active conflicts each tick. To avoid endless battles, ensure that battle outcomes reduce the remaining forces on at least one side. Add unit tests when introducing new logic that could create loops.
