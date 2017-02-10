module KuduRest.Http

open System
open System.Text
open System.Net
open System.IO

let private CreateToken username password = 
    sprintf "%s:%s" username password
    |> Encoding.ASCII.GetBytes
    |> Convert.ToBase64String
    |> sprintf "Basic %s"

let streamToString (stream:Stream) = 
    use reader = new StreamReader(stream)
    reader.ReadToEnd()

let streamToBytes (stream:Stream) =
    use ms = new MemoryStream()
    stream.CopyTo(ms);
    ms.ToArray()

let unpackResponse (unpack: Stream -> 'A) (response:WebResponse) =
    let httpResponse = response :?> HttpWebResponse
    let stream = httpResponse.GetResponseStream()
    if httpResponse.StatusCode = HttpStatusCode.OK
    then Choice1Of2(unpack stream)
    else Choice2Of2(httpResponse.StatusCode.ToString(), streamToString stream)

let private httpAction token (verb:string) (url:string) =
    let request = WebRequest.CreateHttp(url)
    request.Headers.Add("Authorization", token)
    request.Method <- verb
    request.GetResponse()

let private httpActionWithBody token (verb:string) (url:string) (content:string) =
    let request = WebRequest.CreateHttp(url)
    request.Headers.Add("Authorization", token)
    request.Method <- verb
    let stream = request.GetRequestStream()
    let bytes = Encoding.ASCII.GetBytes(content)
    stream.Write(bytes,0,bytes.Length)
    request.GetResponse()

let private httpActionBinary token (verb:string) (url:string) (bytes:byte[]) =
    let request = WebRequest.CreateHttp(url);
    request.Headers.Add("Authorization", token)
    request.Method <- verb
    let stream = request.GetRequestStream()
    stream.Write(bytes,0,bytes.Length)
    request.GetResponse()

type RestClient(username, password) =
    let token = CreateToken username password
    member __.Get = httpAction token "GET"
    member __.Post = httpActionWithBody token "POST"
    member __.Put = httpActionWithBody token "PUT"
    member __.PutBinary = httpActionBinary token "PUT"
    member __.Delete = httpAction token "DELETE"