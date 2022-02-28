using System.Drawing;
using System.Numerics;
using H.Hooks;



using G = LedCSharp.LogitechGSDK;
using N = LedCSharp.keyboardNames;



static class Lightech {
	private static readonly KeyLight[] LOCATED_KEYS = new KeyLight[] {
		// Row 5
		new KeyLight(new Vector2(-7.75f, 5), null, N.G_LOGO),

		// Row 4
		new KeyLight(new Vector2(-6.25f, 3.5f), Key.CapsLock, N.ESC),

		new KeyLight(new Vector2(-4.5833f, 3.5f), Key.F1, N.F1),
		new KeyLight(new Vector2(-3.5833f, 3.5f), Key.F2, N.F2),
		new KeyLight(new Vector2(-2.5833f, 3.5f), Key.F3, N.F3),
		new KeyLight(new Vector2(-1.5833f, 3.5f), Key.F4, N.F4),

		new KeyLight(new Vector2(0.0833f, 3.5f), Key.F5, N.F5),
		new KeyLight(new Vector2(1.0833f, 3.5f), Key.F6, N.F6),
		new KeyLight(new Vector2(2.0833f, 3.5f), Key.F7, N.F7),
		new KeyLight(new Vector2(3.0833f, 3.5f), Key.F8, N.F8),

		new KeyLight(new Vector2(4.75f, 3.5f), Key.F9, N.F9),
		new KeyLight(new Vector2(5.75f, 3.5f), Key.F10, N.F10),
		new KeyLight(new Vector2(6.75f, 3.5f), Key.F11, N.F11),
		new KeyLight(new Vector2(7.75f, 3.5f), Key.F12, N.F12),

		new KeyLight(new Vector2(9.25f, 3.5f), Key.PrintScreen, N.PRINT_SCREEN),
		new KeyLight(new Vector2(10.25f, 3.5f), Key.Scroll, N.SCROLL_LOCK),
		new KeyLight(new Vector2(11.25f, 3.5f), Key.Pause, N.PAUSE_BREAK),

		// Row 3
		new KeyLight(new Vector2(-7.75f, 2), null, N.G_1),

		new KeyLight(new Vector2(-6.25f, 2), Key.OemTilde, N.TILDE),
		new KeyLight(new Vector2(-5.25f, 2), Key.D1, N.ONE),
		new KeyLight(new Vector2(-4.25f, 2), Key.D2, N.TWO),
		new KeyLight(new Vector2(-3.25f, 2), Key.D3, N.THREE),
		new KeyLight(new Vector2(-2.25f, 2), Key.D4, N.FOUR),
		new KeyLight(new Vector2(-1.25f, 2), Key.D5, N.FIVE),
		new KeyLight(new Vector2(-0.25f, 2), Key.D6, N.SIX),
		new KeyLight(new Vector2(0.75f, 2), Key.D7, N.SEVEN),
		new KeyLight(new Vector2(1.75f, 2), Key.D8, N.EIGHT),
		new KeyLight(new Vector2(2.75f, 2), Key.D9, N.NINE),
		new KeyLight(new Vector2(3.75f, 2), Key.D0, N.ZERO),
		new KeyLight(new Vector2(4.75f, 2), Key.OemMinus, N.MINUS),
		new KeyLight(new Vector2(5.75f, 2), Key.OemPlus, N.EQUALS),
		new KeyLight(new Vector2(7.25f, 2), Key.Back, N.BACKSPACE),

		new KeyLight(new Vector2(9.25f, 2), Key.Insert, N.INSERT),
		new KeyLight(new Vector2(10.25f, 2), Key.Home, N.HOME),
		new KeyLight(new Vector2(11.25f, 2), Key.PageUp, N.PAGE_UP),

		new KeyLight(new Vector2(12.75f, 2), Key.NumLock, N.NUM_LOCK),
		new KeyLight(new Vector2(13.75f, 2), Key.Divide, N.NUM_SLASH),
		new KeyLight(new Vector2(14.75f, 2), Key.Multiply, N.NUM_ASTERISK),
		new KeyLight(new Vector2(15.75f, 2), Key.Subtract, N.NUM_MINUS),

		// Row 2
		new KeyLight(new Vector2(-7.75f, 1), null, N.G_2),

		new KeyLight(new Vector2(-6, 1), Key.Tab, N.TAB),
		new KeyLight(new Vector2(-4.75f, 1), Key.Q, N.Q),
		new KeyLight(new Vector2(-3.75f, 1), Key.W, N.W),
		new KeyLight(new Vector2(-2.75f, 1), Key.E, N.E),
		new KeyLight(new Vector2(-1.75f, 1), Key.R, N.R),
		new KeyLight(new Vector2(-0.75f, 1), Key.T, N.T),
		new KeyLight(new Vector2(0.25f, 1), Key.Y, N.Y),
		new KeyLight(new Vector2(1.25f, 1), Key.U, N.U),
		new KeyLight(new Vector2(2.25f, 1), Key.I, N.I),
		new KeyLight(new Vector2(3.25f, 1), Key.O, N.O),
		new KeyLight(new Vector2(4.25f, 1), Key.P, N.P),
		new KeyLight(new Vector2(5.25f, 1), Key.OemOpenBrackets, N.OPEN_BRACKET),
		new KeyLight(new Vector2(6.25f, 1), Key.OemCloseBrackets, N.CLOSE_BRACKET),
		new KeyLight(new Vector2(7.5f, 1), Key.OemPipe, N.BACKSLASH),

		new KeyLight(new Vector2(9.25f, 1), Key.Delete, N.KEYBOARD_DELETE),
		new KeyLight(new Vector2(10.25f, 1), Key.End, N.END),
		new KeyLight(new Vector2(11.25f, 1), Key.PageDown, N.PAGE_DOWN),

		new KeyLight(new Vector2(12.75f, 1), Key.NumPad7, N.NUM_SEVEN),
		new KeyLight(new Vector2(13.75f, 1), Key.NumPad8, N.NUM_EIGHT),
		new KeyLight(new Vector2(14.75f, 1), Key.NumPad9, N.NUM_NINE),
		new KeyLight(new Vector2(15.75f, 0.5f), Key.Add, N.NUM_PLUS),

		// Row 1
		new KeyLight(new Vector2(-7.75f, 0), null, N.G_3),

		new KeyLight(new Vector2(-6, 0), Key.Escape, N.CAPS_LOCK),
		new KeyLight(new Vector2(-4.5f, 0), Key.A, N.A),
		new KeyLight(new Vector2(-3.5f, 0), Key.S, N.S),
		new KeyLight(new Vector2(-2.5f, 0), Key.D, N.D),
		new KeyLight(new Vector2(-1.5f, 0), Key.F, N.F),
		new KeyLight(new Vector2(-0.5f, 0), Key.G, N.G),
		new KeyLight(new Vector2(0.5f, 0), Key.H, N.H),
		new KeyLight(new Vector2(1.5f, 0), Key.J, N.J),
		new KeyLight(new Vector2(2.5f, 0), Key.K, N.K),
		new KeyLight(new Vector2(3.5f, 0), Key.L, N.L),
		new KeyLight(new Vector2(4.5f, 0), Key.OemSemicolon, N.SEMICOLON),
		new KeyLight(new Vector2(5.5f, 0), Key.OemQuotes, N.APOSTROPHE),
		new KeyLight(new Vector2(7.125f, 0), Key.Enter, N.ENTER),

		new KeyLight(new Vector2(12.75f, 0), Key.NumPad4, N.NUM_FOUR),
		new KeyLight(new Vector2(13.75f, 0), Key.NumPad5, N.NUM_FIVE),
		new KeyLight(new Vector2(13.75f, 0), Key.Clear, N.NUM_FIVE),
		new KeyLight(new Vector2(14.75f, 0), Key.NumPad6, N.NUM_SIX),

		// Row -1
		new KeyLight(new Vector2(-7.75f, -1), null, N.G_4),

		new KeyLight(new Vector2(-5.625f, -1), Key.LeftShift, N.LEFT_SHIFT),
		new KeyLight(new Vector2(-4, -1), Key.Z, N.Z),
		new KeyLight(new Vector2(-3, -1), Key.X, N.X),
		new KeyLight(new Vector2(-2, -1), Key.C, N.C),
		new KeyLight(new Vector2(-1, -1), Key.V, N.V),
		new KeyLight(new Vector2(0, -1), Key.B, N.B),
		new KeyLight(new Vector2(1, -1), Key.N, N.N),
		new KeyLight(new Vector2(2, -1), Key.M, N.M),
		new KeyLight(new Vector2(3, -1), Key.OemComma, N.COMMA),
		new KeyLight(new Vector2(4, -1), Key.OemPeriod, N.PERIOD),
		new KeyLight(new Vector2(5, -1), Key.OemQuestion, N.FORWARD_SLASH),
		new KeyLight(new Vector2(6.875f, -1), Key.RightShift, N.RIGHT_SHIFT),

		new KeyLight(new Vector2(10.25f, -1), Key.Up, N.ARROW_UP),

		new KeyLight(new Vector2(12.75f, -1), Key.NumPad1, N.NUM_ONE),
		new KeyLight(new Vector2(13.75f, -1), Key.NumPad2, N.NUM_TWO),
		new KeyLight(new Vector2(14.75f, -1), Key.NumPad3, N.NUM_THREE),
		new KeyLight(new Vector2(15.75f, -1.5f), null, N.NUM_ENTER),

		// Row -2
		new KeyLight(new Vector2(-7.75f, -2), null, N.G_5),

		new KeyLight(new Vector2(-6, -2), Key.LeftControl, N.LEFT_CONTROL),
		new KeyLight(new Vector2(-4.625f, -2), Key.LeftWindows, N.LEFT_WINDOWS),
		new KeyLight(new Vector2(-3.375f, -2), Key.LeftAlt, N.LEFT_ALT),
		new KeyLight(new Vector2(0.125f, -2), Key.Space, N.SPACE),
		new KeyLight(new Vector2(3.625f, -2), Key.RightAlt, N.RIGHT_ALT),
		new KeyLight(new Vector2(4.875f, -2), Key.RightWindows, N.RIGHT_WINDOWS),
		new KeyLight(new Vector2(6.125f, -2), Key.Apps, N.APPLICATION_SELECT),
		new KeyLight(new Vector2(7.5f, -2), Key.RightControl, N.RIGHT_CONTROL),

		new KeyLight(new Vector2(9.25f, -2), Key.Left, N.ARROW_LEFT),
		new KeyLight(new Vector2(10.25f, -2), Key.Down, N.ARROW_DOWN),
		new KeyLight(new Vector2(11.25f, -2), Key.Right, N.ARROW_RIGHT),

		new KeyLight(new Vector2(13.25f, -2), Key.NumPad0, N.NUM_ZERO),
		new KeyLight(new Vector2(14.75f, -2), Key.Decimal, N.NUM_PERIOD)
	};

