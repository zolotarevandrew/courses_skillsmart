from core.path import Path



# Не стал пока что отделять отдельный базовый класс LoopPath, необходимости в нем не было

class LoopCount:
    def __init__(self, count: int):
        self._count = count

    def inv(self):
        return LoopCount(-self._count)

    def merge(self, other: LoopCount) -> LoopCount:
        return LoopCount(self._count + other._count)

# Здесь скорее всего по-умолчанию, если не указан count, нужно создавать с LoopCount = 1
class CircleLoop(Path):
    def __init__(self, base, count: LoopCount):
        self._count = count
        super().__init__(base, base)

    @classmethod
    def refl(cls, base):
        return cls(base, LoopCount(0))

    def trans(self, other):
        is_valid = (
            type(self) is type(other) and
            self.start == other.start
        )
        if not is_valid:
            raise ValueError("Invalid base points")

        return CircleLoop(
            self.start,
            self.count.merge(other.count)
        )

    def sym(self):
        return CircleLoop(
            self.start,
            self.count.inv()
        )

