using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Animator))]
[RequireComponent (typeof(SpriteRenderer))]
public class BatterSprite : MonoBehaviour {
	
	private Animator anim;
	private SpriteRenderer sprite;
	
	void Start () {
		anim = GetComponent<Animator>();
		sprite = GetComponent<SpriteRenderer>();
	}
	
	public void Fade() {
		sprite.color = new Color(0f,0f,0f,.5f);
	}
}