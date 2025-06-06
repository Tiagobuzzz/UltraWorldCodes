```mermaid
classDiagram
    class GameLoop {
        +Run()
    }
    class GameMap {
        +Place()
        +Move()
    }
    class Person {
        +Update()
    }
    GameLoop --* GameMap
    GameLoop --> Person
```
