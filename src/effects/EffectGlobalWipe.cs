class EffectGlobalWipe : Effect {
	public override void onWake() {
		G.colourGlobally(
			Colour.LIME
		);
	}
}
