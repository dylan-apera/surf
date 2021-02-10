
# [CmdletBinding()] attribute allows common parameters (-Verbose, -ErrorAction, etc) to be passed through
[CmdletBinding()]
param 
(    
    [ValidateSet('australiaeast', 'australiasoutheast')] [string] $Location = $env:DEPLOY_AZURE_LOCATION
)

$rg = 'players-rg'
$plan = 'players-aue-plan'
$app = 'players-aue-api'

az group create -n $rg -l $Location 
az appservice plan create -g $rg -n $plan
az webapp create -g $rg -p $plan -n $app
az webapp deployment source config --branch main --name $app --repo-url https://github.com/dylan-apera/hello-api2.git --resource-group $rg 