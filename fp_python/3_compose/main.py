from pymonad.tools import curry
from pymonad.reader import Compose

def attributes_str(props):
    return "" if not props else " " + " ".join(f'{k}="{v}"' for k, v in props.items())

@curry(3)
def tag(name, props, content): 
    return f"<{name}{attributes_str(props)}>{content}</{name}>"

def bold():
    return tag('b')

def italic():
    return tag('i')

@curry(3)
def attr(key: str, val: str, attrs: dict) -> dict:
    return {**attrs, key: val}

bold_attrs = (Compose(attr('class', 'test'))
              .then(attr('data-class', 'lesson-3'))
)

func = (Compose(bold()(bold_attrs({})))
        .then(italic()({'data-class': 'my'}))
        .then(bold()({}))
)

print(func('content'))
