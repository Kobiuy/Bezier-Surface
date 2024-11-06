namespace Bezier_Surface
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			Canvas = new PictureBox();
			splitContainer1 = new SplitContainer();
			flowLayoutPanel1 = new FlowLayoutPanel();
			checkBox1 = new CheckBox();
			label3 = new Label();
			alfaSlider = new TrackBar();
			alfaLabel = new Label();
			label2 = new Label();
			betaSlider = new TrackBar();
			betaLabel = new Label();
			label1 = new Label();
			precisionTrackBar = new TrackBar();
			precisionLabel = new Label();
			((System.ComponentModel.ISupportInitialize)Canvas).BeginInit();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			flowLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)alfaSlider).BeginInit();
			((System.ComponentModel.ISupportInitialize)betaSlider).BeginInit();
			((System.ComponentModel.ISupportInitialize)precisionTrackBar).BeginInit();
			SuspendLayout();
			// 
			// Canvas
			// 
			Canvas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			Canvas.Location = new Point(0, 0);
			Canvas.Name = "Canvas";
			Canvas.Size = new Size(1047, 753);
			Canvas.TabIndex = 0;
			Canvas.TabStop = false;
			// 
			// splitContainer1
			// 
			splitContainer1.Dock = DockStyle.Fill;
			splitContainer1.Location = new Point(0, 0);
			splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.Controls.Add(flowLayoutPanel1);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(Canvas);
			splitContainer1.Size = new Size(1182, 753);
			splitContainer1.SplitterDistance = 131;
			splitContainer1.TabIndex = 1;
			// 
			// flowLayoutPanel1
			// 
			flowLayoutPanel1.Controls.Add(checkBox1);
			flowLayoutPanel1.Controls.Add(label3);
			flowLayoutPanel1.Controls.Add(alfaSlider);
			flowLayoutPanel1.Controls.Add(alfaLabel);
			flowLayoutPanel1.Controls.Add(label2);
			flowLayoutPanel1.Controls.Add(betaSlider);
			flowLayoutPanel1.Controls.Add(betaLabel);
			flowLayoutPanel1.Controls.Add(label1);
			flowLayoutPanel1.Controls.Add(precisionTrackBar);
			flowLayoutPanel1.Controls.Add(precisionLabel);
			flowLayoutPanel1.Dock = DockStyle.Fill;
			flowLayoutPanel1.Location = new Point(0, 0);
			flowLayoutPanel1.Name = "flowLayoutPanel1";
			flowLayoutPanel1.Size = new Size(131, 753);
			flowLayoutPanel1.TabIndex = 0;
			// 
			// checkBox1
			// 
			checkBox1.AutoSize = true;
			checkBox1.Location = new Point(3, 3);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new Size(89, 24);
			checkBox1.TabIndex = 1;
			checkBox1.Text = "GridOnly";
			checkBox1.UseVisualStyleBackColor = true;
			checkBox1.CheckedChanged += checkBox1_CheckedChanged;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(3, 30);
			label3.Name = "label3";
			label3.Size = new Size(39, 20);
			label3.TabIndex = 8;
			label3.Text = "Alfa:";
			// 
			// alfaSlider
			// 
			alfaSlider.Location = new Point(3, 53);
			alfaSlider.Maximum = 45;
			alfaSlider.Minimum = -45;
			alfaSlider.Name = "alfaSlider";
			alfaSlider.Size = new Size(130, 56);
			alfaSlider.TabIndex = 3;
			alfaSlider.Scroll += alfaSlider_Scroll;
			// 
			// alfaLabel
			// 
			alfaLabel.AutoSize = true;
			alfaLabel.Location = new Point(3, 112);
			alfaLabel.Name = "alfaLabel";
			alfaLabel.Size = new Size(92, 20);
			alfaLabel.TabIndex = 9;
			alfaLabel.Text = "Value: 0        ";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(3, 132);
			label2.Name = "label2";
			label2.Size = new Size(42, 20);
			label2.TabIndex = 7;
			label2.Text = "Beta:";
			// 
			// betaSlider
			// 
			betaSlider.Location = new Point(3, 155);
			betaSlider.Maximum = 90;
			betaSlider.Name = "betaSlider";
			betaSlider.Size = new Size(130, 56);
			betaSlider.TabIndex = 2;
			betaSlider.Scroll += betaSlider_Scroll;
			// 
			// betaLabel
			// 
			betaLabel.AutoSize = true;
			betaLabel.Location = new Point(3, 214);
			betaLabel.Name = "betaLabel";
			betaLabel.Size = new Size(60, 20);
			betaLabel.TabIndex = 10;
			betaLabel.Text = "Value: 0";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(3, 234);
			label1.Name = "label1";
			label1.Size = new Size(71, 20);
			label1.TabIndex = 6;
			label1.Text = "Precision:";
			// 
			// precisionTrackBar
			// 
			precisionTrackBar.Location = new Point(3, 257);
			precisionTrackBar.Maximum = 100;
			precisionTrackBar.Minimum = 1;
			precisionTrackBar.Name = "precisionTrackBar";
			precisionTrackBar.Size = new Size(130, 56);
			precisionTrackBar.TabIndex = 4;
			precisionTrackBar.Value = 10;
			precisionTrackBar.Scroll += precisionTrackBar_Scroll;
			// 
			// precisionLabel
			// 
			precisionLabel.AutoSize = true;
			precisionLabel.Location = new Point(3, 316);
			precisionLabel.Name = "precisionLabel";
			precisionLabel.Size = new Size(68, 20);
			precisionLabel.TabIndex = 11;
			precisionLabel.Text = "Value: 10";
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1182, 753);
			Controls.Add(splitContainer1);
			Name = "Form1";
			Text = "Form1";
			Resize += Form1_Resize;
			((System.ComponentModel.ISupportInitialize)Canvas).EndInit();
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			flowLayoutPanel1.ResumeLayout(false);
			flowLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)alfaSlider).EndInit();
			((System.ComponentModel.ISupportInitialize)betaSlider).EndInit();
			((System.ComponentModel.ISupportInitialize)precisionTrackBar).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private PictureBox Canvas;
		private SplitContainer splitContainer1;
		private FlowLayoutPanel flowLayoutPanel1;
		private CheckBox checkBox1;
		private TrackBar betaSlider;
		private TrackBar alfaSlider;
		private TrackBar precisionTrackBar;
		private Label label1;
		private Label label3;
		private Label label2;
		private Label alfaLabel;
		private Label betaLabel;
		private Label precisionLabel;
	}
}
