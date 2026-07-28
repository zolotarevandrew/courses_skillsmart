## 1. Реализуйте `GameField` как 2-тор

Здесь не внедрял изменения, поскольку в любом случае придётся оборачивать координаты.

## 2. Примените `Path` для вычисления сложных траекторий движения

```python
class ShortestPath(Path):
    def __init__(
        self,
        start: Product, # начальная точка
        end: Product, # конечная точка
        loops: Product, # количество оборотов по осям тора
        offset: Product, # нормализованное смещение,
        direction: Direction # направление
    ):
        super().__init__(start, end)
        self.loops = loops
        self.offset = offset
        self.direction = direction

def createShortestPath(start: Product, end: Product, width, height) -> ShortestPath:
    normalizedStart = _normalizePoint(start, width, height)
    normalizedEnd = _normalizePoint(end, width, height)

    loops = None
    offset = None
    shortestLen = None

    for xx in (-1,0,1):
        for yy in (-1,0,1):
            dx = normalizedEnd[0] + xx - normalizedStart[0]
            dy = normalizedEnd[1] + yy - normalizedStart[1]
            curLen = abs(dx) + abs(dy)

            if shortestLen is None or curLen < shortestLen:
                loops = Product(xx, yy)
                offset = Product(dx, dy)
                shortestLen = curLen
    direction = _direction(offset, width, height)
    return ShortestPath(start, end, loops, offset, direction)

def _normalizePoint(pos: Product, width, height):
    new_x = pos.first_value / width
    new_y = pos.second_value / height
    return (new_x, new_y)

def _direction(offset: Product, width, height) -> Direction:
    dx = round(offset.first_value * width)
    dy = round(offset.second_value * height)
    if dx > 0:
        return Direction.right()
    if dx < 0:
        return Direction.left()
    if dy > 0:
        return Direction.down()
    if dy < 0:
        return Direction.up()
    return Direction.none()
```

Далее вызываем этот метод в `calculate_path` в `GameField`:

```python
def calculate_path(self, start: Product, end: Product) -> ShortestPath:
    return createShortestPath(start, end, self.width, self.height)
```

Здесь опосредованно используем конструкцию 2-тора, но неявно.

## 3. Добавьте деморежим автоматической игры

Расширяем `game.py`: добавляем режим `demo`.

```python
def parse_arguments(argv: Optional[Sequence[str]] = None) -> argparse.Namespace:
      parser = argparse.ArgumentParser()
      parser.add_argument(
          "--demo",
          action="store_true",
          help="Run the game in demo mode"
      )
      return parser.parse_args(argv)

game_field, initial_state = initialize_game(width, height, args.demo)

initial_state = GameState(snake, food_position, 0, is_demo)
```

Расширяем `GameState`:

```python
def __init__(self, snake, food_position: Product, 
                 score: int = 0, is_demo: bool = False):
        self.entity_state = Product(snake, food_position)
        self.game_state = Product(score, is_demo)
        self.state = Product(self.entity_state, self.game_state)

def is_demo(self) -> int:
    return self.game_state.second_value
# И добавляем во все методы создания нового объекта копию self.is_demo().
```

Расширяем `renderer`:

```python
elif game_state.is_demo():
    screen.append("Demo mode enabled (uses shortest path for searching food).")
```

Расширяем `game.py`: состояние изменяется всегда, независимо от нажатой клавиши (для использования деморежима).

```python
key = term.inkey(timeout=0.01)
key_name = key.name or key if key else 'default'

current_state = game_engine.get_current_state()
new_state = input_handler.handle_input(key_name, current_state)
game_engine.set_state(new_state)
```

Расширяем `InputHandler`:

```python
class DirectionStrategy(Pi):
    def __init__(self, strategy: Callable[[GameState], Direction]):
        super().__init__(
            domain=GameState,
            codomain=lambda _: Direction,
            function=strategy
        )

def demoModeStrategy(game_field: GameField):
    def strategy(state: GameState) -> Direction:
        start = state.get_snake().get_head()
        end = state.get_food_position()
        path = game_field.calculate_path(start, end)
        return path.direction
    return strategy
```

Расширяем конструктор:

```python
def __init__(self, game_field: GameField, initial_state: GameState):
        self.direction_strategy = self._create_direction_strategy(game_field, initial_state)
        self.key_mapping = self._create_key_mapping()

    def _create_direction_strategy(self, game_field: GameField, initial_state: GameState):
        if initial_state.is_demo():
            return DirectionStrategy(demoModeStrategy(game_field))
        return None
```

Изменяем `handle_input`:

```python
if self.direction_strategy is not None:
            direction = self.direction_strategy(state)
            return self._change_direction(state, direction)
```

## Итоги

1. Встраивание в `InputHandler` получилось странным: всё равно остаются костыли со стратегией в `handle_input`. Совсем неочевидно, что внутри ввод может игнорироваться; к тому же смешали ввод с деморежимом. Преимущество — инкапсуляция этой логики внутри, без костылей снаружи.

   Чуть правильнее было бы создать отдельные `DemoInputHandler` и `UserInputHandler`, а также сделать отдельный фабричный метод вместо конструктора в `InputHandler`:

   - для `DemoInputHandler` — в `handleinput` просто вызывать автоматический переход по рассчитанному пути, а при вводе клавиш `p` и `q` дополнительно обрабатывать паузу и выход;
   - для `UserInputHandler` — обрабатывать клавиши ввода.

   Тогда смысл стратегии пропадает. Пока непонятно, зачем она могла бы понадобиться в будущем: нет опыта в игровой индустрии.

2. Не придумал, как можно приблизить `GameField` к `NTorus`: он по-прежнему не используется. Единственная связь получилась с `ShortestPath`, но и это кастомный класс реализации.

3. В деморежиме не проверяем, может ли змейка натолкнуться на себя.

4. Композиция путей не внедрена, но могла бы понадобиться для более сложных сценариев. Для каких именно — тоже не придумал.
