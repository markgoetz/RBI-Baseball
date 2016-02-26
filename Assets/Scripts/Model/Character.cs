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

	private static int _RollRandomStat() {
		return Mathf.FloorToInt(Random.value * STAT_MAX);
	}

	public static int STAT_MAX = 100;

	public static Character GetCharacter() {
		Character c = new Character();

		c.battingSweetSpot  = new Vector2(Random.value, Random.value);
		c.pitchingSweetSpot = new Vector2(Random.value, Random.value);

		c.strength    = _RollRandomStat();
		c.dexterity   = _RollRandomStat();
		c.runSpeed    = _RollRandomStat();
		c.throwSpeed  = _RollRandomStat();
		c.perception  = _RollRandomStat();
		c.stamina     = _RollRandomStat();

		c.isRightHanded = (Random.value > .5);

		c.fastball    = _RollRandomStat();
		c.curveball   = _RollRandomStat();
		c.knuckleball = _RollRandomStat();
		c.slider      = _RollRandomStat();

		return c;
	}
}
