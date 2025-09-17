from math import pi, sin as _sin

def sin(theta, state):
    return (_sin(theta), state + 1)

(x, count) = sin(pi, 0)
print(x, count)
(x, count) = sin(pi/2, count)
print(x, count)
(x, count) = sin(pi/4, count)
print(x, count)
