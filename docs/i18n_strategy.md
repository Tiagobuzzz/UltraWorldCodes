# Internationalization Strategy

All user facing strings should be looked up via `LocalizationManager`.
Translations are stored as JSON files under `locales/<lang>.json`.
The manager falls back to English when a key is missing.
