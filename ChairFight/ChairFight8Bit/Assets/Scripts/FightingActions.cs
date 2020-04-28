using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class FightingActions : MonoBehaviour
{
    private  const  int strahdHPMax = 110;
    private  const int richtenHPMax = 90;
    //private static readonly UnityEngine.Random rand = new UnityEngine.Random();
    private static int strahdHP;
    private static int richtenHP;
    private static int order; // strix 1/paultin 2
    // Start is called before the first frame update
    void Start()
    {
        strahdHP = strahdHPMax;
        richtenHP = richtenHPMax;
        SetButtons();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (strahdHP < 0)
        {
            //GUI.Label(new Rect(10, 10, 100, 20),
                //"Strahd Von Chairovich falls to the ground in pieces. Paultin:No, my beautiful chair!!");
            endGame();
        }
        else if(richtenHP < 0)
        {
            //GUI.Label(new Rect(10, 10, 100, 20), 
               // "Chair Richten falls to the ground in pieces \n Strix: We were going to go to the big leagues!");
            endGame();
        }
        
    }

    private void endGame()
    {
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
            strahdHP -= 20;
        }
        else
        {
            Debug.Log("attack failed"+ strahdHP +" "+ richtenHP);
        }
        AiAttack("Paultin");
    }

    public  void StrixPunchAttack()
    {

        if ((UnityEngine.Random.Range(0,100) + 1) <= 70)
        {
            strahdHP -= 40;
        }
        else
        {
            Debug.Log("attack failed"+ strahdHP +" "+ richtenHP);
        }
        AiAttack("Paultin");

    }

   public   void StrixPanic()
    {
        Debug.Log("strixHeal"+ strahdHP +" "+ richtenHP);
        richtenHP += 20;
        AiAttack("Paultin");
    }

    public  void PaultinPunch()
    {
        if ((UnityEngine.Random.Range(0,100) + 1) <= 80)
        {
            richtenHP -= 20;
            Debug.Log("punch succeeded, -20 damage"+ strahdHP +" "+ richtenHP);
        }
        else
        {
            Debug.Log("attack failed"+ strahdHP +" "+ richtenHP);
        }
        AiAttack("Strix");
        
    }

   public  void PaultinSlam()
    {
        
        if ((UnityEngine.Random.Range(0,100) + 1) <= 60)
        {
            richtenHP -= 40;
            Debug.Log("punch succeded, -40 damage richten");
        }
        else
        {
            Debug.Log("attack failed");
        }
        AiAttack("Strix");

    }

   private void AiAttack(String person)
   {
       int aiSelection = Random.Range(1,6);
       if (aiSelection == 1 || aiSelection == 2)
       {
           if (person.Equals("Strix"))
           {
               StrixKickAttack();
           }
           else
           {
               PaultinPunch();
           }
       }
       else if (aiSelection == 3 || aiSelection == 4)
       {
           if (person.Equals("Strix"))
           {
               StrixPunchAttack();
           }
           else
           {
               PaultinSlam();
           }
       }
       else
       {
           if (person.Equals("Strix"))
           {
               StrixPanic();
           }
           else
           {
               PaultinDrink();
           }
       }
   }

   public  void PaultinDrink()
    {
        //Console.WriteLine("Paultin uses I need a drink. \n Paultin leaves and gets a new drink for a turn");
        Debug.Log("paultinHeal"+ strahdHP +" "+ richtenHP);
        strahdHP += 20;
        AiAttack("Strix");

    }

   static void TurnSayings(int turnNumber)
    {
        //Text t = null;
        
        if (turnNumber == 2)
        {
            //t.text = "Paultin: It's okay, we scared them with the first round, Strahd von Chairovich! Chair Richten, you bastard! After this next attack you won't have a leg to stand on!";
            //Console.WriteLine(" Paultin: It's okay, we scared them with the first round, Strahd von Chairovich! "
            // + "\n  Chair Richten, you bastard! After this next attack you won't have a leg to stand on!");
        }
        else if (turnNumber == 4)
        {
            //Console.WriteLine(" Paultin: It appears your chair has not trained hard enough.");
        }
        else if (turnNumber == 6)
        {
            //Console.WriteLine(" Strix: Don't give up Chair Richten! We can still do this!");
        }
        
    }
    


    
}
