using System;
using System.Threading;

namespace ChairFightText
{
    class Program
    {
        private  const  int strahdHPMax = 110;
        private  const int richtenHPMax = 90;
        private static readonly Random rand = new Random();
        private static int strahdHP;
        private static int richtenHP;
        private static int order; // strix 1/paultin 2
        static void Main(string[] args)
        {
            string person;
            do
            {
               Console.WriteLine("Choose Your Fighter! \n Strix with Chair Richten: smaller target, but less HP \n "
                        + "Paultin with Strahd Von Chairovich: bigger target, but more HP \n Enter Exit to quit");
                Console.WriteLine("Fighter Name: ");
                strahdHP = strahdHPMax;
                richtenHP = richtenHPMax;
                person = Console.ReadLine().ToLower();
                if (!person.Equals("exit"))
                {
                    Start(person);
                }
            } while (!person.Equals("exit"));
        }
        public static void FightStrix()
        {
            int turnNumber = 0;
            Console.WriteLine("Paultin challenges you with Strahd Von Chairovich!");
            sleep(1);
            Console.WriteLine("Go Chair Richten!");
            sleep(1);
            Console.WriteLine("Rolling for initiative...");
            int initiative1 = rand.Next(20) + 1;
            int initiative2 = rand.Next(20) + 1;
            Console.WriteLine("You got " + initiative1 + " while Paultin got " + initiative2);
            sleep(1);
            if (initiative1 >= initiative2)
            {
                order = 1;
            }
            else
            {
                order = 2;
            }
            Console.WriteLine("Time for battle!");
            //Scanner in = new Scanner(System.in);
            while (strahdHP >= 1 && richtenHP >= 1)
            {
                int selection = 3;
                turnNumber++;
                Console.WriteLine("Strahd Von Charovich: " + strahdHP + "/" + strahdHPMax + "\nChair Richten: " + richtenHP
                        + "/" + richtenHPMax);
                Console.WriteLine("What will Strix do?" + "\n 1:Chair Kick! Power 20, Accuracy 90"
                        + "\n 2:Chair Punch! Power 40 Accuracy 70 " + "\n 3:Panic! Strix gives up a turn due to panicking");
                Console.Write("Selection Number: ");
                //try
                //{                 
                    string temp = Console.ReadLine();
                    selection = int.Parse(temp);
                
                    Console.Write(selection);
               // }
                //catch (System.IO.IOException)
               // {
                   // Console.WriteLine("Incorrect Input\n");
                    //selection = Console.Read();
               // }
                switch (selection)
                {
                    case 1:
                        if (order == 1)
                        {
                            StrixKickAttack();
                            AiAttack("Paultin");

                        }
                        else
                        {
                            AiAttack("Paultin");
                            StrixKickAttack();
                        }
                        break;
                    case 2:
                        if (order == 1)
                        {
                            StrixPunchAttack();
                            AiAttack("Paultin");
                        }
                        else
                        {
                            AiAttack("Paultin");
                            StrixPunchAttack();
                        }
                        break;
                    case 3:
                        if (order == 1)
                        {
                            StrixPanic();
                            AiAttack("Paultin");
                        }
                        else
                        {
                            AiAttack("Paultin");
                            StrixPanic();
                        }
                        break;
                    default:
                        Console.WriteLine("Incorrect Option");
                        AiAttack("Paultin");
                        break;
                }
                TurnSayings(turnNumber);
            }
            if (strahdHP < 0)
            {
                Console.WriteLine("Strahd Von Chairovich falls to the ground in pieces \n Paultin:Nooo, my chair!");
                sleep(1);
            }
            else
            {
                Console.WriteLine(
                        "Chair Richten falls to the ground in pieces \n Strix: Nooo! We were going to go to the big leagues!");
                sleep(1);
            }
        }