	private static readonly List<Key> downKeys = new List<Key>();

	private static readonly List<Ripple> incomingRipples = new List<Ripple>();
	private static readonly List<Ripple> volatileRipples = new List<Ripple>();

	public static void Main(string[] args) {
		AnimationManager.onInitialise();

		register();

		AnimationManager.onAnimate();

		AnimationManager.onExit();
	}

	private static void register() {
		LowLevelKeyboardHook hook = new LowLevelKeyboardHook();

		EventHandler<KeyboardEventArgs> downLogger = (object? sender, KeyboardEventArgs data) => {
			Console.WriteLine($"v {data}");
		};
		EventHandler<KeyboardEventArgs> upLogger = (object? sender, KeyboardEventArgs data) => {
			Console.WriteLine($"^ {data}");
		};
		hook.Down += downLogger;
		hook.Up += upLogger;

		EventHandler<KeyboardEventArgs> downRippler = (object? sender, KeyboardEventArgs data) => {
			foreach (Key hookKey in data.Keys.Values) {
				foreach (KeyLight locatedKey in LOCATED_KEYS) {
					if (hookKey != locatedKey.hookKey) continue;

					if (downKeys.Contains(hookKey)) continue;

					incomingRipples.Add(
						new Ripple(
							locatedKey.location,
							ColourStream.nextColour()
						)
					);
					return;
				}
			}
		};
		hook.Down += downRippler;

		EventHandler<KeyboardEventArgs> downNonce = (object? sender, KeyboardEventArgs data) => {
			foreach (Key key in data.Keys.Values) {
				if (downKeys.Contains(key)) continue;

				downKeys.Add(key);
				Console.WriteLine($"ADD {key}");
			}
		};
		EventHandler<KeyboardEventArgs> upNonce = (object? sender, KeyboardEventArgs data) => {
			foreach (Key key in data.Keys.Values) {
				while (downKeys.Contains(key)) {
					downKeys.Remove(key);
					Console.WriteLine($"REM {key}");
				}
			}
		};
		hook.Down += downNonce;
		hook.Up += upNonce;

		hook.Start();
	}

