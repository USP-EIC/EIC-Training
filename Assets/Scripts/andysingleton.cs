using UnityEngine;
using System.Collections;

public class andysingleton : MonoBehaviour
{
    public static andysingleton reference { get { return me; } }
      private static andysingleton me = null;


    void Start ()
	{
        if(reference != null)
            GameObject.Destroy(gameObject);
        me = this;
        DontDestroyOnLoad(gameObject);
	}

}
