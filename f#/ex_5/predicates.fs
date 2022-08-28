// 16.1
let notDivisible (n,m) = m % n = 0

// 16.2
let prime n = 
    let sqrttoint n = (int (sqrt (float n)))
    let iterations = sqrttoint(n)
    let rec primeInternal = function
      | (n, c) when n <= 1 -> false
      | (n, c) when c < 2 -> true
      | (n, c) -> notDivisible(c, n) = false && primeInternal(n, c - 1)
    primeInternal(n, iterations)