<Query Kind="FSharpProgram">
  <Namespace>System.Drawing</Namespace>
</Query>

let s (p, d, (b: Set<int*int>)) = let p = match d with | 0uy -> (fst p + 1, snd p) | 64uy -> (fst p,snd p + 1) | 128uy -> (fst p - 1, snd p) | _ -> (fst p, snd p - 1)
                                  if b.Contains(p) then (p, d + 64uy, b.Remove(p)) else (p, d - 64uy, b.Add(p))
let r f = List.fold (>>) id (List.replicate 15001 f)

let _,_, points = (r s ((100,100), 0uy, Set.empty))
let bitmap = new Bitmap(400,400)

points |> Seq.iter (fun (x,y) -> bitmap.SetPixel(x,y,Color.Black))
bitmap.Dump()
