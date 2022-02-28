using System.Drawing;



static class ColourUtilities {
	private static double alphaCompositeOverComponent(
		int frontColour,
		int backColour,
		int frontAlpha,
		int backAlpha,
		double finalAlphaInterval
	) {
		double frontAlphaInterval = frontAlpha / 255d;
		double backAlphaInterval = backAlpha / 255d;

		return ((frontColour * frontAlphaInterval) + (backColour * backAlphaInterval * (1 - frontAlphaInterval))) / finalAlphaInterval;
	}

	public static Color alphaCompositeOver(Color front, Color back) {
		double frontAlphaInterval = front.A / 255d;
		double backAlphaInterval = back.A / 255d;

		double finalAlphaInterval = frontAlphaInterval + (backAlphaInterval * (1 - frontAlphaInterval));
		double finalRed = alphaCompositeOverComponent(
			front.R,
			back.R,
			front.A,
			back.A,
			finalAlphaInterval
		);
		double finalGreen = alphaCompositeOverComponent(
			front.G,
			back.G,
			front.A,
			back.A,
			finalAlphaInterval
		);
		double finalBlue = alphaCompositeOverComponent(
			front.B,
			back.B,
			front.A,
			back.A,
			finalAlphaInterval
		);

		int finalAlpha = Convert.ToInt32(finalAlphaInterval * 255);

		return Color.FromArgb(
			finalAlpha,
			Convert.ToInt32(finalRed),
			Convert.ToInt32(finalGreen),
			Convert.ToInt32(finalBlue)
		);
	}

	public static Color overwriteAlpha(Color colour, double alpha) {
		return Color.FromArgb(
			Convert.ToInt32(alpha),
			colour.R,
			colour.G,
			colour.B
		);
	}

	public static int toAlphaPercentage(int component, int alpha) {
		double componentPercentage = (component / 255d) * 100;
		double alphaInterval = alpha / 255d;
		return Convert.ToInt32(componentPercentage * alphaInterval);
	}
}
