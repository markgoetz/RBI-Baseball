using UnityEngine;
using System.Collections;

public class BaseRunners {

	private bool firstBase;
	private bool secondBase;
	private bool thirdBase;
	
	// Move the baserunners forward this many bases
	// return the number of runs scored
	public int Advance(int base_count) {
		return 0;
	}
	
	public bool FirstBase  { get { return firstBase;  } }
	public bool SecondBase { get { return secondBase; } }
	public bool ThirdBase  { get { return thirdBase;  } }
}
