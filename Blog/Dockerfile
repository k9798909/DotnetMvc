# 使用 .NET SDK 作為建置映像
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# 設置工作目錄
WORKDIR /app

# 複製 csproj 文件並還原依賴
COPY ./*.csproj ./
RUN dotnet restore

# 複製所有檔案並建置應用程式
COPY . ./
RUN dotnet publish -c Release -o out

# 使用 ASP.NET Core 運行時映像作為最終映像
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# 安裝 tzdata 套件
USER root
RUN apt-get update && apt-get install -y tzdata

# 設定時區為 Asia/Taipei
ENV TZ=Asia/Taipei
RUN ln -fs /usr/share/zoneinfo/Asia/Taipei /etc/localtime && \
    dpkg-reconfigure -f noninteractive tzdata

# 設定應用程式的啟動命令
ENTRYPOINT ["dotnet", "Blog.dll"]

# 曝露應用程式端口
EXPOSE 8080