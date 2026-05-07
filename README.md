# 📦 Raktárkezelő Rendszer (ProOktatás Projekt)

Ez egy professzionális, többrétegű architektúrára épülő C# alkalmazás, amely a **ProOktatás Full-stack tanfolyamának** keretein belül készül. A projekt a kezdeti fájlalapú tárolástól eljutott a vállalati szintű, tranzakcióbiztos MySQL megoldásig.

## 🚀 Fejlesztési szakaszok
1. **Konzolos prototípus (Legacy):** Kezdeti verzió CSV alapú tárolással. ✅
2. **Adatbázis & Backend (Core):** MySQL alapok, Entity Framework Core és Repository minta. ✅
3. **Üzleti Logika & Biztonság:** Soft Delete, összetett keresőmotor és tranzakciókezelés. ✅ *JELENLEGI ÁLLAPOT*
4. **WinForms GUI:** Modern grafikus felület real-time statisztikákkal és órával. 🔜 *KÖVETKEZŐ LÉPÉS*

## 🛠 Alkalmazott technológiák
- **Nyelv:** C# (.NET 10)
- **Fejlesztőkörnyezet:** JetBrains Rider (macOS M1)
- **Adatbázis:** MySQL / MariaDB (Pomelo EF Core provider)
- **ORM:** Entity Framework Core (Code-First megközelítés)
- **Architektúra:** 
    - **Repository Pattern:** Adatbázis-műveletek absztrakciója.
    - **Service Layer:** Központosított üzleti logika és hibakezelés.
    - **Unit of Work szemlélet:** Tranzakcióbiztos készletmódosítás.

## 🏗 Haladó Megoldások
- **Soft Delete:** A termékek nem törlődnek véglegesen az adatbázisból, így a korábbi tranzakciós előzmények (audit log) megmaradnak.
- **Tranzakció Biztonság (Atomicity):** A készletmódosítás és a naplózás "mindent vagy semmit" alapon fut le; hiba esetén a rendszer automatikusan visszagörgeti (rollback) a folyamatot.
- **Advanced Search:** Összetett szűrési lehetőség név, kategória és árintervallum alapján.
- **Validáció:** Beépített védelem a negatív készlet és érvénytelen árazás ellen.

## 📋 Jelenlegi funkciók
- [x] **Relációs adatmodell:** SQL Foreign Key kapcsolatok a konzisztenciáért.
- [x] **Automatizált naplózás:** Minden mozgás időbélyeggel ellátott tranzakciót generál.
- [x] **Leltárérték számítás:** Valós idejű pénzügyi összesítés a készletről.
- [x] **Kritikus készlet figyelés:** Automatikus riasztás az utánpótlás szükségességéről.
- [x] **Dátum- és Időkezelés:** Központosított, formázott időmegjelenítés.
