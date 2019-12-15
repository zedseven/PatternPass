namespace PatternPass
{
	partial class PatternSetupForm
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
			this.savePatternButton = new System.Windows.Forms.Button();
			this.loadPatternButton = new System.Windows.Forms.Button();
			this.newPatternButton = new System.Windows.Forms.Button();
			this.patternNodeContainer = new System.Windows.Forms.FlowLayoutPanel();
			this.newPatternBox = new System.Windows.Forms.GroupBox();
			this.columnsInputLabel = new System.Windows.Forms.Label();
			this.columnsInput = new System.Windows.Forms.NumericUpDown();
			this.rowsInputLabel = new System.Windows.Forms.Label();
			this.rowsInput = new System.Windows.Forms.NumericUpDown();
			this.loadSaveBox = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.newPatternBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.columnsInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.rowsInput)).BeginInit();
			this.loadSaveBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// savePatternButton
			// 
			this.savePatternButton.Location = new System.Drawing.Point(229, 34);
			this.savePatternButton.Name = "savePatternButton";
			this.savePatternButton.Size = new System.Drawing.Size(191, 51);
			this.savePatternButton.TabIndex = 0;
			this.savePatternButton.Text = "Save Pattern";
			this.savePatternButton.UseVisualStyleBackColor = true;
			this.savePatternButton.Click += new System.EventHandler(this.SavePattern);
			// 
			// loadPatternButton
			// 
			this.loadPatternButton.Location = new System.Drawing.Point(17, 34);
			this.loadPatternButton.Name = "loadPatternButton";
			this.loadPatternButton.Size = new System.Drawing.Size(191, 51);
			this.loadPatternButton.TabIndex = 1;
			this.loadPatternButton.Text = "Load Pattern";
			this.loadPatternButton.UseVisualStyleBackColor = true;
			this.loadPatternButton.Click += new System.EventHandler(this.LoadPattern);
			// 
			// newPatternButton
			// 
			this.newPatternButton.Location = new System.Drawing.Point(17, 34);
			this.newPatternButton.Name = "newPatternButton";
			this.newPatternButton.Size = new System.Drawing.Size(191, 51);
			this.newPatternButton.TabIndex = 3;
			this.newPatternButton.Text = "New Pattern";
			this.newPatternButton.UseVisualStyleBackColor = true;
			this.newPatternButton.Click += new System.EventHandler(this.NewPattern);
			// 
			// patternNodeContainer
			// 
			this.patternNodeContainer.Location = new System.Drawing.Point(29, 329);
			this.patternNodeContainer.Name = "patternNodeContainer";
			this.patternNodeContainer.Size = new System.Drawing.Size(841, 626);
			this.patternNodeContainer.TabIndex = 4;
			// 
			// newPatternBox
			// 
			this.newPatternBox.Controls.Add(this.columnsInputLabel);
			this.newPatternBox.Controls.Add(this.columnsInput);
			this.newPatternBox.Controls.Add(this.rowsInputLabel);
			this.newPatternBox.Controls.Add(this.rowsInput);
			this.newPatternBox.Controls.Add(this.newPatternButton);
			this.newPatternBox.Location = new System.Drawing.Point(29, 36);
			this.newPatternBox.Name = "newPatternBox";
			this.newPatternBox.Size = new System.Drawing.Size(841, 100);
			this.newPatternBox.TabIndex = 5;
			this.newPatternBox.TabStop = false;
			this.newPatternBox.Text = "New Pattern";
			// 
			// columnsInputLabel
			// 
			this.columnsInputLabel.AutoSize = true;
			this.columnsInputLabel.Location = new System.Drawing.Point(456, 45);
			this.columnsInputLabel.Name = "columnsInputLabel";
			this.columnsInputLabel.Size = new System.Drawing.Size(120, 29);
			this.columnsInputLabel.TabIndex = 7;
			this.columnsInputLabel.Text = "Columns: ";
			// 
			// columnsInput
			// 
			this.columnsInput.Location = new System.Drawing.Point(582, 43);
			this.columnsInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.columnsInput.Name = "columnsInput";
			this.columnsInput.Size = new System.Drawing.Size(120, 35);
			this.columnsInput.TabIndex = 6;
			this.columnsInput.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
			// 
			// rowsInputLabel
			// 
			this.rowsInputLabel.AutoSize = true;
			this.rowsInputLabel.Location = new System.Drawing.Point(224, 45);
			this.rowsInputLabel.Name = "rowsInputLabel";
			this.rowsInputLabel.Size = new System.Drawing.Size(86, 29);
			this.rowsInputLabel.TabIndex = 5;
			this.rowsInputLabel.Text = "Rows: ";
			// 
			// rowsInput
			// 
			this.rowsInput.Location = new System.Drawing.Point(316, 43);
			this.rowsInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.rowsInput.Name = "rowsInput";
			this.rowsInput.Size = new System.Drawing.Size(120, 35);
			this.rowsInput.TabIndex = 4;
			this.rowsInput.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
			// 
			// loadSaveBox
			// 
			this.loadSaveBox.Controls.Add(this.button1);
			this.loadSaveBox.Controls.Add(this.loadPatternButton);
			this.loadSaveBox.Controls.Add(this.savePatternButton);
			this.loadSaveBox.Location = new System.Drawing.Point(29, 159);
			this.loadSaveBox.Name = "loadSaveBox";
			this.loadSaveBox.Size = new System.Drawing.Size(841, 100);
			this.loadSaveBox.TabIndex = 6;
			this.loadSaveBox.TabStop = false;
			this.loadSaveBox.Text = "Load / Save";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(443, 34);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(217, 51);
			this.button1.TabIndex = 2;
			this.button1.Text = "Remove Pattern";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.RemovePattern);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
			this.label1.Location = new System.Drawing.Point(29, 277);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(362, 29);
			this.label1.TabIndex = 7;
			this.label1.Text = "Use \'-1\' to denote an empty node";
			// 
			// PatternSetupForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(900, 986);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.loadSaveBox);
			this.Controls.Add(this.newPatternBox);
			this.Controls.Add(this.patternNodeContainer);
			this.Name = "PatternSetupForm";
			this.Text = "PatternSetupForm";
			this.newPatternBox.ResumeLayout(false);
			this.newPatternBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.columnsInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.rowsInput)).EndInit();
			this.loadSaveBox.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button savePatternButton;
		private System.Windows.Forms.Button loadPatternButton;
		private System.Windows.Forms.Button newPatternButton;
		private System.Windows.Forms.FlowLayoutPanel patternNodeContainer;
		private System.Windows.Forms.GroupBox newPatternBox;
		private System.Windows.Forms.Label columnsInputLabel;
		private System.Windows.Forms.NumericUpDown columnsInput;
		private System.Windows.Forms.Label rowsInputLabel;
		private System.Windows.Forms.NumericUpDown rowsInput;
		private System.Windows.Forms.GroupBox loadSaveBox;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
	}
}