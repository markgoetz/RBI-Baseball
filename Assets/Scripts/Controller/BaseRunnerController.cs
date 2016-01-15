using UnityEngine;
using System.Collections;

public class BaseRunnerController : MonoBehaviour {

	private BaseRunners base_runners;

	// Use this for initialization
	void Awake () {
		base_runners = new BaseRunners();
	}
	
	
	
	public int AdvanceRunners(int base_count) {
		return 0;
	}
	
	public BaseRunners baseRunners {
		get { return base_runners; }
	}
	
	public static BaseRunnerController getInstance() {
		return GameObject.FindGameObjectWithTag("BaseRunners").GetComponent<BaseRunnerController>();
	}
}
