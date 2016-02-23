using UnityEngine;
using System.Collections;

public class ResultDebugController : MonoBehaviour {

	public Character pitcher;
	public Character batter;

	private Vector2 pitch_location;
	private Vector2 hit_location;

	private PitchResultController _pitchResultController;

	// Use this for initialization
	void Awake () {
		_pitchResultController = PitchResultController.GetInstance();
		pitcher = new Character();
		batter  = new Character();
	}
	

}
