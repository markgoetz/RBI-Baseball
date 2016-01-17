using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BatterSprite))]
public abstract class BatterController : MonoBehaviour {
	protected Player player_stats;
	protected BatterSprite sprite;
	
	protected Vector2 swing_location;
	
	protected bool swing_ready;
	
	public void Reset() {
		swing_ready = false;
	}

	abstract public void PromptForSwing();
	
	public bool swingReady {
		get { return swing_ready; }
	}
	
	protected void _init() {
		sprite = GetComponent<BatterSprite>();
		player_stats = new Player();
	}
	
	public void Swing() {
		sprite.playSwingAnimation(swing_location);
	}
	
	public static BatterController getInstance() {
		return GameObject.FindGameObjectWithTag("Batter Controller").GetComponent<BatterController>();
	}
}
