FROM harbor.dolgen.net/devops/kit/dotnet/sdk:latest-6 AS build
WORKDIR /build

# Arguments Setup
ARG VER
ARG CI_PROJECT_NAME
ARG APP_NAME
ARG PORT_MAPPING

# copy csproj and restore as distinct layers
COPY . .
RUN dotnet restore

RUN echo ${CI_PROJECT_NAME}

# copy everything else and build app
RUN dotnet publish -c release -o /app --no-restore
COPY src/Coupon-Service/${APP_NAME}/appsettings*.json /app/

# Note that cert and key files get added as volumes in Kubenetes

# final stage/image
FROM harbor.dolgen.net/devops/kit/dotnet/runtime:latest-6

# Arguments Setup
ARG VER
ARG CI_PROJECT_NAME
ARG APP_NAME
ARG PORT_MAPPING

# Labels Setup
LABEL MAINTAINER=${CI_PROJECT_NAME}
LABEL dg.app=${CI_PROJECT_NAME}
LABEL dg.version=${VER}

WORKDIR /app
COPY --from=build /app ./
RUN chmod g+s /app \
  && chmod g+rx /app/* \
  && chown -R container-user:container-user /app

USER container-user
RUN whoami

EXPOSE ${PORT_MAPPING}
ENV ASPNETCORE_URLS=http://0.0.0.0:${PORT_MAPPING}
ENV APP_EXE=${APP_NAME}.dll
ENV PORT_MAPPING=${PORT_MAPPING}

HEALTHCHECK --interval=2m --timeout=3s CMD wget --no-verbose --tries=1 --spider http://localhost:${PORT_MAPPING}/health/live || exit

ENTRYPOINT dotnet ${APP_EXE}

