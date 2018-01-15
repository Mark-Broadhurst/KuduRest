module KuduRest

open System
open System.Text
open System.Net
open System.IO
open System.Net.Http

let client = new HttpClient()

let GenerateBaseUrl siteName =
    siteName
    |> sprintf "https://%s.scm.azurewebsites.net"
    |> Uri

let CreateToken username password = 
    sprintf "%s:%s" username password
    |> Encoding.ASCII.GetBytes
    |> Convert.ToBase64String
    |> sprintf "Basic %s"

let SetUpClient siteName username password =
    let baseUrl = GenerateBaseUrl siteName
    let token = CreateToken username password
    client.DefaultRequestHeaders.Add("Authorization", token)
    client.BaseAddress <- baseUrl
    client

