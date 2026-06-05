# 📦 Raktárkezelő Rendszer (ProOktatás Projekt)

Ez egy professzionális, többrétegű architektúrára épülő C# alkalmazás, amely a **ProOktatás Full-stack tanfolyamának** keretein belül készült. A projekt egyetlen közös backend architektúrából (Core) képes kiszolgálni a korábbi konzolos verziót és a modern, ablakos Windows felületet egyaránt.

## 🚀 Fejlesztési szakaszok
1. **Konzolos prototípus (Legacy):** Kezdeti verzió CSV alapú tárolással, majd MySQL integrációval. ✅
2. **Adatbázis & Backend (Core):** Relációs MySQL alapok, Entity Framework Core és Repository minta. ✅
3. **Üzleti Logika & Biztonság:** Összetett tranzakciókezelés, Unit of Work szemlélet és visszamenőleges API kompatibilitás. ✅
4. **WinForms GUI (Frontend):** Teljes értékű grafikus adminisztrációs felület real-time adatszűréssel, beépített login kapuval és vezetői KPI műszerfallal. ✅ *JELENLEGI ÁLLAPOT*

## 🛠 Alkalmazott technológiák és Környezet
- **Nyelv & Keretrendszer:** C# (.NET 9.0)
- **Hibrid Fejlesztői Környezet:**
  - **Host (Mac):** JetBrains Rider macOS (M1) – A központi backend (Core) üzleti logikájának és a helyi MySQL / MariaDB szervernek a futtató környezete.
  - **Guest (Windows):** Parallels Desktop virtuális gép & Microsoft Visual Studio – Windows-specifikus WinForms frontend, amely belső virtuális hálózati hídon (IP-híd) keresztül éri el a Mac-en pörgő adatbázist.
- **ORM:** Entity Framework Core (Code-First megközelítés, Pomelo provider)

## 🏗 Megvalósított CRUD & Haladó Architekturális Funkciók

### 🔐 1. Biztonsági Beléptető Kapu (Login System)
- **Munkamenet-eltérítés:** A `Program.cs` belépési pontja felül lett bírálva; a főablak csak akkor példányosul, ha a `LoginForm` sikeres `DialogResult.OK` jelzéssel zárul le.
- **Erős ablakkezelés:** A bejelentkező felület az ipari szabványoknak megfelelően lezárt állapotú (`FixedDialog`, `MaximizeBox = False`), így nem átméretezhető, és garantáltan a képernyő közepén jelenik meg (`CenterScreen`) elírásmentes, letisztult felülettel.
- **Jelszóvédelem:** Maszkolt karakteres adatbevitel (`PasswordChar`) a fizikai betekintések ellen.

### 📐 2. Reszponzív, Alkalmazkodó UI & UX
- **Faltól-falig elrendezés:** Szigorú `Dock` (Top, Right, Fill) architektúra, amely teljesen kiküszöböli a fix pixeles koordináta-számolgatást. Az app ablakméretezés vagy teljes képernyő esetén is dinamikusan kitölti a monitor terét.
- **Intelligens Oldalsáv (Toggle Panel):** A helytakarékosság érdekében az Új termék / Szerkesztés panel alapértelmezetten rejtve indul (`Form1_Load`). Gombnyomásra vagy a táblázat egy során végzett **dupla kattintásra** automatikusan előbújik, miközben a fő táblázat reszponzív módon igazodik a maradék térhez.
- **Állapotvezérelt Adatmentés (Double Click CRUD):** A rendszer egy belső állapotváltozó (`_szerkesztendoTermekId`) segítségével intelligensen különbséget tesz az új termék felvétele és egy meglévő rekord módosítása között. Dupla kattintáskor lekéri az adatbázisból az EF Core által trackelt eredeti entitást, így kiküszöböli a duplikált cikkszámok miatti adatbázis-ütközéseket.
- **Modern Vizuális Megjelenés:** A Windows formák alapértelmezetten elavult dizájnját szoftveres úton írtuk felül: minimalizált vékony rácsvonalak, sötétszürke elegáns fejlécek, Segoe UI betűtípuscsalád, teljes soros kijelölés (`FullRowSelect`), valamint a táblázat olvashatóságát drasztikusan javító **váltakozó sorszínű (Zebra csíkozású)** elrendezés.

