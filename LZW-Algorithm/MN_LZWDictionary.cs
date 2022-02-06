using System;
using System.Collections.Generic;

namespace MichałNiedek_LZW_Algorithm.LZW
{
    public partial class MN_LZWDictionary<T1>
    {
        public MN_LZWDictionaryWord this[int mn_index] => mn_myWords[mn_index];

        List<MN_LZWDictionaryWord> mn_myWords = new List<MN_LZWDictionaryWord>();

        public MN_LZWDictionary(T1[] mn_sentSource, bool forCompress)
        {
            if (forCompress)
            {
                //Algorytm okreslajacy slownik poczatkowy na podstawie przeslanego zrodla
                List<T1> mn_source = new List<T1>(mn_sentSource);

                for (int mn_i = 0; mn_i < mn_source.Count; mn_i++)
                {
                    // Dodaje pierwszy obiekt z zrodla
                    MN_AddWord(new MN_LZWDictionaryWord(mn_source[mn_i]));

                    // Usuwam kolejne powtorzenia
                    for (int mn_j = mn_i + 1; mn_j < mn_source.Count; mn_j++)
                    {
                        if (mn_source[mn_i].Equals(mn_source[mn_j]))
                        {
                            mn_source.RemoveAt(mn_j);
                            mn_j--;
                        }
                    }
                }
            }
            else
            {
                // W dekompresji przeslane zrodlo zawsze jest bazowym slownikiem
                // W momencie gdy w przeslanym slowniku bd powtorzenia znakow rzuci mi wyjatek
                foreach (T1 mn_obj in mn_sentSource)
                    MN_AddWord(new MN_LZWDictionaryWord(mn_obj));
            }
        }

        public override string ToString()
        {
            string mn_stringDictionary = "";

            foreach (var word in mn_myWords)
                mn_stringDictionary += word.ToString();

            return mn_stringDictionary;
        }

        public void MN_AddWord(MN_LZWDictionaryWord mn_word)
        {
            if (MN_FindIndex(mn_word) == -1)
                mn_myWords.Add(mn_word);
            else
            {
                Exception e = new Exception("Probujesz dodac do slownika slowo ktore juz sie w nim znajduje!!!");
                e.Source = MN_MainForm.MN_MainManager.MN_ExceptionPlace.BASIC_DICTIONARY.ToString();

                throw e;
            }
        }

        public int MN_FindIndex(MN_LZWDictionaryWord mn_wordToEqual)
        {
            int mn_index = mn_myWords.FindIndex(word => word.MN_Equals(mn_wordToEqual));

            // -1 oznacza ze nie znalazl natomiast gdy znajdzie to musimy zwiekszyc o jeden bo w 
            // algorytmie LZW indexuje sie od 1
            if (mn_index != -1)
                mn_index++;

            return mn_index;
        }

        public void MN_WriteInConsole()
        {
            Console.WriteLine("\nMy Words:");

            for (int i = 0; i < mn_myWords.Count; i++)
                Console.WriteLine(i.ToString() + ". " + mn_myWords[i]);

            Console.WriteLine();
        }

        public string[] MN_GetStringWords()
        {
            var mn_stringDictionary = new List<string>();

            foreach (var word in mn_myWords)
                mn_stringDictionary.Add(word.ToString());

            return mn_stringDictionary.ToArray();
        }
    }
}
