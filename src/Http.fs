module internal Fake.Azure.KuduRest.Http

open System
open System.Text
open System.Net

type HttpResult =
    | OK of string
    | Error of string * string

let private CreateToken username password = 
    sprintf "%s:%s" username password
    |> Encoding.ASCII.GetBytes
    |> Convert.ToBase64String
    |> sprintf "Basic %s"


let private httpAction token (verb:string) (url:string) =
    async {
        let request = WebRequest.CreateHttp(url);
        request.Headers.Add("Authorization", token)
        request.Method <- verb
        return! request.AsyncGetResponse()
    }

let private httpActionWithBody token (verb:string) (url:string) (content:string) =
    async {
        let request = WebRequest.CreateHttp(url);
        request.Headers.Add("Authorization", token)
        request.Method <- verb
        let stream = request.GetRequestStream()
        let bytes = Encoding.ASCII.GetBytes(content)
        stream.Write(bytes,0,bytes.Length)
        return! request.AsyncGetResponse()
    }

let private httpActionBinary token (verb:string) (url:string) (bytes:byte[]) =
    async {
        let request = WebRequest.CreateHttp(url);
        request.Headers.Add("Authorization", token)
        request.Method <- verb
        let stream = request.GetRequestStream()
        stream.Write(bytes,0,bytes.Length)
        return! request.AsyncGetResponse()
    }


type RestClient(username, password) =
    let token = CreateToken username password
    member __.Get = httpAction token "GET"
    member __.Post = httpActionWithBody token "POST"
    member __.Put = httpActionWithBody token "PUT"
    member __.PutBinary = httpActionBinary token "PUT"
    member __.Delete = httpAction token "DELETE"