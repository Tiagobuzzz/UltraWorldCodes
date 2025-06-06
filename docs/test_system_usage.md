# Test System Usage

Each subsystem under `src/UltraWorldAI` has a corresponding test file in `tests/UltraWorldAI.Tests`.
The unit tests construct the subsystem objects directly and exercise their public methods to
verify expected behaviour. Integration style tests use the `GameLoop` and helper builders to
simulate small worlds.
