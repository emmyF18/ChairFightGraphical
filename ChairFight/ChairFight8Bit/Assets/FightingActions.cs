using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingActions : MonoBehaviour
{
    private  const  int strahdHPMax = 110;
    private  const int richtenHPMax = 90;
    private static readonly Random rand = new Random();
    private static int strahdHP;
    private static int richtenHP;
    private static int order; // strix 1/paultin 2
    // Start is called before the first frame update
    void Start()
    {
        strahdHP = strahdHPMax;
        richtenHP = richtenHPMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (strahdHP < 0)
            {
                Debug.Log("end game")
                //Console.WriteLine(
                    //    "Strahd Von Chairovich falls to the ground in pieces \n Paultin:Nooo, my beautiful chair!");
            }
            else
            {
               // Console.WriteLine(
               //         "Chair Richten falls to the ground in pieces \n Strix: Nooo, We were going to go to the big leagues!");
            }
    }

    public void playerControledFight(String playerName)
    {
     Debug.Log("player: "+ playerName);
        if(GameObject.name == "ButtonP1")
        {
            Debug.Log("Atack1");
            if(playerName.equals("Strix"))
            {
                StrixKickAttack();
            }
            else
            {
                PaultinPunch();
            }
        }
        else if(GameObject.name == "ButtonP1-2")
        {
            if(playerName.equals("Strix"))
            {
                StrixPunchAttack();
            }
            else
            {
                PaultinSlam();
            }
            Debug.Log("Attack2");
        }
        else if(GameObject.name == "ButtonP1-3")
        {
            if(playerName.equals("Strix"))
            {
                StrixPanic();
            }
            else
            {
                PaultinDrink();
            }
            Debug.Log("Attack3");
        }   
    }
    

    static void StrixKickAttack()
    {
        //Console.WriteLine("Chair Richten uses Chair Kick!");
        
        if (rand.Next(100) + 1 <= 90)
        {
            strahdHP -= 20;
            //Console.WriteLine("Chair Richten's leg smashes into its opponent for 20 damage!");
        }
        else
        {
            Debug.Log("attack failed");
            //Console.WriteLine("Chair Richten's leg smashes into nothing...");
        }
        
    }

    static void StrixPunchAttack()
    {
        //Console.WriteLine("Chair Richten uses Chair Punch!");
        
        if (rand.Next(100) + 1 <= 70)
        {
            strahdHP -= 40;
            //Console.WriteLine("Chair Richten punches it's opponent for 40 damage!");
        }
        else
        {
            Debug.Log("attack failed");
            //Console.WriteLine("Chair Richten punches nothing...");
        }
        
    }

    static void StrixPanic()
    {
        //Console.WriteLine("Strix uses Panic! \n Strix lays down and starts screaming for a turn");
        Debug.Log("strixHeal 20");
        richtenHP += 20;
    }

    static void PaultinPunch()
    {
        //Console.WriteLine("Strahd Von Chairovich uses Chair Punch!");
        
        if (rand.Next(100) + 1 <= 80)
        {
            richtenHP -= 20;
            Debug.Log("punch succeded, -20 damage")
            //Console.WriteLine("Strahd Von Chairovich punches his opponent for 20 damage!");
        }
        else
        {
            Debug.Log("attack failed");
            //Console.WriteLine("Strahd Von Chairovich punches nothing...");
        }
        
    }

    static void PaultinSlam()
    {
        //Console.WriteLine("Strahd Von Chairovich uses Chair Slam!");
        
        if (rand.Next(100) + 1 <= 60)
        {
            richtenHP -= 40;
            Debug.Log("punch succeded, -40 damage richten")
            //Console.WriteLine("Strahd Von Chairovich slams into its opponent for 40 damage!");
        }
        else
        {
            Debug.Log("attack failed");
            //Console.WriteLine("Strahd Von Chairovich slams into nothing...");
        }
        
    }

    static void PaultinDrink()
    {
        //Console.WriteLine("Paultin uses I need a drink. \n Paultin leaves and gets a new drink for a turn");
        Debug.Log("paultinHeal 20");
        strahdHP += 20;
    }

    static void TurnSayings(int turnNumber)
    {
        if (turnNumber == 2)
        {
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
