FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 51336
ENV ASPNETCORE_URLS=http://*:51336

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["/WM.API/WM.API.csproj", "WM.API/"]
COPY ["/WM.Infra.CrossCutting.IoC/WM.Infra.CrossCutting.IoC.csproj", "WM.Infra.CrossCutting.IoC/"]
COPY ["/WM.Infra.CrossCutting.Bus/WM.Infra.CrossCutting.Bus.csproj", "WM.Infra.CrossCutting.Bus/"]
COPY ["/WM.Domain.Core/WM.Domain.Core.csproj", "WM.Domain.Core/"]
COPY ["/WM.Infra.Data.Cliente/WM.Infra.Data.Cliente.csproj", "WM.Infra.Data.Cliente/"]
COPY ["/WM.Domain.Cliente/WM.Domain.Cliente.csproj", "WM.Domain.Cliente/"]
RUN dotnet restore "WM.API/WM.API.csproj"
COPY . .
WORKDIR "/src/WM.API/"
RUN dotnet build "WM.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WM.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WM.API.dll"]