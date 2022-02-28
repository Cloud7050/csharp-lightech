using H.Hooks;



using N = LedCSharp.keyboardNames;



static class LightKeyManager {
	private static readonly LightKey[] ROW_7 = new LightKey[] {
		new LightKey(new Point(-7.75, 5), null, N.G_LOGO)
	};

	private static readonly LightKey[] ROW_6 = new LightKey[] {
		new LightKey(new Point(-6.25, 3.5), Key.CapsLock, N.ESC),

		new LightKey(new Point(-4.5833, 3.5), Key.F1, N.F1),
		new LightKey(new Point(-3.5833, 3.5), Key.F2, N.F2),
		new LightKey(new Point(-2.5833, 3.5), Key.F3, N.F3),
		new LightKey(new Point(-1.5833, 3.5), Key.F4, N.F4),

		new LightKey(new Point(0.0833, 3.5), Key.F5, N.F5),
		new LightKey(new Point(1.0833, 3.5), Key.F6, N.F6),
		new LightKey(new Point(2.0833, 3.5), Key.F7, N.F7),
		new LightKey(new Point(3.0833, 3.5), Key.F8, N.F8),

		new LightKey(new Point(4.75, 3.5), Key.F9, N.F9),
		new LightKey(new Point(5.75, 3.5), Key.F10, N.F10),
		new LightKey(new Point(6.75, 3.5), Key.F11, N.F11),
		new LightKey(new Point(7.75, 3.5), Key.F12, N.F12),

		new LightKey(new Point(9.25, 3.5), Key.PrintScreen, N.PRINT_SCREEN),
		new LightKey(new Point(10.25, 3.5), Key.Scroll, N.SCROLL_LOCK),
		new LightKey(new Point(11.25, 3.5), Key.Pause, N.PAUSE_BREAK)
	};

	private static readonly LightKey[] ROW_5 = new LightKey[] {
		new LightKey(new Point(-7.75, 2), null, N.G_1),

		new LightKey(new Point(-6.25, 2), Key.OemTilde, N.TILDE),
		new LightKey(new Point(-5.25, 2), Key.D1, N.ONE),
		new LightKey(new Point(-4.25, 2), Key.D2, N.TWO),
		new LightKey(new Point(-3.25, 2), Key.D3, N.THREE),
		new LightKey(new Point(-2.25, 2), Key.D4, N.FOUR),
		new LightKey(new Point(-1.25, 2), Key.D5, N.FIVE),
		new LightKey(new Point(-0.25, 2), Key.D6, N.SIX),
		new LightKey(new Point(0.75, 2), Key.D7, N.SEVEN),
		new LightKey(new Point(1.75, 2), Key.D8, N.EIGHT),
		new LightKey(new Point(2.75, 2), Key.D9, N.NINE),
		new LightKey(new Point(3.75, 2), Key.D0, N.ZERO),
		new LightKey(new Point(4.75, 2), Key.OemMinus, N.MINUS),
		new LightKey(new Point(5.75, 2), Key.OemPlus, N.EQUALS),
		new LightKey(new Point(7.25, 2), Key.Back, N.BACKSPACE),

		new LightKey(new Point(9.25, 2), Key.Insert, N.INSERT),
		new LightKey(new Point(10.25, 2), Key.Home, N.HOME),
		new LightKey(new Point(11.25, 2), Key.PageUp, N.PAGE_UP),

		new LightKey(new Point(12.75, 2), Key.NumLock, N.NUM_LOCK),
		new LightKey(new Point(13.75, 2), Key.Divide, N.NUM_SLASH),
		new LightKey(new Point(14.75, 2), Key.Multiply, N.NUM_ASTERISK),
		new LightKey(new Point(15.75, 2), Key.Subtract, N.NUM_MINUS)
	};

	private static readonly LightKey[] ROW_4 = new LightKey[] {
		new LightKey(new Point(-7.75, 1), null, N.G_2),

		new LightKey(new Point(-6, 1), Key.Tab, N.TAB),
		new LightKey(new Point(-4.75, 1), Key.Q, N.Q),
		new LightKey(new Point(-3.75, 1), Key.W, N.W),
		new LightKey(new Point(-2.75, 1), Key.E, N.E),
		new LightKey(new Point(-1.75, 1), Key.R, N.R),
		new LightKey(new Point(-0.75, 1), Key.T, N.T),
		new LightKey(new Point(0.25, 1), Key.Y, N.Y),
		new LightKey(new Point(1.25, 1), Key.U, N.U),
		new LightKey(new Point(2.25, 1), Key.I, N.I),
		new LightKey(new Point(3.25, 1), Key.O, N.O),
		new LightKey(new Point(4.25, 1), Key.P, N.P),
		new LightKey(new Point(5.25, 1), Key.OemOpenBrackets, N.OPEN_BRACKET),
		new LightKey(new Point(6.25, 1), Key.OemCloseBrackets, N.CLOSE_BRACKET),
		new LightKey(new Point(7.5, 1), Key.OemPipe, N.BACKSLASH),

		new LightKey(new Point(9.25, 1), Key.Delete, N.KEYBOARD_DELETE),
		new LightKey(new Point(10.25, 1), Key.End, N.END),
		new LightKey(new Point(11.25, 1), Key.PageDown, N.PAGE_DOWN),

		new LightKey(new Point(12.75, 1), Key.NumPad7, N.NUM_SEVEN),
		new LightKey(new Point(13.75, 1), Key.NumPad8, N.NUM_EIGHT),
		new LightKey(new Point(14.75, 1), Key.NumPad9, N.NUM_NINE),
		new LightKey(new Point(15.75, 0.5), Key.Add, N.NUM_PLUS)
	};

