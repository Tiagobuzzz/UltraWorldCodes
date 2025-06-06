# EmotionSystem and StressSystem

The `EmotionSystem` updates emotional intensities each tick. The `StressSystem` reads these values indirectly through behaviours in other subsystems. High fear or anger leads to calls to `StressSystem.AddStress`, while positive emotions eventually reduce stress. Both systems decay over time using rates configured in `AIConfig` and updated via `AISettings`.
