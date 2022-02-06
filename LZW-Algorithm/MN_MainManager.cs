using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MichałNiedek_LZW_Algorithm.LZW;

namespace MichałNiedek_LZW_Algorithm
{
    public partial class MN_MainForm
    {
        public static partial class MN_MainManager
        {   
            public enum MN_ExceptionPlace
            { 
                SOURCE_DATA,
                RESULT,
                BASIC_DICTIONARY,
                GENERATED_DICTIONARY
            }

            public enum MN_LZWMode
            {
                COMPRESS,
                DECOMPRESS
            }
            
            public static MN_LZWMode MN_LZWAlgorithmMode
            {
                get => mn_LZWAlgorithmMode;
                set
                {
                    mn_LZWAlgorithmMode = value;
                    MN_ResetResource(false);
                }
            }

            public static int MN_NumberOfPreservedCompressions => mn_preservedCompressions.Count;

            static MN_LZWMode mn_LZWAlgorithmMode = MN_LZWMode.COMPRESS;

            static MN_MainForm mn_form;
            static MN_LZWVisibleDictionary mn_generetedDictionary;

            // Tutaj zapisuje swoje kompresje ktore pozniej bede mogl zapisac do pliku
            // Kluczem jest bazowy slownik a wartoscia skompresowany kod
            static List<KeyValuePair<string, string>> mn_preservedCompressions = new List<KeyValuePair<string, string>>();

            #region Main Methods

            public static void MN_Run()
            {
                mn_form.mn_ErrorProvider.Dispose();

                string mn_txtSource = mn_form.mn_txt_Source.Text;

                try
                {
                    if (MN_LZWAlgorithmMode == MN_LZWMode.COMPRESS)
                        mn_form.mn_txt_Result.Text = MN_Compress(MN_GetSourceForCompression(mn_txtSource));
                    else
                        mn_form.mn_txt_Result.Text = MN_Decompress(MN_GetSourceForDecompression(mn_txtSource));
                }
                catch(Exception mn_e)
                {
                    if (mn_e.Source == MN_ExceptionPlace.SOURCE_DATA.ToString())
                        mn_form.mn_ErrorProvider.SetError(mn_form.mn_lbl_SourceData, mn_e.Message);

                    else if (mn_e.Source == MN_ExceptionPlace.RESULT.ToString())
                        mn_form.mn_ErrorProvider.SetError(mn_form.mn_lbl_Result, mn_e.Message);

                    else if (mn_e.Source == MN_ExceptionPlace.BASIC_DICTIONARY.ToString())
                        mn_form.mn_ErrorProvider.SetError(mn_form.mn_lbl_BDictionary, mn_e.Message);

                    else if (mn_e.Source == MN_ExceptionPlace.GENERATED_DICTIONARY.ToString())
                        mn_form.mn_ErrorProvider.SetError(mn_form.mn_lbl_GeneratedDictionary, mn_e.Message);

                    else
                    mn_form.mn_ErrorProvider.SetError(mn_form.mn_btn_Run, mn_e.Message);
                }
                
            }

            public static void MN_ResetResource(bool mn_resetByButton)
            {
                // Resetowac mozna poprzez uzycie przycisku lub przelaczajac sie pomiedzy trybami

                GC.Collect();

                mn_form.mn_ErrorProvider.Dispose();

                mn_form.mn_txt_Result.ResetText();
                mn_form.mn_txt_Source.ResetText();

                mn_form.mn_txt_BDicitonary.ReadOnly = false;

                // Usuwam graficzna wizualizacje slownika
                if (mn_generetedDictionary!=null)
                {
                    mn_generetedDictionary.MN_Clear();
                    mn_generetedDictionary = null;
                }

                // Dzieki temu przy zmianie na dekompresje nie usunie mi bazowego slownika
                if(mn_resetByButton)
                    mn_form.mn_txt_BDicitonary.ResetText();

                // Gdy jest to reset gdy tryb jest ustawiony na dekompresej
                if (mn_LZWAlgorithmMode == MN_LZWMode.COMPRESS)
                {
                    mn_form.mn_btn_Preserve.Visible = true;
                    mn_form.mn_btn_Preserve.Enabled = false;
                    mn_form.mn_txt_BDicitonary.ResetText();

                    MN_ShowBasicDictionaryInput(false);
                }
                else
                    mn_form.mn_btn_Preserve.Visible = false;
            }
            
