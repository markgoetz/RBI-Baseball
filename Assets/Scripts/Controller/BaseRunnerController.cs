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
	
	public int AdvanceRunners(int base_count) {
		_view.UpdateView(_baseRunners);
		return 0;
	}
	
	public BaseRunners baseRunners {
		get { return _baseRunners; }
	}
	
	public static BaseRunnerController GetInstance() {
		return GameObject.FindGameObjectWithTag("BaseRunners").GetComponent<BaseRunnerController>();
	}
}
