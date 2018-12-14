FROM microsoft/dotnet:2.2-runtime

WORKDIR /app
COPY ./bin/Debug/netcoreapp2.1/publish .
ENTRYPOINT ["dotnet", "sampleapp.dll"]