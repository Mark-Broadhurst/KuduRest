module internal Fake.Azure.KuduRest.Http

open System
open System.Text
open System.Net

type HttpResult =
    | OK of string
    | Error of string * string

let CreateToken username password = 
    sprintf "%s:%s" username password
    |> Encoding.ASCII.GetBytes
    |> Convert.ToBase64String
    |> sprintf "Basic %s"

let private httpAction (verb:string) (url:string) token (content:string) =
    async {
        let request = WebRequest.CreateHttp(url);
        request.Headers.Add("Authorization", token)
        request.Method <- verb
        let stream = request.GetRequestStream()
        let bytes = Encoding.ASCII.GetBytes(content)
        stream.Write(bytes,0,bytes.Length)
        return! request.AsyncGetResponse()
    }

let Get = 
    httpAction "GET"

let Post = 
    httpAction "POST"

let Put = 
    httpAction "PUT"

let Delete =
    httpAction "DELETE"