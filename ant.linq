<Query Kind="FSharpProgram">
  <Namespace>System.Drawing</Namespace>
</Query>

let s ((x,y), d, (b: Set<int*int>)) = let p = match d with 
										| 0uy -> (x + 1, y) 
										| 64uy -> (x, y + 1) 
										| 128uy -> (x - 1, y) 
										| _ -> (x, y - 1)
                                      if b.Contains(p) then (p, d + 64uy, b.Remove(p)) else (p, d - 64uy, b.Add(p))

let r f = List.fold (>>) id (List.replicate 15000 f)

let _,_, points = (r s ((100,100), 0uy, Set.empty))
let bitmap = new Bitmap(400,400)

points |> Seq.iter (fun (x,y) -> bitmap.SetPixel(x,y,Color.Black))
bitmap.Dump()