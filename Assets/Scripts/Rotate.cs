using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour
{
    public Vector3 Rot = new Vector3(15,30,45);
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    transform.Rotate(Rot * Time.deltaTime);
	}
}
