using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{

    
    private int CriateBomber = 2;
    private float timerBomber = 0f;

    private int CriateOnage = 6;
    private float timerOnage = 0f;
    private int CriateBat = 1;
    private float timerBat = 0f;
    public int Levl = 0;
    public int Exp = 0;
    private int NextLevel = 10;

    private int CriateVictory = 3;
    private float timerVictory = 0f;
    private int CriateGameOver = 3;
    private float timerGameOver = 0f;
    public bool Victory = false;
    public bool GameOver = false;
    private GameObject GOVictory;
    private GameObject GOGameOver;

    public Text KileText;

    private GameObject Hiro;
    // Start is called before the first frame update
    void ChekLevel()
    {
        if(Exp >= NextLevel)
        {
            //Transform Trans = Hiro.transform;
            
            switch (Levl)
            {
                case 1:
                    {
                        Destroy(Hiro);
                        Hiro = Instantiate(Resources.Load("Archer2"), new Vector3(45f, -25f, 0f), Quaternion.identity) as GameObject;
                        
                        //NextLevel += 1;
                        break;
                    }
                case 2:
                    {
                        Destroy(Hiro);
                        Hiro = Instantiate(Resources.Load("Archer3"), new Vector3(45f, -25f, 0f), Quaternion.identity) as GameObject;
                        
                        NextLevel += 20;
                        break;
                    }
                case 3:
                    {
                        Victory = true;
                        break;
                    }
                default:
                    {
                        
                        break;
                    }

            }
        }
    }
    void ChekCriateBomber()
    {
        timerBomber += Time.deltaTime;
        if (CriateBomber < timerBomber)
        {

            GameObject Bomber = Instantiate(Resources.Load("Bomber"), new Vector3(-90f, Random.Range(-10, -40), 0f), Quaternion.identity) as GameObject;
            timerBomber = 0f;
            CriateBomber = Random.Range(5, 15);
        }
    }

    void ChekCriateOnage()
    {
        timerOnage += Time.deltaTime;
        if (CriateOnage < timerOnage)
        {

            GameObject Onage = Instantiate(Resources.Load("Onager"), new Vector3(-90f, Random.Range(-10, -40), 0f), Quaternion.identity) as GameObject;
            timerOnage = 0f;
            CriateOnage = Random.Range(10, 20);
        }
    }

    void ChekCriateBat()
    {
        timerBat += Time.deltaTime;
        if (CriateBat < timerBat)
        {

            GameObject Bat = Instantiate(Resources.Load("Bat"), new Vector3(-90f, Random.Range(-10, -40), 0f), Quaternion.identity) as GameObject;
            timerBat = 0f;
            CriateBat = Random.Range(3, 10);
        }
    }
    void Start()
    {
        Hiro = Instantiate(Resources.Load("Archer1"), new Vector3(45f, -25f, 0f), Quaternion.identity) as GameObject;
        
        GameObject Tower = Instantiate(Resources.Load("Tower1"), new Vector3(100f, -25f, 0f), Quaternion.identity) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Victory)
        {
            
            ChekLevel();
            ChekCriateBomber();
            ChekCriateOnage();
            ChekCriateBat();
        }
        ChekVictory();
        ChekGameOver();
    }

    void ChekVictory()
    {
        KileText.text = "Killed mobs   " + Exp + "  from  " + NextLevel;
        if (Victory)
        {
            if(!GOVictory)
            {
                GOVictory= Instantiate(Resources.Load("Victory"), new Vector3(0f, 20f, 0f), Quaternion.identity) as GameObject;
            }
            timerVictory += Time.deltaTime;
            if (CriateVictory < timerVictory)
            {
                SceneManager.LoadScene("Start_Menu");

            }
        }
    }
    void ChekGameOver()
    {
        if (GameOver)
        {
            if (!GOGameOver)
            {
                GOGameOver = Instantiate(Resources.Load("GameOver"), new Vector3(0f, 20f, 0f), Quaternion.identity) as GameObject;
            }
            timerGameOver += Time.deltaTime;
            if (CriateGameOver < timerVictory)
            {
                SceneManager.LoadScene("Start_Menu");

            }
        }
    }
}
