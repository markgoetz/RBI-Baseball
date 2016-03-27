using UnityEngine;
using System.Collections;

public class BatterSprite : GameCharacterSprite {
	private bool _isSwinging;

	public void PlaySwingAnimation (Vector2 swing_location) {
		_isSwinging = true;

		string swing_height;
		if (swing_location.y > .67f) {
			swing_height = "high";
		}
		else if (swing_location.y > .33f) {
			swing_height = "mid";
		}
		else {
			swing_height = "low";
		}
	
		_anim.SetTrigger ("swing" + swing_height);
	}

	// This is called through the animation.
	public void DoneSwinging() {
		_isSwinging = false;
	}

	public bool IsSwinging {
		get { return _isSwinging; }
	}
}