FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
 
WORKDIR /app

EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS builder

WORKDIR /src
COPY *.sln ./

COPY ./Services/Person.api/Person.api.csproj ./Services/Person.api/
COPY ./Services/message.api/message.api.csproj ./Services/message.api/
COPY ./Core/Database/Database.csproj ./Core/Database/
COPY ./APIGateway/desktop.gateway/desktop.gateway.csproj ./APIGateway/desktop.gateway/
COPY ./APIGateway/mobile.gateway/mobile.gateway.csproj ./APIGateway/mobile.gateway/
RUN dotnet restore
COPY . .
WORKDIR /src/Services/Person.api/
RUN dotnet build -c Release  -o /app

FROM builder AS publish
ARG Configuration=Release
RUN dotnet publish -c Release  -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Person.api.dll"] 

