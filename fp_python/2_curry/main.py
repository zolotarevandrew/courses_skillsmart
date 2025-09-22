from pymonad.tools import curry

@curry(2)
def concat(x, y): 
    return x + y

def hello(str):
    return concat('Hello')(', ' + str)

print(hello('World'))

@curry(4)
def extendedHello(hello, separator, finalSign, name):
    return hello + separator + ' ' + name + finalSign

final = extendedHello("Hello")(",")("!")
print(final("Petya"))