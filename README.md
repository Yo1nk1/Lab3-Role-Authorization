# Лабораторная работа №3 — авторизация по ролям

Учебное WinForms-приложение на C# с Entity Framework 6 и SQL Server. При успешном входе оно открывает форму Manager, Seller или Director в соответствии с ролью пользователя.

## Запуск

1. Откройте `RoleAuthorizationLab3.sln` в Visual Studio.
2. В SQL Server Management Studio выполните `User_Data.sql` на экземпляре `.\SQLEXPRESS`.
3. Если SQL Server установлен иначе, измените `User_DataEntities` в `App.config`.
4. В Visual Studio выполните восстановление NuGet-пакетов и соберите решение.
5. Запустите приложение и войдите тестовой учётной записью из таблицы ниже.

| Логин | Пароль | Роль |
| --- | --- | --- |
| `log1` | `pas1` | Manager |
| `log2` | `pas2` | Seller |
| `log3` | `pas3` | Director |
| `log4` | `pas4` | Seller |
| `log5` | `pas5` | Manager |

Пароли открытым текстом оставлены только для соответствия выданной учебной схеме. Не используйте такой способ хранения в реальных приложениях.
