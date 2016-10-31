using UnityEngine;
using System.Collections;

public class KillZone_Script : MonoBehaviour {

	void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
