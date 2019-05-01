FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build1

WORKDIR /app

COPY AspnetcoreVue.sln .
COPY AspnetcoreVue/AspnetcoreVue.csproj ./AspnetcoreVue/
RUN dotnet restore

COPY AspnetcoreVue/. ./AspnetcoreVue/
WORKDIR /app/AspnetcoreVue
RUN dotnet publish -c Release -o out

# 前端
FROM node:alpine as build2

WORKDIR /app

COPY AspnetcoreVueApp/package.json AspnetcoreVueApp/yarn.lock ./
RUN yarn install

COPY AspnetcoreVueApp/. .
RUN yarn run build

# 运行环境
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime

WORKDIR /app

COPY --from=build1 /app/AspnetcoreVue/out ./
COPY --from=build2 /app/dist ./wwwroot/

EXPOSE 80
ENTRYPOINT ["dotnet", "AspnetcoreVue.dll"]