            public static void MN_ShowBasicDictionaryInput(bool mn_value)
            {               
                mn_form.mn_txt_BDicitonary.Visible = mn_value;
                mn_form.mn_lbl_BDictionary.Visible = mn_value;

                // Aktualizuje forme
                mn_form.Show();
            }

            public static void MN_RegisterForm(MN_MainForm mn_sentForm)
            {
                mn_form = mn_sentForm;
            }

            #endregion

            #region Compression Saving Methods

            public static void MN_PreserveCurrentCompression()
            {
                string mn_basicDictionary = mn_form.mn_txt_BDicitonary.Text;
                string mn_compressedCode = mn_form.mn_txt_Result.Text;

                mn_preservedCompressions.Add(new KeyValuePair<string, string>(mn_basicDictionary, mn_compressedCode));

                mn_form.mn_lbl_NumberOfPreservedCompressions.Text = mn_preservedCompressions.Count.ToString();

                mn_form.mn_btn_Preserve.Enabled = false;
            }
            
            public static void MN_SaveCompressionsToFile(bool mn_sort)
            {
                mn_form.mn_SavedFileDialog.Filter = "Plik tekstowy (*.txt)|";
                mn_form.mn_SavedFileDialog.FilterIndex = 1;
                mn_form.mn_SavedFileDialog.RestoreDirectory = true;
                mn_form.mn_SavedFileDialog.InitialDirectory = "C:\\";
                mn_form.mn_SavedFileDialog.Title = " Zapisanie skompresowanych kodów";

                if (mn_form.mn_SavedFileDialog.ShowDialog() == DialogResult.OK)
                {
                    System.IO.StreamWriter mn_file = new System.IO.StreamWriter(mn_form.mn_SavedFileDialog.OpenFile());

                    try
                    {
                        if (mn_sort)
                            MN_SortPreservedCompressions();

                        int mn_i = 1;
                        foreach (var mn_obj in mn_preservedCompressions)
                        {
                            mn_file.WriteLine(mn_i.ToString() + ".\n" + "BasicDictionary:" + mn_obj.Key);
                            mn_file.WriteLine();
                            mn_file.WriteLine("CompressedCode:" + mn_obj.Value);

                            mn_file.WriteLine();
                            mn_file.WriteLine();

                            mn_i++;
                        }
                    }
                    catch (Exception mn_e)
                    {
                        MessageBox.Show(mn_e.Message);
                    }
                    finally
                    {
                        mn_file.Dispose();
                        mn_file.Close();
                    }

                }
            }

            static void MN_SortPreservedCompressions()
            {
                //Bubble sort
                for (int mn_i = 0; mn_i < mn_preservedCompressions.Count; mn_i++)
                {
                    for (int mn_j = 0; mn_j < mn_preservedCompressions.Count - 1; mn_j++)
                    {
                        if (mn_preservedCompressions[mn_j].Value.Length > mn_preservedCompressions[mn_j + 1].Value.Length)
                        {
                            var mn_temp = mn_preservedCompressions[mn_j + 1];
                            mn_preservedCompressions[mn_j + 1] = mn_preservedCompressions[mn_j];
                            mn_preservedCompressions[mn_j] = mn_temp;
                        }
                    }
                }
            }

            public static void MN_ClearPreservedCompressions()
            {
                mn_preservedCompressions.Clear();
                mn_form.mn_lbl_NumberOfPreservedCompressions.Text = "0";
            }

            #endregion

            #region LZW Management Methods

