using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BatterSprite))]
public abstract class BatterController : MonoBehaviour {
	public GameObject batterSwingIcon;
	
	protected StrikeZoneView _strikeZoneView;
	protected Player _playerStats;
	protected BatterSprite _sprite;
	
	private Vector2 _swingLocation;
		
	protected bool _swingReady;
	
	public void Reset() {
		_swingReady = false;
		swingLocation = _playerStats.battingSweetSpot;
	}

	abstract public void PromptForSwing();
	
	public void SetUnready() {
		_swingReady = false;
	}
	
	public bool swingReady {
		get { return _swingReady; }
	}
	
	protected void _Init() {
		_sprite = GetComponent<BatterSprite>();
		_playerStats = new Player();
		_strikeZoneView = StrikeZoneView.GetInstance();
	}
	
	public void Swing() {
		_sprite.PlaySwingAnimation(swingLocation);
		ShowIcon(swingLocation);
	}
	
	// The time between prompts to swing.
	// Will be influenced by stats
	public float swingPromptDelay {
		get {
			return .33f;
		}
	}
	
	// The amount that the batter can adjust their swing spot by.
	// Will be influenced by stats
	public float swingAdjustRadius {
		get {
			return .2f;
		}
	}
	
	public Vector2 swingLocation {
		get { return _swingLocation; }
		set {
			_swingLocation = value;
			_swingReady = true;
		}
	}
	
	
	public bool isInsideRadius(Vector2 strike_zone_location) {
		return (strike_zone_location - swingLocation).magnitude <= swingAdjustRadius;
	}
	
	
	public void ShowIcon(Vector2 strike_zone_location) {	
		Vector2 icon_position = _strikeZoneView.StrikeZoneToWorldSpace(strike_zone_location);
		Instantiate(batterSwingIcon, icon_position, Quaternion.identity);
	}
	
	public static BatterController GetInstance() {
		return GameObject.FindGameObjectWithTag("Batter Controller").GetComponent<BatterController>();
	}
	
	void OnDrawGizmos() {
		try {
		
			Gizmos.color = Color.magenta;
			Gizmos.DrawSphere(
				_strikeZoneView.StrikeZoneToWorldSpace(
					swingLocation
			),
			.1f);
		}
		catch {
		
		}
	}
}
