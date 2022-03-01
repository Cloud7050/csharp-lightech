using H.Hooks;



abstract class Effect {
	public virtual void onStart() {}

	public virtual void onFrame() {}

	public virtual void onKeyDown(Key eventKey) {}

	public virtual void onKeyUp(Key eventKey) {}
}
