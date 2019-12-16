namespace PatternPass
{
	sealed partial class PatternDisplayForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatternDisplayForm));
			this.drawPanel = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// drawPanel
			// 
			this.drawPanel.Location = new System.Drawing.Point(12, 12);
			this.drawPanel.Name = "drawPanel";
			this.drawPanel.Size = new System.Drawing.Size(700, 700);
			this.drawPanel.TabIndex = 1;
			this.drawPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.OnDrawPanelPaint);
			// 
			// PatternDisplayForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(725, 725);
			this.Controls.Add(this.drawPanel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "PatternDisplayForm";
			this.Text = "PatternDisplayForm";
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel drawPanel;
	}
}