FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src

# copy csproj file and install reference
COPY ["donation-MERCHANT.csproj", "./"]
RUN dotnet restore "./donation-MERCHANT.csproj"

# copy all file and build app
COPY . . 
RUN dotnet publish "donation-MERCHANT.csproj" -c Release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime
WORKDIR /app
EXPOSE 80
COPY --from=build /app .
ENTRYPOINT ["dotnet", "donation-MERCHANT.dll"]
