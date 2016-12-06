using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[CustomEditor(typeof(LevelController))]

public class InspectorCustomizer : Editor
{
    
    public static int nivel;
    public int Tipo;
    public GameObject Obj;
    public int TamListlevel;
    public int Actu;

    public override void OnInspectorGUI()   // Funcoes para Inspector customizado do LevelController
    {
        DrawDefaultInspector();

        LevelController lvlcont = (LevelController) target;
        TamListlevel = lvlcont.Niveis.Count;

        EditorGUILayout.LabelField("Para adicionar manualmente objectos trigger");
        EditorGUILayout.LabelField("utilizando a lista dropdown acima, adicione o ");
        EditorGUILayout.LabelField("script TriggerScript ao objeto");
        EditorGUILayout.LabelField(" ");

        if (GUILayout.Button("Limpar Todas Listas"))  // limpa a lista de niveis e as respectivas listas de trigger de cada nivel
        {
            lvlcont.Niveis.Clear();
        }

        EditorGUILayout.LabelField(" ");
        EditorGUILayout.LabelField("Customização por nível: ");
        EditorGUILayout.LabelField(" ");

        nivel = EditorGUILayout.IntField("Nivel: ", nivel);

        
        if (GUILayout.Button("Limpar Lista"))
        {
            if (TamListlevel < nivel)
            {
                EditorUtility.DisplayDialog("Erro", "O Nivel digitado não existe", "Ok");
            }
            else
            {
                lvlcont.Niveis[nivel].Triggers.Clear();
            }
        }

        Tipo = EditorGUILayout.IntField("Tipo de Trigger: ", Tipo);

        if (GUILayout.Button( new GUIContent("Criar Trigger","Cria Objeto Trigger baseado no prefab com tag TRIGGER em (0,0,0) e adiciona ao nível selecionado")))
        {
            if (TamListlevel < nivel)
            {
                EditorUtility.DisplayDialog("Erro", "O Nivel digitado não existe", "Ok");
            }
            else
            {
                if (GameObject.FindWithTag("TRIGGERPAI") == null)
                {
                    EditorUtility.DisplayDialog("Erro", "Não existe nenhum prefab com tag TRIGGERPAI", "Ok");
                }/*
                else if (GameObject.FindGameObjectsWithTag("TRIGGERPAI").Length > 1)
                {
                    EditorUtility.DisplayDialog("Erro", "Existe mais de um objeto com tag TRIGGER", "Ok");
                }*/
                else
                { 
                    Obj = Instantiate(GameObject.FindWithTag("TRIGGERPAI"), new Vector3(273,30,550),Quaternion.identity) as GameObject; // instancia objeto
                    Obj.name = "Trigger " + lvlcont.Niveis[nivel].Triggers.Count.ToString();   // nomeia objecto de forma ordenada numericamente
                    //Obj.gameObject.tag = "TRIGGER";
                    Obj.AddComponent<TriggerScript>();                  // adiciona triggerscript nela
                   // Obj.AddComponent<gNPC_Controller>();
                    lvlcont.Niveis[nivel].Triggers.Add(new LevelController.TriggerClass(Obj,false,Tipo));      // adiciona a lista de triggers do singleton LevelController
                    if (GameObject.FindWithTag("TRIGGER") == null)
                    {
                        GameObject Trigglist = new GameObject("TriggerList");
                        Trigglist.gameObject.tag = "TRIGGER";
                    }
                    Obj.transform.parent = GameObject.FindWithTag("TRIGGER").transform;

                }
            }
        }

        if (GUI.changed)
        {
            ListElementIsStillThere();
        }
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

    public IEnumerator CheckList(int Sec)
    {
        ListElementIsStillThere();
        yield return new WaitForSeconds(Sec);
    }
}

