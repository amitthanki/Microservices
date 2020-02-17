FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
 
WORKDIR /app

EXPOSE 9089

FROM microsoft/dotnet:2.1-sdk AS builder

WORKDIR /src

COPY ["mobile.gateway.csproj",  ""]

RUN dotnet restore "mobile.gateway.csproj"
COPY . .

WORKDIR /src
RUN dotnet build "mobile.gateway.csproj" -c Release  -o /app

FROM builder AS publish
ARG Configuration=Release
RUN dotnet publish "mobile.gateway.csproj" -c Release  -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "mobile.gateway.dll"] 

