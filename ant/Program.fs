module ant

[<EntryPoint>]
let main argv = 
    List.fold(fun((x,y),d,b)_->let m=List.nth[0;1;0;-1;0]in let p=x+m(d+1),y+m d in p,(d+if b-set[p]=b then 3 else 1)%4,(b-set[p])+(set[p]-b))((100,100),0,set[])[0..15000] |> printfn "%A" 
    System.Console.ReadLine() |> ignore
    0 