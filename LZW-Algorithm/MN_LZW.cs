using System;
using System.Collections.Generic;

namespace MichałNiedek_LZW_Algorithm.LZW
{
    public class MN_LZW<T>
    {
        MN_LZWDictionary<T> mn_myDictionary;

        public MN_LZW(MN_LZWDictionary<T> mn_dictionary)
        {
            mn_myDictionary = mn_dictionary;
        }

        public string MN_Compression(List<T> mn_sentSource, bool mn_drawInConsole = false)
        {
            //Zwrocony ciag bedzie zawsze ciagiem liczb
            List<int> mn_resultCode = new List<int>();

            // By nie zmieniac orginalu
            List<T> mn_source = new List<T>(mn_sentSource);

            //Algorytm kompresji
            MN_CompressionAlgorithm(mn_source, mn_resultCode);

            // Stworzenie stringowej wersji resultCoda oraz potencjalne wypisanie w konsoli
            return MN_Finalize<int>(mn_resultCode, true, mn_drawInConsole);
        }

        public string MN_Decompression(int[] mn_sentSource, bool mn_drawInConsole = false)
        {
            //Zwrocony ciag bedzie skladal sie z obiektow klasy T
            List<T> mn_resultCode = new List<T>();

            //By nie pracowac na orginale
            int[] mn_source = new int[mn_sentSource.Length];
            mn_sentSource.CopyTo(mn_source, 0);

            //Algorytm dekompresj
            MN_DecompressionAlgorithm(mn_source, mn_resultCode);

            // Stworzenie stringowej wersji resultCoda oraz potencjalne wypisanie w konsoli
            return MN_Finalize<T>(mn_resultCode, false, mn_drawInConsole);
        }

        void MN_CompressionAlgorithm(List<T> mn_source, List<int> mn_resultCode)
        {
            // Z nich sklada sie skompresowany kod
            int mn_previousSearchedIndex = 0;

            try
            {
                while (true)
                {
                    //Zawsze zaczynam od pierwszego elementu w zrodle
                    int mn_sourceIndex = 0;

                    // Z tego elementu tworze slowo ktorym bd sprawdzac czy jest takie w slowniku
                    MN_LZWDictionary<T>.MN_LZWDictionaryWord mn_tmpWord = new MN_LZWDictionary<T>.MN_LZWDictionaryWord(mn_source[mn_sourceIndex]);

                    do
                    {
                        // Sprawdzam czy slowo jest w slowniku
                        int mn_wordIndex = mn_myDictionary.MN_FindIndex(mn_tmpWord);

                        //Czyli w slowniku jest to slowo wiec je rozszerzam o kolejny obiekt
                        if (mn_wordIndex != -1)
                        {
                            mn_previousSearchedIndex = mn_wordIndex;

                            mn_sourceIndex++;

                            // !!!!-----Jest to kluczowa linijka bo zapewnia wyjscie z petli----!!!!!
                            //W tym miejscu rzuci wyjatek gdy dojde o konca zrodla
                            mn_tmpWord.MN_Increase(mn_source[mn_sourceIndex]);
                        }
                        else
                        {
                            // Dodaje moj index slowa ktorego szukalem
                            mn_resultCode.Add(mn_previousSearchedIndex);

                            //Usuwam niepotrzebne juz elementy ze zrodla
                            mn_source.RemoveRange(0, mn_sourceIndex);

                            //Dodaje do slownika slowo ktorego nie bylo
                            mn_myDictionary.MN_AddWord(mn_tmpWord);

                            break;

                        }

                    } while (true);
                }

            }
            catch (ArgumentOutOfRangeException e)
            {
                //Doszedlem do konca zrodla i dodaje ostatni index
                mn_resultCode.Add(mn_previousSearchedIndex);
            }
        }

        void MN_DecompressionAlgorithm(int[] mn_source, List<T> mn_resultCode)
        {
            MN_LZWDictionary<T>.MN_LZWDictionaryWord mn_firstWord = null;
            MN_LZWDictionary<T>.MN_LZWDictionaryWord mn_secondWord = null;
            MN_LZWDictionary<T>.MN_LZWDictionaryWord mn_newWord;

            // Pozwala przeiterowac przez elementy zrodla
            int mn_index = 0;

            do
            {
                try
                {
                    //!!!Zawartoscia sourca sa indexy slownika!!!
                    mn_firstWord = mn_myDictionary[mn_source[mn_index] - 1];

                    // Dodajemy od razu pierwsze skompresowane slowo do wyniku
                    foreach (T mn_item in mn_firstWord.mn_wordElements)
                        mn_resultCode.Add(mn_item);

                    mn_index++;

                    // Znaczy ze doszedlem do konca zrodla
                    if (mn_index == mn_source.Length)
                        return;

                    // Tutaj moze zucic wyjatek bo index slownika jaki przechowuje source pod
                    // index + 1 moze wykraczac poza zakres ( odwolywac sie do elementow slownika
                    // ktorego w nim jeszcze nie ma)
                    mn_secondWord = mn_myDictionary[mn_source[mn_index] - 1];

                    // Tutaj tworze nowe slowo ktore pozniej dodam do slownika
                    mn_newWord = new MN_LZWDictionary<T>.MN_LZWDictionaryWord(mn_firstWord.mn_wordElements.ToArray());

                    mn_newWord.MN_Increase(mn_secondWord.mn_wordElements[0]);

                    mn_myDictionary.MN_AddWord(mn_newWord);

                }
                catch (ArgumentOutOfRangeException e)
                {
                    // Gdy mamy taki wyjatek nowe slowo tworze calkowicie z pierwszego
                    // Bo drugiego jeszcze nie ma
                    mn_newWord = new MN_LZWDictionary<T>.MN_LZWDictionaryWord(mn_firstWord.mn_wordElements.ToArray());

                    mn_newWord.MN_Increase(mn_firstWord.mn_wordElements[0]);

                    mn_myDictionary.MN_AddWord(mn_newWord);

                }

            } while (true);

        }

        string MN_Finalize<T2>(List<T2> mn_resultCode, bool mn_forCompression, bool mn_drawInConsole)
        {
            if (mn_drawInConsole)
            {
                Console.WriteLine("Wynik kompresji: ");

                foreach (var mn_obj in mn_resultCode)
                    if (mn_forCompression)
                        Console.Write(mn_obj + " ");
                    else
                        Console.Write(mn_obj);

                Console.WriteLine();
                Console.WriteLine();
            }

            string mn_result = "";

            foreach (var mn_obj in mn_resultCode)
                if (mn_forCompression)
                    mn_result += mn_obj.ToString() + " ";
                else
                    mn_result += mn_obj.ToString();

            return mn_result;

        }
    }
}
