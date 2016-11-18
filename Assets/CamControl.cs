using UnityEngine;
using System.Collections;

public class CamControl : MonoBehaviour {

	public Vector3 Mov1; 
	public Vector3 Mov2; 
	public Vector3 Mov3;
    public int HABA;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W)) {
			transform.Translate(Mov1, Space.Self);
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.Rotate (Mov2, Space.Self);
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.Rotate (Mov3, Space.Self);
		}
	}
}
