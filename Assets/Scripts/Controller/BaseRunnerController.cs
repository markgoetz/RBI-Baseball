using UnityEngine;
using System.Collections;

public class BaseRunnerController : MonoBehaviour {

	private BaseRunners _baseRunners;

	// Use this for initialization
	void Awake () {
		_baseRunners = new BaseRunners();
	}
	
	
	
	public int AdvanceRunners(int base_count) {
		return 0;
	}
	
	public BaseRunners baseRunners {
		get { return _baseRunners; }
	}
	
	public static BaseRunnerController GetInstance() {
		return GameObject.FindGameObjectWithTag("BaseRunners").GetComponent<BaseRunnerController>();
	}
}
