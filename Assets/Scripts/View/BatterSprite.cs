using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Animator))]
[RequireComponent (typeof(SpriteRenderer))]
public class BatterSprite : MonoBehaviour {
	private Animator _anim;
	private SpriteRenderer _sprite;
	
	void Awake() {
		_anim = GetComponent<Animator>();
		_sprite = GetComponent<SpriteRenderer>();
	}
	
	public void PlaySwingAnimation (Vector2 swing_location) {
	
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
	
	public void Fade() {
		_sprite.color = new Color(1f,1f,1f,.5f);
	}
}