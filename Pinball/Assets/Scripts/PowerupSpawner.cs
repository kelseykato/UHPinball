using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour {

	public GameObject[] powerups;
	private ScoreKeeper ScoringObject;
	public Vector3 spawnValues;
	public float limit;
	public float resetLimit;
	private GameObject token;
	internal int index;
	internal bool activePowerup;

	// Use this for initialization
	void Start () {
		ScoringObject = GameObject.Find ("Camera").GetComponent<ScoreKeeper> ();
		activePowerup = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (ScoringObject.TotalScore >= limit && !activePowerup) {
			index = Random.Range (0, powerups.Length);
			token = powerups [index];

			Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (token, spawnPosition, spawnRotation);

			limit += limit * 1.5f;
			activePowerup = true;

		} else if (ScoringObject.TotalScore >= limit && activePowerup) {
			limit += limit * 1.5f;
		}
	}

	public void ResetLimit() {
		limit = resetLimit;
		activePowerup = false;
	}
		
}

