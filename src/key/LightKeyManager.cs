using H.Hooks;



using N = LedCSharp.keyboardNames;



static class LightKeyManager {
	private static readonly double KEY_SIZE = 1;
	private static readonly double TAB_SIZE = KEY_SIZE * 1.5;
	private static readonly double CAPSIZE = KEY_SIZE * 1.75;
	private static readonly double LEFT_SHIFT_SIZE = KEY_SIZE * 2.25;
	private static readonly double WINDOWS_SIZE = KEY_SIZE * 1.25;
	private static readonly double SPACE_SIZE = KEY_SIZE * 5.75;
	private static readonly double RIGHT_SHIFT_SIZE = KEY_SIZE * 2.75;

	private static readonly double GAP_SIZE = KEY_SIZE / 3;
	private static readonly double FUNCTION_GAP_SIZE = (2 * KEY_SIZE) / 3;

	private static readonly LightKey[] ROW_1;
	private static readonly LightKey[] ROW_2;
	private static readonly LightKey[] ROW_3;
	private static readonly LightKey[] ROW_4;
	private static readonly LightKey[] ROW_5;
	private static readonly LightKey[] ROW_6;
	private static readonly LightKey[] ROW_7;

	private static readonly LightKey[] LIGHT_KEYS;

	public static readonly bool CONTINUE = true;
	public static readonly bool BREAK = false;

