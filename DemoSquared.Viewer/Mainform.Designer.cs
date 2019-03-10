namespace DemoSquared.Viewer
{
  partial class MainForm
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
      this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
      this.pnlLeft = new System.Windows.Forms.Panel();
      this.label2 = new System.Windows.Forms.Label();
      this.lbSpaces = new System.Windows.Forms.ListBox();
      this.label1 = new System.Windows.Forms.Label();
      this.lbFloors = new System.Windows.Forms.ListBox();
      this.btnLoad = new System.Windows.Forms.Button();
      this.pnlImage = new System.Windows.Forms.Panel();
      this.pbMain = new System.Windows.Forms.PictureBox();
      this.pnlLeft.SuspendLayout();
      this.pnlImage.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pbMain)).BeginInit();
      this.SuspendLayout();
      // 
      // pnlLeft
      // 
      this.pnlLeft.Controls.Add(this.label2);
      this.pnlLeft.Controls.Add(this.lbSpaces);
      this.pnlLeft.Controls.Add(this.label1);
      this.pnlLeft.Controls.Add(this.lbFloors);
      this.pnlLeft.Controls.Add(this.btnLoad);
      this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
      this.pnlLeft.Location = new System.Drawing.Point(0, 0);
      this.pnlLeft.Name = "pnlLeft";
      this.pnlLeft.Size = new System.Drawing.Size(218, 366);
      this.pnlLeft.TabIndex = 3;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(13, 82);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(43, 13);
      this.label2.TabIndex = 10;
      this.label2.Text = "Spaces";
      // 
      // lbSpaces
      // 
      this.lbSpaces.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lbSpaces.FormattingEnabled = true;
      this.lbSpaces.Location = new System.Drawing.Point(12, 101);
      this.lbSpaces.Name = "lbSpaces";
      this.lbSpaces.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
      this.lbSpaces.Size = new System.Drawing.Size(200, 212);
      this.lbSpaces.TabIndex = 9;
      this.lbSpaces.SelectedIndexChanged += new System.EventHandler(this.lbSpaces_SelectedIndexChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(13, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(35, 13);
      this.label1.TabIndex = 8;
      this.label1.Text = "Floors";
      // 
      // lbFloors
      // 
      this.lbFloors.FormattingEnabled = true;
      this.lbFloors.Location = new System.Drawing.Point(12, 25);
      this.lbFloors.Name = "lbFloors";
      this.lbFloors.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
      this.lbFloors.Size = new System.Drawing.Size(200, 43);
      this.lbFloors.TabIndex = 7;
      this.lbFloors.SelectedIndexChanged += new System.EventHandler(this.lbFloors_SelectedIndexChanged);
      // 
      // btnLoad
      // 
      this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnLoad.Location = new System.Drawing.Point(16, 329);
      this.btnLoad.Name = "btnLoad";
      this.btnLoad.Size = new System.Drawing.Size(75, 23);
      this.btnLoad.TabIndex = 6;
      this.btnLoad.Text = "Load";
      this.btnLoad.UseVisualStyleBackColor = true;
      // 
      // pnlImage
      // 
      this.pnlImage.Controls.Add(this.pbMain);
      this.pnlImage.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlImage.Location = new System.Drawing.Point(218, 0);
      this.pnlImage.Name = "pnlImage";
      this.pnlImage.Size = new System.Drawing.Size(382, 366);
      this.pnlImage.TabIndex = 4;
      // 
      // pbMain
      // 
      this.pbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.pbMain.Location = new System.Drawing.Point(17, 15);
      this.pbMain.Name = "pbMain";
      this.pbMain.Size = new System.Drawing.Size(353, 304);
      this.pbMain.TabIndex = 3;
      this.pbMain.TabStop = false;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(600, 366);
      this.Controls.Add(this.pnlImage);
      this.Controls.Add(this.pnlLeft);
      this.Margin = new System.Windows.Forms.Padding(2);
      this.Name = "MainForm";
      this.Text = "DemoViewer";
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.Resize += new System.EventHandler(this.MainForm_Resize);
      this.pnlLeft.ResumeLayout(false);
      this.pnlLeft.PerformLayout();
      this.pnlImage.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pbMain)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.ComponentModel.BackgroundWorker backgroundWorker1;
    private System.Windows.Forms.Panel pnlLeft;
    private System.Windows.Forms.Button btnLoad;
    private System.Windows.Forms.Panel pnlImage;
    private System.Windows.Forms.PictureBox pbMain;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ListBox lbFloors;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ListBox lbSpaces;
  }
}

