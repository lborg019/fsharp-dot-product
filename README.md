# fsharp-dot-product
Program to calculate dot (scalar or inner) product of two matrices
###How to compile it?
Paste the code and run it in [Visual Studio's F# Interactive](https://msdn.microsoft.com/en-us/library/dd233175.aspx) or [SublimeText's REPL](https://github.com/wuub/SublimeREPL)

###How to run it?
I put an example in the code's comments, it works the following way:

    Dot product:
    
    [1 2 3] * [0 1] = [9  11]
    [4 5 6]   [3 2]   [21 26]
              [1 2]
              
> multiply ([[1;2;3];[4;5;6]], [[0;1];[3;2];[1;2]]);; <br/>
val it : int list list = [[9; 11]; [21; 26]]
