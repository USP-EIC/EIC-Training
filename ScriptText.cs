using UnityEngine;
using System.Collections;

public class ScriptText : MonoBehaviour {

    public int i,a;
	void Start () {
        i = 0;
        for(i=0;i<10;i++)
        {
            a += i;
        }
        Debug.log(a);
	}
	
}
