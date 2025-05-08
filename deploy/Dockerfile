FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /building

COPY ./ ./
RUN dotnet restore
RUN dotnet publish -c Release -o /published


FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /published .

EXPOSE 8080

ENTRYPOINT ["dotnet", "FacilityAccessService.Application.dll"]