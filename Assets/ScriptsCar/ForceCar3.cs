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
    public float distancia_outro_carro = 0;
        


	void Start () {

        Rb = GetComponent<Rigidbody>();
        // Pegar componente em outro script
    }
	
	
	void Update () {
        //F = m.a(t)
        Forca = Rb.mass * Aceleracao * Time.deltaTime;
        //V= v0 + a(t).t
        Velocidade += Aceleracao * Time.deltaTime * Time.deltaTime ;
        // F = -m.a(t)i 
        Rb.AddForce(Forca * Vector3.left);

       

	
	}
    void OnTriggerStay(Collider other)
    {
        Sinaleiro Aux_for_Script = other.GetComponent<Sinaleiro>();
        if (Aux_for_Script == null) return;
        // Caso seja Vermelho, alterar Aceleração para negativa
        if (Aux_for_Script.Aux_for_Collor == 1)
        {
            Aceleracao = - ((Velocidade * Velocidade) / 2 * 20);
            if (Velocidade <= -0.01f)
            {
                Velocidade = 0f;
                Aceleracao = 0f;
                Rb.constraints = RigidbodyConstraints.FreezePosition;
                Rb.constraints = RigidbodyConstraints.FreezeRotation;
            }
        }
        //Caso Amarelo, dobrar Aceleração
        if (Aux_for_Script.Aux_for_Collor  == 2)
        {
            Aceleracao = 100f;
        }
        if(Aux_for_Script.Aux_for_Collor == 3)
        {
            Aceleracao = 30f;

        }
        if (other.gameObject.tag =="Car")
        {
            distancia_outro_carro = Vector3.Distance(other.gameObject.transform.position, transform.position);
            Aceleracao =- ((Velocidade * Velocidade) / 2 * distancia_outro_carro);
        }
    }
}
