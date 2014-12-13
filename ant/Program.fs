module ant

[<EntryPoint>]
let main argv = 
    let s ((x,y), d, (b: Set<int*int>)) = let p = match d with | 0uy -> (x + 1, y) | 64uy -> (x, y + 1) | 128uy -> (x - 1, y) | _ -> (x, y - 1)
                                          if b.Contains(p) then (p, d + 64uy, b.Remove(p)) else (p, d - 64uy, b.Add(p))
    let r f = List.fold (>>) id (List.replicate 15001 f)
    printfn "%A" (r s ((0,0), 0uy, Set.empty))
    System.Console.ReadLine() |> ignore
    0 