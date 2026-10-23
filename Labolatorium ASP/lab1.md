Zadanie A1.
Opisz w 1-2 zdaniach rolę każdego elementu:

1.Program.cs - Główny plik startowy projektu, w którym uruchamia się aplikacja. Tutaj rejestruje się potrzebne usługi i ustawia zachowania aplikacji np.
(builder.Services, app Use, MapControllerRoute)

2.Controllers/ - Folder z kontrolerami, które odbierają żądania przychodzące z przeglądarki lub API. Wykonują odpowiednią akcję i odsyłają odpowiedź.
np. stronę HTML albo dane JSON

3.Models/ - Przechowuje klasy reprezentujące dane, na których pracuje aplikacja. Znajdują się tu modele bazodanowe oraz obiekty DTO do przesyłania danych między widokiem
a kontrolerem.

4.Views/ - Zawiera pliki szablonów Razor ".cshtml", czyli to co użytkownik widzi w przeglądarce. W podfolderze "Shared/" trzymanyt jest wspólny wygląd "layout".

5.wwwroot/ - Publiczny folder na pliki statyczne, które przeglądarka pobiera wprost z dysku. Lądują tam pliki stylów CSS, skrypty JavaScrip, biblioteki i obrazki.

6.appsettings.json - Pliki z ogólną konfiguracją projektu zapisaną w formacie JSON. Trzyma się w nim np. ustawienia logowania czy połączenia  bazą.

7.Properties/lunchSettings.json - Lokalne ustawienia uruchamiania projektu w środowisku programistycznym. Określa, na jakich portach (HTTP/HTTPS) ma odpalić się aplikacja podczas testowania na twoim komputerze.

Część B. Podgląd HTTP w przeglądarce

1. Metoda żądania - Get
2. Kod statusu odpowiedzi - 200 Ok
3. Content-type odpowiedzi - text/html; charset=utf-8
4. Nagłówek User-Agent żądania - Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/153.0.0.0 Safari/537.36 OPR/137.0.0.0
5. Ile żądań wykonała strona łącznie i dlaczego więcej niż jedno? - Strona wykonała łącznie 9 żądań ponieważ zczytała Localhost, bootstrap.min.css, site.css?v=j6fhJSuuyLpOSLuPJU0TsDV0iNjor5S3rDnvxJrt4bg, Labolatorium_ASP.style.css , jquery.min.js, bootstrap.bundle.min.js, site.js?v=hRQyftXiu1lLX2P9Ly9xa4gHJgLeR1uGN5qegUobtGo, data:image oraz favicon.ico. Można zobaczyć ilość żądań w lewym dolnym rogu devtoolsa.
6. Wejdź na nieistniejący adres /abc - jaki kod statusu widzisz? - 404 Not Found

Pytania Kontrolne:
1. Czym różnią się metody GET i POST z punktu widzenia idempotentności i miejsca przekazywania danych?
   odpowiedź:
   GET jest idempotentny (oraz bezpieczny) – wykonanie tego samego zapytania raz czy dziesięć razy zwraca ten sam wynik i nie zmienia stanu danych na serwerze (służy tylko do odczytu)
   POST nie jest idempotentny – każde kolejne wysłanie żądania może zmodyfikować stan serwera (np. wysłanie formularza 3 razy może dodać 3 osobne rekordy w bazie danych).
   Miejsce przekazywania danych:
   GET przesyła parametry bezpośrednio w adresie URL (w ścieżce lub w parametrach zapytania po znaku
   POST przesyła dane głównie w ciele żądania (Request Body), np. jako obiekt JSON czy dane formularza, dzięki czemu dane nie są widoczne w pasku adresu i nie ma ograniczenia długości adresu URL.

2.Co oznaczają kody statusu?
200 Ok: żądanie powiodło się, serwer poprawnie zwrócił dane.
302 Found: Przekierowanie tymczasowe - przeglądarka zostaje skierowana pod inny adres URL
400 Bad Request: Błąd po stronie klienta - żądanie zawiera nieprawidłowe dane lub błąd składni
401 Unauthorized: Brak uwietrzytelnienia - użytkownik musi się zalogować/przekazać token autoryzacji
403 Forbidden: Brak uprawnień - serwer wie, kim jest użytkownik, ale nie ma on praw dostępu do zasobu
404 Not Found: Zasób nie istnieje - pod wskazanym adresem URL serwer niczego nie znalazł.
405 Method Not Allowed: Niezadowolona metoda HTTP - adres istnieje, ale nie obsługuje użytej metody (np.próba pobrania akcji post za pomocą get)
415 Unsupported Media Type: Nieobsługiwany format danych - np serwer z atrybutem [FromBody] oczekuje formatu appliocation/json, a otrzymał text/plain
500 Internal Server Error: Wewnętrzny błąd serwera - po stronie kodu backendu wystąpił nieobnsłużony wyjątek.

3.Skąd model binding wie, czy id pochodzi z ścieżki, czy z query string?
Model binding sprawdza źródła w określonej kolejności: najpierw dopasowuje id do wzorca ścieżki (Route data), a jeśli go tam nie znajdzie, szuka go w parametrach adresu po znaku zapytania (Query string).

4.Pliki z wwwroot są udostępniane publicznie jako zwykłe pliki statyczne przez middleware app.UseStaticFiles(), natomiast folder Controllers/ zawiera prywatny kod źródłowy, który jest wykonywany po stronie serwera przez silnik routingu, a nie pobierany z dysku.


