# BookStore

**BookStore** — это REST API на ASP.NET Core (.NET 9) с фронтендом на React для управления книжным магазином. Поддерживает CRUD-операции для книг, регистрацию и аутентификацию пользователей с JWT-токенами. Проект построен по принципам **чистой архитектуры**.

## Возможности
- **Управление книгами**: Создание, просмотр, обновление и удаление книг.
- **Управление пользователями**: Регистрация и аутентификация с ролями (`User`, `Admin`).
- **Безопасность**: Хэширование паролей с BCrypt и аутентификация через JWT.
- **Фронтенд**: Адаптивный интерфейс на React для взаимодействия с API.
- **Валидация**: Проверка входных данных с FluentValidation.
- **Документация**: Документация API через Swagger.

## Архитектура
Проект разделён на слои:
- **BookStore.Api**: Контроллеры и конфигурация API.
- **BookStore.Application**: Бизнес-логика, DTO, сервисы и валидаторы.
- **BookStore.Core**: Сущности, перечисления и интерфейсы.
- **BookStore.Infrastructure**: Контекст базы данных (PostgreSQL), репозитории и безопасность (JWT, хэширование паролей).

## Технологии
- **Бэкенд**: ASP.NET Core (.NET 9), EF Core, PostgreSQL, FluentValidation, AutoMapper.
- **Фронтенд**: React, Axios.
- **Безопасность**: BCrypt, JWT.
- **Инструменты**: Swagger, CORS.

## Требования
- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [PostgreSQL](https://www.postgresql.org/download/) (версия 13 или выше)
- [Node.js](https://nodejs.org/) (версия 18 или выше для React)
- [Git](https://git-scm.com/)

## Установка
1. **Клонируйте репозиторий**:
   ```bash
   git clone https://github.com/llllenivka/BookStore.git
   cd BookStore
   ```

2. **Настройте бэкенд**:
   - Перейдите в директорию бэкенда:
     ```bash
     cd src/BookStore/BookStore.Api
     ```
   - Обновите строку подключения в `appsettings.json`:
     ```json
     "ConnectionStrings": {
       "BookStoreDb": "Host=localhost;Database=BookStore;Username=postgres;Password=your_password"
     }
     ```
   - Примените миграции базы данных:
     ```bash
     dotnet ef database update --project ../BookStore.Infrastructure --startup-project .
     ```

3. **Настройте фронтенд**:
   - Перейдите в директорию фронтенда (предполагается, что она называется `frontend`):
     ```bash
     cd ../../frontend
     ```
   - Установите зависимости:
     ```bash
     npm install
     ```

4. **Настройте JWT**:
   - Обновите настройки JWT в `appsettings.json`:
     ```json
     "Jwt": {
       "SecretKey": "your-secure-key-here",
       "ExpiresHours": "12"
     }
     ```

## Запуск приложения
1. **Запустите бэкенд**:
   ```bash
   cd src/BookStore/BookStore.Api
   dotnet run
   ```
   - API будет доступно по адресу `https://localhost:5138`.
   - Swagger доступен по адресу `https://localhost:5138/swagger`.

2. **Запустите фронтенд**:
   ```bash
   cd frontend
   npm start
   ```
   - React-приложение будет доступно по адресу `http://localhost:3000`.

## Использование
- **Эндпоинты API**:
  - `GET /api/book`: Получить все книги.
  - `POST /api/book`: Создать новую книгу.
  - `POST /api/user/register`: Зарегистрировать пользователя (требуются `username`, `password`, `role`).
  - Исследуйте все эндпоинты через Swagger.

- **Фронтенд**:
  - Просматривайте книги, регистрируйтесь и входите через интерфейс React.

## Тестирование
- Используйте Swagger или Postman для тестирования API.
- Пример запроса для регистрации пользователя:
  ```json
  {
    "username": "testuser",
    "email": "test@test.ru",
    "password": "password123",
    "role": "User"
  }
  ```