	private static void onFrame(object? _state) {
		while (incomingRipples.Count > 0) {
			Ripple incomingRipple = incomingRipples[0];
			incomingRipples.RemoveAt(0);
			volatileRipples.Add(incomingRipple);
		}

		foreach (KeyLight locatedKey in LOCATED_KEYS) {
			Color changingColour = Color.FromArgb(
				128,
				255,
				255,
				255
			); // Faded white
			foreach (Ripple ripple in volatileRipples) {
				double distance = ripple.distanceToCircumference(locatedKey.location);

				double intensityFactor = FADE_DISTANCE - distance;
				if (intensityFactor <= 0) continue;

				double intensityInterval = intensityFactor / FADE_DISTANCE;
				if (intensityInterval <= INTENSITY_SNAP) intensityInterval = 1;
				else intensityInterval = (intensityInterval - INTENSITY_SNAP) / (1 - INTENSITY_SNAP);

				double alpha = intensityInterval * 255;
				Color frontColour = ColourUtilities.overwriteAlpha(
					ripple.colour,
					alpha
				);

				changingColour = ColourUtilities.alphaCompositeOver(
					frontColour,
					changingColour
				);
			}

			G.LogiLedSetLightingForKeyWithKeyName(
				locatedKey.lightKey,
				ColourUtilities.toAlphaPercentage(changingColour.R, changingColour.A),
				ColourUtilities.toAlphaPercentage(changingColour.G, changingColour.A),
				ColourUtilities.toAlphaPercentage(changingColour.B, changingColour.A)
			);
		}

		for (int i = volatileRipples.Count - 1; i >= 0; i--) {
			Ripple ripple = volatileRipples[i];

			ripple.radius += FRAME_RADIUS;

			// 24 width, 7.5 height
			if (ripple.radius > 30) volatileRipples.RemoveAt(i);
		}
	}
}
