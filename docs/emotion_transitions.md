# Emotional State Transitions

This document describes how emotions decay and interact in the simulation.
Each emotion value is updated on every tick by `EmotionSystem.UpdateEmotionsDecay`.
The decay rates are defined in `AIConfig` and can be reloaded at runtime via `AISettings.Reload`.
