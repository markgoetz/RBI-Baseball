using UnityEngine;
using System.Collections;

[System.Serializable]
public class Character {
	public Vector2 battingSweetSpot;
	public Vector2 pitchingSweetSpot;
	public int strength;
	public int dexterity;
	public int runSpeed;
	public int throwSpeed;
	public int perception;
	public int stamina;
	public bool isRightHanded;

	// TODO: Figure how this stat maps to the actual pitch value.  Maybe it's just a calculated stat?
	public int fastball;
	public int curveball;
	public int knuckleball;
	public int slider;


	public Character() {
		battingSweetSpot  = new Vector2(Random.value, Random.value);
		pitchingSweetSpot = new Vector2(Random.value, Random.value);

		strength    = _RollRandomStat();
		dexterity   = _RollRandomStat();
		runSpeed    = _RollRandomStat();
		throwSpeed  = _RollRandomStat();
		perception  = _RollRandomStat();
		stamina     = _RollRandomStat();

		isRightHanded = (Random.value > .5);

		fastball    = _RollRandomStat();
		curveball   = _RollRandomStat();
		knuckleball = _RollRandomStat();
		slider      = _RollRandomStat();
	}

	private int _RollRandomStat() {
		return Mathf.FloorToInt(Random.value * STAT_MAX);
	}

	public static int STAT_MAX = 100;
}
