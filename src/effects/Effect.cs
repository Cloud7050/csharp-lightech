using H.Hooks;



abstract class Effect {
	public virtual void onStart() {}

	public virtual void onFrame() {}

	public virtual void onKeyDown(KeyboardEventArgs data) {}

	public virtual void onKeyUp(KeyboardEventArgs data) {}
}
