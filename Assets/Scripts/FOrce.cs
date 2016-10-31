using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngineInternal;

public class FOrce : MonoBehaviour
{
    public GameObject cubic;
    public GameObject DaSpawn;
    public GameObject Timecube;
    public GameObject VelCube;
    public Vector3 pos;

    public int[] values = {2, 4,4, 5,5,5, 7,7,7,7,7, 9,9,9, 10};

    private Rigidbody RigB;
    public Vector3 VecMov;
    public float Vel = 10;
    public int Cont = 0;
    public Text conta;
    public Text ConDown;
    public Text fim;
    public Text MaisP;
    public Text MenosP;
    public Text Veltext;
    public float Timeinit = 30f;
    public int x = 0, aux = 0;

    public int VelSpawn = 0;
    public int Cubetime = 5;

    public bool sw = true;
    public bool sw2 = true;
    public bool MaisVel = false;

	// Use this for initialization
	void Start ()
	{
	    RigB = GetComponent<Rigidbody>();
	    ContaPickUp();
	    fim.text = "";
	    MaisP.text = "";
	    MenosP.text = "";
	    Veltext.text = "";
        InvokeRepeating("SpawnProcess",0.5f,4.0f);
        VelCubePreSpawner();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    float movH = Input.GetAxis("Horizontal");
	    float movV = Input.GetAxis("Vertical");
        VecMov = new Vector3(movH,0.0f,movV);
        RigB.AddForce(VecMov*Vel);
	    Contador();
	    if (Cont%(5+VelSpawn) == 0 && Cont != 0 && sw == true)
	    {
	        TimeCubeSpawner();
	        sw = false;
	    }
	    if (Cont%5 != 0)
	        sw = true;
	}

    //============== TRIGGER ENTER ================

    void OnTriggerEnter(Collider one)
    {
        if (one.gameObject.tag == "Cube")
        {
            Destroy(one.gameObject);
            if(sw2 == true)
                Cont++;
            ContaPickUp();
        }
        if (one.gameObject.tag == "TimeCube")
        {
            one.gameObject.SetActive(false);
            Timeinit += 10;
            MostraPickup1();
        }
        if (one.gameObject.tag == "Walls")
        {
            CollideWall(one);
        }
        if (one.gameObject.tag == "VelCube")
        {
            VelCubeGer();
        }
    }

    // ========= PICKUP ======================


    void ContaPickUp()
    {
        conta.text = "Score: " + (Cont * 10).ToString();
    }

    void MostraPickup1()
    {
        MaisP.text = "+10 seg ";
      //  pos = RandomPos();
      //  MaisP.transform.position = new Vector2(pos.x,pos.y);
        StartCoroutine(WaitText(3.0f));
    }

    IEnumerator WaitColor(float seconds, Collider one)
    {
        yield return new WaitForSeconds(seconds);
        one.GetComponent<Renderer>().material.color = Color.white;
    }

    IEnumerator WaitText(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        MaisP.text = "";
    }

    IEnumerator WaitText2(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        MenosP.text = "";
    }

    void Contador()
    {
        Timeinit -= Time.deltaTime;
        int a = (int) Timeinit;
        ConDown.text = "Time: " + a.ToString();
        if (Timeinit < 0)
        {
            fim.text = "Acabou o Tempo. Sua Pontuação foi: " + (Cont*10).ToString();
            sw2 = false;
            Application.Quit();
        }
    }

    // ================== GREEN CUBE SPAWN===================

    void SpawnProcess()
    {
        aux = x;
        x = Cont;
        if (x - aux >= 3 && MaisVel == false)
            VelSpawn++;
        for (int i = 0; i <= VelSpawn; i++)
        {
            Spawner();
        }
    }

    void Spawner()
    {
        pos = RandomPos();
        DaSpawn = Instantiate(cubic, pos, Quaternion.identity) as GameObject;
    }
    
    void TimeCubeSpawner()
    {
        pos = RandomPos();
        Timecube.transform.position = pos;
        Timecube.gameObject.SetActive(true);
       
    }

    void CollideWall(Collider one)
    {
        Timeinit -= 5;
        one.GetComponent<Renderer>().material.color = Color.gray;
        StartCoroutine(WaitColor(1,one));
        MenosP.text = "-5 seg";
        StartCoroutine(WaitText2(2));

    }
    
    
    Vector3 RandomPos()
    {
        pos = new Vector3();
        pos.x = Random.Range(-8, 8);
        pos.z = Random.Range(-8, 8);
        pos.y = 0.65f;
        return pos;
    }

    // ========== VEL CUBE ===============
    void VelCubePreSpawner()
    {
        int selected = values[Random.Range(0, values.Length)];
        StartCoroutine(WaitVelCubeStart(selected));
    }

    IEnumerator WaitVelCubeStart(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        VelCubeSpawner();
    }

    void VelCubeSpawner()
    {
        pos = RandomPos();
        VelCube.transform.position = pos;
        VelCube.gameObject.SetActive(true);
        StartCoroutine(WaitVelCubeCountdown(5));
    }

    void VelCubeGer()
    {
        VelCube.SetActive(false);
        MaisVel = true;
        Veltext.text = "Increased Speed for 6 seconds!!";
        Vel = 60;
        StartCoroutine(WaitVelCube(6));
    }

    IEnumerator WaitVelCubeCountdown(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        VelCube.gameObject.SetActive(false);
        VelCubePreSpawner();
    }

    IEnumerator WaitVelCube(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Veltext.text = "";
        Vel = 10;
        VelCube.gameObject.SetActive(false);
        MaisVel = false;
        VelCubePreSpawner();
    }

    // =================== VELCUBE END ====================
}


