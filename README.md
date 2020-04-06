# RekrutacjaBackend
Zadania rekrutacyjne backend

Obecnie jesteśmy w trkacie aktualizacji polegającej
na przepisywaniu kwerend z ręcznego SQL na dedykowany format C#,
z któego potem kwerendy są kompilowane za pomocą kompilatora Rosyln.

W projecie Przyklad znajdują się pliki prezentujące kilka prostuch kwerend (PrzykladA1.cs) i
jedną procedurę (PrzykladA2.cs) zapisane w formacie SQL oraz w naszym C#.

Struktura bazy danych jest poisana w pliku Context.cs w projekcie Lib.

Tak ptzygotowana kwerenda jest potem używana w kontrolerze ASP.Net Core aby zwrócić dane do
klienta. Akcja w kontrolerze zwraca dane w strukturze drzewa, które jest automatycznie tłumaczone 
na JSON. W każdym elemencie drzewa (IEnumerable) pierwszym elementem musi być klucz a ostatnim
elementem są elementy niższego poziomu (jeżeli występują).

Klucz każdego elementu musi być unikatowy w zwracanym drzewie.

W projekcie Przyklad znajduje sie plik z przykładową implementacją (PrzykladB.cs).

Rozwiązanie jest dla platformy NET Core 3.1

Państwa zadanie polega na:
 - sklonowaniu niniejszego repozytorium
 - dodaniu nowego projektu classlib C# "Rozwiązanie"
 - dopisanie go do pliku sln
 - stowrzenie kwerend (tylko C#, bez SQL):
    - liczącą sumę kwot kontraktów dla każdego klienta
    - liczącą sumę kwot kontraktów dla każdego departamentu
    - liczącą udział sumy kowot kontraktów klienta w sumie kwot kontraktów departamentów dla podanego id klienta
- stworzenie procedury (tylko C#, bez SQL) która dla każdego pracownika znajdzie klienta który podpisał z tym pracownikiem kontrakty na najmniejsząsumę kwot 
- (zadanie opcjonalne - łatwe) stowrzeniu kwerendy, która pokaże departamenty, dla których istnieją klienci mający kontrakty na sumę kwot powyżej kwoty podanej jako parametr
- przygotowaniu implementacji akcji Kontrakty w kontrolerze PrzykladBController
- (zadanie opcjonalne - średnie) akcje w kontrolerze używają operatora group by aby zgrupować IEnumerable pozyskany z bazy danych - to jest nieefektywne, gdzyż wymaga przeczytania całości danych zanim zaczniemy zwracać dane do klienta. Zaproponuj alternatywną implementację funkccji Enumerable.GroupBy która będzie uwzględniała fakt posortowania danych wejściowych i zwracała grupowania przy każdej zmianie klucza
- (zadanie opcjonalne - trudne) zaproponuj metodę aby obecne funkcje akcji kontrolera korzystały z nowej metody Enumerable.GroupBy przy możliwie niewielkiej modyfikacji.

Przy rozwiązywaniu zadań można korzystać ze wszystkich dostępnych źródeł wiedzy. Używanie już gotowego, dobrego kodu jest mile widziane.
W takich sytuacjach prosimy o podanie linków do wykorzystanego kodu (jako dostarczyciel oprogramownaia musimy mieć pewność, że będziemy
go używać zgodnie z licencją).

Rozwiązanie prosimy umieścić jako prywatne (nie pozwalamy innym korzystać z naszego kodu bez naszej zgody) repozytorium na GitHub i
dodać nas (mrgleba) do osób uprawnionych do przeglądania.

Życzymy powodzenia!