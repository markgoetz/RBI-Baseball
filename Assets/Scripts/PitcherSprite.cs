using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Animator))]
public class PitcherSprite : MonoBehaviour {

	private Animator anim;

	void Start () {
		anim = GetComponent<Animator>();
	}
	
	public void playThrowAnimation (int pitch_number) {
		anim.SetTrigger ("throwpitch");
	}
}
