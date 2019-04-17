#!/bin/bash

# Install dotnet core
wget -q https://packages.microsoft.com/config/ubuntu/16.04/packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
sudo apt-get -y update
sudo apt-get -y install dotnet-sdk-2.2

# Get the code for the sample app
cd /home/azureuser
git clone https://github.com/MicrosoftDocs/mslearn-load-balance-web-traffic-with-application-gateway vehicleapp

# Build and publish the web app
export DOTNET_CLI_HOME=/home/azureuser
cd /home/azureuser/vehicleapp
dotnet build
dotnet publish -o published -c Release
sudo cp -r /home/azureuser/vehicleapp/vehicles/published /opt/vehicleapp

# Configure the web service
cd /home/azureuser
cat << EOD > vehicleapp.service 
[Unit]
Description=Vehicle Web App

[Service]
WorkingDirectory=/opt/vehicleapp
ExecStart=/usr/bin/dotnet /opt/vehicleapp/vehicles.dll --server.urls 'http://*:80'
Restart=always
RestartSec=10

[Install]
WantedBy=multi-user.target
EOD

sudo cp vehicleapp.service /etc/systemd/system/vehicleapp.service
sudo systemctl enable vehicleapp.service
sudo systemctl start vehicleapp.service
sudo systemctl status vehicleapp.service