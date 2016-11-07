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


/* ========== OBSERVAÇÕES ============

*/


public class LevelController : MonoBehaviour
{
    // ====================  VARIAVEIS =================================

    public static LevelController ThisInstance = null;

    // Agente causador (PLAYER)
    public GameObject Commt;

    // Matriz de Triggers para cada cena // [X,Y,Z] // X = Level // Y = Categoria // Z = Trigger
    public bool[,,] Trigg = 
    {
        { { false, false, false, false }, { false, false, false, false }, { false, false, false, false } },
        { { false, false, false, false }, { false, false, false, false }, { false, false, false, false } },
        { { false, false, false, false }, { false, false, false, false }, { false, false, false, false } },
        { { false, false, false, false }, { false, false, false, false }, { false, false, false, false } },
        { { false, false, false, false }, { false, false, false, false }, { false, false, false, false } }
    };
      
    // Array de contadores de triggers ativados para todas as cenas STATIC
    public static int[] ContTriggLvl = {0, 0, 0, 0, 0};

    // Matriz de nome dos triggerBoxes para detecção de colisão // [X,Y,Z] // X = Level // Y = Categoria // Z = Trigger
    public static string[,,] TriggerName =
    {
        { { "A1", "A2", "A3", "A4" }, { "B1", "B2", "B3", "B4" }, { "C1", "C2", "C3", "C4" } },
        { { "A1", "A2", "A3", "A4" }, { "B1", "B2", "B3", "B4" }, { "C1", "C2", "C3", "C4" } },
        { { "A1", "A2", "A3", "A4" }, { "B1", "B2", "B3", "B4" }, { "C1", "C2", "C3", "C4" } },
        { { "A1", "A2", "A3", "A4" }, { "B1", "B2", "B3", "B4" }, { "C1", "C2", "C3", "C4" } },
        { { "A1", "A2", "A3", "A4" }, { "B1", "B2", "B3", "B4" }, { "C1", "C2", "C3", "C4" } }
    };

    //DEACT// public static string[] TriggerNames;//DEACT// = {TriggerNameLvl1,TriggerNameLvl2,TriggerNameLvl3};

    //DEACT// Vector3 TriggerPos = new Vector3(0, 0, 0);

    // Vector3 para armazenar uma posição de trigger a ser usada nas matrizes acima
    public Vector3 TriggerPos; 

    //Propriedades da cena atual
    public Scene SceneActu; 
    public int SceneActuInd;

        // ============== DELEGATES ===============

    public delegate void ChangeScene(); // delegate para evento DetectSceneChanged

        // ============== EVENTOS ==================

    public static event ChangeScene DetectSceneChanged;

    // ======================= FIM VARIAVEIS //// METODOS CALLBACK MONOBEHAVIOUR =============================

    void Start()
    {
        ActualScene(); // Atualiza status da cena atual na inicialização

        if (DetectSceneChanged != null)
        {
            DetectSceneChanged += ActualScene; // subscreve evento para atualizar status da cena atual ao mudar de cena
        }
        else
        {
            Debug.LogWarning("Evento DetectSceneChanged é null");
        }
    }

    void Update()
    {
        
    }

    void Awake()
    {
        if (ThisInstance != null)
        {
            GameObject.Destroy(gameObject);
            Debug.LogWarning("Instância já existe, deletando atual",ThisInstance);
        }
        ThisInstance = this;
        DontDestroyOnLoad(ThisInstance);
    }

    void OnTriggerEnter(Collider one)
    {

        TriggerPos = FindTrigger(one);
        ActivateTrigger(TriggerPos);

    }

    // =============================== FIM CALLBACK //// FUNCOES GERAIS ========================================

    void Logger(int cod) // Controla log e erros // código 1xxx = Log // código 3xxx = Erros
    {
        switch (cod)
        {
            case 1011:
                Debug.Log("Passando para proximo nivel");
                break;
            case 1021:
                Debug.Log("Trigger encontrado, ("+TriggerPos.x.ToString()+","+TriggerPos.y.ToString()+","+TriggerPos.z.ToString()+")");
                break;
            case 1022:
                Debug.Log("Trigger não encontrado, objeto não é trigger");
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

    Vector3 FindTrigger(Collider one) // encontra qual trigger foi ativado e retorna Vector3 com as coordenadas
    {
        TriggerPos = new Vector3(0, 0, 0);
        foreach (string currentName in TriggerName)
        {
            if (currentName == one.gameObject.name)
            {
                Logger(1021);
                return TriggerPos;
            }
            TriggerPos.z++;
            if ((int)TriggerPos.z == 5)
            {
                TriggerPos.z = 0;
                TriggerPos.y++;
            }
            if ((int)TriggerPos.y == 4)
            {
                TriggerPos.y = 0;
                TriggerPos.x++;
            }
        }
        Logger(1022);
        return new Vector3(-1,-1,-1);
    }

    void ActivateTrigger(Vector3 pos) // Ativa o trigger da posição pos
    {
        Trigg[(int)pos.x,(int)pos.y,(int)pos.z] = true;
        ContTriggLvl[SceneActuInd]++;
    }

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
                Logger(1011);
                //ADD// else:
                break;
            case 3:
                //ADD// MENSAGEM (UI) -> Muito bem, você achou todos os triggers
                //ADD// Passar automaticamente
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

        // ======== FUNCOES AUXILIARES ==========
    
    // ================ FIM FUNCOES GERAIS //// COROTINAS ====================

    
}
