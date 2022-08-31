// 20.3.1
let vat n x  =
    if x <= 0.0 || x > 100.0 then
        n * 1.0
    else
        n + ((n / 100.0) * x)

// 20.3.2
let unvat n x = (float (x - n)/ n) * 100.0

// 20.3.3
let rec min f = 
    let rec minInternal = function
      | (f, n: int) when f n = 0 -> n
      | (f, n: int) -> minInternal(f, n + 1)
    minInternal(f, 0)
