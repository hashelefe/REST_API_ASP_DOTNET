# Zadanie rekrutacyjne 

Zadanie stworzone przez Jakuba Nowaczka w ASP .NET Core
Baza danych użyta do realizacji projektu - MS SQL

## Konfiguracja
Aby korzystać z aplikacji, najpierw należy skonfigurować baze danych oraz połączenie z bazą.

W pliku konfiguracyjnym appsettings.json należy podmienić wartości YOUR_SERVER oraz YOUR_DATABASE na odpowiadające użytkownikowi
```json
   "ConnectionStrings": {
    "ContactDB": "server=;YOUR_SERVER;database=YOUR_DATABASE;Integrated Security=false;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true"
  },
```
Aby aktywować baze danych należy w konsoli menadżera pakietów użyć 
```bash
update-database
```

# Opis 
W projekcie użyto:
- Microsoft Entity Framework Core
- Microsoft Identity
- MS EFC SQL Server
- MS EFC SQL Tools

## Contact Entity Model

CKategoria - enum składający sie z 3 wyborów (nazewnictwo spowodowane konfliktem nazw)- Sluzbowy, Prywatny, Inny

Wedle wskazań składa sie z:
- automatycznie generowanego Guid
- imienia
- nazwiska
- emaila
- hasła
- kategorii (CKategoria)
- podkategorii
- telefonu
- daty urodzenia

Do modelu należy klasa CheckPassword, która odpowiada za sprawdzenie poprawności składni hasła zanim trafi do bazy danych.

```bash
  contact.CheckPassword(contact.haslo) => true or false
```

## ContactsController

 REST Kontroler obsługujący wszystkie operacje na kontaktach.
 Obsługuje takie operacje jak:
 - GET
 - GET by id 
 - POST (utworzenie nowego kontaktu)
 - PUT (edycja utworzonego kontaktu)
 - DELETE

 Wszystkie operacje poza wyświetlaniem wszystkich wyników są objete autoryzacją.
 Dostep do nich mają wszyscy użytkownicy zalogowani.

 ## Migracje

 W folderze Migrations zdefiniowane są migracje. Tabele znajdujące sie w migracjach to:
 - Contacts
 - AspNetUsers

## Views
 Wszystkie widoki (oprócz widoków zajmujących sie zarządzaniem kontem użytkownika) znajdują sie w folderze Views oraz mogą być modyfikowane wedle potrzeb. Pozostałe widoki można znaleźć w folderze Areas.

## Program
Do konfiguracji programu dodano połączenie z server:
```C#
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("ContactDB"))
);
``` 

Oraz serwis identyfikacji użytkownika
```C#
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AppDbContext>();
```

