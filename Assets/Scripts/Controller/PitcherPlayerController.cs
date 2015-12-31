using UnityEngine;
using System.Collections;

public class PitcherPlayerController : PitcherController {



	public override void ThrowPitch() {
		sprite.playThrowAnimation(this.currentPitch.number);
	}
}
