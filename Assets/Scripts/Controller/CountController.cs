using UnityEngine;
using System.Collections;

public class CountController : MonoBehaviour {
	private Count _count;
	private CountView _view;

	void Awake() {
		_view = CountView.GetInstance();
	}

	void Start() {
		_count = new Count();
	}

	public void UpdateCount(PitchResult result) {
		switch (result.type) {
			case PitchResultType.Ball:
				_Ball();
				break;
			case PitchResultType.Strike:
				_Strike();
				break;
			case PitchResultType.Foul:
				_Foul();
				break;
		}

		_view.UpdateCount(_count);
	}

	private void _Strike() {
		_count.strikes++;
	}

	private void _Foul() {
		if (_count.strikes < 2)
			_count.strikes++;
	}

	private void _Ball() {
		_count.balls++;
	}

	public bool IsStrikeout {
		get { return (_count.strikes >= 3); }
	}

	public bool IsWalk {
		get { return (_count.balls >= 4); }
	}

	public bool IsBatterDone {
		get { return (IsStrikeout || IsWalk); }
	}

	public void ResetCount() {
		_count.balls = 0;
		_count.strikes = 0;
		_view.UpdateCount(_count);
	}

	public static CountController GetInstance() {
		return GameObject.FindGameObjectWithTag("Count Controller").GetComponent<CountController>();
	}
}
