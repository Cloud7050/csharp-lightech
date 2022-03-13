abstract class Ripple {
	protected Circle ring;
	protected Colour colour;

	public Ripple(ImmutablePoint centre) {
		ring = new Circle(centre);

		colour = ColourStream.nextColour();
	}

	public abstract Colour onGetColour(LightKey lightKey);

	public virtual void onFrameEnd() {}

	public virtual bool onCheckRemove() {
		return false;
	}
}
