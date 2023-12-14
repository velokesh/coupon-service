FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

# Copy everything
COPY *.sln .
COPY Coupon.API/*.csproj ./Coupon.API/
COPY Coupon.Application/*.csproj ./Coupon.Application/
COPY Coupon.Domain/*.csproj ./Coupon.Domain/
COPY Coupon.Infrastructure/*.csproj ./Coupon.Infrastructure/
COPY Coupon.Api.Tests/*.csproj ./Coupon.Api.Tests/
COPY Coupon.Application.Tests/*.csproj ./Coupon.Application.Tests/

# Restore as distinct layers
RUN dotnet restore

COPY Coupon.API/. ./Coupon.API/
COPY Coupon.Application/. ./Coupon.Application/
COPY Coupon.Domain/. ./Coupon.Domain/
COPY Coupon.Infrastructure/. ./Coupon.Infrastructure/
#COPY Coupon.Api.Tests/. ./Coupon.Api.Tests/
#COPY Coupon.Application.Tests/. ./Coupon.Application.Tests/

# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App
COPY --from=build-env /App/out ./
ENTRYPOINT ["dotnet", "Coupon.API.dll"]
