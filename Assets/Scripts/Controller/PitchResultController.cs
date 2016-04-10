using UnityEngine;
using System.Collections;

public class PitchResultController : MonoBehaviour {
	private PitchResultCalculator _calculator;
	private CountController _count;
	private BaseRunnerController _baseRunners;
	private bool _isBatterDone;
	private PitchResultView _view;
	private OutsView _outsView;

	private Character _pitcher;
	private Character _batter;

	private int _outs;

	// Use this for initialization
	void Awake () {
		_calculator = new PitchResultCalculator();
		_baseRunners = BaseRunnerController.GetInstance();
		_count = CountController.GetInstance();
		_view = PitchResultView.GetInstance();
		_outsView = OutsView.GetInstance();
	}

	public void HandleResult(Character pitcher_stats, Vector2 pitch_location, Character batter_stats, Vector2 swing_location) {
		_pitcher = pitcher_stats;
		_batter  = batter_stats;

		PitchResult result = _calculator.CalculatePitchResult(pitcher_stats, pitch_location, batter_stats, swing_location);

		_UpdateGameState(result);
		_view.DisplayResult(pitch_location, swing_location, result);
	}

	private void _UpdateGameState(PitchResult result) {
		if (result.type == PitchResultType.InPlay) {
			_isBatterDone = true;

			_outs += result.outs;
			_outsView.SetOuts(_outs);
			_AddRuns(_baseRunners.AdvanceRunners(_batter, result.basesAdvanced));

			_count.ResetCount();
		}
		else {
			_count.UpdateCount(result);
			if (_count.IsWalk) {
				_count.ResetCount();
				_AddRuns(_baseRunners.WalkRunners(_batter));
				_isBatterDone = true;
			}
			else if (_count.IsStrikeout) {
				_outs++;
				_count.ResetCount();
				_isBatterDone = true;
			}
		}
	}

	public bool IsInningOver {
		get { return _outs >= 3; }
	}

	public bool IsResultDone {
		get { return _view.IsDone; }
	}

	public bool IsBatterDone {
		get { return _isBatterDone; }
	}

	public void ResetAfterPitch() {
		_isBatterDone = false;
	}

	private void _AddRuns(int run_count) {
		return; // TODO: stub method
	}


	public static PitchResultController GetInstance() {
		return GameObject.FindGameObjectWithTag("Pitch Result Controller").GetComponent<PitchResultController>();
	}
}
