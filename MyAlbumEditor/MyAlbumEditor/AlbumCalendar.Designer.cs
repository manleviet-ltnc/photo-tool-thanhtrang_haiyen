namespace MyAlbumEditor
{
    partial class AlbumCalendar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.callDates = new System.Windows.Forms.MonthCalendar();
            this.SuspendLayout();
            // 
            // callDates
            // 
            this.callDates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.callDates.Location = new System.Drawing.Point(0, 0);
            this.callDates.MaxSelectionCount = 1;
            this.callDates.Name = "callDates";
            this.callDates.ShowToday = false;
            this.callDates.TabIndex = 0;
            this.callDates.MouseDown += new System.Windows.Forms.MouseEventHandler(this.callDates_MouseDown);
            // 
            // AlbumCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.callDates);
            this.Name = "AlbumCalendar";
            this.Size = new System.Drawing.Size(376, 186);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar callDates;
    }
}
