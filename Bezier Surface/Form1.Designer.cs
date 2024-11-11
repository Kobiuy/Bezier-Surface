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
			controlPointsCheckbox = new CheckBox();
			meshCheckBox = new CheckBox();
			label3 = new Label();
			alfaSlider = new TrackBar();
			alfaLabel = new Label();
			label2 = new Label();
			betaSlider = new TrackBar();
			betaLabel = new Label();
			label1 = new Label();
			precisionTrackBar = new TrackBar();
			precisionLabel = new Label();
			lightColorButton = new Button();
			groupBox1 = new GroupBox();
			normalMapButton = new RadioButton();
			textureButton = new RadioButton();
			solidColorButton = new RadioButton();
			label4 = new Label();
			kdTrackbar = new TrackBar();
			kdLabel = new Label();
			label6 = new Label();
			ksTrackbar = new TrackBar();
			ksLabel = new Label();
			label8 = new Label();
			mTrackbar = new TrackBar();
			mLabel = new Label();
			label10 = new Label();
			zLightTrackbar = new TrackBar();
			zLightLabel = new Label();
			animationButton = new Button();
			((System.ComponentModel.ISupportInitialize)Canvas).BeginInit();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			flowLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)alfaSlider).BeginInit();
			((System.ComponentModel.ISupportInitialize)betaSlider).BeginInit();
			((System.ComponentModel.ISupportInitialize)precisionTrackBar).BeginInit();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)kdTrackbar).BeginInit();
			((System.ComponentModel.ISupportInitialize)ksTrackbar).BeginInit();
			((System.ComponentModel.ISupportInitialize)mTrackbar).BeginInit();
			((System.ComponentModel.ISupportInitialize)zLightTrackbar).BeginInit();
			SuspendLayout();
			// 
			// Canvas
			// 
			Canvas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			Canvas.Location = new Point(15, 0);
			Canvas.Name = "Canvas";
			Canvas.Size = new Size(1008, 1053);
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
			splitContainer1.Size = new Size(1182, 1053);
			splitContainer1.SplitterDistance = 170;
			splitContainer1.TabIndex = 1;
			// 
			// flowLayoutPanel1
			// 
			flowLayoutPanel1.Controls.Add(controlPointsCheckbox);
			flowLayoutPanel1.Controls.Add(meshCheckBox);
			flowLayoutPanel1.Controls.Add(label3);
			flowLayoutPanel1.Controls.Add(alfaSlider);
			flowLayoutPanel1.Controls.Add(alfaLabel);
			flowLayoutPanel1.Controls.Add(label2);
			flowLayoutPanel1.Controls.Add(betaSlider);
			flowLayoutPanel1.Controls.Add(betaLabel);
			flowLayoutPanel1.Controls.Add(label1);
			flowLayoutPanel1.Controls.Add(precisionTrackBar);
			flowLayoutPanel1.Controls.Add(precisionLabel);
			flowLayoutPanel1.Controls.Add(lightColorButton);
			flowLayoutPanel1.Controls.Add(groupBox1);
			flowLayoutPanel1.Controls.Add(label4);
			flowLayoutPanel1.Controls.Add(kdTrackbar);
			flowLayoutPanel1.Controls.Add(kdLabel);
			flowLayoutPanel1.Controls.Add(label6);
			flowLayoutPanel1.Controls.Add(ksTrackbar);
			flowLayoutPanel1.Controls.Add(ksLabel);
			flowLayoutPanel1.Controls.Add(label8);
			flowLayoutPanel1.Controls.Add(mTrackbar);
			flowLayoutPanel1.Controls.Add(mLabel);
			flowLayoutPanel1.Controls.Add(label10);
			flowLayoutPanel1.Controls.Add(zLightTrackbar);
			flowLayoutPanel1.Controls.Add(zLightLabel);
			flowLayoutPanel1.Controls.Add(animationButton);
			flowLayoutPanel1.Dock = DockStyle.Fill;
			flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
			flowLayoutPanel1.Location = new Point(0, 0);
			flowLayoutPanel1.Name = "flowLayoutPanel1";
			flowLayoutPanel1.Size = new Size(170, 1053);
			flowLayoutPanel1.TabIndex = 0;
			// 
			// controlPointsCheckbox
			// 
			controlPointsCheckbox.AutoSize = true;
			controlPointsCheckbox.Checked = true;
			controlPointsCheckbox.CheckState = CheckState.Checked;
			controlPointsCheckbox.Location = new Point(3, 3);
			controlPointsCheckbox.Name = "controlPointsCheckbox";
			controlPointsCheckbox.Size = new Size(163, 24);
			controlPointsCheckbox.TabIndex = 1;
			controlPointsCheckbox.Text = "Show Control Points";
			controlPointsCheckbox.UseVisualStyleBackColor = true;
			controlPointsCheckbox.CheckedChanged += controlPointsCheckbox_CheckedChanged;
			// 
			// meshCheckBox
			// 
			meshCheckBox.AutoSize = true;
			meshCheckBox.Checked = true;
			meshCheckBox.CheckState = CheckState.Checked;
			meshCheckBox.Location = new Point(3, 33);
			meshCheckBox.Name = "meshCheckBox";
			meshCheckBox.Size = new Size(106, 24);
			meshCheckBox.TabIndex = 31;
			meshCheckBox.Text = "Show Mesh";
			meshCheckBox.UseVisualStyleBackColor = true;
			meshCheckBox.CheckedChanged += checkBox1_CheckedChanged;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(3, 60);
			label3.Name = "label3";
			label3.Size = new Size(39, 20);
			label3.TabIndex = 8;
			label3.Text = "Alfa:";
			// 
			// alfaSlider
			// 
			alfaSlider.Location = new Point(3, 83);
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
			alfaLabel.Location = new Point(3, 142);
			alfaLabel.Name = "alfaLabel";
			alfaLabel.Size = new Size(60, 20);
			alfaLabel.TabIndex = 9;
			alfaLabel.Text = "Value: 0";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(3, 162);
			label2.Name = "label2";
			label2.Size = new Size(42, 20);
			label2.TabIndex = 7;
			label2.Text = "Beta:";
			// 
			// betaSlider
			// 
			betaSlider.Location = new Point(3, 185);
			betaSlider.Maximum = 90;
			betaSlider.Name = "betaSlider";
			betaSlider.Size = new Size(130, 56);
			betaSlider.TabIndex = 2;
			betaSlider.Scroll += betaSlider_Scroll;
			// 
			// betaLabel
			// 
			betaLabel.AutoSize = true;
			betaLabel.Location = new Point(3, 244);
			betaLabel.Name = "betaLabel";
			betaLabel.Size = new Size(60, 20);
			betaLabel.TabIndex = 10;
			betaLabel.Text = "Value: 0";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(3, 264);
			label1.Name = "label1";
			label1.Size = new Size(71, 20);
			label1.TabIndex = 6;
			label1.Text = "Precision:";
			// 
			// precisionTrackBar
			// 
			precisionTrackBar.Location = new Point(3, 287);
			precisionTrackBar.Maximum = 300;
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
			precisionLabel.Location = new Point(3, 346);
			precisionLabel.Name = "precisionLabel";
			precisionLabel.Size = new Size(68, 20);
			precisionLabel.TabIndex = 11;
			precisionLabel.Text = "Value: 10";
			// 
			// lightColorButton
			// 
			lightColorButton.Location = new Point(3, 369);
			lightColorButton.Name = "lightColorButton";
			lightColorButton.Size = new Size(94, 29);
			lightColorButton.TabIndex = 12;
			lightColorButton.Text = "Set Light Color";
			lightColorButton.UseVisualStyleBackColor = true;
			lightColorButton.Click += lightColorButton_Click;
			// 
			// groupBox1
			// 
			groupBox1.AutoSize = true;
			groupBox1.Controls.Add(normalMapButton);
			groupBox1.Controls.Add(textureButton);
			groupBox1.Controls.Add(solidColorButton);
			groupBox1.Location = new Point(3, 404);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(126, 136);
			groupBox1.TabIndex = 17;
			groupBox1.TabStop = false;
			groupBox1.Text = "Surface Type";
			// 
			// normalMapButton
			// 
			normalMapButton.AutoSize = true;
			normalMapButton.Location = new Point(6, 86);
			normalMapButton.Name = "normalMapButton";
			normalMapButton.Size = new Size(114, 24);
			normalMapButton.TabIndex = 15;
			normalMapButton.Text = "Normal Map";
			normalMapButton.UseVisualStyleBackColor = true;
			normalMapButton.CheckedChanged += normalMapbutton_CheckedChanged;
			// 
			// textureButton
			// 
			textureButton.AutoSize = true;
			textureButton.Location = new Point(6, 56);
			textureButton.Name = "textureButton";
			textureButton.Size = new Size(84, 24);
			textureButton.TabIndex = 13;
			textureButton.Text = "Teksture";
			textureButton.UseVisualStyleBackColor = true;
			textureButton.CheckedChanged += textureButton_CheckedChanged;
			// 
			// solidColorButton
			// 
			solidColorButton.AutoSize = true;
			solidColorButton.Checked = true;
			solidColorButton.Location = new Point(6, 26);
			solidColorButton.Name = "solidColorButton";
			solidColorButton.Size = new Size(104, 24);
			solidColorButton.TabIndex = 14;
			solidColorButton.TabStop = true;
			solidColorButton.Text = "Solid Color";
			solidColorButton.UseVisualStyleBackColor = true;
			solidColorButton.CheckedChanged += solidColorButton_CheckedChanged;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(3, 543);
			label4.Name = "label4";
			label4.Size = new Size(30, 20);
			label4.TabIndex = 19;
			label4.Text = "Kd:";
			// 
			// kdTrackbar
			// 
			kdTrackbar.Location = new Point(3, 566);
			kdTrackbar.Maximum = 9;
			kdTrackbar.Minimum = 1;
			kdTrackbar.Name = "kdTrackbar";
			kdTrackbar.Size = new Size(130, 56);
			kdTrackbar.TabIndex = 18;
			kdTrackbar.Value = 8;
			kdTrackbar.Scroll += kdTrackbar_Scroll;
			// 
			// kdLabel
			// 
			kdLabel.AutoSize = true;
			kdLabel.Location = new Point(3, 625);
			kdLabel.Name = "kdLabel";
			kdLabel.Size = new Size(71, 20);
			kdLabel.TabIndex = 20;
			kdLabel.Text = "Value: 0.8";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(3, 645);
			label6.Name = "label6";
			label6.Size = new Size(27, 20);
			label6.TabIndex = 22;
			label6.Text = "Ks:";
			// 
			// ksTrackbar
			// 
			ksTrackbar.Location = new Point(3, 668);
			ksTrackbar.Name = "ksTrackbar";
			ksTrackbar.Size = new Size(130, 56);
			ksTrackbar.TabIndex = 21;
			ksTrackbar.Value = 2;
			ksTrackbar.Scroll += ksTrackbar_Scroll;
			// 
			// ksLabel
			// 
			ksLabel.AutoSize = true;
			ksLabel.Location = new Point(3, 727);
			ksLabel.Name = "ksLabel";
			ksLabel.Size = new Size(71, 20);
			ksLabel.TabIndex = 23;
			ksLabel.Text = "Value: 0.2";
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Location = new Point(3, 747);
			label8.Name = "label8";
			label8.Size = new Size(25, 20);
			label8.TabIndex = 25;
			label8.Text = "M:";
			// 
			// mTrackbar
			// 
			mTrackbar.Location = new Point(3, 770);
			mTrackbar.Maximum = 100;
			mTrackbar.Minimum = 1;
			mTrackbar.Name = "mTrackbar";
			mTrackbar.Size = new Size(130, 56);
			mTrackbar.TabIndex = 24;
			mTrackbar.Value = 10;
			mTrackbar.Scroll += mTrackbar_Scroll;
			// 
			// mLabel
			// 
			mLabel.AutoSize = true;
			mLabel.Location = new Point(3, 829);
			mLabel.Name = "mLabel";
			mLabel.Size = new Size(68, 20);
			mLabel.TabIndex = 26;
			mLabel.Text = "Value: 10";
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Location = new Point(3, 849);
			label10.Name = "label10";
			label10.Size = new Size(58, 20);
			label10.TabIndex = 28;
			label10.Text = "Light Z:";
			// 
			// zLightTrackbar
			// 
			zLightTrackbar.Location = new Point(3, 872);
			zLightTrackbar.Maximum = 1000;
			zLightTrackbar.Minimum = 100;
			zLightTrackbar.Name = "zLightTrackbar";
			zLightTrackbar.Size = new Size(130, 56);
			zLightTrackbar.TabIndex = 27;
			zLightTrackbar.Value = 500;
			zLightTrackbar.Scroll += zLightTrackbar_Scroll;
			// 
			// zLightLabel
			// 
			zLightLabel.AutoSize = true;
			zLightLabel.Location = new Point(3, 931);
			zLightLabel.Name = "zLightLabel";
			zLightLabel.Size = new Size(76, 20);
			zLightLabel.TabIndex = 29;
			zLightLabel.Text = "Value: 200";
			// 
			// animationButton
			// 
			animationButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			animationButton.Location = new Point(3, 954);
			animationButton.Name = "animationButton";
			animationButton.Size = new Size(163, 29);
			animationButton.TabIndex = 30;
			animationButton.Text = "Start Animation";
			animationButton.UseVisualStyleBackColor = true;
			animationButton.Click += animationButton_Click;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1182, 1053);
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
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)kdTrackbar).EndInit();
			((System.ComponentModel.ISupportInitialize)ksTrackbar).EndInit();
			((System.ComponentModel.ISupportInitialize)mTrackbar).EndInit();
			((System.ComponentModel.ISupportInitialize)zLightTrackbar).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private PictureBox Canvas;
		private SplitContainer splitContainer1;
		private FlowLayoutPanel flowLayoutPanel1;
		private CheckBox controlPointsCheckbox;
		private TrackBar betaSlider;
		private TrackBar alfaSlider;
		private TrackBar precisionTrackBar;
		private Label label1;
		private Label label3;
		private Label label2;
		private Label alfaLabel;
		private Label betaLabel;
		private Label precisionLabel;
		private Button lightColorButton;
		private RadioButton textureButton;
		private RadioButton solidColorButton;
		private GroupBox groupBox1;
		private Label label4;
		private TrackBar kdTrackbar;
		private Label kdLabel;
		private Label label6;
		private TrackBar ksTrackbar;
		private Label ksLabel;
		private Label label8;
		private TrackBar mTrackbar;
		private Label mLabel;
		private Label label10;
		private TrackBar zLightTrackbar;
		private Label zLightLabel;
		private CheckBox meshCheckBox;
		private Button animationButton;
		private RadioButton normalMapButton;
	}
}
