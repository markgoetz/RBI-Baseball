using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Animator))]
[RequireComponent (typeof(SpriteRenderer))]
public class PitcherSprite : MonoBehaviour {

	private Animator anim;
	private SpriteRenderer sprite;

	void Start () {
		anim = GetComponent<Animator>();
		sprite = GetComponent<SpriteRenderer>();
	}
	
	public void playThrowAnimation (int pitch_number) {
		anim.SetTrigger ("throwpitch" + pitch_number);
	}
	
	public void Fade() {
		sprite.color = new Color(0f,0f,0f,.5f);
	}
}
