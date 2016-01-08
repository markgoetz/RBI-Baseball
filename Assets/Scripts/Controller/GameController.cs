using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	private BatterController batter;
	private PitcherController pitcher;
	private FieldingUIController uiController;
	
	private BaseRunners runners;

	void Awake() {
		batter = BatterController.getInstance();
		pitcher = PitcherController.getInstance();
		uiController = FieldingUIController.getInstance();
	}
	
	public void StartPitch() {
		batter.StartPitch();
		pitcher.StartPitch();
		uiController.StartPitch();
	}

	public void PitchAdvanced() {
		batter.PitchAdvanced();
		pitcher.PitchAdvanced();
		uiController.PitchAdvanced();
	}
	
	public void PitchDone() {
		batter.PitchDone();
		pitcher.PitchDone();
		uiController.PitchDone();
	}
	
	public static GameController getInstance() {
		return GameObject.FindGameObjectWithTag("Game Controller").GetComponent<GameController>();
	}
}
