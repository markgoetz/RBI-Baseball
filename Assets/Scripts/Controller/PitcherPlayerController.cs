using UnityEngine;
using System.Collections;

public class PitcherPlayerController : PitcherController {
	public override void StartPitch() {
		sprite.playThrowAnimation(this.currentPitch.number);
	}
	
	public override void ThrowPitch() {
		ThrownPitch pitch = new ThrownPitch(currentPitch, new Vector2(.5f,.5f), pitchLocation);
		pitchedBall.Pitch = pitch;	
		pitchedBall.Prepare();	
	
		pitchedBall.SetVisible(true);	
		pitchedBall.AdvanceBy(1);
	}
	
	public override void PitchDone() {
		
	}
	
	public override void PitchAdvanced() {}
}
