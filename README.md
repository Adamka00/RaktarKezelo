# 📦 Raktárkezelő Rendszer (ProOktatás Projekt)

Ez egy C# nyelven íródott raktárkezelő alkalmazás, amely a **ProOktatás Full-stack tanfolyamának** keretein belül készül. A projekt célja a C# nyelv alapjainak, az OOP elveknek és a Windows Forms keretrendszernek a bemutatása.

## 🚀 Fejlesztési terv
A projekt két szakaszban valósul meg:
1. **Konzolos prototípus:** Az üzleti logika (mentés, betöltés, listázás, keresés) kidolgozása. ✅ *KÉSZ*
2. **WinForms GUI:** Felhasználóbarát grafikus felület kialakítása (Windows környezetben). 🔜 *KÖVETKEZŐ LÉPÉS*

## 🛠 Alkalmazott technológiák és elvek
- **Nyelv:** C# (.NET 8/10)
- **Fejlesztőkörnyezet:** JetBrains Rider (macOS)
- **OOP alapelvek:** Egységbe zárás (Encapsulation), Polimorfizmus (Override)
- **S.O.L.I.D. elvek:** - *Single Responsibility:* Külön osztályok az adatnak, a logikának és a fájlkezelésnek.
    - *Dependency Inversion:* Interfész alapú fejlesztés (`IRaktar`, `IFajlKezelo`).
- **Adattárolás:** CSV fájl alapú perzisztencia (StreamWriter/StreamReader).
- **Adatkezelés:** LINQ (Language Integrated Query) és Lambda kifejezések a kereséshez és rendezéshez.

## 📋 Jelenlegi funkciók (Konzol)
Az alkalmazás jelenlegi állapotában a backend logika teljesen funkcionális:
- [x] **Termékek kezelése:** Új termékek felvétele egyedi azonosítóval (ID).
- [x] **Listázás:** Teljes raktárkészlet megjelenítése formázott kimenettel.
- [x] **Perzisztencia:** Adatok automatikus mentése és betöltése CSV fájlból (UTF-8 kódolással).
- [x] **Keresés:** Szűrés terméknévre (LINQ `Where`, kis/nagybetű független).
- [x] **Rendezés:** Termékek listázása ár szerint növekvő vagy csökkenő sorrendben (LINQ `OrderBy`).
- [x] **Hibakezelés:** `try-catch` blokkok a fájlműveleteknél és a bevitel ellenőrzésénél.

## 🔜 További fejlesztési tervek
- **Grafikus felület (GUI):** Átállás Windows Forms alapokra.
- **Interakció:** Gombok, beviteli mezők és DataGridView használata.
- **Bővített CRUD:** Termékek törlése és módosítása az ID alapján.