        public static void FightPaultin()
        {
            int turnNumber = 0;
            int selection = 3;
            Console.WriteLine("Strix challenges you with Chair Richten!");
            sleep(1);
            Console.WriteLine("Go Strahd Von Chairovich!");
            sleep(1);
            Console.WriteLine("Rolling for initiative...");
            int initiative1 = rand.Next(20) + 1;
            int initiative2 = rand.Next(20) + 1;
            Console.WriteLine("You got " + initiative1 + " while Strix got " + initiative2);
            if (initiative1 >= initiative2)
            {
                order = 2;
            }
            else
            {
                order = 1;
            }
            sleep(1);
            Console.WriteLine("Time for battle!");
            //Scanner in = new Scanner(System.in);
            while (strahdHP >= 0 && richtenHP >= 0)
            {
                turnNumber++;
                Console.WriteLine(" Strahd Von Charovich: " + strahdHP + "/" + strahdHPMax + "\nChair Richten: "
                        + richtenHP + "/" + richtenHPMax);
                Console.WriteLine("What will Paultin do?" + "\n 1:Chair Punch! Power 20, Accuracy 80"
                        + "\n 2:Chair Slam! Power 40 Accuracy 60 "
                        + "\n 3:I need a drink. Paultin leaves and gets himself a drink for a turn.");
                Console.Write("Selection Number: ");
                try
                {
                    selection = Console.Read();
                }
                catch (System.IO.IOException)
                {
                    Console.WriteLine("Incorrect Input\n");
                    selection = Console.Read();
                }
                switch (selection)
                {
                    case 1:
                        if (order == 2)
                        {
                            PaultinPunch();
                            AiAttack("Strix");

                        }
                        else
                        {
                            AiAttack("Strix");
                            PaultinPunch();
                        }
                        break;
                    case 2:
                        if (order == 2)
                        {
                            PaultinSlam();
                            AiAttack("Strix");
                        }
                        else
                        {
                            AiAttack("Strix");
                            PaultinSlam();
                        }
                        break;
                    case 3:
                        if (order == 2)
                        {
                            PaultinDrink();
                            AiAttack("Strix");
                        }
                        else
                        {
                            AiAttack("Strix");
                            PaultinDrink();
                        }
                        break;
                    default:
                        Console.WriteLine("Incorrect Option");
                        AiAttack("Strix");
                        break;
                }
                TurnSayings(turnNumber);
            }
            Winner();

        }

        public static void AiAttack(String person)
        {
            int aiSelection = rand.Next(5) + 1;
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

        static void sleep(int seconds)
        {
            try
            {
                Thread.Sleep(seconds * 1000);
            }
            catch (ThreadInterruptedException e)
            {
                e.ToString();
            }
        }

        static void StrixKickAttack()
        {
            Console.WriteLine("Chair Richten uses Chair Kick!");
            sleep(1);
            if (rand.Next(100) + 1 <= 90)
            {
                strahdHP -= 20;
                Console.WriteLine("Chair Richten's leg smashes into its opponent for 20 damage!");
            }
            else
            {
                Console.WriteLine("Chair Richten's leg smashes into nothing...");
            }
            sleep(1);
        }

        static void StrixPunchAttack()
        {
            Console.WriteLine("Chair Richten uses Chair Punch!");
            sleep(1);
            if (rand.Next(100) + 1 <= 70)
            {
                strahdHP -= 40;
                Console.WriteLine("Chair Richten punches it's opponent for 40 damage!");
            }
            else
            {
                Console.WriteLine("Chair Richten punches nothing...");
            }
            sleep(1);
        }

        static void StrixPanic()
        {
            Console.WriteLine("Strix uses Panic! \n Strix lays down and starts screaming for a turn");
            sleep(1);
        }

        static void PaultinPunch()
        {
            Console.WriteLine("Strahd Von Chairovich uses Chair Punch!");
            sleep(1);
            if (rand.Next(100) + 1 <= 80)
            {
                richtenHP -= 20;
                Console.WriteLine("Strahd Von Chairovich punches his opponent for 20 damage!");
            }
            else
            {
                Console.WriteLine("Strahd Von Chairovich punches nothing...");
            }
            sleep(1);
        }

        static void PaultinSlam()
        {
            Console.WriteLine("Strahd Von Chairovich uses Chair Slam!");
            sleep(1);
            if (rand.Next(100) + 1 <= 60)
            {
                richtenHP -= 40;
                Console.WriteLine("Strahd Von Chairovich slams into its opponent for 40 damage!");
            }
            else
            {
                Console.WriteLine("Strahd Von Chairovich slams into nothing...");
            }
            sleep(1);
        }

        static void PaultinDrink()
        {
            Console.WriteLine("Paultin uses I need a drink. \n Paultin leaves and gets a new drink for a turn");
            sleep(1);
        }

        static void TurnSayings(int turnNumber)
        {
            if (turnNumber == 2)
            {
                Console.WriteLine(" Paultin: It's okay, we scared them with the first round, Strahd von Chairovich! "
                        + "\n  Chair Richten, you bastard! After this next attack you won't have a leg to stand on!");
            }
            else if (turnNumber == 4)
            {
                Console.WriteLine(" Paultin: It appears your chair has not trained hard enough.");
            }
            else if (turnNumber == 6)
            {
                Console.WriteLine(" Strix: Don't give up Chair Richten! We can still do this!");
            }
            sleep(1);
        }

        static void Winner()
        {
            if (strahdHP < 0)
            {
                Console.WriteLine(
                        "Strahd Von Chairovich falls to the ground in pieces \n Paultin:Nooo, my beautiful chair!");
            }
            else
            {
                Console.WriteLine(
                        "Chair Richten falls to the ground in pieces \n Strix: Nooo, We were going to go to the big leagues!");
            }

        }

        static void Start(string person)
        {
            person = person.ToLower();
            if (person.Equals("strix"))
            {
                FightStrix();
            }
            else if (person.Equals("paultin"))
            {
                FightPaultin();
            }
        }
    }
}
