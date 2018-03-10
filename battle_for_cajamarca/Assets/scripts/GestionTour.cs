using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionTour : MonoBehaviour {


	static Dictionary<string,List<TactiqueMouvement>> units = new Dictionary<string,List<TactiqueMouvement>> ();
	static Queue<string> turnKey = new Queue<string>();
	static Queue<TactiqueMouvement> turnTeam = new Queue<TactiqueMouvement> ();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (turnTeam.Count == 0) {
			InitTeamTurnQueue ();
		}
		
	}

	static void InitTeamTurnQueue()
	{
		List<TactiqueMouvement> teamList = units [turnKey.Peek ()];

		foreach (TactiqueMouvement unit in teamList) {
			turnTeam.Enqueue (unit);
		}

		StartTurn ();
	}

	public static void StartTurn()
	{
		if (turnTeam.Count > 0) {
			turnTeam.Peek ().BeginTurn ();
		}
	}

	public static void EndTurn()
	{
		TactiqueMouvement unit = turnTeam.Dequeue ();
		unit.EndTurn ();

		if (turnTeam.Count > 0) {
			StartTurn ();
		} else {
			string team = turnKey.Dequeue ();
			turnKey.Enqueue (team);
			InitTeamTurnQueue ();
		}
	}

	public static void AddUnit(TactiqueMouvement unit)
	{
		List<TactiqueMouvement> list;

		if (!units.ContainsKey (unit.tag)) {
			list = new List<TactiqueMouvement> ();
			units [unit.tag] = list;

			if (!turnKey.Contains (unit.tag)) {
				turnKey.Enqueue (unit.tag);
			}
		} else {
			list = units [unit.tag];
		
		}
		list.Add (unit);
	}

}
