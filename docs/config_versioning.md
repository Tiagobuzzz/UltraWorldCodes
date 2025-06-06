# Configuration Versioning

Configuration files such as `AIConfig.json` may evolve between releases. Add a `Version` field at the root of the JSON and increment it when the structure changes. Loaders should check the version and apply migrations if needed.
