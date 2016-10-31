using UnityEngine;
using System.Collections;

public class VelocitySlerp : MonoBehaviour {

		//variaveis
		public Transform Start;
		public Transform End;
		public Transform Parede;
		public float time;
		public float distance=0;
		public float Velocidade;
		public float angle;
		// Tempo de Execução
		void Update () {
			
			distance = Vector3.Distance (Parede.position, transform.position);
			
			if (distance >= 5f)
				transform.Translate (Velocidade, 0, 0, Space.World);//Movimentação antes de chegar a 20m
			if(angle < 90.0f){
				angle += Time.deltaTime;
				transform.Rotate(Mathf.Cos(angle)*Time.deltaTime,0,0);
		}
			
			if(distance >6f)
				transform.Translate (0, 0, -Velocidade, Space.World);//Continuação do movimento no sentido final da rotacao
		}
	}

