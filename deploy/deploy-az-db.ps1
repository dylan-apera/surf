#!/bin/bash
$location = 'australiaeast'
$resource = 'weather-rg'
$sqlserver = 'weather-sql-server'
$sqldb = 'weather-sql-db'

$login="dylanapera"
$password="c1sc0Dylan!"

$startIP = 10.0.0.0
$endIP = 10.0.0.254

echo "Creating $resource..."
az group create --name $resource --location "$location"

echo "Creating $sqlserver in $location..."
az sql server create --name $sqlserver --resource-group $resource --location $location --admin-user $login --admin-password $password

echo "Configuring firewall..."
az sql server firewall-rule create --resource-group $resource --server $sqlserver -n AllowYourIp --start-ip-address 10.0.0.1 --end-ip-address 10.0.0.5

echo "Creating $sqldb on $sqlserver..."
az sql db create --resource-group $resource --server $sqlserver --name $sqldb --edition Standard --family Gen5 --service-objective S2 --zone-redundant false # zone redundancy is only supported on premium and business critical service tiers