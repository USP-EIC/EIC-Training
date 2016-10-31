using UnityEngine;
using System.Collections;

public class ForceCarTwo : MonoBehaviour {



        public float velocidade = 0 ;
        public float aceleracao = 5 ;
        public Rigidbody rb;
        private float force;
        public float wait = 0;
        private bool caso = true;
       



    void Start () {

        rb = GetComponent<Rigidbody>();


    }


    void Update () {
        wait += Time.deltaTime;

        force = aceleracao * rb.mass;

        velocidade += aceleracao * Time.deltaTime;

        rb.AddForce(force * Vector3.left);

        if(wait > 4f && caso == true)
        {

            aceleracao = (-1f) * aceleracao;
            caso = false;

        }
        if(wait > 20f)
        {
            rb.constraints = RigidbodyConstraints.None;
            aceleracao = 5f;
        }
        if(velocidade < 0f && wait < 29.9f)
        {
            
            rb.constraints = RigidbodyConstraints.FreezePosition;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
          
	}
}