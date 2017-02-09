namespace Fake.Azure

open Fake.Azure.KuduRest

type KuduRestClient (siteName:string, username:string, password:string) =
    
    let baseUrl = sprintf "https://%s.scm.azurewebsites.net" siteName
    let client = Http.RestClient(username,password)

    member __.ScmInfo () = client.Get (sprintf "%s/api/scm/info" baseUrl) 
    member __.ScmClean () = client.Post (sprintf "%s/api/scm/info" baseUrl) ""
    member __.ScmDelete () = client.Delete (sprintf "%s/api/scm" baseUrl)
    member __.Command command dir = client.Post (sprintf "%s/api/command" baseUrl) (sprintf """{ "command": "%s", "dir": "%s" }""" command dir)
    member __.GetFile path = client.Get (sprintf "%s/api/vfs/%s" baseUrl path)
    member __.PutFile filepath fileContent = client.PutBinary (sprintf "%s/api/vfs/%s" baseUrl filepath) fileContent
    member __.PutDirectory dir = client.Put (sprintf "%s/api/vfs/%s/" baseUrl dir) ""
    member __.VfsDeleteFile filePath = client.Delete (sprintf "%s/api/vfs/%s" baseUrl filePath)
    member __.ZipGet filePath = client.Get (sprintf "%s/api/zip/%s" baseUrl filePath)
    member __.ZipPut filePath fileContent = client.PutBinary (sprintf "%s/api/zip/%s" baseUrl filePath) fileContent
    member __.DeploymentsList () = client.Get (sprintf "%s/api/deployments" baseUrl)
    member __.GetDeployment id = client.Get (sprintf "%s/api/deployments/%s" baseUrl id)
    member __.RedployDeployment id = client.Put (sprintf "%s/api/deployments/%s" baseUrl id) ""
    member __.AddDeploymentStatus id = client.Put (sprintf "%s/api/deployments/%s" baseUrl id) "TODO"
    member __.DeleteDeployment id = client.Delete (sprintf "%s/api/deployments/%s" baseUrl id)
    member __.GetDeploymentLog deploymentId = client.Get (sprintf "%s/api/deployments/%s/log" baseUrl deploymentId)
    member __.GetDeploymentLogById deploymentId logId = client.Get (sprintf "%s/api/deployments/%s/log/%s" baseUrl deploymentId logId)
    member __.DeployPost () = client.Post (sprintf "%s/deploy" baseUrl) ""
    member __.GenerateSshKey () = client.Get (sprintf "%s/api/sshkey?ensurePublicKey=1" baseUrl)
    member __.SetSshPrivateKey key = client.Put (sprintf "%s/api/sshkey" baseUrl) key
    member __.GetSsHPublicKey () = client.Get (sprintf "%s/api/sshkey" baseUrl)
    member __.KuduVersion () = client.Get (sprintf "%s/api/environment" baseUrl)
    member __.UpdateSettings () = client.Post (sprintf "%s/api/settings" baseUrl) ""
    member __.GetAllSettings () = client.Get (sprintf "%s/api/settings" baseUrl)
    member __.GetSetting key = client.Get (sprintf "%s/api/settings/%s" baseUrl key)
    member __.DeleteSetting key = client.Delete (sprintf "%s/api/settings/%s" baseUrl key)
    member __.Diagnostics () = client.Get (sprintf "%s/api/dump" baseUrl)
    member __.SetDiagnosticsSetting () = client.Post (sprintf "%s/api/diagnostics/settings" baseUrl) ""
    member __.GetAllGetDiagnosticsSettings () = client.Get (sprintf "%s/api/diagnostics/settings" baseUrl)
    member __.GetDiagnosticsSetting key = client.Get (sprintf "%s/api/diagnostics/settings/%s" baseUrl key)
    member __.DeleteDiagnosticsSetting key = client.Delete (sprintf "%s/api/diagnostics/settings/%s" baseUrl key)
    member __.Logs () = client.Get (sprintf "%s/api/logs/recent" baseUrl)
    member __.ListAllExtentions () = client.Get (sprintf "%s/api/extensionfeed" baseUrl)
    member __.ListExtentionById id = client.Get (sprintf "%s/api/extensionfeed/%s" baseUrl id)
    member __.InstalledSiteExtentions () = client.Get (sprintf "%s/api/siteextensions" baseUrl)
    member __.GetInstalledExtentionById id = client.Get (sprintf "%s/api/siteextensions/%s" baseUrl id)
    member __.InstallSiteExtention id package = client.Put (sprintf "%s/api/siteextensions/%s" baseUrl id) ""
    member __.UninstallExtentions id = client.Delete (sprintf "%s/api/siteextensions/%s" baseUrl id)