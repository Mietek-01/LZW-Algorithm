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

            // Domyslnie program jest ustawiony na kompresje, wiec bazowy slownik
            // nie musi byc widoczny
            MN_MainManager.MN_ShowBasicDictionary(false);

            // Te kontorlki sluza mi do stworzenia graficznego slownika algorytmu LZW,
            // wiec nie moga byc widoczne
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

            // Pokazuje okno z pytaniem czy zamknac program
            System.Func<bool> mn_CloseWindowQuestion = () =>
            {

                mn_response = MessageBox.Show("Czy zamknąć aplikacje?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question
                , MessageBoxDefaultButton.Button3);

                if (mn_response == DialogResult.No)
                    e.Cancel = true;

                return !e.Cancel;
            };

            // Gdy nie mam zadnych zachowanych kompresji to moge odrazu zapytac czy zamknac
            if (MN_MainManager.MN_NumberOfPreservedCompressions == 0)
            {
                mn_CloseWindowQuestion();
                return;
            }

            mn_response = MessageBox.Show("Czy chcesz zapisać swoje kompresje do pliku tekstowego?", this.Text
                , MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);

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
                        mn_response = MessageBox.Show("Czy chcesz posortować swoje kompresje od najkrótszej do najdłuższej?"
                            , this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);

                        MN_MainManager.MN_SaveCompressionsToFile(mn_response == DialogResult.Yes);

                        if (!mn_CloseWindowQuestion())
                        {
                            MN_MainManager.MN_ClearPreservedCompressions();
                            MN_MainManager.MN_ResetForm(true);
                        }

                        break;
                    }

            }
        }

        private void mn_chb_compress_CheckedChanged(object sender, EventArgs e)
        {
            if (mn_chb_compress.Checked)
            {
                MN_MainManager.MN_ShowBasicDictionary(false);

                MN_MainManager.MN_LZWAlgorithmMode = MN_MainManager.MN_LZWMode.COMPRESSION;

                mn_chb_decompress.Checked = false;

            }
            else
                if (MN_MainManager.MN_LZWAlgorithmMode == MN_MainManager.MN_LZWMode.COMPRESSION)
                mn_chb_compress.Checked = true;
        }

        private void mn_chb_decompress_CheckedChanged(object sender, EventArgs e)
        {
            if (mn_chb_decompress.Checked)
            {
                MN_MainManager.MN_ShowBasicDictionary(true);

                MN_MainManager.MN_LZWAlgorithmMode = MN_MainManager.MN_LZWMode.DECOMPRESSION;

                // Wazne to musi byc po ustawieniu nowego trybu, bo inaczej sie zapetli
                mn_chb_compress.Checked = false;

                // Bo w kompresji bazowego slownika sie nie wypelnia ale w dekompresji juz tak
                mn_txt_BDicitonary.ReadOnly = false;
            }
            else
                if (MN_MainManager.MN_LZWAlgorithmMode == MN_MainManager.MN_LZWMode.DECOMPRESSION)
                mn_chb_decompress.Checked = true;

        }

        private void mn_btn_Run_Click(object sender, EventArgs e)
        {
            MN_MainManager.MN_Run();
        }

        private void mn_btn_Reset_Click(object sender, EventArgs e)
        {
            MN_MainManager.MN_ResetForm(true);
        }

        private void mn_btn_Preserve_Click(object sender, EventArgs e)
        {
            MN_MainManager.MN_PreserveCurrentCompression();
        }

        #endregion
    }
}
