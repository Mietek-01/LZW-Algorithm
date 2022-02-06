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

        public string MN_Compress(List<T> mn_sentSource, bool mn_writeInConsole = false)
        {
            // Rezultatem kompresji bedzie ciag liczb
            var mn_resultedCode = new List<int>();

            // By nie zmieniac orginalu
            var mn_source = new List<T>(mn_sentSource);

            // Algorytm kompresji
            MN_CompressionAlgorithm(mn_source, mn_resultedCode);

            // Konwersja skompresowanego zrodla na string
            return MN_ConvertToString<int>(mn_resultedCode, true, mn_writeInConsole);
        }

        public string MN_Decompress(int[] mn_sentSource, bool mn_writeInConsole = false)
        {
            // Rezultatem dekompresji bedzie ciag obiektow typu T
            var mn_resultedCode = new List<T>();

            // By nie pracowac na orginale
            var mn_source = new int[mn_sentSource.Length];
            mn_sentSource.CopyTo(mn_source, 0);

            // Algorytm dekompresj
            MN_DecompressionAlgorithm(mn_source, mn_resultedCode);

            // Konwersja zdekompresowanego zrodla na string
            return MN_ConvertToString<T>(mn_resultedCode, false, mn_writeInConsole);
        }

        void MN_CompressionAlgorithm(List<T> mn_source, List<int> mn_resultedCode)
        {
            // Z nich sklada sie skompresowany kod
            int mn_previousSearchedIndex = 0;

            try
            {
                while (true)
                {
                    // Zawsze zaczynam od pierwszego elementu w zrodle
                    int mn_sourceIndex = 0;

                    // Z tego elementu tworze slowo ktorym bede sprawdzac czy jest takie w slowniku
                    var mn_tmpWord = new MN_LZWDictionary<T>.MN_LZWDictionaryWord(mn_source[mn_sourceIndex]);

                    do
                    {
                        // Sprawdzam czy slowo jest w slowniku
                        int mn_wordIndex = mn_myDictionary.MN_FindIndex(mn_tmpWord);

                        // Jesli jest to rozszerzam je o kolejny element zrodla
                        if (mn_wordIndex != -1)
                        {
                            mn_previousSearchedIndex = mn_wordIndex;

                            mn_sourceIndex++;

                            // !!! W tym miejscu rzuci wyjatek gdy dojde o konca zrodla !!!
                            mn_tmpWord.MN_Increase(mn_source[mn_sourceIndex]);
                        }
                        else
                        {
                            // Dodaje moj index slowa ktorego szukalem
                            mn_resultedCode.Add(mn_previousSearchedIndex);

                            // Usuwam niepotrzebne juz elementy ze zrodla
                            mn_source.RemoveRange(0, mn_sourceIndex);

                            // Dodaje do slownika slowo ktorego nie bylo
                            mn_myDictionary.MN_AddWord(mn_tmpWord);

                            break;
                        }

                    } while (true);
                }

            }
            catch (ArgumentOutOfRangeException e)
            {
                // Doszedlem do konca zrodla i dodaje ostatni index
                mn_resultedCode.Add(mn_previousSearchedIndex);
            }
        }

        void MN_DecompressionAlgorithm(int[] mn_source, List<T> mn_resultedCode)
        {
            MN_LZWDictionary<T>.MN_LZWDictionaryWord mn_firstWord = null;
            MN_LZWDictionary<T>.MN_LZWDictionaryWord mn_secondWord = null;
            MN_LZWDictionary<T>.MN_LZWDictionaryWord mn_newWord = null;

            // Pozwala iterowac przez zrodlo
            int mn_index = 0;

            do
            {
                try
                {
                    // !!! Source sklada sie z indexow slownika !!!
                    mn_firstWord = mn_myDictionary[mn_source[mn_index] - 1];

                    // Dodajemy od razu pierwsze skompresowane slowo do wyniku mn_resultedCode
                    foreach (var mn_wordElement in mn_firstWord.mn_myElements)
                        mn_resultedCode.Add(mn_wordElement);

                    mn_index++;

                    // Znaczy ze doszedlem do konca zrodla
                    if (mn_index == mn_source.Length)
                        return;

                    // Tutaj moze zucic wyjatek bo index slownika jaki przechowuje source pod
                    // index + 1 moze wykraczac poza zakres tzn. moze odwolywac sie do elementow slownika
                    // ktory jeszcze nie istnieje
                    mn_secondWord = mn_myDictionary[mn_source[mn_index] - 1];

                    // Tutaj tworze nowe slowo ktore pozniej dodam do slownika
                    mn_newWord = new MN_LZWDictionary<T>.MN_LZWDictionaryWord(mn_firstWord.mn_myElements.ToArray());

                    mn_newWord.MN_Increase(mn_secondWord.mn_myElements[0]);

                    mn_myDictionary.MN_AddWord(mn_newWord);

                }
                catch (ArgumentOutOfRangeException e)
                {
                    // Gdy mamy taki wyjatek nowe slowo tworze calkowicie z pierwszego bo drugiego jeszcze nie ma
                    mn_newWord = new MN_LZWDictionary<T>.MN_LZWDictionaryWord(mn_firstWord.mn_myElements.ToArray());

                    mn_newWord.MN_Increase(mn_firstWord.mn_myElements[0]);

                    mn_myDictionary.MN_AddWord(mn_newWord);

                }

            } while (true);

        }

        string MN_ConvertToString<T2>(List<T2> mn_resultedCode, bool mn_forCompression, bool mn_writeInConsole)
        {
            if (mn_writeInConsole)
            {
                Console.WriteLine("Result: ");

                foreach (var mn_obj in mn_resultedCode)
                    if (mn_forCompression)
                        Console.Write(mn_obj + " ");
                    else
                        Console.Write(mn_obj);

                Console.WriteLine();
                Console.WriteLine();
            }

            string mn_stringedResult = "";

            foreach (var mn_obj in mn_resultedCode)
                if (mn_forCompression)
                    mn_stringedResult += mn_obj.ToString() + " ";
                else
                    mn_stringedResult += mn_obj.ToString();

            return mn_stringedResult;

        }
    }
}
