using UnityEngine;
using System.Collections;

public class Nascimento_Prefab : MonoBehaviour {

    public GameObject prefab;
    public float wait=0f;
    public float intervalo_nascimento = 8f;
	void Start () {
	
	}
	
	
	void Update () {
        wait += Time.deltaTime;

        if(wait >= intervalo_nascimento)
        {
            Instantiate(prefab, transform.position, transform.rotation);
            wait = 0f;
        }

	}
}
