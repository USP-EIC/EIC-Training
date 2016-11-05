using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public Vector3 Mov;
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    MovePlayer();
	}

    void MovePlayer()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal")*0.5f,0.0f,Input.GetAxis("Vertical")*0.5f));
    }
}
