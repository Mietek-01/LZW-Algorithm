using System;
using System.Collections.Generic;
using System.Linq;

namespace MichałNiedek_LZW_Algorithm.LZW
{
    public partial class MN_LZWDictionary<T1>
    {
        public class MN_LZWDictionaryWord
        {
            // Slowo moze skladac sie z kilku elementow, klasa ta umozliwia wypisanie slowa i jego porownanie
            public List<T1> mn_wordElements { get; private set; }

            public MN_LZWDictionaryWord(T1[] mn_obj)
            {
                // Slowo moze byc zbudowane z kilku objektow dla slowa "aba" beda to 3 chary
                mn_wordElements = mn_obj.ToList();
            }

            public MN_LZWDictionaryWord(T1 mn_obj)
            {
                // Lub slowo moze byc pojedynczym obiektem 
                mn_wordElements = new List<T1>();

                mn_wordElements.Add(mn_obj);
            }

            public override string ToString()
            {
                string mn_name = "";

                foreach (T1 mn_elementOfObject in mn_wordElements)
                {
                    // Gdy obiekt nie bd mial przeciazanej metody ToString wywolanie jej zworci nazwe klasy ale z 
                    // nazwa namespaca
                    string mn_stringVersionOfObject = mn_elementOfObject.ToString();

                    if (mn_stringVersionOfObject == "_53421_MN_LZW." + mn_elementOfObject.GetType().Name)
                    {
                        Exception e = new Exception("Slowo jest zbudowane z obiektu ktory nie ma metody ToString!!!");
                        e.Source = MN_MainForm.MN_MainManager.MN_ExceptionPlace.RESULT.ToString();

                        throw e;
                    }
                    else
                        mn_name += mn_elementOfObject.ToString();
                }

                return mn_name;
            }

            //W algorytmie kompresji potrzbuje rozszerzac slowo o kolejne obiekty w celu szukania kolejnych slow
            public void MN_Increase(T1 mn_obj)
            {
                mn_wordElements.Add(mn_obj);
            }

            // Zwykle porownanie z innym slowem
            public bool MN_Equals(MN_LZWDictionaryWord mn_word)
            {
                if (mn_word == null) return false;

                if (mn_word.mn_wordElements.Count != this.mn_wordElements.Count)
                    return false;

                // Porownuje poszczegolne elementy dwoch slow
                for (int i = 0; i < this.mn_wordElements.Count; i++)
                    if (!this.mn_wordElements[i].Equals(mn_word.mn_wordElements[i]))
                        return false;

                return true;
            }
        }
    }
}
