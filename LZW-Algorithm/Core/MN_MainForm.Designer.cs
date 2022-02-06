namespace MichałNiedek_LZW_Algorithm
{
    partial class MN_MainForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mn_lbl_GeneratedDictionary = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mn_lbl_Result = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mn_lbl_SourceData = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.mn_btn_Run = new System.Windows.Forms.Button();
            this.mn_txt_Source = new System.Windows.Forms.TextBox();
            this.mn_txt_Result = new System.Windows.Forms.TextBox();
            this.mn_chb_compress = new System.Windows.Forms.CheckBox();
            this.mn_chb_decompress = new System.Windows.Forms.CheckBox();
            this.mn_ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.mn_lbl_BDictionary = new System.Windows.Forms.Label();
            this.mn_txt_BDicitonary = new System.Windows.Forms.TextBox();
            this.mn_txt_Cell = new System.Windows.Forms.TextBox();
            this.mn_lbl_NumberOfCell = new System.Windows.Forms.Label();
            this.mn_btn_Reset = new System.Windows.Forms.Button();
            this.mn_btn_Preserve = new System.Windows.Forms.Button();
            this.mn_lbl_PreservedCompressions = new System.Windows.Forms.Label();
            this.mn_lbl_NumberOfPreservedCompressions = new System.Windows.Forms.Label();
            this.mn_ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.mn_SavedFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.mn_ErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // mn_lbl_GeneratedDictionary
            // 
            this.mn_lbl_GeneratedDictionary.AutoSize = true;
            this.mn_lbl_GeneratedDictionary.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mn_lbl_GeneratedDictionary.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mn_lbl_GeneratedDictionary.Location = new System.Drawing.Point(32, 116);
            this.mn_lbl_GeneratedDictionary.Name = "mn_lbl_GeneratedDictionary";
            this.mn_lbl_GeneratedDictionary.Size = new System.Drawing.Size(197, 27);
            this.mn_lbl_GeneratedDictionary.TabIndex = 0;
            this.mn_lbl_GeneratedDictionary.Text = "Generated Dictionary";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(32, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "Description";
            // 
            // mn_lbl_Result
            // 
            this.mn_lbl_Result.AutoSize = true;
            this.mn_lbl_Result.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mn_lbl_Result.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mn_lbl_Result.Location = new System.Drawing.Point(200, 520);
            this.mn_lbl_Result.Name = "mn_lbl_Result";
            this.mn_lbl_Result.Size = new System.Drawing.Size(68, 27);
            this.mn_lbl_Result.TabIndex = 2;
            this.mn_lbl_Result.Text = "Result";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(32, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(557, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "LZW - metoda strumieniowej bezstratnej kompresji słownikowej";
            // 
            // mn_lbl_SourceData
            // 
            this.mn_lbl_SourceData.AutoSize = true;
            this.mn_lbl_SourceData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mn_lbl_SourceData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mn_lbl_SourceData.Location = new System.Drawing.Point(968, 30);
            this.mn_lbl_SourceData.Name = "mn_lbl_SourceData";
            this.mn_lbl_SourceData.Size = new System.Drawing.Size(123, 27);
            this.mn_lbl_SourceData.TabIndex = 4;
            this.mn_lbl_SourceData.Text = "Source Data";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(32, 520);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 27);
            this.label7.TabIndex = 6;
            this.label7.Text = "Algorithm mode";
            // 
            // mn_btn_Run
            // 
            this.mn_btn_Run.BackColor = System.Drawing.Color.Red;
            this.mn_btn_Run.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mn_btn_Run.Location = new System.Drawing.Point(844, 561);
            this.mn_btn_Run.Name = "mn_btn_Run";
            this.mn_btn_Run.Size = new System.Drawing.Size(79, 77);
            this.mn_btn_Run.TabIndex = 7;
            this.mn_btn_Run.Text = "Run";
            this.mn_btn_Run.UseVisualStyleBackColor = false;
            this.mn_btn_Run.Click += new System.EventHandler(this.mn_btn_Run_Click);
            // 
            // mn_txt_Source
            // 
            this.mn_txt_Source.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mn_txt_Source.Location = new System.Drawing.Point(880, 69);
            this.mn_txt_Source.Multiline = true;
            this.mn_txt_Source.Name = "mn_txt_Source";
            this.mn_txt_Source.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mn_txt_Source.Size = new System.Drawing.Size(281, 468);
            this.mn_txt_Source.TabIndex = 8;
            // 
            // mn_txt_Result
            // 
            this.mn_txt_Result.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mn_txt_Result.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mn_txt_Result.Location = new System.Drawing.Point(200, 561);
            this.mn_txt_Result.Multiline = true;
            this.mn_txt_Result.Name = "mn_txt_Result";
            this.mn_txt_Result.ReadOnly = true;
            this.mn_txt_Result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mn_txt_Result.Size = new System.Drawing.Size(609, 155);
            this.mn_txt_Result.TabIndex = 9;
            // 
            // mn_chb_compress
            // 
            this.mn_chb_compress.AutoSize = true;
            this.mn_chb_compress.Checked = true;
            this.mn_chb_compress.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mn_chb_compress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mn_chb_compress.Location = new System.Drawing.Point(32, 561);
            this.mn_chb_compress.Name = "mn_chb_compress";
            this.mn_chb_compress.Size = new System.Drawing.Size(118, 28);
            this.mn_chb_compress.TabIndex = 10;
            this.mn_chb_compress.Text = "Compress";
            this.mn_chb_compress.UseVisualStyleBackColor = true;
            this.mn_chb_compress.CheckedChanged += new System.EventHandler(this.mn_chb_compress_CheckedChanged);
            // 
            // mn_chb_decompress
            // 
            this.mn_chb_decompress.AutoSize = true;
            this.mn_chb_decompress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mn_chb_decompress.Location = new System.Drawing.Point(32, 602);
            this.mn_chb_decompress.Name = "mn_chb_decompress";
            this.mn_chb_decompress.Size = new System.Drawing.Size(139, 28);
            this.mn_chb_decompress.TabIndex = 11;
            this.mn_chb_decompress.Text = "Decompress";
            this.mn_chb_decompress.UseVisualStyleBackColor = true;
            this.mn_chb_decompress.CheckedChanged += new System.EventHandler(this.mn_chb_decompress_CheckedChanged);
            // 
            // mn_ErrorProvider
            // 
            this.mn_ErrorProvider.ContainerControl = this;
            // 
            // mn_lbl_BDictionary
            // 
            this.mn_lbl_BDictionary.AutoSize = true;
            this.mn_lbl_BDictionary.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mn_lbl_BDictionary.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mn_lbl_BDictionary.Location = new System.Drawing.Point(687, 33);
            this.mn_lbl_BDictionary.Name = "mn_lbl_BDictionary";
            this.mn_lbl_BDictionary.Size = new System.Drawing.Size(153, 27);
            this.mn_lbl_BDictionary.TabIndex = 13;
            this.mn_lbl_BDictionary.Text = "Basic Dictionary";
            // 
            // mn_txt_BDicitonary
            // 
            this.mn_txt_BDicitonary.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mn_txt_BDicitonary.Location = new System.Drawing.Point(674, 72);
            this.mn_txt_BDicitonary.Multiline = true;
            this.mn_txt_BDicitonary.Name = "mn_txt_BDicitonary";
            this.mn_txt_BDicitonary.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mn_txt_BDicitonary.Size = new System.Drawing.Size(177, 71);
            this.mn_txt_BDicitonary.TabIndex = 14;
            // 
            // mn_txt_Cell
            // 
            this.mn_txt_Cell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.mn_txt_Cell.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mn_txt_Cell.Location = new System.Drawing.Point(61, 162);
            this.mn_txt_Cell.Multiline = true;
            this.mn_txt_Cell.Name = "mn_txt_Cell";
            this.mn_txt_Cell.ReadOnly = true;
            this.mn_txt_Cell.Size = new System.Drawing.Size(50, 27);
            this.mn_txt_Cell.TabIndex = 15;
            // 
            // mn_lbl_NumberOfCell
            // 
            this.mn_lbl_NumberOfCell.AutoSize = true;
            this.mn_lbl_NumberOfCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mn_lbl_NumberOfCell.Location = new System.Drawing.Point(27, 162);
            this.mn_lbl_NumberOfCell.Name = "mn_lbl_NumberOfCell";
            this.mn_lbl_NumberOfCell.Size = new System.Drawing.Size(34, 25);
            this.mn_lbl_NumberOfCell.TabIndex = 16;
            this.mn_lbl_NumberOfCell.Text = "10";
            // 
            // mn_btn_Reset
            // 
            this.mn_btn_Reset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.mn_btn_Reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mn_btn_Reset.Location = new System.Drawing.Point(841, 654);
            this.mn_btn_Reset.Name = "mn_btn_Reset";
            this.mn_btn_Reset.Size = new System.Drawing.Size(93, 62);
            this.mn_btn_Reset.TabIndex = 17;
            this.mn_btn_Reset.Text = "Reset";
            this.mn_btn_Reset.UseVisualStyleBackColor = false;
            this.mn_btn_Reset.Click += new System.EventHandler(this.mn_btn_Reset_Click);
            // 
            // mn_btn_Preserve
            // 
            this.mn_btn_Preserve.BackColor = System.Drawing.Color.Lime;
            this.mn_btn_Preserve.Enabled = false;
            this.mn_btn_Preserve.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mn_btn_Preserve.Location = new System.Drawing.Point(986, 639);
            this.mn_btn_Preserve.Name = "mn_btn_Preserve";
            this.mn_btn_Preserve.Size = new System.Drawing.Size(131, 77);
            this.mn_btn_Preserve.TabIndex = 18;
            this.mn_btn_Preserve.Text = "Preserve";
            this.mn_btn_Preserve.UseVisualStyleBackColor = false;
            this.mn_btn_Preserve.Click += new System.EventHandler(this.mn_btn_Preserve_Click);
            // 
            // mn_lbl_PreservedCompressions
            // 
            this.mn_lbl_PreservedCompressions.AutoSize = true;
            this.mn_lbl_PreservedCompressions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mn_lbl_PreservedCompressions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mn_lbl_PreservedCompressions.Location = new System.Drawing.Point(951, 563);
            this.mn_lbl_PreservedCompressions.Name = "mn_lbl_PreservedCompressions";
            this.mn_lbl_PreservedCompressions.Size = new System.Drawing.Size(208, 52);
            this.mn_lbl_PreservedCompressions.TabIndex = 19;
            this.mn_lbl_PreservedCompressions.Text = "Number Of Preserved \r\n      Compressions:";
            // 
            // mn_lbl_NumberOfPreservedCompressions
            // 
            this.mn_lbl_NumberOfPreservedCompressions.AutoSize = true;
            this.mn_lbl_NumberOfPreservedCompressions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mn_lbl_NumberOfPreservedCompressions.Location = new System.Drawing.Point(1136, 590);
            this.mn_lbl_NumberOfPreservedCompressions.Name = "mn_lbl_NumberOfPreservedCompressions";
            this.mn_lbl_NumberOfPreservedCompressions.Size = new System.Drawing.Size(23, 25);
            this.mn_lbl_NumberOfPreservedCompressions.TabIndex = 18;
            this.mn_lbl_NumberOfPreservedCompressions.Text = "0";
            // 
            // mn_ToolTip
            // 
            this.mn_ToolTip.AutomaticDelay = 300;
            this.mn_ToolTip.AutoPopDelay = 8000;
            this.mn_ToolTip.InitialDelay = 300;
            this.mn_ToolTip.ReshowDelay = 60;
            this.mn_ToolTip.ShowAlways = true;
            // 
            // MN_MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 732);
            this.Controls.Add(this.mn_lbl_NumberOfPreservedCompressions);
            this.Controls.Add(this.mn_lbl_PreservedCompressions);
            this.Controls.Add(this.mn_btn_Preserve);
            this.Controls.Add(this.mn_btn_Reset);
            this.Controls.Add(this.mn_lbl_NumberOfCell);
            this.Controls.Add(this.mn_txt_Cell);
            this.Controls.Add(this.mn_txt_BDicitonary);
            this.Controls.Add(this.mn_lbl_BDictionary);
            this.Controls.Add(this.mn_chb_decompress);
            this.Controls.Add(this.mn_chb_compress);
            this.Controls.Add(this.mn_txt_Result);
            this.Controls.Add(this.mn_txt_Source);
            this.Controls.Add(this.mn_btn_Run);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.mn_lbl_SourceData);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mn_lbl_Result);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mn_lbl_GeneratedDictionary);
            this.Name = "MN_MainForm";
            this.Text = "LZW";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MN_LZW_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.mn_ErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mn_lbl_GeneratedDictionary;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label mn_lbl_Result;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label mn_lbl_SourceData;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button mn_btn_Run;
        private System.Windows.Forms.TextBox mn_txt_Source;
        private System.Windows.Forms.TextBox mn_txt_Result;
        private System.Windows.Forms.CheckBox mn_chb_compress;
        private System.Windows.Forms.CheckBox mn_chb_decompress;
        private System.Windows.Forms.ErrorProvider mn_ErrorProvider;
        private System.Windows.Forms.TextBox mn_txt_BDicitonary;
        private System.Windows.Forms.Label mn_lbl_BDictionary;
        private System.Windows.Forms.Label mn_lbl_NumberOfCell;
        private System.Windows.Forms.TextBox mn_txt_Cell;
        private System.Windows.Forms.Button mn_btn_Reset;
        private System.Windows.Forms.Label mn_lbl_NumberOfPreservedCompressions;
        private System.Windows.Forms.Label mn_lbl_PreservedCompressions;
        private System.Windows.Forms.Button mn_btn_Preserve;
        private System.Windows.Forms.ToolTip mn_ToolTip;
        private System.Windows.Forms.SaveFileDialog mn_SavedFileDialog;
    }
}

