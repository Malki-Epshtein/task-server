# השתמש בגרסת ה-SDK של .NET לבנייה
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# העתקת קבצי הפרויקט ובנייה
COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

# יצירת התמונה הסופית להרצה
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# הגדרת פקודת ההרצה (שני את Lesson_4.dll לשם הקובץ שלך אם הוא שונה)
ENTRYPOINT ["dotnet", "Lesson_4.dll"]