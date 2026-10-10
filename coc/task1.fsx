#load "core.fs"
open Core

// Тест 1:  тест, проверяющий тип зависимой функции
let test1 () =
    let pi = Pi(Star, fun A -> Pi(A, fun _ -> A))
    let lam = Lam(fun A -> Lam(fun x -> x))
    let result = infer 0 [] (check 0 [] (lam, pi))
    printfn "Type of *: %s" (pp 0 result)

// Тест 2: Создайте реализацию типа Bool (булево) как Pi-тип,
// принимающий произвольный тип A и возвращающий функцию,
// которая для двух значений этого типа A выбирает одно из них (по сути реализация if-then-else на уровне типов в System Fω)
let test2 () =
    let bool_type = Pi(Star, fun A -> Pi(A, fun _ -> Pi(A, fun _ -> A)))
    let t_rue = Lam(fun A -> Lam(fun x -> Lam(fun y -> x)))
    let f_alse = Lam(fun A -> Lam(fun x -> Lam(fun y -> y)))

    let result = infer 0 [] (check 0 [] (t_rue, bool_type))
    printfn "True: Type of *: %s" (pp 0 result)

    let result = infer 0 [] (check 0 [] (f_alse, bool_type))
    printfn "False: Type of *: %s" (pp 0 result)

test1 ()
test2 ()
