from pymonad.maybe import Maybe, Just, Nothing

def to_left(num):
    def inner(pair):
        l, r = pair
        return Nothing if abs((l + num) - r) > 4 else Just((l + num, r))
    return inner

def to_right(num):
    def inner(pair):
        l, r = pair
        return Nothing if abs((r + num) - l) > 4 else Just((l, r + num))
    return inner

def banana(pair):
    return Nothing

def show(maybe: Maybe):
    print(f"Just({maybe.value})" if maybe.is_just() else "Nothing")


begin = Just((0,0))

show(begin
     .bind(to_left(2))
     .bind(to_right(5))
     .bind(to_left(-2)))

show(begin
     .bind(to_left(2))
     .bind(to_right(5))
     .bind(to_left(-1)))

show(begin
     .bind(to_left(2))
     .bind(banana)
     .bind(to_right(5))
     .bind(to_left(-1)))
