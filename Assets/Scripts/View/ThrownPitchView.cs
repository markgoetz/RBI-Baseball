using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class ThrownPitchView : MonoBehaviour {
	public GameObject pitchLandedIcon;
	
	private Animator anim;
	private GameObject ball;
	private SpriteRenderer sprite;
	private Bounds sprite_bounds;
	
	void Awake() {
		anim = GetComponent<Animator>();
		ball = transform.GetChild(0).gameObject;
		sprite = GetComponent<SpriteRenderer>(); 
		sprite_bounds = sprite.bounds;
	}

	public void setLocation(Vector3 location) {
		anim.SetFloat ("z", _scaleZ(location.z));
		ball.transform.localPosition = _pitchToSpritePosition(location);
	}
	
	public void showIcon() {
		Instantiate(pitchLandedIcon, ball.transform.position, Quaternion.identity);
	}
	
	private Vector2 _pitchToSpritePosition(Vector2 pitch_location) {
		Vector2 sprite_position;
		sprite_position.x = Mathf.Lerp (sprite_bounds.min.x, sprite_bounds.max.x, pitch_location.x);
		sprite_position.y = Mathf.Lerp (sprite_bounds.min.y, sprite_bounds.max.y, pitch_location.y);
		return sprite_position;
	}
	
	public void SetVisible(bool status) {
		//sprite.enabled = status;
		ball.GetComponent<SpriteRenderer>().enabled = status;
	}
	
	private float _scaleZ(float z) {
		return Mathf.Pow(z, 3);	
	}
}
