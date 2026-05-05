# 📦 Raktárkezelő Rendszer (ProOktatás Projekt)

Ez egy modern, rétegelt architektúrájú C# alkalmazás, amely a **ProOktatás Full-stack tanfolyamának** keretein belül készül. A projekt a fájlalapú tárolástól eljutott a professzionális, adatbázis-központú vállalati megoldásokig.

## 🚀 Fejlesztési szakaszok
1. **Konzolos prototípus (Legacy):** Kezdeti verzió CSV alapú tárolással. ✅
2. **Adatbázis & Backend (Core):** Átállás MySQL alapokra, Entity Framework Core és Repository minta bevezetése. ✅ *JELENLEGI ÁLLAPOT*
3. **WinForms GUI:** Modern grafikus felület és real-time statisztikák kialakítása. 🔜 *KÖVETKEZŐ LÉPÉS*

## 🛠 Alkalmazott technológiák
- **Nyelv:** C# (.NET 10)
- **Fejlesztőkörnyezet:** JetBrains Rider (macOS M1)
- **Adatbázis:** MySQL / MariaDB (Pomelo EF Core provider)
- **ORM:** Entity Framework Core (Code-First megközelítés, Migrations)
- **Architektúra:** 
    - **Repository Pattern:** Az adatkezelés elszigetelése az üzleti logikától.
    - **Service Layer:** Központosított üzleti logika és készletkezelési algoritmusok.

## 🏗 Felépítés és Elvek (S.O.L.I.D.)
A projekt a tiszta kód irányelveit követi:
- **Single Responsibility:** Különálló rétegek az entitásoknak, az adatbázis-elérésnek és a logikának.
- **Dependency Injection:** A Service réteg Repository-kon keresztül kommunikál az adatokkal.
- **Adatintegritás:** SQL kényszerek (Foreign Keys), precíz `decimal(18,2)` típusú pénzügyi elszámolás.

## 📋 Jelenlegi funkciók (Backend)
- [x] **Relációs adatmodell:** Összetett kapcsolatok a Termékek, Kategóriák és Tranzakciók között.
- [x] **Automatizált naplózás:** Minden készletmozgás (bevételezés/eladás) automatikusan bekerül a `Tranzakciok` táblába.
- [x] **Leltárkezelés:** Teljes raktárérték számítása, kategória szintű statisztikák.
- [x] **Kritikus készlet figyelés:** Automatikus lekérdezés a minimum készlet alatti termékekre.
- [x] **Keresőmotor:** Cikkszám és név alapú gyorskeresés LINQ segítségével.
- [x] **Dátumkezelés:** Központosított időformázás és tranzakció-időbélyegzés.
