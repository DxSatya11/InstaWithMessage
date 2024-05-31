param appServiceBaseName string
param appServiceBaseSkuName string
param webAppName string
param webAppInsightsName string
param environmentName string
param storageAccountName string
param runtime string = 'dotnet'
param storageAccountType string = 'Standard_LRS'
param containerNames array = ['instagram-post','instagram-profilpicture'] 
param location string = resourceGroup().location
//param timeforplan string
//param timeforanalysis string
//param timeformonthlyscore string

resource appServiceBase 'Microsoft.Web/serverfarms@2015-08-01' = {
  name: appServiceBaseName
  location: location
  sku: {
    name: appServiceBaseSkuName
  }
  tags: {
    displayName: 'appServiceBase'
  }
  dependsOn: []
}

resource webApp 'Microsoft.Web/sites@2015-08-01' = {
  name: webAppName
  location: location
  identity: {
    type: 'SystemAssigned'
  }
  properties: {
    serverFarmId: appServiceBase.id
    siteConfig: {
      netFrameworkVersion: 'v7.0'
      httpsOnly: true
      //ftpsState: 'FtpsOnly'
      appSettings: [
        {
          name: 'ASPNETCORE_ENVIRONMENT'
          value: environmentName
        }
        
      ]
    }
  }
}

resource storageAccount 'Microsoft.Storage/storageAccounts@2022-05-01' = {
  name: storageAccountName
  location: location
  sku: {
    name: storageAccountType
  }
  kind: 'StorageV2'
  properties: {
    supportsHttpsTrafficOnly: true
    defaultToOAuthAuthentication: true
  }
}



resource containers 'Microsoft.Storage/storageAccounts/blobServices/containers@2022-09-01' = [for containerName in containerNames : {
  name: '${storageAccount.name}/default/${containerName}'
  properties: {
    publicAccess: 'Container'
    defaultEncryptionScope: '$account-encryption-key'
    denyEncryptionScopeOverride: false
    accessTier: 'Hot'
  }
}]



resource webAppInsights 'Microsoft.Insights/components@2020-02-02' = {
  name: webAppInsightsName
  location: location
  kind: 'web'
  properties: {
    Application_Type:'web'
    Flow_Type: 'Redfield'
    Request_Source: 'rest'
  }
}
