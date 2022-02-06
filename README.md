# LZW-Algorithm

![Browser Screenshot](https://github.com/Mietek-01/LZW-Algorithm/blob/master/Start%20View.png)

Algorytm LZW jest algorytmem kompresującym mającym na celu skompresować dane do mniejszych rozmiarów np. mając plik tekstowy o rozmiarze 10MB 
po jego skompresowaniu możemy uzyskać plik o rozmiarze 7MB.

Program, który napisałem w ramach projektu zaliczeniowego na studia, jest wizualizacją działania owego algorytmu na podstawie tekstu wprowadzonego przez użytkownika.

## Kompresja

Ilość zaoszczędzonej pamięci, dzięki takiej kompresji, będzie bardziej widoczna dla dużych plików, gdyż w skrócie algorytm ten po prostu zastępuję powtórzenia 
pewnych sekwencji znajdujących się w pliku odpowiednim indeksem słownika, który jest przez algorytm tworzony przed a później w trakcie jego działania. 

Przykład dwóch kompresji znajduje się w [Compression Examples](https://github.com/Mietek-01/LZW-Algorithm/blob/master/Compression%20Examples.txt) oraz na zdjęciu poniżej.

![Browser Screenshot](https://github.com/Mietek-01/LZW-Algorithm/blob/master/Compression%20Screen.png)

## Dekompresja

W moim programie zaimplementowałem możliwość zapisania skompresowanego kodu, jak również możliwość jego późniejszego zdekompresowania.

W celu zdekompresowania, algorytm potrzebuje do tego skompresowany kod (odpowiedni ciąg liczb) oraz słownik podstawowy, czyli taki który jest tworzony na początku kompresji.

![Browser Screenshot](https://github.com/Mietek-01/LZW-Algorithm/blob/master/Decompression%20Screen.png)

## Odnośniki

- Jeśli chcesz, możesz zobaczyć jak program działa pobierając go z sekcji [Releases](https://github.com/Mietek-01/LZW-Algorithm/releases).

- Mała dokumentacja znajduje sie [tutaj](https://github.com/Mietek-01/LZW-Algorithm/blob/master/Documentation.odt).

- Kod programu znajdu się w folderze [Core](https://github.com/Mietek-01/LZW-Algorithm/tree/master/LZW-Algorithm/Core).

- Cały algorytm LZW znajduje się w folderze [LZWAlgorithm](https://github.com/Mietek-01/LZW-Algorithm/tree/master/LZW-Algorithm/LZWAlgorithm).
