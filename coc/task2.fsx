#load "core.fs"
open Core

// Тест 1:  тест, который проверяет корректность типизации полиморфной функции идентичности (id),
// для любого типа A возвращающей то же самое значение, которое получила на вход
// id : ∏ A:*. A -> A
// Тест должен проверять, что система типов правильно выводит тип этой функции как универсальный полиморфный тип (Pi-тип),
// который сначала принимает произвольный тип A,
// а затем значение этого типа, и возвращает то же самое значение неизменным.
let test4_1 () =
    let Id_Type = Pi(Star, fun A -> Pi(A, fun _ -> A))
    let Id_Type_Ann = Ann(Id_Type, Star)

    let Id_Val = Lam(fun A -> Lam(fun x -> x))
    let Id_Val_Ann = Ann(Id_Val, Id_Type)

    let id_type_res = infer 0 [] Id_Type_Ann
    let id_val_res = infer 0 [] Id_Val_Ann

    printfn "Test 4_1: Type of Id_Type: %s" (pp 0 id_type_res)
    printfn "Test 4_1: Type of Id_Val: %s" (pp 0 id_val_res)

    assert (equate 0 (id_type_res, Star))
    assert (equate 0 (id_val_res, Id_Type))


test4_1 ()
