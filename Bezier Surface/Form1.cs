namespace Bezier_Surface
{
	internal partial class Form1 : Form
	{
		Blueprint blueprint;
		Animator animator; // TODO generacja mapy wektorów normalnych, kilka Ÿróde³ œwiat³a
		public Form1()
		{
			InitializeComponent();
			blueprint = new Blueprint(Canvas.Width, Canvas.Height, Canvas);
			blueprint.canvas = Canvas;
			Canvas.Image = blueprint.bitmap;
			animator = new Animator(blueprint, this);
			animator.ChangeState();
		}

		private void controlPointsCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			blueprint.showControlPoints = controlPointsCheckbox.Checked;
			blueprint.DrawAndRefresh();
		}

		private void alfaSlider_Scroll(object sender, EventArgs e)
		{
			lock (Blueprint.lockObject)
			{
				blueprint.alfa = alfaSlider.Value;
				alfaLabel.Text = "Alfa value: " + alfaSlider.Value.ToString();
				blueprint.Rotate();
			}
			blueprint.DrawAndRefresh();
		}

		private void betaSlider_Scroll(object sender, EventArgs e)
		{
			lock (Blueprint.lockObject)
			{
				blueprint.beta = betaSlider.Value;
				betaLabel.Text = "Beta value: " + betaSlider.Value.ToString();
				blueprint.Rotate();
			}
			blueprint.DrawAndRefresh();
		}

		private void precisionTrackBar_Scroll(object sender, EventArgs e)
		{
			lock (Blueprint.lockObject)
			{
				blueprint.precision = precisionTrackBar.Value;
				precisionLabel.Text = "Precision value: " + precisionTrackBar.Value.ToString();
				blueprint.CreateTriangularMesh();
				blueprint.Rotate();
			}
			blueprint.DrawAndRefresh();
		}

		private void Form1_Resize(object sender, EventArgs e)
		{
			blueprint.bitmap = new Bitmap(Canvas.Width, Canvas.Height);
			Canvas.Image = blueprint.bitmap;
			blueprint.DrawAndRefresh();
		}

		private void lightColorButton_Click(object sender, EventArgs e)
		{
			var colorDialog = new ColorDialog();
			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				blueprint.lightColor = colorDialog.Color;
				lightColorButton.BackColor = colorDialog.Color;
			}
			blueprint.DrawAndRefresh();
		}

		private void kdTrackbar_Scroll(object sender, EventArgs e)
		{
			blueprint.kd = kdTrackbar.Value / 10f;
			kdLabel.Text = "Kd value: " + blueprint.kd.ToString();
			blueprint.DrawAndRefresh();
		}

		private void ksTrackbar_Scroll(object sender, EventArgs e)
		{
			blueprint.ks = ksTrackbar.Value / 10f;
			ksLabel.Text = "Ks value: " + blueprint.ks.ToString();
			blueprint.DrawAndRefresh();
		}

		private void mTrackbar_Scroll(object sender, EventArgs e)
		{
			blueprint.m = mTrackbar.Value;
			mLabel.Text = "M value: " + mTrackbar.Value.ToString();
			blueprint.DrawAndRefresh();
		}

		private void zLightTrackbar_Scroll(object sender, EventArgs e)
		{
			blueprint.lightPosition.Z = zLightTrackbar.Value;
			zLightLabel.Text = "Light Z value: " + zLightTrackbar.Value.ToString();
			blueprint.DrawAndRefresh();
		}

		private void animationButton_Click(object sender, EventArgs e)
		{
			animator.ChangeState();
			animationButton.Text = animator.running ? "Pause Animation" : "Start Animation";
		}

		private void meshCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			blueprint.showMesh = meshCheckBox.Checked;
			blueprint.DrawAndRefresh();
		}

		private void textureButton_CheckedChanged(object sender, EventArgs e)
		{
			lock (Blueprint.lockObject)
			{
				blueprint.useTexture = textureButton.Checked;
				if (blueprint.useTexture)
					blueprint.CreateTriangularMesh();
			}
			blueprint.Rotate();
			blueprint.DrawAndRefresh();

		}

		private void normalMapbutton_CheckedChanged(object sender, EventArgs e)
		{
			lock (Blueprint.lockObject)
			{
				blueprint.useNormalMap = normalmapCheckbox.Checked;
				if (blueprint.useTexture)
					blueprint.CreateTriangularMesh();
			}
			blueprint.Rotate();
			blueprint.DrawAndRefresh();
		}

		private void fillingCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			blueprint.showFilling = fillingCheckbox.Checked;
			blueprint.DrawAndRefresh();
		}

		private void speedTrackbar_Scroll(object sender, EventArgs e)
		{
			animator.speed = speedTrackbar.Value;
		}

		private void changeTextureButton_Click(object sender, EventArgs e)
		{
			var ofd = new OpenFileDialog();
			ofd.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG";
			ofd.Title = "Select texture file";
			ofd.InitialDirectory = Application.StartupPath + "Textures\\";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				blueprint.textureFilePatch = ofd.FileName;
				blueprint.LoadTexture();
			}
		}

		private void changeNormalMapButton_Click(object sender, EventArgs e)
		{
			var ofd = new OpenFileDialog();
			ofd.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG";
			ofd.Title = "Select normal map file";
			ofd.InitialDirectory = Application.StartupPath + "NormalMaps\\";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				blueprint.normalMapFilePatch = ofd.FileName;
				blueprint.LoadMap();
			}
		}
	}
}
