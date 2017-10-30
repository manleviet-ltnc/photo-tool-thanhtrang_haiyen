namespace Manning.MyPhotoControls
{
    partial class PhotoEditDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tblPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPhotoFile = new System.Windows.Forms.TextBox();
            this.txtCaption = new System.Windows.Forms.TextBox();
            this.mskDateTaken = new System.Windows.Forms.MaskedTextBox();
            this.cmbPhotographer = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.tblPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tblPanel);
            // 
            // tblPanel
            // 
            this.tblPanel.ColumnCount = 2;
            this.tblPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tblPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tblPanel.Controls.Add(this.label1, 0, 0);
            this.tblPanel.Controls.Add(this.label2, 0, 1);
            this.tblPanel.Controls.Add(this.label3, 0, 2);
            this.tblPanel.Controls.Add(this.label4, 0, 3);
            this.tblPanel.Controls.Add(this.txtPhotoFile, 1, 0);
            this.tblPanel.Controls.Add(this.txtCaption, 1, 1);
            this.tblPanel.Controls.Add(this.mskDateTaken, 1, 2);
            this.tblPanel.Controls.Add(this.cmbPhotographer, 1, 3);
            this.tblPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblPanel.Location = new System.Drawing.Point(0, 0);
            this.tblPanel.Name = "tblPanel";
            this.tblPanel.RowCount = 4;
            this.tblPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblPanel.Size = new System.Drawing.Size(258, 110);
            this.tblPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Photo &File:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cap&tion:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 27);
            this.label3.TabIndex = 4;
            this.label3.Text = "&Date Taken:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 29);
            this.label4.TabIndex = 6;
            this.label4.Text = "&Photographer:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPhotoFile
            // 
            this.txtPhotoFile.Location = new System.Drawing.Point(93, 3);
            this.txtPhotoFile.Name = "txtPhotoFile";
            this.txtPhotoFile.ReadOnly = true;
            this.txtPhotoFile.Size = new System.Drawing.Size(162, 20);
            this.txtPhotoFile.TabIndex = 1;
            // 
            // txtCaption
            // 
            this.txtCaption.Location = new System.Drawing.Point(93, 30);
            this.txtCaption.Name = "txtCaption";
            this.txtCaption.Size = new System.Drawing.Size(162, 20);
            this.txtCaption.TabIndex = 3;
            this.txtCaption.TextChanged += new System.EventHandler(this.txtCaption_TextChanged);
            // 
            // mskDateTaken
            // 
            this.mskDateTaken.Location = new System.Drawing.Point(93, 57);
            this.mskDateTaken.Mask = "00/00/0000";
            this.mskDateTaken.Name = "mskDateTaken";
            this.mskDateTaken.Size = new System.Drawing.Size(162, 20);
            this.mskDateTaken.TabIndex = 0;
            this.mskDateTaken.ValidatingType = typeof(System.DateTime);
            this.mskDateTaken.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(this.mskDateTaken_TypeValidationCompleted);
            // 
            // cmbPhotographer
            // 
            this.cmbPhotographer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPhotographer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPhotographer.FormattingEnabled = true;
            this.cmbPhotographer.Location = new System.Drawing.Point(93, 84);
            this.cmbPhotographer.MaxDropDownItems = 4;
            this.cmbPhotographer.Name = "cmbPhotographer";
            this.cmbPhotographer.Size = new System.Drawing.Size(162, 21);
            this.cmbPhotographer.Sorted = true;
            this.cmbPhotographer.TabIndex = 7;
            this.cmbPhotographer.Leave += new System.EventHandler(this.cmbPhotographer_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "&Notes:";
            // 
            // txtNotes
            // 
            this.txtNotes.AcceptsReturn = true;
            this.txtNotes.Location = new System.Drawing.Point(13, 143);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(255, 78);
            this.txtNotes.TabIndex = 4;
            // 
            // PhotoEditDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.label5);
            this.Name = "PhotoEditDialog";
            this.Text = "Photo Properties";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtNotes, 0);
            this.panel1.ResumeLayout(false);
            this.tblPanel.ResumeLayout(false);
            this.tblPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPhotoFile;
        private System.Windows.Forms.TextBox txtCaption;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.MaskedTextBox mskDateTaken;
        private System.Windows.Forms.ComboBox cmbPhotographer;
    }
}
