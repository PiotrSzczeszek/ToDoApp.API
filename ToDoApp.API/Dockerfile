#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ToDoApp.API/ToDoApp.API.csproj", "ToDoApp.API/"]
COPY ["ToDoApp.Data/ToDoApp.Data.csproj", "ToDoApp.Data/"]
COPY ["ToDoApp.Core/ToDoApp.Core.csproj", "ToDoApp.Core/"]
COPY ["ToDoApp.Infrastracture/ToDoApp.Infrastracture.csproj", "ToDoApp.Infrastracture/"]
RUN dotnet restore "ToDoApp.API/ToDoApp.API.csproj"
COPY . .
WORKDIR "/src/ToDoApp.API"
RUN dotnet build "ToDoApp.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ToDoApp.API.csproj" -c Release -o /app/publish

CMD /bin/bash ./entrypoint.sh

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToDoApp.API.dll"]