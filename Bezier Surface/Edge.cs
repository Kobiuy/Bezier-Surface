using Bezier_Surface;

public class Edge
{
	public Edge next;
	public float x;
	public float yMax;
	public float yMin;
	public float invSlope;

	public Edge(Vertex V1, Vertex V2)
	{
		x = V1.pointAR.Y < V2.pointAR.Y ? V1.pointAR.X : V2.pointAR.X;
		yMax = Math.Max(V1.pointAR.Y, V2.pointAR.Y);
		yMin = Math.Min(V1.pointAR.Y, V2.pointAR.Y);
		invSlope = V1.pointAR.Y < V2.pointAR.Y
			? (V2.pointAR.X - V1.pointAR.X) / (V2.pointAR.Y - V1.pointAR.Y)
			: (V1.pointAR.X - V2.pointAR.X) / (V1.pointAR.Y - V2.pointAR.Y);
	}

	public void IncreaseX()
	{
		x += invSlope;
	}
}
