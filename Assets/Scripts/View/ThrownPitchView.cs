using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class ThrownPitchView : MonoBehaviour {
	public GameObject pitchLandedIcon;
	
	public bool DEBUGShowPerspective;
	
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
	
	void Start() {
		SetVisible(false);
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
		
		float location_x = pitch_location.x;
		float location_y = pitch_location.y;
		
		// Do not use Mathf.Lerp because it clamps to the edge of the strike zone.
		sprite_position.x = location_x * _spriteBounds.max.x + (1-location_x) * _spriteBounds.min.x;
		sprite_position.y = location_y * _spriteBounds.max.y + (1-location_y) * _spriteBounds.min.y;
		
		return sprite_position;
	}
	
	public void SetVisible(bool status) {
		//sprite.enabled = status;
		_ball.GetComponent<SpriteRenderer>().enabled = status;
	}
	
	private float _ScaleZ(float z) {
		if (DEBUGShowPerspective)
			return Mathf.Pow (z, 3);
		else
			return 1;
	}
}
