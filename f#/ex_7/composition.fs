// 20.3.1
let vat n x =
    let nn: int = n
    let xx: float = x
    if xx <= 0.0 || xx > 100.0 then
        float nn
    else
        float nn + ((float nn) / 100.0) * xx

// 20.3.2
let unvat n x =
    let nn: int = n
    let xx: float = x
    (float (xx - float nn) / float nn) * 100.0

// 20.3.3
let rec min f =
    let rec minInternal = function
      | (f, n: int) when f n = 0 -> n
      | (f, n: int) -> minInternal(f, n + 1)
    minInternal(f, 0)