## GetBankNameLibrary

Przykład biblioteki, gotowej do wywołania z pozomiu aplikacji produkcyjno-logistycznych pakietu Rekord.ERP.
Składa sie z dwóch projektów:
* GetBankNameLibrary - właściwy projekt, który tworzy nasz przykładowy DLL
* LaunchGetBankName - prosty programik do uruchamiania tej DLL-ki pod testy

Dzięki zastosowania własnej technologii do kastomizacji aplikacji opartej na XML, można m.in. podłączać pliki DLL napisane w środowisku Visual Studio. 
Wymagane środowisko do kompilacji to ASP.NET 4 a klasy dostępne z tego pakietu muszą być oznaczone [ComVisible(true)] i posiadać metodę Execute z 3 parametrami, tak jak w tym przykładzie. Dwa parametry są wejściowe, tekstowe. 

Pierwszy to stała lista parametrów takich jak: ALIAS, USERNAME, PASSWORD, HANDLE, DBPATH, SHAREDCLIHANDLE, NAZWAFIRMY, MIASTOFIRMY i APLIKACJA.
Drugi to lista definiowana w XML. Dla tej DLL-ki takim parametrem (najważniejszym) jest BANKKONTO. Trzeci parametr to tekst zwracany do Delphi. Tu też oczekujemy listy w formacie nazwaparametru=wartosc. Dla tej DLL-ki najważniejszym zwracanym parametrem jest BANKNAZWA. Funkcja zwraca kod o typie integer. Gdy 0 to wszystko OK i jest ustawiane odpowiednie pole przy kontrahencie. Gdy wartość ujemna to wyświetlony jest komunikat o błędzie. Więcej na [forum firmy Rekord](https://forum.rekord.com.pl/)

## Licencja
Ten przykład można nieodpłatnie używać, dystrybuować oraz modyfikować [licencja MIT]
[Rekord SI](https://www.rekord.com.pl)
