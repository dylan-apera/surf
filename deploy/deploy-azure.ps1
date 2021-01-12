az group create -n weather-rg -l australiaeast 
az appservice plan create -g weather-rg -n weather-aue-plan --sku f1
az webapp create -g weather-rg -p weather-aue-plan -n weather-aue-api
az webapp deployment source config --branch main --name weather-aue-api --repo-url https://github.com/dylan-apera/surfMonitor.git --resource-group weather-rg 
#start https://weather-aue-api.azurewebsites.net/