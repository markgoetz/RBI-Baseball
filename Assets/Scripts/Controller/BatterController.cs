using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BatterSprite))]
public abstract class BatterController : MonoBehaviour {
	public GameObject batterSwingIcon;
	
	protected StrikeZoneView _strikeZoneView;
	protected Player _playerStats;
	protected BatterSprite _sprite;
	
	protected Vector2 _swingLocation;
	
	protected bool _swingReady;
	
	public void Reset() {
		_swingReady = false;
		_swingLocation = _playerStats.battingSweetSpot;
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
		_sprite.PlaySwingAnimation(_swingLocation);
		ShowIcon(_swingLocation);
	}
	
	// The time between prompts to swing.
	public float swingPromptDelay {
		get {
			return .33f;
		}
	}
	
	// The amount that the batter can adjust their swing spot by.
	// Will be influenced by stats
	protected float _swingAdjustRadius {
		get {
			return .2f;
		}
	}
	
	
	public void ShowIcon(Vector2 location) {	
		Vector2 icon_position = _strikeZoneView.StrikeZoneToWorldSpace(location);
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
					_swingLocation
			),
			.1f);
		}
		catch {
		
		}
	}
}
