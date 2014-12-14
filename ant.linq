<Query Kind="FSharpProgram">
  <Namespace>System.Drawing</Namespace>
</Query>

let _,_, points = List.fold(fun((x,y),d,b)_->
	let a=[|0;1;0;-1;0|] in
	let p=x+a.[d+1],y+a.[d] in
	p,(d+if b-set[p]=b then 3 else 1)%4,(b-set[p])+(set[p]-b))((100,100),0,set[])[0..15000]
let bitmap = new Bitmap(400,400)
points |> Seq.iter (fun (x,y) -> bitmap.SetPixel(x,y,Color.Black))
bitmap.Dump()