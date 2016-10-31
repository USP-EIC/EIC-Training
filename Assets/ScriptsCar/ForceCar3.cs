using UnityEngine;
using System.Collections;

public class ForceCar3 : MonoBehaviour {
    //VARIAVEIS
    public float Aceleracao = 5f;
    public float Velocidade = 0f;
    public float Forca = 0;
    public Rigidbody Rb;
    public float wait=0;
    public float Distancia = 0f;
    public Sinaleiro Aux_for_Script;
        


	void Start () {

        Rb = GetComponent<Rigidbody>();
        Aux_for_Script = GetComponent<Sinaleiro>();

    }
	
	
	void Update () {

        Forca = Rb.mass * Aceleracao * Time.deltaTime;

        Velocidade += Aceleracao * Time.deltaTime;

        Rb.AddForce(Forca * Vector3.left);

        if(Velocidade <= 0.1f)
        {
            Velocidade = 0f;
            Rb.constraints = RigidbodyConstraints.FreezePosition;
            Rb.constraints = RigidbodyConstraints.FreezeRotation;
        }

	
	}
    void OnTriggerEnter(Collider other)
    {
        if(Aux_for_Script.Aux_for_Collor == 1)
        {
            Aceleracao = - 100 - Aceleracao;
        }
        if (Aux_for_Script.Aux_for_Collor == 2)
        {
            Aceleracao = 2f * Aceleracao;
        }
    }
}
