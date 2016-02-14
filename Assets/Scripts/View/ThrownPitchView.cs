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
	
	private ParticleSystem _ballTrail;
	private SpriteRenderer _ballSprite;
	
	void Awake() {
		_anim = GetComponent<Animator>();
		_ball = transform.GetChild(0).gameObject;
		
		_ballTrail = _ball.GetComponent<ParticleSystem>();
		_ballSprite = _ball.GetComponent<SpriteRenderer>();
		
		_sprite = GetComponent<SpriteRenderer>(); 
		_spriteBounds = _sprite.bounds;
	}
	
	void Start() {
		SetVisible(false);
	}

	public void setLocation(Vector3 location) {
		_anim.SetFloat ("z", _ScaleZ(location.z));
		_ball.transform.localPosition = _PitchToSpritePosition(location);
		_ballTrail.startSize = _ScaleZ(location.z) * .5f;
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
		_ballSprite.enabled = status;
		
		if (status) {
			_ballTrail.Play();
		}
		else {
			_ballTrail.Clear (true);
			_ballTrail.Stop();
		}
		
	}
	
	public void Pause() {
		_ballTrail.Pause(true);
	}
	
	public void Unpause() {
		_ballTrail.Play (true);
	}
	
	private float _ScaleZ(float z) {
		if (DEBUGShowPerspective)
			return Mathf.Pow (z, 3);
		else
			return 1;
	}
}
