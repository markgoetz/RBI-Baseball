using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseRunners {

	private List<Character> _bases;

	public BaseRunners() {
		_bases = new List<Character>();
		_bases.Add(null);
		_bases.Add(null);
		_bases.Add(null);
	}

	public Character firstBase  {
		get { return _bases[0];  }
		set { _bases[0] = value; }
	}
	public Character secondBase {
		get { return _bases[1]; }
		set { _bases[1] = value; }
	}
	public Character thirdBase  {
		get { return _bases[2];  }
		set { _bases[2] = value; }
	}

	public void pushBaseRunner(Character base_runner) {
		_bases.Insert(0, base_runner);
		_bases.RemoveAt(3);
	}
}
