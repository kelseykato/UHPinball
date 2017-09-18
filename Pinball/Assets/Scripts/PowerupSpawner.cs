using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour {

	public GameObject[] powerups;
	public GameObject ball;
	private ScoreKeeper ScoringObject;
	public Vector3 spawnValues;
	private int limit = 10;
	private GameObject token;
	internal int index; 

	// Use this for initialization
	void Start () {
		ScoringObject = GameObject.Find ("Camera").GetComponent<ScoreKeeper> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (ScoringObject.TotalScore > limit) {
			index = Random.Range (0, powerups.Length);
			token = powerups [index];
			Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (token, spawnPosition, spawnRotation);
			limit += 100;
		}
	}
		
}

