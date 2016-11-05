using System;
using UnityEngine;
using System.Collections;
using UnityEditorInternal;
using UnityEngine.SceneManagement;

/* ========== SISTEMA DE COMENTARIOS ============
    Comentario //: Comentario sobre codigo
    Comentario // ================ <algo> ======================: Separa seções de código de acordo com funcionalidade
    Comentario //DEACT//: Parte do código desativada
    Comentário //ADD//: Adicionar codigo no futuro
*/


public class LevelController : MonoBehaviour
{
    // ====================  VARIAVEIS =================================

    public static LevelController ThisInstance = null;

    // Agente causador (PLAYER)
    public GameObject Commt;

    // Matriz de Triggers para cada cena --- 
    public bool[,] TriggLvl1 = { { false, false, false, false }, { false, false, false, false }, { false, false, false, false } };
    public bool[,] TriggLvl2 = { { false, false, false, false }, { false, false, false, false }, { false, false, false, false } };
    public bool[,] TriggLvl3 = { { false, false, false, false }, { false, false, false, false }, { false, false, false, false } };
    public bool[,] TriggLvl4 = { { false, false, false, false }, { false, false, false, false }, { false, false, false, false } };
    public bool[,] TriggLvl5 = { { false, false, false, false }, { false, false, false, false }, { false, false, false, false } };

    // Array de contadores de triggers ativados para todas as cenas STATIC
    public static int[] ContTriggLvl = {0, 0, 0, 0, 0};

    //DEACT// public string[] Nomes;

    //Propriedades da cena atual
    public Scene SceneActu;
    public int SceneActuInd;

    // ======================= FIM VARIAVEIS //// METODOS CALLBACK MONOBEHAVIOUR =============================

    void Start()
    {
        SceneActuInd = ActualScene();
    }

    void Update()
    {
        
    }

    void Awake()
    {
        if (ThisInstance != null)
            GameObject.Destroy(gameObject);
        ThisInstance = this;
        DontDestroyOnLoad(ThisInstance);
    }

    // =============================== FIM CALLBACK //// FUNCOES GERAIS ========================================

    void DebugLogger(int cod)
    {
        switch (cod)
        {
            case 1011:
                Debug.Log("Passando para proximo nivel / Switching to next level");
                break;
            case 102:
                break;
            case 103:
                break;
            case 104:
                break;
            case 105:
                break;
        }
    }

        //====== FUNCOES DE INFO DE CENAS =================


    private int ActualScene()   // Retorna index de cena atual
    {
        SceneActu = SceneManager.GetActiveScene();
        SceneActuInd = SceneActu.buildIndex;
        return SceneActuInd;
    }

        //======= FUNCOES DE CONTROLE DE CENAS =============

    void CallNextLevel(int condition) // Chama próximo nível baseado em condição (1-Triggers insuficientes, 2-Suficiente, 3-Todos)
    {
        switch (condition)
        {
            case 1:
                //ADD// MENSAGEM (UI) -> Triggers insuficientes
                break;
            case 2:
                //ADD// MENSAGEM (UI) -> Deseja ir para proxima cena?
                //ADD// Passar para proximo nivel (ou não)
                //ADD// if passou:
                DebugLogger(1011);
                //ADD// else:
                break;
            case 3:
                //ADD// MENSAGEM (UI) -> Muito bem, você achou todos os triggers
                //ADD// Passar automaticamente
                DebugLogger(1011);
                break;
        }
    }

    //DEACT// public static void Triggerer()
    void Triggerer()   // Determina se quantidade de triggers é suficiente para mudar de nivel
    {
        int actuCont = ContTriggLvl[SceneActuInd];

        if (actuCont < 4)
        {
            CallNextLevel(1);
        }
        else if (actuCont >= 4 && actuCont < 12)
        {
            CallNextLevel(2);
        }
        else if (actuCont == 12)
        {
            CallNextLevel(3);
        }
        else
        {
            throw new Exception("Erro:\n (void Triggerer() em LevelController) Numero de triggers em actuCont nao condiz com maximo de triggers por cena");
        }
    }
    
    // ================ FIM FUNCOES GERAIS //// COROTINAS IENUMERATOR ====================
    
}
