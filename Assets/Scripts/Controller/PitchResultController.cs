using UnityEngine;
using System.Collections;

public class PitchResultController : MonoBehaviour {
	private PitchResultCalculator _calculator;
	private CountController _count;
	private BaseRunnerController _baseRunners;
	private bool _isDone;
	private bool _isBatterDone;

	private int _outs;

	// Use this for initialization
	void Awake () {
		_calculator = new PitchResultCalculator();
		_baseRunners = BaseRunnerController.GetInstance();
		_count = CountController.GetInstance();
	}

	public void HandleResult(Character pitcher_stats, Vector2 pitch_location, Character batter_stats, Vector2 swing_location) {
		PitchResult result = _calculator.CalculatePitchResult(pitcher_stats, pitch_location, batter_stats, swing_location);

		_UpdateGameState(result);
		_DisplayResult(result);
	}

	private void _UpdateGameState(PitchResult result) {
		if (result.type == PitchResultType.InPlay) {
			_isBatterDone = true;

			_outs += result.outs;
			_AddRuns(_baseRunners.AdvanceRunners(result.basesAdvanced));

			_count.ResetCount();
		}
		else {
			_count.UpdateCount(result);
			if (_count.IsWalk) {
				_count.ResetCount();
				_AddRuns(_baseRunners.AdvanceRunners(1));
				_isBatterDone = true;
			}
			else if (_count.IsStrikeout) {
				_outs++;
				_count.ResetCount();
				_isBatterDone = true;
			}
		}
	}

	private void _DisplayResult(PitchResult result) {
		// TODO: Implement the views
		_isDone = true;
	}

	public bool IsInningOver {
		get { return _outs >= 3; }
	}

	public bool IsDone {
		get { return _isDone; }
	}

	public bool IsBatterDone {
		get { return _isBatterDone; }
	}

	public void Reset() {
		_isBatterDone = false;
		_isDone = false;
	}

	private void _AddRuns(int run_count) {
		return; // TODO: stub method
	}


	public static PitchResultController GetInstance() {
		return GameObject.FindGameObjectWithTag("Pitch Result Controller").GetComponent<PitchResultController>();
	}
}
