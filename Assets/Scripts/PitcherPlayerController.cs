using UnityEngine;
using System.Collections;

public class PitcherPlayerController : MonoBehaviour {

	public PitcherSprite pitcher;

	public void ThrowPitch(int pitch_number) {
		pitcher.playThrowAnimation(pitch_number);
	}
}
