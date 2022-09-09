// 39.1
let rec rmodd = function
  | [] -> []
  | [ _ ] -> []
  | [ x; y ] -> [y]
  | f1::f2::tail -> f2 :: rmodd tail
     
// 39.2
let rec del_even lst = 
    let rec _del = function
      | [] -> []
      | head::tail -> if head % 2 = 0 then _del tail
                      else head :: (_del tail)
    _del lst

// 39.3
let rec multiplicity x xs = 
    let rec _mul = function
      | [] -> 0
      | head::tail -> if head = x then 1 + _mul tail
                      else _mul tail
    _mul xs

// 39.4
let rec split x = 
    let rec _split lst ar1 ar2 = 
        match lst with
          | [] -> ar1, ar2
          | [x] -> ar1 @ [x], ar2
          | [x; y] -> ar1 @ [x], ar2 @ [y]
          | first::second::tail -> _split tail (ar1 @ [first]) (ar2 @ [second])
    _split x [] []

exception ListLengthMismatch

// 39.5
let rec zip (xs1,xs2) = 
  if List.length xs1 <> List.length xs2 then raise ListLengthMismatch

  let rec _zip left right =
    match left, right with 
     | [], [] -> []
     | x::xs, y::ys -> (x, y) :: _zip xs ys
  _zip xs1 xs2

multiplicity 1 [1;1;1;1;2]