using UnityEngine;
using System.Collections;

public class Nascimento_Prefab : MonoBehaviour {

    public GameObject prefab;
    public float wait=0f;
	void Start () {
	
	}
	
	
	void Update () {
        wait += Time.deltaTime;

        if(wait >=5f)
        {
            Instantiate(prefab, transform.position, transform.rotation);
            wait = 0f;
        }

	}
}
