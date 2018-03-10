﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCmove : TactiqueMouvement {

	GameObject target;

	// Use this for initialization
	void Start () {
		Init ();
	}
	
	// Update is called once per frame
	void Update () {

		if (!turn) {
			return;
		}

		if (!moving) {
			FindNearestTarget ();
			CalculatePath ();
			FindSelectableTiles ();
			actualTargetTile.target = true;

		} else {
			//deplacement
			Move();
		}
	}

	void CalculatePath()
	{
		Tile targetTile = GetTargetTile (target);
		FindPath (targetTile);


	}

	void FindNearestTarget()
	{
		GameObject[] targets = GameObject.FindGameObjectsWithTag("Player");

		GameObject nearest = null;
		float distance = Mathf.Infinity;

		foreach (GameObject obj in targets) {
			float d = Vector3.Distance (transform.position, obj.transform.position);

			if (d < distance) {
				distance = d;
				nearest = obj;
			}
		}

		target = nearest;

	}

}
