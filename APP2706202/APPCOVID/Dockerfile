FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
ENV APP_DIR="/app" 
ENV LD_LIBRARY_PATH=$home/app/bin/debug/netcoreapp3.1/clidriver/lib/
ENV PATH=$PATH:"/app/bin/debug/netcoreapp3.1/clidriver/lib"

RUN set -e; 
RUN mkdir -p ${APP_DIR}; 
RUN apt-get update; 
RUN apt-get install -y libxml2-dev;

WORKDIR ${APP_DIR}
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["APPCOVID/APPCOVID.csproj", "APPCOVID/"]
RUN dotnet restore "APPCOVID/APPCOVID.csproj"
COPY . .
WORKDIR "/src/APPCOVID"
RUN dotnet build "APPCOVID.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish --no-restore --no-build "APPCOVID.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/bin .
ENTRYPOINT ["dotnet", "/app/bin/debug/.netcoreapp3.1/APPCOVID.dll"]