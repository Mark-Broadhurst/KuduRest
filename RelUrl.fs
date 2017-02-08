module internal Fake.Azure.KuduRest.Url

open Fake.Azure.KuduRest.Http

type HttpResult =
    | OK of string
    | Error of string * string

let siteRoot siteName =
    sprintf "https://%s.scm.azurewebsites.net" siteName

let scmInfo baseUrl = 
    Get (sprintf "%s/api/scm/info" baseUrl)
let scmClean baseUrl = 
    Post (sprintf "%s/api/scm/info" baseUrl)
let scmDelete baseUrl = 
    Delete (sprintf "%s/api/scm" baseUrl)
let command baseUrl =
    Post (sprintf "%s/api/command" baseUrl)
let vfsGetFile baseUrl path = 
    Get (sprintf "%s/api/vfs/%s" baseUrl path)
let vfsPutFile baseUrl path = 
    Put (sprintf "%s/api/vfs/%s" baseUrl path)
let vfsDeleteFile baseUrl path = 
    Delete (sprintf "%s/api/vfs/%s" baseUrl path)
let zipGet baseUrl path =
    Get (sprintf "%s/api/zip/%s" baseUrl path)
let zipPut baseUrl path = 
    Put (sprintf "%s/api/zip/%s" baseUrl path)
let deploymentsList baseUrl = 
    Get (sprintf "%s/api/deployments" baseUrl)
let deploymentGet baseUrl deploymentId = 
    Get (sprintf "%s/api/deployments/%s" baseUrl deploymentId)
let deploymentPut baseUrl deploymentId =
    Put (sprintf "%s/api/deployments/%s" baseUrl deploymentId)
let deploymentDelete baseUrl deploymentId =
    Delete (sprintf "%s/api/deployments/%s" baseUrl deploymentId)
let deploymentLogGet baseUrl deploymentId =
    Get (sprintf "%s/api/deployments/%s/log" baseUrl deploymentId)
let deploymentLogGetLogId baseUrl deploymentId logId =
    Get (sprintf "%s/api/deployments/%s/log/%s" baseUrl deploymentId logId)
let deployPost baseUrl =
    Post (sprintf "%s/deploy" baseUrl)
let sshGetGenertate baseUrl = 
    Get (sprintf "%s/api/sshkey?ensurePublicKey=1" baseUrl)
let sshGet baseUrl = 
    Put (sprintf "%s/api/sshkey" baseUrl)
let sshGetPublicKey baseUrl = 
    Get (sprintf "%s/api/sshkey" baseUrl)
let kuduVersion baseUrl = 
    Get (sprintf "%s/api/environment" baseUrl)
let settingsPost baseUrl = 
    Post (sprintf "%s/api/settings" baseUrl)
let settingsGet baseUrl = 
    Get (sprintf "%s/api/settings" baseUrl)
let settingsGetKey baseUrl key = 
    Get (sprintf "%s/api/settings/%s" baseUrl key)
let settingsDeleteKey baseUrl key =
    Delete (sprintf "%s/api/settings/%s" baseUrl key)
let diagnostics baseUrl =
    Get (sprintf "%s/api/dump" baseUrl)
let diagnosticsSettingsPost baseUrl =
    Post (sprintf "%s/api/diagnostics/settings" baseUrl)
let diagnosticsSettingsGet baseUrl =
    Get (sprintf "%s/api/diagnostics/settings" baseUrl)
let diagnosticsSettingsGetKey baseUrl key =
    Get (sprintf "%s/api/diagnostics/settings/%s" baseUrl key)
let diagnosticsSettingsDeleteKey baseUrl key =
    Delete (sprintf "%s/api/diagnostics/settings/%s" baseUrl key)
let logs baseUrl =
    Get (sprintf "%s/api/logs/recent" baseUrl)
let listExtentionFeed baseUrl =
    Get (sprintf "%s/api/extensionfeed" baseUrl)
let listSiteExtentions baseUrl =
    Get (sprintf "%s/api/siteextensions" baseUrl)
let listExtentionFeedId baseUrl id =
    Get (sprintf "%s/api/extensionfeed/%s" baseUrl id)
let listSiteExtentionsId baseUrl id =
    Get (sprintf "%s/api/siteextensions/%s" baseUrl id)
let installSiteExtention baseUrl id =
    Put (sprintf "%s/api/siteextensions/%s" baseUrl id)
let listExtentions baseUrl id =
    Delete (sprintf "%s/api/siteextensions/%s" baseUrl id)
