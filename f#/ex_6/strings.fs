// 17.1
let rec pow = function
  | (s, n) when n = 1 -> s
  | (s, n) -> s + pow(s, n - 1)

// 17.2
let rec isIthChar = function
  | (s: string, n, c) -> s.[n] = c

// 17.3
let rec occFromIth = function
  | (s: string, n, c) when n > String.length s -> 0
  | (s: string, n, c) when isIthChar(s, n, c) -> 1 + occFromIth(s, n + 1, c)
  | (s: string, n, c) -> 0 + occFromIth(s, n + 1, c)