using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MichałNiedek_LZW_Algorithm
{
    public partial class MN_MainForm
    {
        static partial class MN_MainManager
        {
            /// <summary>
            /// Klasa odpowiedzialna za wyrysowanie slownika w oknie
            /// </summary>
            class MN_LZWVisibleDictionary
            {
                MN_MainForm mn_form;

                // Komurka sklada sie z numerka i textBox-a
                List<KeyValuePair<Label, TextBox>> mn_myCells = new List<KeyValuePair<Label, TextBox>>();

                // Pierwowzory
                Label mn_basicLabel;
                TextBox mn_basicTextBox;

                readonly int mn_maxNumberOfCollumns = 9;
                readonly int mn_rows = 6;
                readonly Point mn_offset = new Point(70, 50);

                public MN_LZWVisibleDictionary(MN_MainForm mn_sentForm, string [] mn_dictionary)
                {
                    mn_form = mn_sentForm;
                    mn_basicLabel = mn_form.mn_lbl_NumberOfCell;
                    mn_basicTextBox = mn_form.mn_txt_Cell;

                    MN_CreateCells(mn_dictionary);
                }

                public void MN_Clear()
                {
                    // Najpierw musze usunac z globalnego kontenera
                    for (int mn_i = 0; mn_i < mn_myCells.Count; mn_i++)
                    {
                        mn_form.Controls.Remove(mn_myCells[mn_i].Key);
                        mn_form.Controls.Remove(mn_myCells[mn_i].Value);
                    }

                    mn_myCells.Clear();
                }

                public void MN_Update(string[] mn_dictionary)
                {
                    int mn_counter = 0;

                    for (int mn_i = 0; mn_i < mn_maxNumberOfCollumns; mn_i++)
                        for (int mn_j = 0; mn_j < mn_rows; mn_j++)
                        {          
                            // Gdy przelecialem juz przez wszystkie slowa w slowniku
                            if (mn_counter == mn_dictionary.Length)
                            {
                                // Nadmiar komorek musze usunac
                                if (mn_counter < mn_myCells.Count)
                                {
                                    // Usuwam nadmiar komorek
                                    for (; mn_counter < mn_myCells.Count; mn_counter++)
                                    {
                                        mn_form.Controls.Remove(mn_myCells[mn_counter].Key);
                                        mn_form.Controls.Remove(mn_myCells[mn_counter].Value);
                                    }

                                    mn_myCells.RemoveRange(mn_dictionary.Length, mn_counter - mn_dictionary.Length);
                                }

                                mn_i = mn_maxNumberOfCollumns;
                                break;
                            }

                            // Gdy sa jeszcze slowa a ja juz przelecialem przez caly swoj slownik
                            // To musze dorobic komorek
                            if(mn_counter==mn_myCells.Count)
                                MN_CreateCell(mn_counter, mn_i, mn_j, mn_dictionary[mn_counter]);
                            else
                                //Zmieniam aktualne komorki
                                mn_myCells[mn_counter].Value.Text = mn_dictionary[mn_counter];

                            mn_counter++;
                        }
                }

                void MN_CreateCells(string[] mn_dictionary)
                {
                    int mn_counter = 0;

                    for (int mn_i = 0; mn_i < mn_maxNumberOfCollumns; mn_i++)
                        for (int mn_j = 0; mn_j < mn_rows; mn_j++)
                        {
                            // Czyli stworzylem juz komurki dla wszystkich slow w slowniku
                            if (mn_counter == mn_dictionary.Length)
                            {
                                mn_i = mn_maxNumberOfCollumns;
                                break;
                            }

                            MN_CreateCell(mn_counter, mn_i, mn_j, mn_dictionary[mn_counter]);
                            mn_counter++;
                        }
                }

                void MN_CreateCell(int mn_whichCell, int mn_whichCollumn, int mn_whichRow,string mn_word)
                {
                    Point mn_pointOfNumberOfCell;
                    
                    //Bo od zera
                    mn_whichCell++;

                    if (mn_whichCell>9)
                        mn_pointOfNumberOfCell = new Point((mn_basicLabel.Location.X + mn_offset.X * mn_whichCollumn), mn_basicLabel.Location.Y + mn_offset.Y * mn_whichRow);
                    else
                        mn_pointOfNumberOfCell = new Point((mn_basicLabel.Location.X + mn_offset.X * mn_whichCollumn) + 5, mn_basicLabel.Location.Y + mn_offset.Y * mn_whichRow);

                    Label mn_numberOfCell = new Label()
                    {
                        Location = mn_pointOfNumberOfCell,
                        Text = mn_whichCell.ToString(),
                        Font = mn_basicLabel.Font,
                        Size = mn_basicLabel.Size
                    };

                    TextBox mn_cell = new TextBox()
                    {
                        Location = new Point(mn_basicTextBox.Location.X + mn_offset.X * mn_whichCollumn, mn_basicTextBox.Location.Y + mn_offset.Y * mn_whichRow),
                        Text = mn_word,
                        Font = mn_basicTextBox.Font,
                        ReadOnly = true,
                        Size = mn_basicTextBox.Size,
                        BackColor = mn_basicTextBox.BackColor
                    };

                    // Dodaje do globalnego kontenera
                    mn_form.Controls.Add(mn_numberOfCell);
                    mn_form.Controls.Add(mn_cell);
                    
                    // Dodaje do mojej listy
                    mn_myCells.Add(new KeyValuePair<Label, TextBox>(mn_numberOfCell,mn_cell));
                    
                    // By numer nie najezdzal
                    mn_cell.BringToFront();
                }
            
            }
        }
    }
}
