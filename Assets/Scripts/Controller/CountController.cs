using UnityEngine;
using System.Collections;

public class CountController : MonoBehaviour {
	private Count count;

	void Start() {
		count = new Count();
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
	}

	private void _Strike() {
		count.strikes++;
	}

	private void _Foul() {
		if (count.strikes < 2)
			count.strikes++;
	}

	private void _Ball() {
		count.balls++;
	}

	public bool IsStrikeout {
		get { return (count.strikes >= 3); }
	}

	public bool IsWalk {
		get { return (count.balls >= 4); }
	}

	public bool IsBatterDone {
		get { return (IsStrikeout || IsWalk); }
	}

	public void ResetCount() {
		count.balls = 0;
		count.strikes = 0;
	}

	public static CountController GetInstance() {
		return GameObject.FindGameObjectWithTag("Count Controller").GetComponent<CountController>();
	}
}
