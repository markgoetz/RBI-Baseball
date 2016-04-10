using UnityEngine;
using System.Collections;

public class BaseRunnerController : MonoBehaviour {
	public bool isPlayer;

	private BaseRunnerView _view;
	private BaseRunners _baseRunners;

	// Use this for initialization
	void Awake () {
		_baseRunners = new BaseRunners();
		_view = BaseRunnerView.GetInstance();
	}
	
	void Start() {
		_view.SetIsPlayer(isPlayer);
		_view.UpdateView(_baseRunners);
	}

	// AdvanceRunners - update the current state of base runners when there's a hit.  Do not use this on a walk.
	// int base_count - the number of bases that each runner advances.  For instance, if it's a double, base_count should be 2.
	// return value: the number of runners that scored.
	public int AdvanceRunners(int base_count) {
		int runs = 0;

		for (int i = 0; i < base_count; i++) {
			if (_baseRunners.thirdBase) runs++;

			// This will result in a "true" on the base that the batter arrived at, and a "false" at all prior bases.
			_baseRunners.pushBaseRunner((i == 0));
		}

		_view.UpdateView(_baseRunners);
		return runs;
	}

	// WalkRunners - update the current state of the base runners when there is a walk.  Do not use this on a hit.
	// return value: the number of runners that scored.
	public int WalkRunners() {
		int runs = 0;

		if (!_baseRunners.firstBase) {
			_baseRunners.firstBase = true;
			return 0;
		}

		else if (!_baseRunners.secondBase) {
			_baseRunners.secondBase = true;
			return 0;
		}

		else if (!_baseRunners.thirdBase) {
			_baseRunners.thirdBase = true;
			return 0;
		}

		else {
			return 1;
		}
	}
	
	public BaseRunners baseRunners {
		get { return _baseRunners; }
	}
	
	public static BaseRunnerController GetInstance() {
		return GameObject.FindGameObjectWithTag("BaseRunners").GetComponent<BaseRunnerController>();
	}
}
