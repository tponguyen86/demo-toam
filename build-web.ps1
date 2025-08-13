$ErrorActionPreference = "Stop";

New-Item -ItemType Directory -Force -Path ./build
New-Item -ItemType Directory -Force -Path ./zip
Remove-Item ./build/* -Recurse -Force
Remove-Item ./zip/* -Recurse -Force

dotnet restore ./web-client/web-client.csproj
dotnet publish ./web-client/web-client.csproj -c Release --runtime linux-musl-x64 --no-restore -o ./build
Start-Sleep 2

Compress-Archive ./build/*  ./zip/netecs.zip

ssh root@45.119.85.180 docker stop  production-netecs-vn
ssh root@45.119.85.180 rm -rf /app/netecs.vn/*

scp ./zip/netecs.zip root@45.119.85.180:/app/netecs.vn

ssh root@45.119.85.180 unzip /app/netecs.vn/netecs.zip  -d /app/netecs.vn

ssh root@45.119.85.180 docker start  production-netecs-vn