type TimeOfDay = { hours: int; minutes: int; f: string }

let (.>.) x y = 
  let fixT (x, t) = 
    if t = "AM" then x + 0
    elif t = "PM" then x + 12
    else x
  let { hours = _h1; minutes = m1; f = f1 } = x
  let { hours = _h2; minutes = m2; f = f2 } = y
  (fixT(_h1, f1) * 60 + m1) > (fixT(_h2, f2) * 60 + m2)
