# 📦 Raktárkezelő Rendszer (ProOktatás Projekt)

Ez egy professzionális, többrétegű architektúrára épülő C# alkalmazás, amely a **ProOktatás Full-stack tanfolyamának** keretein belül készül. A projekt a kezdeti fájlalapú tárolástól mára eljutott egy hálózaton átívelő, Windows-Mac hibrid környezetben futó, vállalati szintű MySQL megoldásig.

## 🚀 Fejlesztési szakaszok
1. **Konzolos prototípus (Legacy):** Kezdeti verzió CSV alapú tárolással. ✅
2. **Adatbázis & Backend (Core):** MySQL alapok, Entity Framework Core és Repository minta. ✅
3. **Üzleti Logika & Biztonság:** Soft Delete, összetett keresőmotor és tranzakciókezelés. ✅
4. **WinForms GUI (Frontend):** Modern grafikus felület real-time MySQL adatszűréssel, adatbeviteli validációval és ketyegő rendszeridővel. ✅ *JELENLEGI ÁLLAPOT*

## 🛠 Alkalmazott technológiák és Környezet
- **Nyelv & Keretrendszer:** C# (.NET 9.0)
- **Hibrid Fejlesztői Környezet:**
  - **Host (Mac):** JetBrains Rider macOS (M1) – Itt fut a központi backend fejlesztés és a helyi MySQL / MariaDB szerver.
  - **Guest (Windows):** Parallels Desktop virtuális gép & Microsoft Visual Studio – Itt fut a Windows-specifikus WinForms frontend, amely belső virtuális hálózati hídon (Named Pipes & IP-híd) keresztül kommunikál a Mac-es adatbázissal.
- **ORM:** Entity Framework Core (Code-First megközelítés, Pomelo provider)
- **Architektúra:** - **Repository Pattern:** Adatbázis-műveletek tiszta absztrakciója.
    - **Service Layer:** Központosított üzleti logika és hibakezelés.
    - **Unit of Work szemlélet:** Tranzakcióbiztos készletmódosítás.

## 🏗 Haladó Megoldások & WinForms Funkciók
- **Élő Grafikus Felület:** DataGridView alapú termékmegjelenítés, amely közvetlenül a távoli MySQL szerverről táplálkozik.
- **Real-time Keresőmotor:** Gépelés közbeni (TextChanged alapú) azonnali szűrés név és cikkszám alapján.
- **Golyóálló Adatbevitel:** Beépített `TryParse` alapú formvalidáció a frontend oldalon, ami megakadályozza az érvénytelen árak, negatív készletek vagy hibás karakterek adatbázisba kerülését.
- **Soft Delete:** A termékek nem törlődnek véglegesen az adatbázisból, így a korábbi tranzakciós előzmények (audit log) megmaradnak.
- **Tranzakció Biztonság (Atomicity):** A készletmódosítás és a naplózás "mindent vagy semmit" alapon fut le; hiba esetén a rendszer automatikusan visszagörgeti (rollback) a folyamatot.

## 📋 Jelenlegi funkciók
- [x] **Relációs adatmodell:** SQL Foreign Key kapcsolatok a konzisztenciáért.
- [x] **Automatizált naplózás:** Minden mozgás időbélyeggel ellátott tranzakciót generál.
- [x] **Leltárérték számítás:** Valós idejű pénzügyi összesítés a készletről.
- [x] **Kritikus készlet figyelés:** Automatikus riasztás az utánpótlás szükségességéről.
- [x] **Dátum- és Időkezelés:** Központosított, másodpercre pontos rendszeridő-kijelzés a WinForms StatusStrip-en.
- [x] **Biztonságos mentés:** Teljes Unicode (UTF-8) támogatás a magyar ékezetes karakterek megőrzéséért.
