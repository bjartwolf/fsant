module ant

[<EntryPoint>]
let main argv = 
    let step ((pos: int*int), (dir: byte), (blacks: Set<int*int>)) =
        let x,y = pos
        let pos = match dir with | 0uy -> (x+1, y) | 64uy -> (x,y+1) | 128uy -> (x-1, y) | _ -> (x,y-1)
        if blacks.Contains(pos) then (pos, dir + 64uy, blacks.Remove(pos)) else (pos, dir - 64uy, blacks.Add(pos))
    let repeat n f = List.fold (>>) id (List.replicate n f)
    let play a b c turns = repeat turns step (a, b, c)
    printfn "%A" (play (0,0) 0uy Set.empty 15001)
    System.Console.ReadLine() |> ignore
    0 