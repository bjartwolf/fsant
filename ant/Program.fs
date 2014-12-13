module ant

[<EntryPoint>]
let main argv = 
    let s ((pos: int*int), dir , (b: Set<int*int>)) =
        let pos = match dir with | 0uy -> (fst pos + 1, snd pos) | 64uy -> (fst pos,snd pos + 1) | 128uy -> (fst pos - 1, snd pos) | _ -> (fst pos, snd pos - 1)
        if b.Contains(pos) then (pos, dir + 64uy, b.Remove(pos)) else (pos, dir - 64uy, b.Add(pos))
    let repeat n f = List.fold (>>) id (List.replicate n f)
    let play a b c turns = repeat turns s (a, b, c)
    printfn "%A" (play (0,0) 0uy Set.empty 15001)
    System.Console.ReadLine() |> ignore
    0 