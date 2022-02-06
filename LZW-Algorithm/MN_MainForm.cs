using System;
using System.Windows.Forms;

namespace MichałNiedek_LZW_Algorithm
{
    public partial class MN_MainForm : Form
    {
        public MN_MainForm()
        {
            InitializeComponent();
            
            MN_MainManager.MN_RegisterForm(this);

            // Bo domyslnie program jest ustawiony na kompresje a bazowy slownik
            // Jest widoczny i zdatny do modyfikacji tylko w okreslonych sytuacjach
            MN_MainManager.MN_ShowBasicDictionaryInput(false);
          
            // Te kontorlki sluza mi do kopiowania, nie maja byc widoczne
            mn_lbl_NumberOfCell.Visible = false;
            mn_txt_Cell.Visible = false;

            mn_ToolTip.SetToolTip(mn_btn_Preserve, " Zachowaj swój skompresowany kod razem z jego bazowym słownikiem.\n "
                + "Przy zamknięciu aplikacji pojawi sie okno z pytaniem,\n " +
                "czy chcesz zapisać zachowane kompresje do pliku tekstowego.");

        }

        #region Events

        private void MN_LZW_FormClosing(object sender, FormClosingEventArgs e)
        {
            // W momencie proby zamknieciea okna wyswietle kilka okien z informacjami

            DialogResult mn_response;

            // Pokazuje okno z pytaniem czy zamknac okno i zwraca true jesli tak
            System.Func<bool> mn_CloseWindowQuestion = () => {
                
                mn_response = MessageBox.Show("Czy zamknąć aplikacje?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question
                , MessageBoxDefaultButton.Button3);

                if (mn_response == DialogResult.No)
                    e.Cancel = true;

                return !e.Cancel;
            };

            // Gdy nie mam zadnych zachowanych kompresji to nie mam co zapisywac i zamykam aplikacje
            if (MN_MainManager.MN_NumberOfPreservedCompressions == 0)
            {
                mn_CloseWindowQuestion();
                return;
            }

            mn_response = MessageBox.Show("Czy chcesz zapisać swoje kompresje do pliku tekstowego?", this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question
                            , MessageBoxDefaultButton.Button3);

            switch (mn_response)
            {
                case DialogResult.No:
                    {
                        mn_CloseWindowQuestion();
                        break;
                    }


                case DialogResult.Cancel:
                    {
                        e.Cancel = true;
                        break;
                    }

                case DialogResult.Yes:
                    {
                        mn_response = MessageBox.Show("Czy chcesz posortować swoje kompresje od najkrótszej do najdłuższej?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question
                                                        , MessageBoxDefaultButton.Button3);

                        MN_MainManager.MN_SaveCompressionsToFile(mn_response == DialogResult.Yes);

                        if (!mn_CloseWindowQuestion())
                        {
                            MN_MainManager.MN_ClearPreservedCompressions();
                            MN_MainManager.MN_ResetResource(true);
                        }

                        break;
                    }

            }
        }

        private void mn_btn_Run_Click(object sender, EventArgs e)
        {
            MN_MainManager.MN_Run();
        }

        private void mn_btn_Reset_Click(object sender, EventArgs e)
        {
            MN_MainManager.MN_ResetResource(true);
        }

        private void mn_btn_Preserve_Click(object sender, EventArgs e)
        {
            MN_MainManager.MN_PreserveCurrentCompression();
        }

        private void mn_chb_compress_CheckedChanged(object sender, EventArgs e)
        {
            if (mn_chb_compress.Checked)
            {
                // Gdy klikam gdy ta jest nie zaznaczona
                MN_MainManager.MN_ShowBasicDictionaryInput(false);

                MN_MainManager.MN_LZWAlgorithmMode = MN_MainManager.MN_LZWMode.COMPRESS;
                mn_chb_decompress.Checked = false;
            
            }else
            // Gdy klikam gdy ta jest juz zaznaczona
                if (MN_MainManager.MN_LZWAlgorithmMode == MN_MainManager.MN_LZWMode.COMPRESS)
                    mn_chb_compress.Checked = true;
        }

        private void mn_chb_decompress_CheckedChanged(object sender, EventArgs e)
        {
            if (mn_chb_decompress.Checked)
            {
                // Gdy klikam gdy ta jest nie zaznaczona

                MN_MainManager.MN_ShowBasicDictionaryInput(true);
                
                // Bo w kompresji bazowego slownika sie nie wypelnia ale w dekompresji juz tak
                mn_txt_BDicitonary.ReadOnly = false;

                MN_MainManager.MN_LZWAlgorithmMode = MN_MainManager.MN_LZWMode.DECOMPRESS;
                mn_chb_compress.Checked = false;
            }
            else
            // Gdy klikam gdy ta jest juz zaznaczona
                if (MN_MainManager.MN_LZWAlgorithmMode == MN_MainManager.MN_LZWMode.DECOMPRESS)
                    mn_chb_decompress.Checked = true;
               
        }

        #endregion
    }
}
