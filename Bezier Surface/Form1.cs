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
	}
}
