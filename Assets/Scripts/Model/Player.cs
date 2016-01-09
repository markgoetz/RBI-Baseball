using UnityEngine;
using System.Collections;

public class Player {
	public Vector2 battingSweetSpot;
	public Vector2 pitchingSweetSpot;
	
	public Player() {
		battingSweetSpot  = new Vector2(Random.value, Random.value);
		pitchingSweetSpot = new Vector2(Random.value, Random.value);
	}
}
