using H.Hooks;



abstract class Ripple {
	protected bool isStillDown = true;

	protected LightKey lightKey;

	protected Circle ring;
	protected Colour colour;

	public Ripple(LightKey _lightKey) {
		lightKey = _lightKey;
		ring = new Circle(_lightKey.circle.centre);

		colour = ColourStream.nextColour();
	}

	public bool isForEventKey(Key eventKey) {
		return lightKey.eventKey == eventKey;
	}

	public void onThisKeyUp() {
		if (isStillDown) {
			onNoLongerDown();
			return;
		}

		isStillDown = false;
	}

	public virtual void onNoLongerDown() {}

	public virtual void onFrameStart() {}

	public abstract Colour onGetColour(LightKey lightKey);

	public virtual void onFrameEnd() {}

	public virtual bool onCheckRemove() {
		return false;
	}
}
