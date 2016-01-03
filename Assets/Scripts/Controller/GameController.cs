using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	private BatterController batter;
	private PitcherController pitcher;
	private FieldingUIController uiController;
	
	private BaseRunners runners;

	void Awake() {
		FieldingMasterController master = FieldingMasterController.getInstance();
		batter = master.batterController;
		pitcher = master.pitcherController;
		uiController = master.UIController;
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
}
