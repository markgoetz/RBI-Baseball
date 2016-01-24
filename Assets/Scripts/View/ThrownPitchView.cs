using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class ThrownPitchView : MonoBehaviour {
	public GameObject pitchLandedIcon;
	
	private Animator _anim;
	private GameObject _ball;
	private SpriteRenderer _sprite;
	private Bounds _spriteBounds;
	
	void Awake() {
		_anim = GetComponent<Animator>();
		_ball = transform.GetChild(0).gameObject;
		_sprite = GetComponent<SpriteRenderer>(); 
		_spriteBounds = _sprite.bounds;
	}

	public void setLocation(Vector3 location) {
		_anim.SetFloat ("z", _ScaleZ(location.z));
		_ball.transform.localPosition = _PitchToSpritePosition(location);
	}
	
	public void ShowIcon() {
		Instantiate(pitchLandedIcon, _ball.transform.position, Quaternion.identity);
	}
	
	private Vector2 _PitchToSpritePosition(Vector2 pitch_location) {
		Vector2 sprite_position;
		sprite_position.x = Mathf.Lerp (_spriteBounds.min.x, _spriteBounds.max.x, pitch_location.x);
		sprite_position.y = Mathf.Lerp (_spriteBounds.min.y, _spriteBounds.max.y, pitch_location.y);
		return sprite_position;
	}
	
	public void SetVisible(bool status) {
		//sprite.enabled = status;
		_ball.GetComponent<SpriteRenderer>().enabled = status;
	}
	
	private float _ScaleZ(float z) {
		return Mathf.Pow(z, 3);	
	}
}
