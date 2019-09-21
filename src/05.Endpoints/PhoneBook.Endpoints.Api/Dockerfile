FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/05.Endpoints/PhoneBook.Endpoints.Api/PhoneBook.Endpoints.Api.csproj", "src/05.Endpoints/PhoneBook.Endpoints.Api/"]
RUN dotnet restore "src/05.Endpoints/PhoneBook.Endpoints.Api/PhoneBook.Endpoints.Api.csproj"
COPY . .
WORKDIR "/src/src/05.Endpoints/PhoneBook.Endpoints.Api"
RUN dotnet build "PhoneBook.Endpoints.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "PhoneBook.Endpoints.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PhoneBook.Endpoints.Api.dll"]