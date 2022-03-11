using LedCSharp;



static class G {
	public static bool connect() {
		return SDK.LogiLedInitWithName("Lightech ☁");
	}

	public static void disconnect() {
		SDK.LogiLedShutdown();
	}

	public static void reconnect() {
		disconnect();
		connect();
	}

	public static bool dummyCommand() {
		return colour(
			(GKey) 7050,
			Colour.BLACK
		);
	}

	public static bool colourGlobally(
		Colour colour
	) {
		bool success = SDK.LogiLedSetLighting(
			colour.getPercentageDimmedRed(),
			colour.getPercentageDimmedGreen(),
			colour.getPercentageDimmedBlue()
		);

		if (success) LightKeyManager.notifyGlobalColour(colour);

		return success;
	}

	public static bool colour(
		GKey keyName,
		Colour colour
	) {
		return SDK.LogiLedSetLightingForKeyWithKeyName(
			keyName,
			colour.getPercentageDimmedRed(),
			colour.getPercentageDimmedGreen(),
			colour.getPercentageDimmedBlue()
		);
	}
}
