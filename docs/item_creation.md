# Item Creation Process

This project uses simple immutable `Item` records. To add a new item:

1. Define the item name and any additional behaviour in `src/UltraWorldAI/Game/Item.cs`.
2. Instantiate the item and store it in an `Inventory` via `Add`.
3. Persist inventories by saving the owning `Person` or related system.

Items are lightweight and do not require registration. Inventories simply hold a list of items.
