module KuduRest.Http

open System
open System.Text
open System.Net
open System.IO

type HttpResult =
    | OK of string
    | Error of string * string

let private CreateToken username password = 
    sprintf "%s:%s" username password
    |> Encoding.ASCII.GetBytes
    |> Convert.ToBase64String
    |> sprintf "Basic %s"

let unpackResponse (response:WebResponse) =
    let httpResponse = response :?> HttpWebResponse
    use stream = response.GetResponseStream()
    use reader = new StreamReader(stream)
    let content = reader.ReadToEnd()
    if httpResponse.StatusCode = HttpStatusCode.OK
    then OK(content)
    else Error(httpResponse.StatusCode.ToString(), content)

let private httpAction token (verb:string) (url:string) =
    let request = WebRequest.CreateHttp(url);
    request.Headers.Add("Authorization", token)
    request.Method <- verb
    request.GetResponse()
    |> unpackResponse

let private httpActionWithBody token (verb:string) (url:string) (content:string) =
    let request = WebRequest.CreateHttp(url);
    request.Headers.Add("Authorization", token)
    request.Method <- verb
    let stream = request.GetRequestStream()
    let bytes = Encoding.ASCII.GetBytes(content)
    stream.Write(bytes,0,bytes.Length)
    request.GetResponse()
    |> unpackResponse

let private httpActionBinary token (verb:string) (url:string) (bytes:byte[]) =
    let request = WebRequest.CreateHttp(url);
    request.Headers.Add("Authorization", token)
    request.Method <- verb
    let stream = request.GetRequestStream()
    stream.Write(bytes,0,bytes.Length)
    request.GetResponse()
    |> unpackResponse

type RestClient(username, password) =
    let token = CreateToken username password
    member __.Get = httpAction token "GET"
    member __.Post = httpActionWithBody token "POST"
    member __.Put = httpActionWithBody token "PUT"
    member __.PutBinary = httpActionBinary token "PUT"
    member __.Delete = httpAction token "DELETE"