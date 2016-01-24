using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Pitch List")]
public class PitchList : ScriptableObject {
	public Pitch[] pitches;
	
	public Pitch Get(int index) {
		return pitches[index];
	}
}