            static string MN_Compress(char[] mn_source)
            {
                var mn_dictionary = new MN_LZWDictionary<char>(mn_source,mn_LZWAlgorithmMode == MN_LZWMode.COMPRESS);

                // Zapisze to sobie pozniej do textBoxa
                string mn_basicDictionary = mn_dictionary.ToString();

                //--------------Kompresja LZW----------//

                var mn_lzw = new MN_LZW<char>(mn_dictionary);

                //Console.WriteLine("KOMPRESJA");
                //Console.WriteLine("ZRODLO: " + new string(source));

                //dictionary.Draw();

                string mn_result = mn_lzw.MN_Compression(mn_source.ToList());

                //dictionary.Draw();

                MN_ShowBasicDictionaryInput(true);

                mn_form.mn_txt_BDicitonary.Text = mn_basicDictionary;
                mn_form.mn_txt_BDicitonary.ReadOnly = true;

                // Tworze graficzna wizualizacje slownika lub go aktualizuje
                if (mn_generetedDictionary == null)
                    mn_generetedDictionary = new MN_LZWVisibleDictionary(mn_form, mn_dictionary.MN_GetStringWords());
                else
                    mn_generetedDictionary.MN_Update(mn_dictionary.MN_GetStringWords());

                mn_form.mn_btn_Preserve.Enabled = true;

                return mn_result;

            }

            static string MN_Decompress(int[] mn_source)
            {
                // Pobieram bazowy slownik podany przez uzytkownika
                string mn_basicDictionary = mn_form.mn_txt_BDicitonary.Text;

                if (new string(mn_basicDictionary.ToCharArray()).Trim(' ').Length == 0)
                {
                    Exception mn_e = new Exception("Bazowy słownik nie może być pusty!!!");
                    mn_e.Source = MN_ExceptionPlace.BASIC_DICTIONARY.ToString();

                    throw mn_e;
                }

                var mn_dictionary = new MN_LZWDictionary<char>(mn_basicDictionary.ToCharArray()
                    ,mn_LZWAlgorithmMode == MN_LZWMode.COMPRESS);

                //-----------Dekompresja--------

                var mn_lzw = new MN_LZW<char>(mn_dictionary);

                //Console.WriteLine("DEKOMPRESJA");

                //dictionary.Draw();

                string mn_result = mn_lzw.MN_Decompression(mn_source);

                //dictionary.Draw();

                mn_form.mn_txt_BDicitonary.ReadOnly = true;

                // Tworze graficzna wizualizacje slownika lub jego aktualizacja
                if (mn_generetedDictionary == null)
                    mn_generetedDictionary = new MN_LZWVisibleDictionary(mn_form, mn_dictionary.MN_GetStringWords());
                else
                    mn_generetedDictionary.MN_Update(mn_dictionary.MN_GetStringWords());

                return mn_result;
            }

            static char[] MN_GetSourceForCompression(string mn_txtSource)
            {
                if (mn_txtSource.Length <= 3 || new string(mn_txtSource.ToCharArray()).Trim(' ').Length == 0)
                {
                    Exception mn_e = new Exception("Ciąg musi składać się z przynajmniej 3 znaków nie będacymi spacją");
                    mn_e.Source = MN_ExceptionPlace.SOURCE_DATA.ToString();

                    throw mn_e;
                }

                return mn_txtSource.ToCharArray();
            }

            static int[] MN_GetSourceForDecompression(string mn_txtSource)
            {
                if (new string(mn_txtSource.ToCharArray()).Trim(' ').Length == 0)
                {
                    Exception mn_e = new Exception("Podaj kod do dekompresji!!!");
                    mn_e.Source = MN_ExceptionPlace.SOURCE_DATA.ToString();

                    throw mn_e;
                }

                List<int> mn_source=new List<int>();

                // Poprostu dziele txtSource na spacje
                List<string> mn_splitSource = new List<string>(mn_txtSource.Split(' '));

                foreach (var mn_obj in mn_splitSource)
                {
                    int mn_number;

                    // Sprawdzam czy podzielony tekst sklada sie z liczb
                    if(!int.TryParse(mn_obj,out mn_number))
                    {
                        // Dzieki temu biale znaki mi poprostu pominie i zrobienie np dwoch spacji
                        // Nie zablokuje pobierania danych

                        if (new string(mn_obj.ToCharArray()).Trim(' ').Length != 0 )// Czyli gdy obiekt jest litera
                        {
                            Exception mn_e = new Exception("Błędny kod, w kodzie do dekompresji moga wystepować tylko liczby odzielone jedną spacja!!!");
                            mn_e.Source = MN_ExceptionPlace.SOURCE_DATA.ToString();

                            throw mn_e;
                        }

                    }else
                        mn_source.Add(mn_number);
                }


                return mn_source.ToArray();
            }

            #endregion

        }
    }
}
