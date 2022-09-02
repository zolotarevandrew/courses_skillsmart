let curry f = 
  let g x =
    let h y = f x y
    h
  g

let uncurry f =
  let g x y = 
    let h = f x
    h y
  g
