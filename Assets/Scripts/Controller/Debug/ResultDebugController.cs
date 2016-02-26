using UnityEngine;
using System.Collections;

public class ResultDebugController : MonoBehaviour {

	public Character pitcher;
	public Character batter;

	private ResultDebugUIController _uiController;

	private PitchResultController _pitchResultController;

	// Use this for initialization
	void Awake () {
		_pitchResultController = PitchResultController.GetInstance();
		_uiController = ResultDebugUIController.GetInstance() as ResultDebugUIController;
		pitcher = Character.GetCharacter();
		batter  = Character.GetCharacter();
	}

	void Start() {
		StartCoroutine(GameLoop());
	}
	
	private IEnumerator GameLoop() {
		while (true) {
			while (!_uiController.resultReady) {
				yield return null;
			}

			Vector2 location = _pitchResultController.GetHitVector(
				pitcher,
				_uiController.pitchLocation,
				batter,
				_uiController.swingLocation
			);

			// TODO: Display the vector.
			Debug.Log(location);

			_uiController.DisplayResult(location);

			while (!_uiController.resultDone) {
				yield return null;
			}

			_uiController.Clear();
		}
	}
}
