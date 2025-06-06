# Architecture Overview

The project is organized around small subsystems under `src/UltraWorldAI`. Each subsystem encapsulates a specific aspect of gameplay such as memory, beliefs or trade mechanics. The `GameLoop` ties these pieces together and coordinates updates to persons on a `GameMap`.

Tests under `tests/UltraWorldAI.Tests` validate the behaviour of each subsystem in isolation. The diagrams in `docs/uml_overview.md` provide a high level visual perspective.
