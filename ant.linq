<Query Kind="FSharpProgram">
  <Namespace>System.Drawing</Namespace>
</Query>

let _,_, points = (List.fold (fun ((x,y), d, b) _ -> let m x = match x % 4 with | 0 -> 1 | 2 -> -1 | _ -> 0 in let p = x + m d, y + m (d - 1) in p, d + (if Set.contains p b then 1 else 3), (b - set[p]) + (set[p] - b)) ((100,100), 0, Set.empty) [0 .. 15000])
let bitmap = new Bitmap(400,400)
points |> Seq.iter (fun (x,y) -> bitmap.SetPixel(x,y,Color.Black))
bitmap.Dump()