using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Animator))]
[RequireComponent (typeof(SpriteRenderer))]
public class PitcherSprite : MonoBehaviour {

	private Animator _anim;
	private SpriteRenderer _sprite;
	private PitcherController _controller;

	void Awake () {
		_anim = GetComponent<Animator>();
		_sprite = GetComponent<SpriteRenderer>();
		_controller = PitcherController.GetInstance();
	}
	
	public void PlayThrowAnimation (int pitch_number) {
		// TODO: Possibly set different animations depending on pitch location and type
		_anim.SetTrigger ("throwpitch");
	}
	
	public void Fade() {
		_sprite.color = new Color(1f,1f,1f,.5f);
	}
	
	public void SpawnPitchTrigger() {
		_controller.SpawnPitch();
	}
}
