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
                    // ale z nazwa namespaca w ktorej obirkt sie znajduje !!!

                    /*string mn_stringedObject = mn_myElement.ToString();

                    if (mn_stringedObject == "MichałNiedek_LZW_Algorithm." + mn_myElement.GetType().Name)
                    {
                        var e = new Exception("Slowo jest zbudowane z obiektu ktory nie ma metody ToString!!!");
                        e.Source = MN_MainForm.MN_MainManager.MN_ExceptionPlace.RESULT.ToString();

                        throw e;
                    }
                    else*/

                    mn_stringedWord += mn_myElement.ToString();
                }

                return mn_stringedWord;
            }

            // W algorytmie kompresji potrzbuje rozszerzac slowo o kolejne obiekty w celu szukania kolejnych slow
            public void MN_Increase(T1 mn_newObject)
            {
                mn_myElements.Add(mn_newObject);
            }

            public bool MN_Equals(MN_LZWDictionaryWord mn_word)
            {
                if (mn_word == null) return false;

                if (mn_word.mn_myElements.Count != this.mn_myElements.Count)
                    return false;

                // Porownuje poszczegolne elementy dwoch slow
                for (int i = 0; i < this.mn_myElements.Count; i++)
                    if (!this.mn_myElements[i].Equals(mn_word.mn_myElements[i]))
                        return false;

                return true;
            }
        }
    }
}
