public class PitchResult {
	public PitchResultType type;
	public int outs;
	public int basesAdvanced;
	public BallHit hit;
}

public enum PitchResultType {
	Strike,
	Ball,
	Foul,
	InPlay
}