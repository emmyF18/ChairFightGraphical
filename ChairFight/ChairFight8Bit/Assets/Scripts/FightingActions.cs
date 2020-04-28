using System.Collections;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class FightingActions : MonoBehaviour
{
    private  const  int StrahdHpMax = 110;
    private  const int RichtenHpMax = 90;
    private static int _strahdHp;
    private static int _richtenHp;
    private static int _order; // strix 1/paultin 2

    private Text pHeath;
    private Text sayings;
    private Text sHeath;
    // Start is called before the first frame update
    void Start()
    {
        _strahdHp = StrahdHpMax;
        _richtenHp = RichtenHpMax;
        SetButtons(); 
         sHeath = GameObject.Find("SHeath").GetComponent<Text>();
         pHeath = GameObject.Find("PHeath").GetComponent<Text>();
         sayings = GameObject.Find("SayingText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        pHeath.text = _strahdHp.ToString();
        sHeath.text = _richtenHp.ToString();
        if (_strahdHp < 0)
        {
            sayings.text = "Strahd Von Chairovich falls to the ground in pieces. Paultin:No, my beautiful chair!!";
            EndGame();
        }
        else if(_richtenHp < 0)
        {
            sayings.text = "Chair Richten falls to the ground in pieces. Strix: We were going to go to the big leagues!";
            EndGame();
        }
        
    }

    private void EndGame()
    {
        StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(30);
        SceneManager.LoadScene("Scenes/StartScene");
    }


    /*public void PlayerControlledFight()
    {
        string buttonName = GameObject.Find("buttonp1").name;
        string playerN = PlayerPrefs.GetString("Player");
        
        Debug.Log("player: "+ playerN);
        switch (buttonName)
        {
            case "ButtonP1":
            {
                Debug.Log("Attack1");
                if(playerN.Equals("Strix"))
                {
                    StrixKickAttack();
                }
                else
                {
                    PaultinPunch();
                }

                break;
            }
            case "ButtonP1-2":
            {
                if(playerN.Equals("Strix"))
                {
                    StrixPunchAttack();
                }
                else
                {
                    PaultinSlam();
                }
                Debug.Log("Attack2");
                break;
            }
            case "ButtonP1-3":
            {
                if(playerN.Equals("Strix"))
                {
                    StrixPanic();
                }
                else
                {
                    PaultinDrink();
                }
                Debug.Log("Attack3");
                break;
            }
        } 
    }*/

    private void SetButtons()
    {
        string playerN = PlayerPrefs.GetString("Player");
        if (playerN.Equals("Strix"))
        {
            GameObject[] buttons =GameObject.FindGameObjectsWithTag("PaultinButtons");
            foreach(var button in buttons)
            {
                button.SetActive(false);
            }
        }
        else
        {
            GameObject[] buttons =GameObject.FindGameObjectsWithTag("StrixButtons");
            foreach(var button in buttons)
            {
                button.SetActive(false);
            }
        }
    }
    
    public void StrixKickAttack()
    {
        if ((UnityEngine.Random.Range(0,100) + 1) <= 90)
        {
            //Debug.Log("attack "+ _strahdHp +" "+ _richtenHp);
            _strahdHp -= 20;
        }
        else
        {
            //Debug.Log("attack failed"+ _strahdHp +" "+ _richtenHp);
        }
        TurnSayings();
        AiAttack("Paultin");
    }

    public  void StrixPunchAttack()
    {
        if ((UnityEngine.Random.Range(0,100) + 1) <= 70)
        {
            //Debug.Log("attack"+ _strahdHp +" "+ _richtenHp);
            _strahdHp -= 40;
        }
        else
        {
            //Debug.Log("attack failed"+ _strahdHp +" "+ _richtenHp);
        }
        TurnSayings();
        AiAttack("Paultin");
    }
    public   void StrixPanic()
    {
        //Debug.Log("strixHeal"+ _strahdHp +" "+ _richtenHp);
        _richtenHp += 20;
        TurnSayings();
        AiAttack("Paultin");
        
    }

    public  void PaultinPunch()
    {
        if ((UnityEngine.Random.Range(0,100) + 1) <= 80)
        {
            _richtenHp -= 20;
            //Debug.Log("punch succeeded, -20 damage"+ _strahdHp +" "+ _richtenHp);
        }
        else
        {
            //Debug.Log("attack failed"+ _strahdHp +" "+ _richtenHp);
        }
        TurnSayings();
        AiAttack("Strix");
        
    }
    public  void PaultinSlam()
    {
        if ((UnityEngine.Random.Range(0,100) + 1) <= 60)
        {
            _richtenHp -= 40;
            //Debug.Log("punch succeded, -40 damage richten");
        }
        else
        {
            //Debug.Log("attack failed");
        }
        TurnSayings();
        AiAttack("Strix");
    }
    public  void PaultinDrink()
    {
        //Debug.Log("paultinHeal"+ _strahdHp +" "+ _richtenHp);
        _strahdHp += 20;
        TurnSayings();
        AiAttack("Strix");
    }
   private void AiAttack(String person)
   {
       int aiSelection = Random.Range(1,6);
       if (aiSelection == 1 || aiSelection == 2)
       {
           if (person.Equals("Strix"))
           {
               if ((UnityEngine.Random.Range(0,100) + 1) <= 90)
               {
                   Debug.Log("attack "+ _strahdHp +" "+ _richtenHp);
                   _strahdHp -= 20;
               }
               else
               {
                   Debug.Log("attack failed"+ _strahdHp +" "+ _richtenHp);
               }
           }
           else
           {
               if ((UnityEngine.Random.Range(0,100) + 1) <= 80)
               {
                   _richtenHp -= 20;
                   Debug.Log("punch succeeded, -20 damage"+ _strahdHp +" "+ _richtenHp);
               }
               else
               {
                   Debug.Log("attack failed"+ _strahdHp +" "+ _richtenHp);
               }
           }
       }
       else if (aiSelection == 3 || aiSelection == 4)
       {
           if (person.Equals("Strix"))
           {
               if ((UnityEngine.Random.Range(0,100) + 1) <= 70)
               {
                   Debug.Log("attack"+ _strahdHp +" "+ _richtenHp);
                   _strahdHp -= 40;
               }
               else
               {
                   Debug.Log("attack failed"+ _strahdHp +" "+ _richtenHp);
               }
           }
           else
           {
               if ((UnityEngine.Random.Range(0,100) + 1) <= 60)
               {
                   _richtenHp -= 40;
                   Debug.Log("punch succeded, -40 damage richten");
               }
               else
               {
                   Debug.Log("attack failed");
               }
           }
       }
       else
       {
           if (person.Equals("Strix"))
           {
               Debug.Log("strixHeal"+ _strahdHp +" "+ _richtenHp);
               _richtenHp += 20;
           }
           else
           {
               Debug.Log("paultinHeal"+ _strahdHp +" "+ _richtenHp);
               _strahdHp += 20;
           }
       }
   }
   
    void TurnSayings()
   {
       int turnNumber = Random.Range(1, 7);
        
        if (turnNumber == 1 || turnNumber == 2)
        {
            sayings.text ="Paultin: Chair Richten, you bastard! After this next attack you won't have a leg to stand on!";
        }
        else if (turnNumber == 3 || turnNumber == 4)
        {
            sayings.text =" Paultin: It appears your chair has not trained hard enough.";
        }
        else if (turnNumber == 5 || turnNumber == 6)
        {
            sayings.text =" Strix: Don't give up Chair Richten! We can still do this!";
        }
   }
}
