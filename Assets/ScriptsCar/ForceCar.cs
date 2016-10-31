using UnityEngine;
using System.Collections;

public class ForceCar : MonoBehaviour {

    //VARIAVEIS

    public float Force = 5f;     //Força de atuação no Carro
    public float aceleracao = 0;      //Aceleração
    public float velocidade = 0;    //Velocidade do carro
    public Rigidbody Rb;    //Rigidbody para aplicar a força
    public float wait = 0;
    public float aux = 0;
    public bool sw = true;

    void Start() {
        Rb = GetComponent<Rigidbody>();
       
    }

    void Update() {
        wait += Time.deltaTime;
       // aceleracao = Force / Rb.mass; // F = m . a -> a = F/m
       // velocidade += aceleracao * Time.deltaTime;  // v = v0 + a.t -> v0 = 0 -> v = a.t
       //  Rb.AddForce(Force * Vector3.left); // 10f . (-1,0,0) = (-10f,0,0) -> F = -10i
        if (wait < 2.9f)
        {
            aceleracao = Force / Rb.mass;
            aceleracao *= Time.deltaTime;                                // F = m . a -> a = F/m
            velocidade += aceleracao * Time.deltaTime;  // v = v0 + a.t -> v0 = 0 -> v = a.t
            Rb.AddForce(Force * Vector3.left); // 10f . (-1,0,0) = (-10f,0,0) -> F = -10i
        }
        if(wait>3.0f)
        {
            aux = velocidade * Time.deltaTime ;
            Rb.AddForce(-Force * Vector3.left);
            velocidade = aux - (Force / Rb.mass) ;
            velocidade *= Time.deltaTime;
        }

        /* EXEMPLO */

        /* 
         * massa = 1kg 
         * força = 10N . (-1) Sentido Negativo  = -10i
         * a = -10/1 = -10 
         * v += 10 * deltaT
         * Caso Toque no Trigger do Script FaixaPare
         * forca = -10 * (-1,0,0) = (10,0,0) = 10i
         * a = 10/1
         * v += 10 , diminuindo o valor da velocidade a medida que a porca é aplicada
         * Quando chega a 0
         * Carro para       
         */
}
    void velo()
    {
        aux = velocidade;
        sw = false;
    }
}

