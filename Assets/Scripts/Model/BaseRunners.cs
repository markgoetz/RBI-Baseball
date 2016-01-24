using UnityEngine;
using System.Collections;

public class BaseRunners {

	private bool _firstBase;
	private bool _secondBase;
	private bool _thirdBase;
	
	public bool firstBase  {
		get { return _firstBase;  }
		set { _firstBase = value; }
	}
	public bool secondBase {
		get { return _secondBase; }
		set { _secondBase = value; }
	}
	public bool thirdBase  {
		get { return _thirdBase;  }
		set { _thirdBase = value; }
	}
}
