// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

module ant

type Pos = int*int
type Blacks = Set<Pos>
type Dir = Right | Up | Left | Down
type State = Pos * Dir * Blacks 

let moveInDirection (pos: Pos) (dir: Dir) = 
    let x,y = pos
    match dir with 
        | Right -> (x+1, y)
        | Up -> (x,y+1) 
        | Left -> (x-1, y) 
        | Down -> (x,y-1)

let turnLeft (dir:Dir) =
    match dir with
        | Right -> Up
        | Up -> Left 
        | Left -> Down
        | Down -> Right 

let turnRight(dir:Dir) =
    match dir with
        | Right -> Down 
        | Up -> Right 
        | Left -> Up 
        | Down -> Left 

let step (state : State) : State =
    let pos, dir, blacks = state
    if blacks.Contains(pos) then 
        let dir = turnRight dir  
        (moveInDirection pos dir, dir, blacks.Remove(pos))
    else  
        let dir = turnLeft dir  
        (moveInDirection pos dir, dir, blacks.Add(pos))

let rec play (state: State) (turns: int) : State = 
   if turns = 0 then state
   else play (step state) (turns - 1)

[<EntryPoint>]
let main argv = 
//    printfn "%A" (play ((0,0),Right, Set.empty) 15000)
    printfn "%A" (play ((0,0),Right, Set.empty) 15001)
    System.Console.ReadLine() |> ignore
    0 