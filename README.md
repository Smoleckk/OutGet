## OutGet - system do zarządzania paczkami (na wzor InPost)
Aplikacja internetowa do zarządzania paczkami, pozwala na rejestracje i zalogowanie użytkownika przy wykorzystaniu JWT oraz OAuth2.
W zależności od roli dostarcza inne funkcjinalności:

###### Użytkownik
* nadawaje nowe paczki,
* wybiera użytkownika do którego zostanie nadana
* wybiera paczkomat nadania i odebrania paczki
* może edytkować dane przesyłki dopóki paczka nie zostanie przyjęta przez administratora serwisu

###### Administrator
* przyjmuje przesyłki, zmieniając ich status
* może dodawac nowe paczkomaty

### Schemat działania aplikacji
![image](https://user-images.githubusercontent.com/73690548/210547215-7c895420-8169-4ced-812a-4d69f07b9891.png)

### Technologie
* ASP.NET Core 6 Web API
* Angular 14
* MSSQL Server
* Docker

### Uruchomienie 
Należy w katalogu z plikiem **'OutGet/OutGetDotNet/'** wywołać komende 
**docker compose build**
a następnie 
**docker compose up**
co pozwoli na uruchomienie aplikacji poprzez docker przy wykorzystaniu pliku **docker-compose.yml**
