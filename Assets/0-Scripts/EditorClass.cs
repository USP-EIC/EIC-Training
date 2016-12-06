using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class EditorClass : MonoBehaviour
{

    public int Actu;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    ListElementIsStillThere();
	}

    public void ListElementIsStillThere()
    {
        if (LevelController.ThisInstance.Niveis[1].Triggers.Count < Actu)
        {
            int X = LevelController.ThisInstance.Niveis[1].Triggers.Count - Actu;
            DestroyObject(GameObject.Find("Trigger 1"));
        }
        Actu = LevelController.ThisInstance.Niveis[1].Triggers.Count;
    }
}