	static LightKeyManager() {
		double row1Y = KEY_SIZE / 2;
		double row2Y = row1Y + KEY_SIZE;
		double row3Y = row2Y + KEY_SIZE;
		double row4Y = row3Y + KEY_SIZE;
		double row5Y = row4Y + KEY_SIZE;
		double row6Y = row5Y + KEY_SIZE + GAP_SIZE;
		double row7Y = row6Y + KEY_SIZE + GAP_SIZE;

		double row1X = 0;
		double row2X = 0;
		double row3X = 0;
		double row4X = 0;
		double row5X = 0;
		double row6X = 0;
		double row7X = 0;

		ROW_1 = new LightKey[] {
			new LightKey(new Point(
				row1X += KEY_SIZE / 2,
				row1Y
			), null, N.G_5),

			new LightKey(new Point(
				row1X += (KEY_SIZE / 2) + GAP_SIZE + (TAB_SIZE / 2),
				row1Y
			), Key.LeftControl, N.LEFT_CONTROL),
			new LightKey(new Point(
				row1X += (TAB_SIZE / 2) + (WINDOWS_SIZE / 2),
				row1Y
			), Key.LeftWindows, N.LEFT_WINDOWS),
			new LightKey(new Point(
				row1X += WINDOWS_SIZE,
				row1Y
			), Key.LeftAlt, N.LEFT_ALT),
			new LightKey(new Point(
				row1X += (WINDOWS_SIZE / 2) + (SPACE_SIZE / 2),
				row1Y
			), Key.Space, N.SPACE),
			new LightKey(new Point(
				row1X += (SPACE_SIZE / 2) + (WINDOWS_SIZE / 2),
				row1Y
			), Key.RightAlt, N.RIGHT_ALT),
			new LightKey(new Point(
				row1X += WINDOWS_SIZE,
				row1Y
			), Key.RightWindows, N.RIGHT_WINDOWS),
			new LightKey(new Point(
				row1X += WINDOWS_SIZE,
				row1Y
			), Key.Apps, N.APPLICATION_SELECT),
			new LightKey(new Point(
				row1X += (WINDOWS_SIZE / 2) + (TAB_SIZE / 2),
				row1Y
			), Key.RightControl, N.RIGHT_CONTROL),

			new LightKey(new Point(
				row1X += (TAB_SIZE / 2) + GAP_SIZE + (KEY_SIZE / 2),
				row1Y
			), Key.Left, N.ARROW_LEFT),
			new LightKey(new Point(
				row1X += KEY_SIZE,
				row1Y
			), Key.Down, N.ARROW_DOWN),
			new LightKey(new Point(
				row1X += KEY_SIZE,
				row1Y
			), Key.Right, N.ARROW_RIGHT),

			new LightKey(new Point(
				row1X += (KEY_SIZE * 1.5) + GAP_SIZE,
				row1Y
			), Key.NumPad0, N.NUM_ZERO),
			new LightKey(new Point(
				row1X += KEY_SIZE * 1.5,
				row1Y
			), Key.Decimal, N.NUM_PERIOD),
			new LightKey(new Point(
				row1X += KEY_SIZE,
				row1Y + (KEY_SIZE / 2)
			), null, N.NUM_ENTER)
		};

		ROW_2 = new LightKey[] {
			new LightKey(new Point(
				row2X += KEY_SIZE / 2,
				row2Y
			), null, N.G_4),

			new LightKey(new Point(
				row2X += (KEY_SIZE / 2) + GAP_SIZE + (LEFT_SHIFT_SIZE / 2),
				row2Y
			), Key.LeftShift, N.LEFT_SHIFT),
			new LightKey(new Point(
				row2X += (LEFT_SHIFT_SIZE / 2) + (KEY_SIZE / 2),
				row2Y
			), Key.Z, N.Z),
			new LightKey(new Point(
				row2X += KEY_SIZE,
				row2Y
			), Key.X, N.X),
			new LightKey(new Point(
				row2X += KEY_SIZE,
				row2Y
			), Key.C, N.C),
			new LightKey(new Point(
				row2X += KEY_SIZE,
				row2Y
			), Key.V, N.V),
			new LightKey(new Point(
				row2X += KEY_SIZE,
				row2Y
			), Key.B, N.B),
			new LightKey(new Point(
				row2X += KEY_SIZE,
				row2Y
			), Key.N, N.N),
			new LightKey(new Point(
				row2X += KEY_SIZE,
				row2Y
			), Key.M, N.M),
			new LightKey(new Point(
				row2X += KEY_SIZE,
				row2Y
			), Key.OemComma, N.COMMA),
			new LightKey(new Point(
				row2X += KEY_SIZE,
				row2Y
			), Key.OemPeriod, N.PERIOD),
			new LightKey(new Point(
				row2X += KEY_SIZE,
				row2Y
			), Key.OemQuestion, N.FORWARD_SLASH),
			new LightKey(new Point(
				row2X += (KEY_SIZE / 2) + (RIGHT_SHIFT_SIZE / 2),
				row2Y
			), Key.RightShift, N.RIGHT_SHIFT),

			new LightKey(new Point(
				row2X += (RIGHT_SHIFT_SIZE / 2) + GAP_SIZE + (KEY_SIZE * 1.5),
				row2Y
			), Key.Up, N.ARROW_UP),

			new LightKey(new Point(
				row2X += (KEY_SIZE * 2) + GAP_SIZE,
				row2Y
			), Key.NumPad1, N.NUM_ONE),
			new LightKey(new Point(
				row2X += KEY_SIZE,
				row2Y
			), Key.NumPad2, N.NUM_TWO),
			new LightKey(new Point(
				row2X += KEY_SIZE,
				row2Y
			), Key.NumPad3, N.NUM_THREE)
		};

		ROW_3 = new LightKey[] {
			new LightKey(new Point(
				row3X += KEY_SIZE / 2,
				row3Y
			), null, N.G_3),

			new LightKey(new Point(
				row3X += (KEY_SIZE / 2) + GAP_SIZE + (CAPSIZE / 2),
				row3Y
			), Key.Escape, N.CAPS_LOCK),
			new LightKey(new Point(
				row3X += (CAPSIZE / 2) + (KEY_SIZE / 2),
				row3Y
			), Key.A, N.A),
			new LightKey(new Point(
				row3X += KEY_SIZE,
				row3Y
			), Key.S, N.S),
			new LightKey(new Point(
				row3X += KEY_SIZE,
				row3Y
			), Key.D, N.D),
			new LightKey(new Point(
				row3X += KEY_SIZE,
				row3Y
			), Key.F, N.F),
			new LightKey(new Point(
				row3X += KEY_SIZE,
				row3Y
			), Key.G, N.G),
			new LightKey(new Point(
				row3X += KEY_SIZE,
				row3Y
			), Key.H, N.H),
			new LightKey(new Point(
				row3X += KEY_SIZE,
				row3Y
			), Key.J, N.J),
			new LightKey(new Point(
				row3X += KEY_SIZE,
				row3Y
			), Key.K, N.K),
			new LightKey(new Point(
				row3X += KEY_SIZE,
				row3Y
			), Key.L, N.L),
			new LightKey(new Point(
				row3X += KEY_SIZE,
				row3Y
			), Key.OemSemicolon, N.SEMICOLON),
			new LightKey(new Point(
				row3X += KEY_SIZE,
				row3Y
			), Key.OemQuotes, N.APOSTROPHE),
			new LightKey(new Point(
				row3X += (KEY_SIZE / 2) + (LEFT_SHIFT_SIZE / 2),
				row3Y
			), Key.Enter, N.ENTER),

			new LightKey(new Point(
				row3X += (LEFT_SHIFT_SIZE / 2) + (GAP_SIZE * 2) + (KEY_SIZE * 3.5),
				row3Y
			), Key.NumPad4, N.NUM_FOUR),
			new LightKey(new Point(
				row3X += KEY_SIZE,
				row3Y
			), Key.NumPad5, N.NUM_FIVE),
			new LightKey(new Point(
				row3X,
				row3Y
			), Key.Clear, N.NUM_FIVE),
			new LightKey(new Point(
				row3X += KEY_SIZE,
				row3Y
			), Key.NumPad6, N.NUM_SIX),
			new LightKey(new Point(
				row3X += KEY_SIZE,
				row3Y + (KEY_SIZE / 2)
			), Key.Add, N.NUM_PLUS)
		};

		ROW_4 = new LightKey[] {
			new LightKey(new Point(
				row4X += KEY_SIZE / 2,
				row4Y
			), null, N.G_2),

			new LightKey(new Point(
				row4X += (KEY_SIZE / 2) + GAP_SIZE + (TAB_SIZE / 2),
				row4Y
			), Key.Tab, N.TAB),
			new LightKey(new Point(
				row4X += (TAB_SIZE / 2) + (KEY_SIZE / 2),
				row4Y
			), Key.Q, N.Q),
			new LightKey(new Point(
				row4X += KEY_SIZE,
				row4Y
			), Key.W, N.W),
			new LightKey(new Point(
				row4X += KEY_SIZE,
				row4Y
			), Key.E, N.E),
			new LightKey(new Point(
				row4X += KEY_SIZE,
				row4Y
			), Key.R, N.R),
			new LightKey(new Point(
				row4X += KEY_SIZE,
				row4Y
			), Key.T, N.T),
			new LightKey(new Point(
				row4X += KEY_SIZE,
				row4Y
			), Key.Y, N.Y),
			new LightKey(new Point(
				row4X += KEY_SIZE,
				row4Y
			), Key.U, N.U),
			new LightKey(new Point(
				row4X += KEY_SIZE,
				row4Y
			), Key.I, N.I),
			new LightKey(new Point(
				row4X += KEY_SIZE,
				row4Y
			), Key.O, N.O),
			new LightKey(new Point(
				row4X += KEY_SIZE,
				row4Y
			), Key.P, N.P),
			new LightKey(new Point(
				row4X += KEY_SIZE,
				row4Y
			), Key.OemOpenBrackets, N.OPEN_BRACKET),
			new LightKey(new Point(
				row4X += KEY_SIZE,
				row4Y
			), Key.OemCloseBrackets, N.CLOSE_BRACKET),
			new LightKey(new Point(
				row4X += (KEY_SIZE / 2) + (TAB_SIZE / 2),
				row4Y
			), Key.OemPipe, N.BACKSLASH),

			new LightKey(new Point(
				row4X += (TAB_SIZE / 2) + GAP_SIZE + (KEY_SIZE / 2),
				row4Y
			), Key.Delete, N.KEYBOARD_DELETE),
			new LightKey(new Point(
				row4X += KEY_SIZE,
				row4Y
			), Key.End, N.END),
			new LightKey(new Point(
				row4X += KEY_SIZE,
				row4Y
			), Key.PageDown, N.PAGE_DOWN),

			new LightKey(new Point(
				row4X += KEY_SIZE + GAP_SIZE,
				row4Y
			), Key.NumPad7, N.NUM_SEVEN),
			new LightKey(new Point(
				row4X += KEY_SIZE,
				row4Y
			), Key.NumPad8, N.NUM_EIGHT),
			new LightKey(new Point(
				row4X += KEY_SIZE,
				row4Y
			), Key.NumPad9, N.NUM_NINE)
		};

		ROW_5 = new LightKey[] {
			new LightKey(new Point(
				row5X += KEY_SIZE / 2,
				row5Y
			), null, N.G_1),

			new LightKey(new Point(
				row5X += KEY_SIZE + GAP_SIZE,
				row5Y
			), Key.OemTilde, N.TILDE),
			new LightKey(new Point(
				row5X += KEY_SIZE,
				row5Y
			), Key.D1, N.ONE),
			new LightKey(new Point(
				row5X += KEY_SIZE,
				row5Y
			), Key.D2, N.TWO),
			new LightKey(new Point(
				row5X += KEY_SIZE,
				row5Y
			), Key.D3, N.THREE),
			new LightKey(new Point(
				row5X += KEY_SIZE,
				row5Y
			), Key.D4, N.FOUR),
			new LightKey(new Point(
				row5X += KEY_SIZE,
				row5Y
			), Key.D5, N.FIVE),
			new LightKey(new Point(
				row5X += KEY_SIZE,
				row5Y
			), Key.D6, N.SIX),
			new LightKey(new Point(
				row5X += KEY_SIZE,
				row5Y
			), Key.D7, N.SEVEN),
			new LightKey(new Point(
				row5X += KEY_SIZE,
				row5Y
			), Key.D8, N.EIGHT),
			new LightKey(new Point(
				row5X += KEY_SIZE,
				row5Y
			), Key.D9, N.NINE),
			new LightKey(new Point(
				row5X += KEY_SIZE,
				row5Y
			), Key.D0, N.ZERO),
			new LightKey(new Point(
				row5X += KEY_SIZE,
				row5Y
			), Key.OemMinus, N.MINUS),
			new LightKey(new Point(
				row5X += KEY_SIZE,
				row5Y
			), Key.OemPlus, N.EQUALS),
			new LightKey(new Point(
				row5X += KEY_SIZE * 1.5,
				row5Y
			), Key.Back, N.BACKSPACE),

			new LightKey(new Point(
				row5X += (KEY_SIZE * 1.5) + GAP_SIZE,
				row5Y
			), Key.Insert, N.INSERT),
			new LightKey(new Point(
				row5X += KEY_SIZE,
				row5Y
			), Key.Home, N.HOME),
			new LightKey(new Point(
				row5X += KEY_SIZE,
				row5Y
			), Key.PageUp, N.PAGE_UP),

			new LightKey(new Point(
				row5X += KEY_SIZE + GAP_SIZE,
				row5Y
			), Key.NumLock, N.NUM_LOCK),
			new LightKey(new Point(
				row5X += KEY_SIZE,
				row5Y
			), Key.Divide, N.NUM_SLASH),
			new LightKey(new Point(
				row5X += KEY_SIZE,
				row5Y
			), Key.Multiply, N.NUM_ASTERISK),
			new LightKey(new Point(
				row5X += KEY_SIZE,
				row5Y
			), Key.Subtract, N.NUM_MINUS)
		};

		ROW_6 = new LightKey[] {
			new LightKey(new Point(
				row6X += (KEY_SIZE * 1.5) + GAP_SIZE,
				row6Y
			), Key.CapsLock, N.ESC),

			new LightKey(new Point(
				row6X += KEY_SIZE + FUNCTION_GAP_SIZE,
				row6Y
			), Key.F1, N.F1),
			new LightKey(new Point(
				row6X += KEY_SIZE,
				row6Y
			), Key.F2, N.F2),
			new LightKey(new Point(
				row6X += KEY_SIZE,
				row6Y
			), Key.F3, N.F3),
			new LightKey(new Point(
				row6X += KEY_SIZE,
				row6Y
			), Key.F4, N.F4),

			new LightKey(new Point(
				row6X += KEY_SIZE + FUNCTION_GAP_SIZE,
				row6Y
			), Key.F5, N.F5),
			new LightKey(new Point(
				row6X += KEY_SIZE,
				row6Y
			), Key.F6, N.F6),
			new LightKey(new Point(
				row6X += KEY_SIZE,
				row6Y
			), Key.F7, N.F7),
			new LightKey(new Point(
				row6X += KEY_SIZE,
				row6Y
			), Key.F8, N.F8),

			new LightKey(new Point(
				row6X += KEY_SIZE + FUNCTION_GAP_SIZE,
				row6Y
			), Key.F9, N.F9),
			new LightKey(new Point(
				row6X += KEY_SIZE,
				row6Y
			), Key.F10, N.F10),
			new LightKey(new Point(
				row6X += KEY_SIZE,
				row6Y
			), Key.F11, N.F11),
			new LightKey(new Point(
				row6X += KEY_SIZE,
				row6Y
			), Key.F12, N.F12),

			new LightKey(new Point(
				row6X += KEY_SIZE + GAP_SIZE,
				row6Y
			), Key.PrintScreen, N.PRINT_SCREEN),
			new LightKey(new Point(
				row6X += KEY_SIZE,
				row6Y
			), Key.Scroll, N.SCROLL_LOCK),
			new LightKey(new Point(
				row6X += KEY_SIZE,
				row6Y
			), Key.Pause, N.PAUSE_BREAK),

			new LightKey(new Point(
				row6X += KEY_SIZE + GAP_SIZE,
				row6Y
			), Key.MediaPreviousTrack, null, 0.5),
			new LightKey(new Point(
				row6X += KEY_SIZE,
				row6Y
			), Key.MediaPlayPause, null, 0.5),
			new LightKey(new Point(
				row6X += KEY_SIZE,
				row6Y
			), Key.MediaNextTrack, null, 0.5),
			new LightKey(new Point(
				row6X += KEY_SIZE,
				row6Y
			), Key.VolumeMute, null, 0.5)
		};

		ROW_7 = new LightKey[] {
			new LightKey(new Point(
				row7X += KEY_SIZE / 2,
				row7Y
			), null, N.G_LOGO, 1),

			new LightKey(new Point(
				row7X += (KEY_SIZE * 20.5) + (GAP_SIZE * 3),
				row7Y + (KEY_SIZE / 2)
			), Key.VolumeUp, null),
			new LightKey(new Point(
				row7X += (KEY_SIZE * 20.5) + (GAP_SIZE * 3),
				row7Y + (KEY_SIZE / 2)
			), Key.VolumeDown, null)
		};

		LIGHT_KEYS = ROW_1
			.Concat(ROW_2)
			.Concat(ROW_3)
			.Concat(ROW_4)
			.Concat(ROW_5)
			.Concat(ROW_6)
			.Concat(ROW_7)
			.ToArray();
	}

	private static void forEachCondition(
		Func<LightKey, bool> condition,
		Func<LightKey, bool> callback
	) {
		foreach (LightKey lightKey in LIGHT_KEYS) {
			if (!condition(lightKey)) continue;

			// If not callback, break
			bool action = callback(lightKey);
			if (action == BREAK) break;
		}
	}

	public static void forEachWithEventKey(Func<LightKey, bool> callback) {
		forEachCondition(
			(LightKey lightKey) => lightKey.eventKey != null,
			callback
		);
	}

	public static void forEachWithGKey(Func<LightKey, bool> callback) {
		forEachCondition(
			(LightKey lightKey) => lightKey.gKey != null,
			callback
		);
	}
}
