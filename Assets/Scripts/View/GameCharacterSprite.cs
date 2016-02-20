using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Animator))]
[RequireComponent (typeof(SpriteRenderer))]
public class GameCharacterSprite : MonoBehaviour {
	protected Animator _anim;
	protected SpriteRenderer _sprite;
	
	virtual protected void Awake() {
		_anim = GetComponent<Animator>();
		_sprite = GetComponent<SpriteRenderer>();
	}

	public void Fade() {
		_sprite.color = new Color(1f,1f,1f,.5f);
	}

	public void SetRunning(bool status) {
		if (status)
			_anim.speed = 1;
		else {
			_anim.speed = 0;
		}
	}
}
