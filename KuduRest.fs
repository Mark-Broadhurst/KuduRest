namespace Fake.Azure

open Fake.Azure.KuduRest

type KuduRestClient (siteName:string, username:string, password:string) =
    
    let baseUrl = Url.siteRoot siteName
    let token = Http.CreateToken username password

    member __.ScmInfo = Url.scmInfo baseUrl token ""
    member __.ScmClean = Url.scmClean baseUrl token ""
    member __.ScmDelete = Url.scmDelete baseUrl token ""
    member __.Command = Url.command baseUrl token ""
    member __.VfsGetFile = Url.vfsGetFile baseUrl token ""
    member __.VfsPutFile = Url.vfsPutFile baseUrl token ""
    member __.VfsDeleteFile = Url.vfsDeleteFile baseUrl token ""
    member __.ZipGet = Url.zipGet baseUrl token ""
    member __.ZipPut = Url.zipPut baseUrl token ""
    member __.DeploymentsList = Url.deploymentsList baseUrl token ""
    member __.DeploymentGet = Url.deploymentGet baseUrl token ""
    member __.DeploymentPut = Url.deploymentPut baseUrl token ""
    member __.DeploymentDelete = Url.deploymentDelete baseUrl token ""
    member __.DeploymentLogGet = Url.deploymentLogGet baseUrl token ""
    member __.DeploymentLogGetLogId = Url.deploymentLogGetLogId baseUrl token ""
    member __.DeployPost = Url.deployPost baseUrl token ""
    member __.SshGetGenertate = Url.sshGetGenertate baseUrl token ""
    member __.SshGet = Url.sshGet baseUrl token ""
    member __.SshGetPublicKey = Url.sshGetPublicKey baseUrl token ""
    member __.KuduVersion = Url.kuduVersion baseUrl token ""
    member __.SettingsPost = Url.settingsPost baseUrl token ""
    member __.SettingsGet = Url.settingsGet baseUrl token ""
    member __.SettingsGetKey = Url.settingsGetKey baseUrl token ""
    member __.SettingsDeleteKey = Url.settingsDeleteKey baseUrl token ""
    member __.Diagnostics = Url.diagnostics baseUrl token ""
    member __.DiagnosticsSettingsPost = Url.diagnosticsSettingsPost baseUrl token ""
    member __.DiagnosticsSettingsGet = Url.diagnosticsSettingsGet baseUrl token ""
    member __.DiagnosticsSettingsGetKey = Url.diagnosticsSettingsGetKey baseUrl token ""
    member __.DiagnosticsSettingsDeleteKey = Url.diagnosticsSettingsDeleteKey baseUrl token ""
    member __.Logs = Url.logs baseUrl token ""
    member __.ListExtentionFeed = Url.listExtentionFeed baseUrl token ""
    member __.ListSiteExtentions = Url.listSiteExtentions baseUrl token ""
    member __.ListExtentionFeedId = Url.listExtentionFeedId baseUrl token ""
    member __.ListSiteExtentionsId = Url.listSiteExtentionsId baseUrl token ""
    member __.InstallSiteExtention = Url.installSiteExtention baseUrl token ""
    member __.ListExtentions = Url.listExtentions baseUrl token ""