	private static readonly LightKey[] ROW_3 = new LightKey[] {
		new LightKey(new Point(-7.75, 0), null, N.G_3),

		new LightKey(new Point(-6, 0), Key.Escape, N.CAPS_LOCK),
		new LightKey(new Point(-4.5, 0), Key.A, N.A),
		new LightKey(new Point(-3.5, 0), Key.S, N.S),
		new LightKey(new Point(-2.5, 0), Key.D, N.D),
		new LightKey(new Point(-1.5, 0), Key.F, N.F),
		new LightKey(new Point(-0.5, 0), Key.G, N.G),
		new LightKey(new Point(0.5, 0), Key.H, N.H),
		new LightKey(new Point(1.5, 0), Key.J, N.J),
		new LightKey(new Point(2.5, 0), Key.K, N.K),
		new LightKey(new Point(3.5, 0), Key.L, N.L),
		new LightKey(new Point(4.5, 0), Key.OemSemicolon, N.SEMICOLON),
		new LightKey(new Point(5.5, 0), Key.OemQuotes, N.APOSTROPHE),
		new LightKey(new Point(7.125, 0), Key.Enter, N.ENTER),

		new LightKey(new Point(12.75, 0), Key.NumPad4, N.NUM_FOUR),
		new LightKey(new Point(13.75, 0), Key.NumPad5, N.NUM_FIVE),
		new LightKey(new Point(13.75, 0), Key.Clear, N.NUM_FIVE),
		new LightKey(new Point(14.75, 0), Key.NumPad6, N.NUM_SIX)
	};

	private static readonly LightKey[] ROW_2 = new LightKey[] {
		new LightKey(new Point(-7.75, -1), null, N.G_4),

		new LightKey(new Point(-5.625, -1), Key.LeftShift, N.LEFT_SHIFT),
		new LightKey(new Point(-4, -1), Key.Z, N.Z),
		new LightKey(new Point(-3, -1), Key.X, N.X),
		new LightKey(new Point(-2, -1), Key.C, N.C),
		new LightKey(new Point(-1, -1), Key.V, N.V),
		new LightKey(new Point(0, -1), Key.B, N.B),
		new LightKey(new Point(1, -1), Key.N, N.N),
		new LightKey(new Point(2, -1), Key.M, N.M),
		new LightKey(new Point(3, -1), Key.OemComma, N.COMMA),
		new LightKey(new Point(4, -1), Key.OemPeriod, N.PERIOD),
		new LightKey(new Point(5, -1), Key.OemQuestion, N.FORWARD_SLASH),
		new LightKey(new Point(6.875, -1), Key.RightShift, N.RIGHT_SHIFT),

		new LightKey(new Point(10.25, -1), Key.Up, N.ARROW_UP),

		new LightKey(new Point(12.75, -1), Key.NumPad1, N.NUM_ONE),
		new LightKey(new Point(13.75, -1), Key.NumPad2, N.NUM_TWO),
		new LightKey(new Point(14.75, -1), Key.NumPad3, N.NUM_THREE),
		new LightKey(new Point(15.75, -1.5), null, N.NUM_ENTER)
	};

	private static readonly LightKey[] ROW_1 = new LightKey[] {
		new LightKey(new Point(-7.75, -2), null, N.G_5),

		new LightKey(new Point(-6, -2), Key.LeftControl, N.LEFT_CONTROL),
		new LightKey(new Point(-4.625, -2), Key.LeftWindows, N.LEFT_WINDOWS),
		new LightKey(new Point(-3.375, -2), Key.LeftAlt, N.LEFT_ALT),
		new LightKey(new Point(0.125, -2), Key.Space, N.SPACE),
		new LightKey(new Point(3.625, -2), Key.RightAlt, N.RIGHT_ALT),
		new LightKey(new Point(4.875, -2), Key.RightWindows, N.RIGHT_WINDOWS),
		new LightKey(new Point(6.125, -2), Key.Apps, N.APPLICATION_SELECT),
		new LightKey(new Point(7.5, -2), Key.RightControl, N.RIGHT_CONTROL),

		new LightKey(new Point(9.25, -2), Key.Left, N.ARROW_LEFT),
		new LightKey(new Point(10.25, -2), Key.Down, N.ARROW_DOWN),
		new LightKey(new Point(11.25, -2), Key.Right, N.ARROW_RIGHT),

		new LightKey(new Point(13.25, -2), Key.NumPad0, N.NUM_ZERO),
		new LightKey(new Point(14.75, -2), Key.Decimal, N.NUM_PERIOD)
	};

	private static readonly LightKey[] LIGHT_KEYS = ROW_1
		.Concat(ROW_2)
		.Concat(ROW_3)
		.Concat(ROW_4)
		.Concat(ROW_5)
		.Concat(ROW_6)
		.Concat(ROW_7)
		.ToArray();

	public static readonly bool CONTINUE = true;
	public static readonly bool BREAK = false;

	public static void forEachWithEventKey(Func<LightKey, bool> callback) {
		foreach (LightKey lightKey in LIGHT_KEYS) {
			if (lightKey.eventKey == null) continue;

			bool action = callback(lightKey);
			if (action == BREAK) break;
		}
	}

	//TODO Gkey loop, extracted condition
}
