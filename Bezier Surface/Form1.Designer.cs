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
			tableLayoutPanel1 = new TableLayoutPanel();
			Canvas = new PictureBox();
			flowLayoutPanel1 = new FlowLayoutPanel();
			controlPointsCheckbox = new CheckBox();
			meshCheckBox = new CheckBox();
			fillingCheckbox = new CheckBox();
			alfaLabel = new Label();
			alfaSlider = new TrackBar();
			betaLabel = new Label();
			betaSlider = new TrackBar();
			precisionLabel = new Label();
			precisionTrackBar = new TrackBar();
			lightColorButton = new Button();
			groupBox1 = new GroupBox();
			textureButton = new RadioButton();
			solidColorButton = new RadioButton();
			normalmapCheckbox = new CheckBox();
			changeTextureButton = new Button();
			changeNormalMapButton = new Button();
			flowLayoutPanel2 = new FlowLayoutPanel();
			kdLabel = new Label();
			kdTrackbar = new TrackBar();
			ksLabel = new Label();
			ksTrackbar = new TrackBar();
			mLabel = new Label();
			mTrackbar = new TrackBar();
			zLightLabel = new Label();
			zLightTrackbar = new TrackBar();
			animationButton = new Button();
			label1 = new Label();
			speedTrackbar = new TrackBar();
			lightPositionCheckbox = new CheckBox();
			tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)Canvas).BeginInit();
			flowLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)alfaSlider).BeginInit();
			((System.ComponentModel.ISupportInitialize)betaSlider).BeginInit();
			((System.ComponentModel.ISupportInitialize)precisionTrackBar).BeginInit();
			groupBox1.SuspendLayout();
			flowLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)kdTrackbar).BeginInit();
			((System.ComponentModel.ISupportInitialize)ksTrackbar).BeginInit();
			((System.ComponentModel.ISupportInitialize)mTrackbar).BeginInit();
			((System.ComponentModel.ISupportInitialize)zLightTrackbar).BeginInit();
			((System.ComponentModel.ISupportInitialize)speedTrackbar).BeginInit();
			SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 3;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250F));
			tableLayoutPanel1.Controls.Add(Canvas, 1, 0);
			tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 0);
			tableLayoutPanel1.Controls.Add(flowLayoutPanel2, 2, 0);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 1;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel1.Size = new Size(1582, 953);
			tableLayoutPanel1.TabIndex = 1;
			// 
			// Canvas
			// 
			Canvas.Dock = DockStyle.Fill;
			Canvas.Location = new Point(253, 3);
			Canvas.Name = "Canvas";
			Canvas.Size = new Size(1076, 947);
			Canvas.TabIndex = 0;
			Canvas.TabStop = false;
			// 
			// flowLayoutPanel1
			// 
			flowLayoutPanel1.Controls.Add(controlPointsCheckbox);
			flowLayoutPanel1.Controls.Add(meshCheckBox);
			flowLayoutPanel1.Controls.Add(fillingCheckbox);
			flowLayoutPanel1.Controls.Add(alfaLabel);
			flowLayoutPanel1.Controls.Add(alfaSlider);
			flowLayoutPanel1.Controls.Add(betaLabel);
			flowLayoutPanel1.Controls.Add(betaSlider);
			flowLayoutPanel1.Controls.Add(precisionLabel);
			flowLayoutPanel1.Controls.Add(precisionTrackBar);
			flowLayoutPanel1.Controls.Add(lightColorButton);
			flowLayoutPanel1.Controls.Add(groupBox1);
			flowLayoutPanel1.Controls.Add(normalmapCheckbox);
			flowLayoutPanel1.Controls.Add(changeTextureButton);
			flowLayoutPanel1.Controls.Add(changeNormalMapButton);
			flowLayoutPanel1.Dock = DockStyle.Fill;
			flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
			flowLayoutPanel1.Location = new Point(3, 3);
			flowLayoutPanel1.Name = "flowLayoutPanel1";
			flowLayoutPanel1.Size = new Size(244, 947);
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
			meshCheckBox.CheckedChanged += meshCheckbox_CheckedChanged;
			// 
			// fillingCheckbox
			// 
			fillingCheckbox.AutoSize = true;
			fillingCheckbox.Checked = true;
			fillingCheckbox.CheckState = CheckState.Checked;
			fillingCheckbox.Location = new Point(3, 63);
			fillingCheckbox.Name = "fillingCheckbox";
			fillingCheckbox.Size = new Size(111, 24);
			fillingCheckbox.TabIndex = 33;
			fillingCheckbox.Text = "Show Filling";
			fillingCheckbox.UseVisualStyleBackColor = true;
			fillingCheckbox.CheckedChanged += fillingCheckbox_CheckedChanged;
			// 
			// alfaLabel
			// 
			alfaLabel.AutoSize = true;
			alfaLabel.Location = new Point(3, 90);
			alfaLabel.Name = "alfaLabel";
			alfaLabel.Size = new Size(90, 20);
			alfaLabel.TabIndex = 9;
			alfaLabel.Text = "Alfa value: 0";
			// 
			// alfaSlider
			// 
			alfaSlider.Location = new Point(3, 113);
			alfaSlider.Maximum = 45;
			alfaSlider.Minimum = -45;
			alfaSlider.Name = "alfaSlider";
			alfaSlider.Size = new Size(124, 56);
			alfaSlider.TabIndex = 3;
			alfaSlider.TickStyle = TickStyle.None;
			alfaSlider.Scroll += alfaSlider_Scroll;
			// 
			// betaLabel
			// 
			betaLabel.AutoSize = true;
			betaLabel.Location = new Point(3, 172);
			betaLabel.Name = "betaLabel";
			betaLabel.RightToLeft = RightToLeft.No;
			betaLabel.Size = new Size(93, 20);
			betaLabel.TabIndex = 10;
			betaLabel.Text = "Beta value: 0";
			// 
			// betaSlider
			// 
			betaSlider.Location = new Point(1, 193);
			betaSlider.Margin = new Padding(1);
			betaSlider.Maximum = 45;
			betaSlider.Name = "betaSlider";
			betaSlider.Size = new Size(130, 56);
			betaSlider.TabIndex = 2;
			betaSlider.TickStyle = TickStyle.None;
			betaSlider.Scroll += betaSlider_Scroll;
			// 
			// precisionLabel
			// 
			precisionLabel.AutoSize = true;
			precisionLabel.Location = new Point(3, 250);
			precisionLabel.Name = "precisionLabel";
			precisionLabel.Size = new Size(130, 20);
			precisionLabel.TabIndex = 11;
			precisionLabel.Text = "Precision value: 10";
			// 
			// precisionTrackBar
			// 
			precisionTrackBar.Location = new Point(3, 273);
			precisionTrackBar.Maximum = 100;
			precisionTrackBar.Minimum = 1;
			precisionTrackBar.Name = "precisionTrackBar";
			precisionTrackBar.Size = new Size(130, 56);
			precisionTrackBar.TabIndex = 4;
			precisionTrackBar.TickStyle = TickStyle.None;
			precisionTrackBar.Value = 10;
			precisionTrackBar.Scroll += precisionTrackBar_Scroll;
			// 
			// lightColorButton
			// 
			lightColorButton.Location = new Point(3, 335);
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
			groupBox1.Controls.Add(textureButton);
			groupBox1.Controls.Add(solidColorButton);
			groupBox1.Location = new Point(3, 370);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(116, 106);
			groupBox1.TabIndex = 17;
			groupBox1.TabStop = false;
			groupBox1.Text = "Surface Type";
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
			// 
			// normalmapCheckbox
			// 
			normalmapCheckbox.AutoSize = true;
			normalmapCheckbox.Location = new Point(3, 482);
			normalmapCheckbox.Name = "normalmapCheckbox";
			normalmapCheckbox.Size = new Size(115, 24);
			normalmapCheckbox.TabIndex = 32;
			normalmapCheckbox.Text = "Normal Map";
			normalmapCheckbox.UseVisualStyleBackColor = true;
			normalmapCheckbox.CheckedChanged += normalMapbutton_CheckedChanged;
			// 
			// changeTextureButton
			// 
			changeTextureButton.Location = new Point(3, 512);
			changeTextureButton.Name = "changeTextureButton";
			changeTextureButton.Size = new Size(163, 29);
			changeTextureButton.TabIndex = 34;
			changeTextureButton.Text = "Change Texture";
			changeTextureButton.UseVisualStyleBackColor = true;
			changeTextureButton.Click += changeTextureButton_Click;
			// 
			// changeNormalMapButton
			// 
			changeNormalMapButton.Location = new Point(3, 547);
			changeNormalMapButton.Name = "changeNormalMapButton";
			changeNormalMapButton.Size = new Size(163, 29);
			changeNormalMapButton.TabIndex = 35;
			changeNormalMapButton.Text = "Change Normal Map";
			changeNormalMapButton.UseVisualStyleBackColor = true;
			changeNormalMapButton.Click += changeNormalMapButton_Click;
			// 
			// flowLayoutPanel2
			// 
			flowLayoutPanel2.Controls.Add(kdLabel);
			flowLayoutPanel2.Controls.Add(kdTrackbar);
			flowLayoutPanel2.Controls.Add(ksLabel);
			flowLayoutPanel2.Controls.Add(ksTrackbar);
			flowLayoutPanel2.Controls.Add(mLabel);
			flowLayoutPanel2.Controls.Add(mTrackbar);
			flowLayoutPanel2.Controls.Add(zLightLabel);
			flowLayoutPanel2.Controls.Add(zLightTrackbar);
			flowLayoutPanel2.Controls.Add(animationButton);
			flowLayoutPanel2.Controls.Add(label1);
			flowLayoutPanel2.Controls.Add(speedTrackbar);
			flowLayoutPanel2.Controls.Add(lightPositionCheckbox);
			flowLayoutPanel2.Dock = DockStyle.Fill;
			flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
			flowLayoutPanel2.Location = new Point(1335, 3);
			flowLayoutPanel2.Name = "flowLayoutPanel2";
			flowLayoutPanel2.Size = new Size(244, 947);
			flowLayoutPanel2.TabIndex = 1;
			// 
			// kdLabel
			// 
			kdLabel.AutoSize = true;
			kdLabel.Location = new Point(3, 0);
			kdLabel.Name = "kdLabel";
			kdLabel.Size = new Size(92, 20);
			kdLabel.TabIndex = 20;
			kdLabel.Text = "Kd value: 0.8";
			// 
			// kdTrackbar
			// 
			kdTrackbar.Location = new Point(3, 23);
			kdTrackbar.Name = "kdTrackbar";
			kdTrackbar.Size = new Size(130, 56);
			kdTrackbar.TabIndex = 18;
			kdTrackbar.TickStyle = TickStyle.None;
			kdTrackbar.Value = 8;
			kdTrackbar.Scroll += kdTrackbar_Scroll;
			// 
			// ksLabel
			// 
			ksLabel.AutoSize = true;
			ksLabel.Location = new Point(3, 82);
			ksLabel.Name = "ksLabel";
			ksLabel.Size = new Size(89, 20);
			ksLabel.TabIndex = 23;
			ksLabel.Text = "Ks value: 0.2";
			// 
			// ksTrackbar
			// 
			ksTrackbar.Location = new Point(3, 105);
			ksTrackbar.Name = "ksTrackbar";
			ksTrackbar.Size = new Size(130, 56);
			ksTrackbar.TabIndex = 21;
			ksTrackbar.TickStyle = TickStyle.None;
			ksTrackbar.Value = 2;
			ksTrackbar.Scroll += ksTrackbar_Scroll;
			// 
			// mLabel
			// 
			mLabel.AutoSize = true;
			mLabel.Location = new Point(3, 164);
			mLabel.Name = "mLabel";
			mLabel.Size = new Size(84, 20);
			mLabel.TabIndex = 26;
			mLabel.Text = "M value: 10";
			// 
			// mTrackbar
			// 
			mTrackbar.Location = new Point(3, 187);
			mTrackbar.Maximum = 100;
			mTrackbar.Minimum = 1;
			mTrackbar.Name = "mTrackbar";
			mTrackbar.Size = new Size(130, 56);
			mTrackbar.TabIndex = 24;
			mTrackbar.TickStyle = TickStyle.None;
			mTrackbar.Value = 10;
			mTrackbar.Scroll += mTrackbar_Scroll;
			// 
			// zLightLabel
			// 
			zLightLabel.AutoSize = true;
			zLightLabel.Location = new Point(3, 246);
			zLightLabel.Name = "zLightLabel";
			zLightLabel.Size = new Size(125, 20);
			zLightLabel.TabIndex = 29;
			zLightLabel.Text = "Light Z value: 200";
			// 
			// zLightTrackbar
			// 
			zLightTrackbar.Location = new Point(3, 269);
			zLightTrackbar.Maximum = 1000;
			zLightTrackbar.Minimum = 100;
			zLightTrackbar.Name = "zLightTrackbar";
			zLightTrackbar.Size = new Size(130, 56);
			zLightTrackbar.TabIndex = 27;
			zLightTrackbar.TickStyle = TickStyle.None;
			zLightTrackbar.Value = 500;
			zLightTrackbar.Scroll += zLightTrackbar_Scroll;
			// 
			// animationButton
			// 
			animationButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			animationButton.Location = new Point(3, 331);
			animationButton.Name = "animationButton";
			animationButton.Size = new Size(160, 29);
			animationButton.TabIndex = 30;
			animationButton.Text = "Start Animation";
			animationButton.UseVisualStyleBackColor = true;
			animationButton.Click += animationButton_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(3, 363);
			label1.Name = "label1";
			label1.Size = new Size(122, 20);
			label1.TabIndex = 35;
			label1.Text = "Animation speed";
			// 
			// speedTrackbar
			// 
			speedTrackbar.Location = new Point(3, 386);
			speedTrackbar.Maximum = 100;
			speedTrackbar.Minimum = 1;
			speedTrackbar.Name = "speedTrackbar";
			speedTrackbar.Size = new Size(130, 56);
			speedTrackbar.TabIndex = 34;
			speedTrackbar.TickStyle = TickStyle.None;
			speedTrackbar.Value = 50;
			speedTrackbar.Scroll += speedTrackbar_Scroll;
			// 
			// lightPositionCheckbox
			// 
			lightPositionCheckbox.AutoSize = true;
			lightPositionCheckbox.Location = new Point(3, 448);
			lightPositionCheckbox.Name = "lightPositionCheckbox";
			lightPositionCheckbox.Size = new Size(160, 24);
			lightPositionCheckbox.TabIndex = 36;
			lightPositionCheckbox.Text = "Show Light Position";
			lightPositionCheckbox.UseVisualStyleBackColor = true;
			lightPositionCheckbox.CheckedChanged += lightPositionCheckbox_CheckedChanged;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1582, 953);
			Controls.Add(tableLayoutPanel1);
			Name = "Form1";
			Text = "Form1";
			Resize += Form1_Resize;
			tableLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)Canvas).EndInit();
			flowLayoutPanel1.ResumeLayout(false);
			flowLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)alfaSlider).EndInit();
			((System.ComponentModel.ISupportInitialize)betaSlider).EndInit();
			((System.ComponentModel.ISupportInitialize)precisionTrackBar).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			flowLayoutPanel2.ResumeLayout(false);
			flowLayoutPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)kdTrackbar).EndInit();
			((System.ComponentModel.ISupportInitialize)ksTrackbar).EndInit();
			((System.ComponentModel.ISupportInitialize)mTrackbar).EndInit();
			((System.ComponentModel.ISupportInitialize)zLightTrackbar).EndInit();
			((System.ComponentModel.ISupportInitialize)speedTrackbar).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private TableLayoutPanel tableLayoutPanel1;
		private FlowLayoutPanel flowLayoutPanel1;
		private CheckBox controlPointsCheckbox;
		private CheckBox meshCheckBox;
		private CheckBox fillingCheckbox;
		private Label alfaLabel;
		private TrackBar alfaSlider;
		private Label betaLabel;
		private TrackBar betaSlider;
		private Label precisionLabel;
		private TrackBar precisionTrackBar;
		private Button lightColorButton;
		private GroupBox groupBox1;
		private RadioButton textureButton;
		private RadioButton solidColorButton;
		private CheckBox normalmapCheckbox;
		private Label kdLabel;
		private TrackBar kdTrackbar;
		private Label ksLabel;
		private TrackBar ksTrackbar;
		private Label mLabel;
		private TrackBar mTrackbar;
		private Label zLightLabel;
		private TrackBar zLightTrackbar;
		private Button animationButton;
		private TrackBar speedTrackbar;
		private PictureBox Canvas;
		private Button changeTextureButton;
		private Button changeNormalMapButton;
		private FlowLayoutPanel flowLayoutPanel2;
		private Label label1;
		private CheckBox lightPositionCheckbox;
	}
}
