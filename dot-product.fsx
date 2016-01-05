let rec inner xs ys =
    match xs, ys with
    | [], [] -> 0
    | [], ys -> 0
    | xs, [] -> 0
    | x::xs, y::ys -> x * y + inner xs ys;;
    (*
        The head of the first list (xs) gets multiplied
        by the head of the second list (ys).
        We add the next call to this value and recursion
        takes care of everything.

        1 * 4 +
        2 * 4 + 
        3 * 6 = 32

        > inner [1;2;3] [4;5;6];;
        val it : int = 32
    *)

let rec combine x ys = 
    match x with 
    | [] -> []
    | [x] -> [x :: List.head ys]
    | x::xs -> [x :: List.head ys] @ (combine xs (List.tail ys))

let rec transpose = function
    | [] -> failwith "empty list does not have a transposition" 
    | [x] -> List.map (fun y -> y::[]) x
    | x::xs -> combine x (transpose xs)

let rec multiply (xs, ys) =
    match xs, ys with 
    | [[]], [[]] -> []
    | _, [] -> []
    | [], _ -> []
    | x::xs, ys -> [List.map (inner x) ((transpose(ys)))] @ multiply (xs, ys);;

    (*
        We use combine, transpose and inner for this one.
        We have to perform the inner product of the the
        first matrix with the transposed version of the
        second matrix. The problem is that transpose
        takes in a list (ys) and inner takes in the value
        of whatever is in the list (x::xs).

        In order to combine functions that work with 
        different types we have to use List.map.

        List.map (inner x) ((transpose(ys))) performs the
        inner product of the first list with the transposed
        version of the second list.

        We append the recursive call at the end with
        @ multiply (xs, ys) catch all values.

      

        [1 2 3] * [0 1] = [9  11]
        [4 5 6]   [3 2]   [21 26]
                  [1 2]

        multiply ([[1;2;3];[4;5;6]], [[0;1];[3;2];[1;2]]);;
        > val it : int list list = [[9; 11]; [21; 26]]
    *)