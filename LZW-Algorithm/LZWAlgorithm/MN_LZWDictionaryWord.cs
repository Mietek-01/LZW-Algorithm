using System;
using System.Collections.Generic;
using System.Linq;

namespace MichałNiedek_LZW_Algorithm.LZW
{
    public partial class MN_LZWDictionary<T1>
    {
        public class MN_LZWDictionaryWord
        {
            // Slowo sklada sie elementow czyli poszczegolnych obietkow.
            // Klasa ta umozliwia stworzenie slowa oraz jego wypisanie i porownanie z innymi slowami
            public List<T1> mn_myElements { get; private set; } = new List<T1>();

            public MN_LZWDictionaryWord(T1[] mn_objects)
            {
                // Slowo moze skladac sie z kilku elementow jak np. dla obiektu typu string "aba" beda to 3 chary
                mn_myElements = mn_objects.ToList();
            }

            public MN_LZWDictionaryWord(T1 mn_object)
            {
                // Slowo moze skladac sie z jednego elementu jak np. dla obiektu typu string "a" bedzie to jeden char
                mn_myElements.Add(mn_object);
            }

            public override string ToString()
            {
                string mn_stringedWord = "";

                foreach (var mn_myElement in mn_myElements)
                {
                    // !!! Gdy obiekt nie bd mial przeciazanej metody ToString wywolanie jej zworci nazwe klasy
                    // ale z nazwa namespaca w ktorej obiekt sie znajduje !!!

                    mn_stringedWord += mn_myElement.ToString();
                }

                return mn_stringedWord;
            }

            // W algorytmie kompresji potrzbuje rozszerzac slowo o kolejne obiekty w celu szukania kolejnych slow
            public void MN_Increase(T1 mn_newObject)
            {
                mn_myElements.Add(mn_newObject);
            }

            public override bool Equals(object obj)
            {
                if (obj == null || !(obj is MN_LZWDictionaryWord)) return false;

                if (this == obj) return true;

                var mn_wordToCompare = (MN_LZWDictionaryWord)obj;

                if (this.mn_myElements.Count != mn_wordToCompare.mn_myElements.Count) return false;

                // Porownuje poszczegolne elementy dwoch slow
                for (int i = 0; i < this.mn_myElements.Count; i++)
                    if (!this.mn_myElements[i].Equals(mn_wordToCompare.mn_myElements[i]))
                        return false;

                return true;
            }

            public override int GetHashCode()
            {
                return mn_myElements.GetHashCode();
            }
        }
    }
}
