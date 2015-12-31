using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Pitch List")]
public class PitchList : ScriptableObject {
	public Pitch[] pitches;
	
	public Pitch get(int index) {
		return pitches[index];
	}
}
