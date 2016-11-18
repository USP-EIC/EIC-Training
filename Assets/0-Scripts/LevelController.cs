using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine.SceneManagement;

/* ========== SISTEMA DE COMENTARIOS ============
    Comentario //: Comentario sobre codigo
    Comentario // ================ <algo> ======================: Separa seções de código de acordo com funcionalidade
    Comentario //DEACT//: Parte do código desativada
    Comentário //ADD//: Adicionar codigo no futuro
    Comentário //TEMP//: Código temporário
*/


/* ========== OBSERVAÇÕES ============

*/


public class LevelController : MonoBehaviour
{
    // ====================  VARIAVEIS =================================



    // Instancia Singleton
    public static LevelController ThisInstance = null;

    // Agente causador (PLAYER)
    public GameObject Commt;
    // Agente para mudar de fase (trigger final para mudança de fase)
    public GameObject Rankeador;

    List<TriggerClass> Triggs = new List<TriggerClass>();

    // Array de gameObject de triggers
    //DEACT// public GameObject[] Triggers;

    // Array de contadores de triggers ativados para todas as cenas STATIC
    public int[] ContTriggLvl = {0, 0, 0, 0, 0};

    //Propriedades da cena atual
    public Scene SceneActu; 
    public int SceneActuInd;


    // ======================= FIM VARIAVEIS //// METODOS CALLBACK MONOBEHAVIOUR =============================



    void Start()
    {
        ActualScene(); // Atualiza status da cena atual na inicialização
        
    }

    void Update()
    {
        
    }

    void Awake()
    {
        if (ThisInstance != null)
        {
            GameObject.Destroy(gameObject);
            Logger(1071);
        }
        ThisInstance = this;
        DontDestroyOnLoad(ThisInstance);

    }

    public void OnTriggerEnterCaller(Collider other)
    {
        
    }

    public void OnLevelWasLoaded(int level)
    {
        ActualScene();
    }

    // =============================== FIM CALLBACK //// FUNCOES GERAIS ========================================




    void Logger(int cod) // Controla log e erros // código 1xxx = Log // código 2xxx = Warning código 3xxx = Erros
    {
        switch (cod)
        {
            case 1011:
                Debug.Log("Passando para proximo nivel");
                break;
            case 1021:
                Debug.Log("Trigger encontrado, ("/*+TriggerPos.x.ToString()+","+TriggerPos.y.ToString()+","+TriggerPos.z.ToString()+")"*/);
                break;
            case 1022:
                Debug.Log("Trigger não encontrado, objeto não é trigger");
                break;
            case 1023:
                Debug.Log("Trigger não pertence a Matriz, trigger é agente");
                break;
            case 1071:
                Debug.Log("Instância já existe, deletando atual");
                break;

            case 3011:
                throw new Exception("Erro:\n (void Triggerer() em LevelController) Numero de triggers em actuCont nao condiz com maximo de triggers por cena");


            default:
                Debug.Log("Código de logging inválido!");
                break;
        }
    }

        //====== FUNCOES DE INFO DE CENAS =================



    public void ActualScene()   // Atualiza index de cena atual
    {
        SceneActu = SceneManager.GetActiveScene();
        SceneActuInd = SceneActu.buildIndex;
    }

        //======= FUNCOES DE CONTROLE DE CENAS =============



    void CallNextLevel(int condition) // Chama próximo nível baseado em condição (1-Triggers insuficientes, 2-Suficiente, 3-Todos)
    {
        switch (condition)
        {
            case 1:
                //TEMP//
                Debug.Log("Triggers Insuficientes");
                UiTextOnAgent(1);
                break;
            case 2:
                //TEMP// 
                Debug.Log("Triggers suficientes, pode passar ou não");
                if(UiTextOnAgent(2)==1)
                    SceneManager.LoadScene(SceneActuInd + 1);
                    Logger(1011);
                break;
            case 3:
                //TEMP//
                Debug.Log("Todos os triggers ativados");
                UiTextOnAgent(3);
                SceneManager.LoadScene(SceneActuInd + 1);
                Logger(1011);
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
            Logger(3011);
        }
    }

    public int UiTextOnAgent(int cod) //mostra mensagem quando player entra no objeto Agente (Objeto Rankeador)
    {                                   // para o caso 2 (triggers suficientes mas não todos) retorna 1 se quser passar de nivel, 0 se quiser ficar
        switch (cod)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
        }
        return 0;
    }


        // ======== FUNCOES AUXILIARES ==========
    




    // ================ FIM FUNCOES GERAIS //// COROTINAS ====================

    
}
