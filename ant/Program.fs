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

[<EntryPoint>]
let main argv = 
    let repeat n f = List.fold (>>) id (List.replicate n f)
    let play state turns = repeat turns step state
    printfn "%A" (play ((0,0),Right, Set.empty) 15001)
    System.Console.ReadLine() |> ignore
    0 