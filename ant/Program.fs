﻿module ant

type Pos = int*int
type Blacks = Set<Pos>
type Dir = byte 
type State = Pos * Dir * Blacks 

let step (state : State) =
    let pos, dir, blacks = state
    let x,y = pos
    let pos = match dir with | 0uy -> (x+1, y) | 64uy -> (x,y+1) | 128uy -> (x-1, y) | _ -> (x,y-1)
    if blacks.Contains(pos) then (pos, dir + 64uy, blacks.Remove(pos)) else (pos, dir - 64uy, blacks.Add(pos))

[<EntryPoint>]
let main argv = 
    let repeat n f = List.fold (>>) id (List.replicate n f)
    let play state turns = repeat turns step state
    printfn "%A" (play ((0,0),0uy, Set.empty) 15001)
    System.Console.ReadLine() |> ignore
    0 