// 20.3.1
let vat n x =
    if n <= 0 || n > 100 then
        x
    else
        x + (x / 100.0) * float n

// 20.3.2
let unvat n x =
    if n <= 0 || n > 100 then
        x
    else
        (x / (100.0 + float n )) * 100.0

// 20.3.3
let rec min f =
    let rec minInternal = function
      | (f, n: int) when f n = 0 -> n
      | (f, n: int) -> minInternal(f, n + 1)
    minInternal(f, 0)