using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject cubic;

    // Use this for initialization
    void Start () {
	    GameObject Player = GameObject.Find("Player");
        FOrce player = Player.GetComponent<FOrce>();
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void Spanwer()
    {
        GameObject Player = GameObject.Find("Player");
        FOrce player = Player.GetComponent<FOrce>();
        if (player.Cont == 10)
        {
            Instantiate(cubic, new Vector3(7f, 9.5f, 10f), Quaternion.identity);
        }
    }
}
