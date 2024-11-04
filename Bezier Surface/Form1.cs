namespace Bezier_Surface
{
	public partial class Form1 : Form
	{
		Blueprint blueprint;
		public Form1()
		{
			InitializeComponent();
			blueprint = new Blueprint(Canvas.Width, Canvas.Height, Canvas);
			blueprint.Canvas = Canvas;
			Canvas.Image = blueprint.bitmap;
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void alfaSlider_Scroll(object sender, EventArgs e)
		{
			blueprint.alfa = alfaSlider.Value;
			alfaLabel.Text = "Value: " + alfaSlider.Value.ToString() + "       ";
			blueprint.Draw();
		}

		private void betaSlider_Scroll(object sender, EventArgs e)
		{
			blueprint.beta = betaSlider.Value;
			betaLabel.Text = "Value: " + betaSlider.Value.ToString() + "       ";
			blueprint.Draw();
		}

		private void precisionTrackBar_Scroll(object sender, EventArgs e)
		{
			blueprint.precision = precisionTrackBar.Value;
			precisionLabel.Text = "Value: " + precisionTrackBar.Value.ToString();
			blueprint.Draw();
		}

	}
}
