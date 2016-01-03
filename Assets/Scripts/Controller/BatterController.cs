using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BatterSprite))]
public abstract class BatterController : MonoBehaviour {
	abstract public void PitchAdvanced();
	abstract public void PitchDone();
}
