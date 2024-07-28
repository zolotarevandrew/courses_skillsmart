def get_fibs(num):
    a, b = 0, 1
    for _ in range(num):
        yield a 
        a, b = b, a + b 

# Example usage:
for num in get_fibs(10):
    print(num)