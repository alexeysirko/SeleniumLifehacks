# Используем официальный образ .NET SDK версии 6.0 в качестве базового образа.
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Устанавливаем рабочую директорию внутри контейнера.
# Все последующие команды будут выполняться относительно этой директории.
WORKDIR /app

# Копируем файл проекта (.csproj) в рабочую директорию контейнера.
# Это необходимо для того, чтобы восстановить зависимости проекта.
COPY "C:/Users/a.sirko/source/repos/SeleniumLifehacks/Unit8Tests/Unit8Tests.csproj" ./

# Выполняем команду dotnet restore, чтобы восстановить все зависимости, указанные в файле проекта.
# Это позволяет нам скачать все необходимые пакеты NuGet.
RUN dotnet restore

# Копируем все остальные файлы проекта в рабочую директорию контейнера
COPY "C:/Users/a.sirko/source/repos/SeleniumLifehacks/Unit8Tests" ./

# Выполняем команду dotnet build, чтобы собрать проект в режиме Release.
# Собранные файлы будут помещены в директорию /app/build.
RUN dotnet build -c Release -o /app/build

# Создаем новый этап сборки, который будет использоваться для запуска тестов.
# Это позволяет нам разделить этапы сборки и тестирования.
FROM build AS testrunner

# Устанавливаем рабочую директорию для этапа тестирования.
# Это директория, куда были помещены собранные файлы проекта.
WORKDIR /app/build

# Устанавливаем команду по умолчанию для запуска контейнера.
# Эта команда будет выполняться при запуске контейнера и запустит тесты с использованием dotnet test.
ENTRYPOINT ["dotnet", "test", "--no-build", "--logger:trx"]

# cd C:/Users/a.sirko/source/repos/SeleniumLifehacks/Unit8Tests/DockerTestRun
# -t это тэг. . - текущая дериктория как контекст сборки. --rm автоудаление после завершения работы
# docker build -t nunit-tests .
# docker run --rm nunit-tests