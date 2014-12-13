module ant

[<EntryPoint>]
let main argv = 
    let s (p, d, (b: Set<int*int>)) = let p = match d with | 0uy -> (fst p + 1, snd p) | 64uy -> (fst p,snd p + 1) | 128uy -> (fst p - 1, snd p) | _ -> (fst p, snd p - 1)
                                      if b.Contains(p) then (p, d + 64uy, b.Remove(p)) else (p, d - 64uy, b.Add(p))
    let repeat n f = List.fold (>>) id (List.replicate n f)
    let play a b c turns = repeat turns s (a, b, c)
    printfn "%A" (play (0,0) 0uy Set.empty 15001)
    System.Console.ReadLine() |> ignore
    0 