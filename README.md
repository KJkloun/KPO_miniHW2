# Zoo API (KPO Mini HW2)

## Описание проекта

Это **Web API** для управления процессами в зоопарке:

- **Управление животными**: добавление, удаление, просмотр.
- **Управление вольерами**: добавление, удаление, просмотр.
- **Перемещение животных** между вольерами.
- **Расписание кормлений**: создание, просмотр, отметка выполнения.
- **Статистика зоопарка**: общее количество животных, свободные вольеры.
- **Метаданные**: получение кодов и названий для `Gender` и `FeedType`.

Проект построен по принципам **Clean Architecture** и **Domain-Driven Design**.

## Структура проекта

```
KPO_mini_hw2/               # корень решения
  ├── src/
  │    └── KPO_mini_hw2/    # основной проект
  │         ├── Domain/     # доменная модель
  │         │    ├── Entities/
  │         │    ├── Events/
  │         │    ├── Interfaces/
  │         │    └── ValueObjects/
  │         ├── Application/ # сервисы и интерфейсы
  │         │    ├── Interfaces/
  │         │    ├── DTOs/
  │         │    └── Services/
  │         ├── Infrastructure/  # in-memory репозитории и события
  │         │    ├── Repositories/
  │         │    └── Events/
  │         ├── Presentation/    # Web API
  │         │    ├── Controllers/
  │         │    └── Program.cs
  │         └── KPO_mini_hw2.csproj
  
```

## Технологии

- .NET 8.0 (C# 11)
- ASP.NET Core Web API
- xUnit, FluentAssertions (модульное тестирование)
- In-memory хранилище (для простоты)
- Swagger / OpenAPI

## Установка и запуск
### 1. Восстановить зависимости и собрать

```bash
dotnet restore
dotnet build --configuration Debug
```

### 2. Запустить приложение

```bash
dotnet run --configuration Debug
```

По умолчанию приложение слушает `http://localhost:5000`.

## Документация API (Swagger)

После старта приложения откройте в браузере:

```
http://localhost:5000/swagger
```

Там вы увидите все доступные эндпоинты и сможете их протестировать через Swagger UI.

## Основные эндпоинты

### /api/Animal

- `GET /api/Animal` – получить список животных
- `GET /api/Animal/{id}` – получить одно животное по ID
- `POST /api/Animal` – создать новое животное
- `DELETE /api/Animal/{id}` – удалить животное
- `POST /api/Animal/{id}/move` – переместить животное в другой вольер

**Пример тела для POST**:
```json
{
  "species": "Lion",
  "name": "Simba",
  "birthDate": "2018-05-01T00:00:00Z",
  "gender": 0,
  "favouriteFood": 0
}
```

### /api/Enclosure

- `GET /api/Enclosure` – список вольеров
- `GET /api/Enclosure/{id}` – один вольер
- `POST /api/Enclosure` – создать
- `DELETE /api/Enclosure/{id}` – удалить

**Пример тела для POST**:
```json
{
  "type": "Carnivore",
  "size": 120.0,
  "capacity": 3
}
```

### /api/FeedingSchedule

- `GET /api/FeedingSchedule` – расписание кормлений
- `POST /api/FeedingSchedule` – запланировать кормление
- `POST /api/FeedingSchedule/{id}/complete` – отметить выполненным

**Пример тела для POST**:
```json
{
  "animalId": "<animal-id>",
  "time": "2025-04-20T18:00:00Z",
  "feedType": 0
}
```

### /api/Statistics

- `GET /api/Statistics` – общая статистика: количество животных, свободные вольеры и т.д.

### /api/metadata

- `GET /api/metadata/genders` – список `Gender` (0 = Male, 1 = Female)
- `GET /api/metadata/feedtypes` – список `FeedType`:
  - 0 = Meat
  - 1 = Vegetables
  - 2 = Fruits
  - 3 = Fish
  - 4 = Pellets

Автор: KJkloun © 2025