### 📊 3. 3-Kártyás Vezetői Műszerfal (KPI Dashboard)
- **Rácsos Elrendezés:** `TableLayoutPanel` segítségével felépített, egyenlő arányban (33.33%) osztott vezetői KPI panel, amely modális ablakként nyitható meg.
- **Azonnali Üzleti Mutatók:**
  - **💰 Raktár Érték kártya:** A teljes készlet összesített pénzbeli értéke LINQ aggregálással, ezres csoportosítással formázva.
  - **⚠️ Kritikus Termékek kártya:** Azonnali darabszámos riasztás a kritikus szintet elért árukról.
  - **📦 Cikkek Száma kártya:** A raktárban található egyedi termékfajták száma.
- **📉 Top 5 Beszerzési Lista:** A műszerfal alsó felében egy letisztult, egyedi `Padding`-gal ellátott, fehér hátterű táblázat található, amely LINQ rendezéssel (`OrderBy` + `Take(5)`) kizárólag a legkritikusabb 5 terméket emeli ki a beszerzés könnyítésére.

## 📋 Rendelkezésre álló üzleti funkciók
- [x] **Kétoldalú Frontend Kiszolgálás:** A `RaktarService` egyszerre támogatja az új WinForms eseményeket és nyújt legacy támogatást a konzolos kliens felé (`UjTermekMentese`).
- [x] **Kategória Relációk Kezelése:** A backend a numerikus azonosítók helyett komplex objektum-összeköttetéseket kezel. A frontend oldalon a kategóriák dinamikus `ComboBox` listából választhatók ki, a táblázatban pedig intelligens LINQ vizsgálat (`t.Kategoria != null ? ...`) jeleníti meg a szöveges megnevezéseket.
- [x] **Dinamikus Élő Keresés:** A `txtKereses_TextChanged` esemény bekötésével a rendszer minden gombnyomásra valós időben szűri a MySQL adatbázist, miközben a prémium formázott táblázatnézet nem ugrik vissza az alapértelmezett nyers formátumra.
- [x] **Univerzális CSV Export:** Beépített `SaveFileDialog` segítségével a felhasználó tetszőleges helyre mentheti ki a teljes raktárkészlet aktuális pillanatképét standard formátumban.
- [x] **Soft Delete:** Biztonsági törlés `IsDeleted` logikai jelzővel az adatbázis-konzisztencia megőrzéséért.
- [x] **Tranzakció Biztonság:** Rollback-biztos, atomi adatbázis-tranzakciók kezelése hiba esetén.
- [x] **UTF-8 Kódolás:** Teljes körű Unicode támogatás a magyar ékezetes karakterek hibátlan megjelenítéséért.

## 🔮 Jövőbeli fejlesztési lehetőségek (Roadmap)
A projekt architektúrája úgy lett kialakítva, hogy a magasan skálázható backend rétegnek köszönhetően a jövőben az alábbi funkciók minimális ráfordítással integrálhatóak:

1. **Gyors Készletkorrekció (In-line CRUD):** A főtáblázat sorai mellé integrált azonnali `+1` és `-1` gombok elhelyezése, amivel a gyors napi raktári mozgások dupla kattintásos szerkesztőpanel nélkül, egyetlen kattintással adminisztrálhatóak.
2. **Élő Riasztási Rendszer:** Az alsó állapotsor (`StatusStrip`) dinamikus háttérszín-változtatása (pl. halványvörös villogás), amennyiben a háttérben futó szál detektálja, hogy egy termék készlete a kritikus minimum szint alá süllyedt.
3. **Valós idejű Tranzakciós Audit-Napló:** Egy dedikált kezelőfelület vagy fül, amely egy adott termékre kattintva idővonalas nézetben képes listázni a teljes életutat (ki, mikor, milyen irányba és mekkora mennyiséggel módosította a készletet).
4. **C# nanoFramework & Beágyazott Rendszerek:** A Core üzleti logika hordozhatóságát kihasználva a szoftver összekötése egy ESP32 / NodeMCU alapú mikrokontrolleres fizikai hardverrel (pl. fizikai vonalkódolvasó, vagy raktári állapotjelző LED kijelző).
