using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Animator))]
[RequireComponent (typeof(SpriteRenderer))]
public class PitcherSprite : MonoBehaviour {

	private Animator anim;
	private SpriteRenderer sprite;
	private PitcherController controller;

	void Start () {
		anim = GetComponent<Animator>();
		sprite = GetComponent<SpriteRenderer>();
		
		FieldingMasterController master = FieldingMasterController.getInstance();
		controller = master.pitcherController;
	}
	
	public void playThrowAnimation (int pitch_number) {
		// TODO: Possibly set different animations depending on pitch location and type
		anim.SetTrigger ("throwpitch");
	}
	
	public void Fade() {
		sprite.color = new Color(0f,0f,0f,.5f);
	}
	
	public void ThrowPitchTrigger() {
		controller.ThrowPitch();
	}
	
	public GameObject ReleasePoint {
		get {
			Transform child = transform.GetChild (0) as Transform;
			return child.gameObject;
		}
	}
}
