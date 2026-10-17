#load "core.fs"
open Core

// Функция add работает следующим образом:
// - принимает два числа m и n
// - применяет m раз функцию следующего элемента
// к результату применения n раз той же функции к начальному значению
let test5 () =
    // Nat : *
    let Nat = Pi(Star, fun A -> Pi(Pi(A, fun _ -> A), fun _ -> Pi(A, fun _ -> A)))
    let Nat_ann = Ann(Nat, Star)

    // zero : Nat
    let zero = Lam(fun A -> Lam(fun s -> Lam(fun z -> z)))
    let zero_ann = Ann(zero, Nat)

    // succ : Nat -> Nat
    let succ = Lam(fun n ->
                    Lam(fun A ->
                        Lam(fun s ->
                        Lam(fun z ->
                            Appl(s, Appl(Appl(Appl(n, A), s), z))))))
    let succ_type = Pi(Nat, fun _ -> Nat)
    let succ_ann = Ann(succ, succ_type)

    // one = succ zero
    let one = Appl(succ_ann, zero_ann)

    // add
    let add_impl = Lam(fun m ->
        Lam(fun n ->
            Appl(
                Appl(Appl(m, Nat), succ_ann),
                Appl(
                    Appl(Appl(n, Nat), succ_ann),
                    zero_ann
                )
            )
        )
    )
    let add_type = Pi(Nat, fun _ -> Pi(Nat, fun _ -> Nat))
    let add_ann = Ann(add_impl, add_type)

    // Проверяем типы
    let nat_type = infer 0 [] Nat_ann
    let zero_type = infer 0 [] zero_ann
    let succ_check = infer 0 [] succ_ann
    let one_type = infer 0 [] one
    let add_type_сheck = infer 0 [] add_ann

    printfn "Test: Type of Nat: %s" (pp 0 nat_type)
    printfn "Test: Type of zero: %s" (pp 0 zero_type)
    printfn "Test: Type of succ: %s" (pp 0 succ_check)
    printfn "Test: Type of one: %s" (pp 0 one_type)
    printfn "Test: Type of add_type: %s" (pp 0 add_type_сheck)

    assert (equate 0 (nat_type, Star))
    assert (equate 0 (zero_type, Nat))
    assert (equate 0 (succ_check, succ_type))
    assert (equate 0 (add_type_сheck, add_type))
    assert (equate 0 (one_type, Nat))


test5 ()
