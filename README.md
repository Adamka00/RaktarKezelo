# 📦 Raktárkezelő Rendszer (ProOktatás Projekt)

Ez egy professzionális, többrétegű architektúrára épülő C# alkalmazás, amely a **ProOktatás Full-stack tanfolyamának** keretein belül készül. A projekt egyetlen közös backend architektúrából (Core) képes kiszolgálni a korábbi konzolos verziót és a modern, ablakos Windows felületet egyaránt.

## 🚀 Fejlesztési szakaszok
1. **Konzolos prototípus (Legacy):** Kezdeti verzió CSV alapú tárolással, majd MySQL integrációval. ✅
2. **Adatbázis & Backend (Core):** Relációs MySQL alapok, Entity Framework Core és Repository minta. ✅
3. **Üzleti Logika & Biztonság:** Összetett tranzakciókezelés, Unit of Work szemlélet és visszamenőleges API kompatibilitás. ✅
4. **WinForms GUI (Frontend):** Teljes értékű grafikus adminisztrációs felület real-time adatszűréssel és helyszíni adatvalidációval. ✅ *JELENLEGI ÁLLAPOT*

## 🛠 Alkalmazott technológiák és Környezet
- **Nyelv & Keretrendszer:** C# (.NET 9.0)
- **Hibrid Fejlesztői Környezet:**
  - **Host (Mac):** JetBrains Rider macOS (M1) – A központi backend (Core) üzleti logikájának és a helyi MySQL / MariaDB szervernek a futtató környezete.
  - **Guest (Windows):** Parallels Desktop virtuális gép & Microsoft Visual Studio – A Windows-specifikus WinForms frontend hazája, amely belső virtuális hálózati hídon (IP-híd) keresztül éri el a Mac-en pörgő adatbázist.
- **ORM:** Entity Framework Core (Code-First megközelítés, Pomelo provider)

## 🏗 Megvalósított CRUD & Haladó Funkciók
- **[C] Create (Hozzáadás):** Új termékek felvétele oldalsávos adatbeviteli panellel. Golyóálló frontend oldali `TryParse` validáció véd az üres mezők, a negatív készletek és az érvénytelen árak ellen.
- **[R] Read (Megjelenítés & Keresés):** DataGridView alapú táblázat, amely az aszinkron adatelérés mellett `TextChanged` eseményre kötött, azonnali (gépelés közbeni) szűrést biztosít név és cikkszám alapján.
- **[U] Update (Módosítás):** Intelligens, kettős funkciójú mentési logika. A táblázat egy során végzett dupla kattintásra az adatok visszatöltődnek a beviteli mezőkbe, a form állapota átvált, és a gomb a meglévő rekordot frissíti a MySQL-ben.
- **[D] Delete (Soft Delete):** Biztonsági kérdéssel megerősített törlés. A rekordok nem semmisülnek meg fizikai szinten, csupán egy `IsDeleted` logikai jelzőt kapnak, megőrizve a korábbi tranzakciós naplók konzisztenciáját.
- **Tranzakció Biztonság (Atomicity):** A készletmódosítások és a hozzájuk tartozó pénzügyi/raktári naplózások "mindent vagy semmit" alapon, rollback-biztos adatbázis-tranzakciókban futnak le.

## 📋 Rendelkezésre álló üzleti funkciók
- [x] **Kétoldalú Frontend Kiszolgálás:** A `RaktarService` egyszerre támogatja az új WinForms eseményeket és nyújt legacy támogatást a konzolos kliens felé.
- [x] **Automatizált naplózás:** Minden készletmozgás időbélyeggel ellátott audit-tranzakciót generál.
- [x] **Leltárérték számítás:** Valós idejű pénzügyi összesítés a teljes készletről a LINQ motor segítségével.
- [x] **Kritikus készlet figyelés:** Automatikus riasztási szint az utánpótlás szükségességéről (`MinKeszlet`).
- [x] **Rendszeridő szinkron:** Központosított, másodpercre pontos formázott időkijelzés a WinForms alsó állapotsorán (`StatusStrip`).
- [x] **UTF-8 Kódolás:** Teljes körű Unicode támogatás a magyar ékezetes karakterek hibátlan mentéséért és megjelenítéséért.
