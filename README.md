# 📦 Raktárkezelő Rendszer (ProOktatás Projekt)

Ez egy professzionális, többrétegű architektúrára épülő C# alkalmazás, amely a **ProOktatás Full-stack tanfolyamának** keretein belül készül. A projekt egyetlen közös backend architektúrából (Core) képes kiszolgálni a korábbi konzolos verziót és a modern, ablakos Windows felületet egyaránt.

## 🚀 Fejlesztési szakaszok
1. **Konzolos prototípus (Legacy):** Kezdeti verzió CSV alapú tárolással, majd MySQL integrációval. ✅
2. **Adatbázis & Backend (Core):** Relációs MySQL alapok, Entity Framework Core és Repository minta. ✅
3. **Üzleti Logika & Biztonság:** Összetett tranzakciókezelés, Unit of Work szemlélet és visszamenőleges API kompatibilitás. ✅
4. **WinForms GUI (Frontend):** Teljes értékű grafikus adminisztrációs felület real-time adatszűréssel, beépített login kapuval és vezetői KPI műszerfallal. ✅ *JELENLEGI ÁLLAPOT*

## 🛠 Alkalmazott technológiák és Környezet
- **Nyelv & Keretrendszer:** C# (.NET 9.0)
- **Hibrid Fejlesztői Környezet:**
  - **Host (Mac):** JetBrains Rider macOS (M1) – A központi backend (Core) üzleti logikájának és a helyi MySQL / MariaDB szervernek a futtató környezete.
  - **Guest (Windows):** Parallels Desktop virtuális gép & Microsoft Visual Studio – A Windows-specifikus WinForms frontend hazája, amely belső virtuális hálózati hídon (IP-híd) keresztül éri el a Mac-en pörgő adatbázist.
- **ORM:** Entity Framework Core (Code-First megközelítés, Pomelo provider)

## 🏗 Megvalósított CRUD & Haladó Architekturális Funkciók

### 🔐 1. Biztonsági Beléptető Kapu (Login System)
- **Munkamenet-eltérítés:** A `Program.cs` belépési pontja felül lett bírálva; a főablak csak akkor példányosul, ha a `LoginForm` sikeres `DialogResult.OK` jelzéssel zárul le.
- **Golyóálló ablakkezelés:** A bejelentkező felület az ipari szabványoknak megfelelően lezárt állapotú (`FixedDialog`, `MaximizeBox = False`), így nem átméretezhető, és garantáltan a képernyő közepén jelenik meg (`CenterScreen`).
- **Jelszóvédelem:** Maszkolt karakteres adatbevitel (`PasswordChar`) a fizikai betekintések ellen.

### 📐 2. Reszponzív, Alkalmazkodó UI & Modern UX
- **Faltól-falig elrendezés:** Szigorú `Dock` (Top, Right, Fill) architektúra, amely teljesen kiküszöböli a fix pixeles koordináta-számolgatást. Az app ablakméretezés vagy teljes képernyő esetén is dinamikusan kitölti a monitor terét.
- **Intelligens Oldalsáv (Toggle Panel):** A helytakarékosság érdekében az Új termék / Szerkesztés panel alapértelmezetten rejtve indul (`Form1_Load`). Gombnyomásra vagy a táblázat egy során végzett **dupla kattintásra** automatikusan előbújik, miközben a fő táblázat reszponzív módon igazodik a maradék térhez.

### 📊 3. 3-Kártyás Vezetői Műszerfal (KPI Dashboard)
- **Rácsos Elrendezés:** `TableLayoutPanel` segítségével felépített, egyenlő arányban (33.33%) osztott vezetői KPI panel, amely modális ablakként nyitható meg.
- **Azonnali Üzleti Mutatók:**
  - **💰 Raktár Érték kártya:** A teljes készlet összesített pénzbeli értéke LINQ aggregálással, ezres csoportosítással formázva.
  - **⚠️ Kritikus Termékek kártya:** Azonnali darabszámos riasztás a kritikus szintet elért árukról.
  - **📦 Cikkek Száma kártya:** A raktárban található egyedi termékfajták száma.
- **📉 Top 5 Beszerzési Lista:** A műszerfal alsó felében egy letisztult, egyedi `Padding`-gal ellátott, fehér hátterű táblázat található, amely LINQ rendezéssel (`OrderBy` + `Take(5)`) kizárólag a legkritikusabb 5 terméket emeli ki a beszerzés könnyítésére.

## 📋 Rendelkezésre álló üzleti funkciók
- [x] **Kétoldalú Frontend Kiszolgálás:** A `RaktarService` egyszerre támogatja az új WinForms eseményeket és nyújt legacy támogatást a konzolos kliens felé (`UjTermekMentese`).
- [x] **Automatizált naplózás:** Minden készletmozgás időbélyeggel ellátott audit-tranzakciót generál.
- [x] **Soft Delete:** Biztonsági törlés `IsDeleted` logikai jelzővel az adatbázis-konzisztencia megőrzéséért.
- [x] **Tranzakció Biztonság:** Rollback-biztos, atomi adatbázis-tranzakciók kezelése hiba esetén.
- [x] **UTF-8 Kódolás:** Teljes körű Unicode támogatás a magyar ékezetes karakterek hibátlan megjelenítéséért.
