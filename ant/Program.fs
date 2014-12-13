module ant

type Pos = int*int
type Blacks = Set<Pos>
type Dir = byte 
type State = Pos * Dir * Blacks 

let moveInDirection pos dir = 
    let x,y = pos
    match dir with 
        | 0uy -> (x+1, y)
        | 64uy -> (x,y+1) 
        | 128uy -> (x-1, y) 
        | _ -> (x,y-1)

let turnLeft dir = dir + 64uy

let turnRight dir = dir - 64uy

let step (state : State) =
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
    printfn "%A" (play ((0,0),0uy, Set.empty) 15001)
    System.Console.ReadLine() |> ignore
    0 