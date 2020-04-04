# RekrutacjaBackend
Zadania rekrutacyjne backend

Obecnie jesteśmy w trkacie aktualizacji polegającej
na przepisywaniu kwerend z ręcznego SQL na dedykowany format C#,
z któego potem kwerendy są kompilowane za pomocą kompilatora Rosyln.

W projecie Przyklad znajdują się pliki prezentujące kilka prostuch kwerend (PrzykladA1.cs) i
jedną procedurę (PrzykladA2.cs) zapisane w formacie SQL oraz w naszym C#.

Struktura bazy danych jest poisana w pliku Context.cs w projekcie Lib.

Rozwiązanie jest dla platformy NET Core 3.1

Państwa zadanie polega na:
 - dodaniu nowego projektu classlib C# "Rozwiązanie"
 - dopisanie go do pliku sln
 - stowrzenie kwerend (tylko C#, bez SQL):
    - liczącą sumę kwot kontraktów dla każdego klienta
    - liczącą sumę kwot kontraktów dla każdego departamentu
    - liczącą udział sumy kowot kontraktów klienta w sumie kwot kontraktów departamentów dla podanego id klienta
- stworzenie procedury (tylko C#, bez SQL) która dla każdego pracownika znajdzie klienta który podpisał z tym pracownikiem kontrakty na najmniejsząsumę kwot 
- (zadanie opcjonalne) stowrzeniu kwerendy, która pokaże departamenty, dla których istnieją klienci mający kontrakty na sumę kwot powyżej kwoty podanej jako parametr