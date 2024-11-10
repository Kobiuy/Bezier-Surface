namespace Bezier_Surface
{
	internal partial class Form1 : Form
	{
		Blueprint blueprint;
		Animator animator;
		public Form1()
		{
			InitializeComponent();
			blueprint = new Blueprint(Canvas.Width, Canvas.Height, Canvas);
			blueprint.Canvas = Canvas;
			Canvas.Image = blueprint.bitmap;
			animator = new Animator(blueprint, this);
			animator.ChangeState();
		}

		private void controlPointsCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			blueprint.showControlPoints = controlPointsCheckbox.Checked;
			blueprint.Draw();
		}

		private void alfaSlider_Scroll(object sender, EventArgs e)
		{
			blueprint.alfa = alfaSlider.Value;
			alfaLabel.Text = "Value: " + alfaSlider.Value.ToString();
			blueprint.Rotate();
			blueprint.Draw();
		}

		private void betaSlider_Scroll(object sender, EventArgs e)
		{
			blueprint.beta = betaSlider.Value;
			betaLabel.Text = "Value: " + betaSlider.Value.ToString();
			blueprint.Rotate();
			blueprint.Draw();
		}

		private void precisionTrackBar_Scroll(object sender, EventArgs e)
		{
			blueprint.precision = precisionTrackBar.Value;
			precisionLabel.Text = "Value: " + precisionTrackBar.Value.ToString();
			blueprint.CreateTriangularMesh();
			blueprint.Rotate();
			blueprint.Draw();
		}

		private void Form1_Resize(object sender, EventArgs e)
		{
			blueprint.bitmap = new Bitmap(Canvas.Width, Canvas.Height);
			Canvas.Image = blueprint.bitmap;
			blueprint.Draw();

		}

		private void lightColorButton_Click(object sender, EventArgs e)
		{
			var colorDialog = new ColorDialog();
			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				blueprint.lightColor = colorDialog.Color;
				lightColorButton.BackColor = colorDialog.Color;
			}
		}

		private void kdTrackbar_Scroll(object sender, EventArgs e)
		{
			blueprint.kd = kdTrackbar.Value / 10f;
			kdLabel.Text = "Value: " + blueprint.kd.ToString();
			blueprint.Draw();
		}

		private void ksTrackbar_Scroll(object sender, EventArgs e)
		{
			blueprint.ks = ksTrackbar.Value / 10f;
			ksLabel.Text = "Value: " + blueprint.ks.ToString();
			blueprint.Draw();
		}

		private void mTrackbar_Scroll(object sender, EventArgs e)
		{
			blueprint.m = mTrackbar.Value;
			mLabel.Text = "Value: " + mTrackbar.Value.ToString();
			blueprint.Draw();
		}

		private void zLightTrackbar_Scroll(object sender, EventArgs e)
		{
			blueprint.lightPosition.Z = zLightTrackbar.Value;
			zLightLabel.Text = "Value: " + zLightTrackbar.Value.ToString();
			blueprint.Draw();
		}

		private void animationButton_Click(object sender, EventArgs e)
		{
			animator.ChangeState();
			animationButton.Text = animator.running ? "Pause Animation" : "Start Animation";

		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			blueprint.showMesh = meshCheckBox.Checked;
			blueprint.Draw();
		}

		private void textureButton_CheckedChanged(object sender, EventArgs e)
		{
			blueprint.useTexture = textureButton.Checked;
			if (textureButton.Checked)
			{
				blueprint.Rotate();
				blueprint.Draw();
			}
		}

		private void solidColorButton_CheckedChanged(object sender, EventArgs e)
		{

		}
	}
}
