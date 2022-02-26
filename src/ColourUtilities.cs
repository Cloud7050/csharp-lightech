using System.Drawing;



public static class ColourUtilities {
	public static Color overwriteAlpha(Color colour, double alpha) {
		return Color.FromArgb(
			Convert.ToInt32(alpha),
			colour.R,
			colour.G,
			colour.B
		);
	}

	public static Color alphaCompositeOver(Color front, Color back) {
		double intervalFrontAlpha = front.A / 255d;
		double intervalBackAlpha = back.A / 255d;

		double intervalFinalAlpha = intervalFrontAlpha + (intervalBackAlpha * (1 - intervalFrontAlpha));
		double finalRed = alphaCompositeOverComponent(
			front.R,
			back.R,
			front.A,
			back.A,
			intervalFinalAlpha
		);
		double finalGreen = alphaCompositeOverComponent(
			front.G,
			back.G,
			front.A,
			back.A,
			intervalFinalAlpha
		);
		double finalBlue = alphaCompositeOverComponent(
			front.B,
			back.B,
			front.A,
			back.A,
			intervalFinalAlpha
		);

		int finalAlpha = Convert.ToInt32(intervalFinalAlpha * 255);

		return Color.FromArgb(
			finalAlpha,
			Convert.ToInt32(finalRed),
			Convert.ToInt32(finalGreen),
			Convert.ToInt32(finalBlue)
		);
	}
	private static double alphaCompositeOverComponent(
		int frontColour,
		int backColour,
		int frontAlpha,
		int backAlpha,
		double intervalFinalAlpha
	) {
		double intervalFrontAlpha = frontAlpha / 255d;
		double intervalBackAlpha = backAlpha / 255d;

		return ((frontColour * intervalFrontAlpha) + (backColour * intervalBackAlpha * (1 - intervalFrontAlpha))) / intervalFinalAlpha;
	}

	public static int toPercentage(int component) {
		return Convert.ToInt32((component / 255d) * 100);
	}
}
