using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseRunners {

	private List<bool> _bases;

	public BaseRunners() {
		_bases = new List<bool>();
		_bases.Add(false);
		_bases.Add(false);
		_bases.Add(false);
	}
	
	public bool firstBase  {
		get { return _bases[0];  }
		set { _bases[0] = value; }
	}
	public bool secondBase {
		get { return _bases[1]; }
		set { _bases[1] = value; }
	}
	public bool thirdBase  {
		get { return _bases[2];  }
		set { _bases[2] = value; }
	}

	public void pushBaseRunner(bool base_runner) {
		_bases.Insert(0, base_runner);
		_bases.RemoveAt(3);
	}
}
