using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTactique : MonoBehaviour {

	public void RotationGauche()
	{
		transform.Rotate (Vector3.up, 90, Space.Self);
	}

	public void RotationDroite()
	{
		transform.Rotate (Vector3.up, -90, Space.Self);
	}

}
