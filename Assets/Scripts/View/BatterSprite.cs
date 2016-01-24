using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Animator))]
[RequireComponent (typeof(SpriteRenderer))]
public class BatterSprite : MonoBehaviour {
	private Animator anim;
	private SpriteRenderer sprite;
	
	void Awake() {
		anim = GetComponent<Animator>();
		sprite = GetComponent<SpriteRenderer>();
	}
	
	public void playSwingAnimation (Vector2 location) {
	
		string swing_height;
		if (location.y > .67f) {
			swing_height = "high";
		}
		else if (location.y > .33f) {
			swing_height = "mid";
		}
		else {
			swing_height = "low";
		}
	
		anim.SetTrigger ("swing" + swing_height);
	}
	
	public void Fade() {
		sprite.color = new Color(1f,1f,1f,.5f);
	}
}