using UnityEngine;
using System.Collections;

public class Sinaleiro : MonoBehaviour {

    public GameObject Amarelo;
    public GameObject Vermelho;
    public GameObject Verde;
    public int Aux_for_Collor = 0;

    public float wait = 0f;
	
	void Start () {
	
	}

	void Update () {

        wait += Time.deltaTime;
        if(wait < 10.0f )
        {
            Vermelho.GetComponent<Renderer>().material.color = Color.red;
            Amarelo.GetComponent<Renderer>().material.color = Color.white;
            Aux_for_Collor = 1;
        }
        if(wait > 10.1f && wait <20f)
        {
            Verde.GetComponent<Renderer>().material.color = Color.green;
            Vermelho.GetComponent<Renderer>().material.color = Color.white;
            Aux_for_Collor = 2;
        }
        if(wait > 20.1f && wait < 23.1f)
        {
            Verde.GetComponent<Renderer>().material.color = Color.white;
            Amarelo.GetComponent<Renderer>().material.color = Color.yellow;
            Aux_for_Collor = 3;
        }
        if(wait >23.1f)
        {
            wait = 0;
           
        }
        
        	
	}
}
