using UnityEngine;
using System.Collections;

public class CamContr : MonoBehaviour
{

    public GameObject Player;
    public Vector3 Pos;

	// Use this for initialization
	void Start ()
	{
	    Pos = transform.position - Player.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    transform.position = Player.transform.position + Pos;
	}
}
