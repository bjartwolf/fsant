module ant

[<EntryPoint>]
let main argv = 
    let step ((pos: int*int), (dir: byte), (blacks: Set<int*int>)) =
        let pos = match dir with | 0uy -> (fst pos + 1, snd pos) | 64uy -> (fst pos,snd pos + 1) | 128uy -> (fst pos - 1, snd pos) | _ -> (fst pos, snd pos - 1)
        if blacks.Contains(pos) then (pos, dir + 64uy, blacks.Remove(pos)) else (pos, dir - 64uy, blacks.Add(pos))
    let repeat n f = List.fold (>>) id (List.replicate n f)
    let play a b c turns = repeat turns step (a, b, c)
    printfn "%A" (play (0,0) 0uy Set.empty 15001)
    System.Console.ReadLine() |> ignore
    0 