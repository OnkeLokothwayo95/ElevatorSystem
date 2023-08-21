using ElevatorSystem.Domain;
using System;


namespace ElevatorSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            //elevator will start on a random floor.
            //person will push floor number and elevator will move to that floor. 

            Elevator elevator = new Elevator();
            

            Console.WriteLine("Hello, welcome to the DVT Elevator Simulator!\n.\n.\n.");
            Console.WriteLine("How many people does one elevator allow?\n.\n.\n.");

            int weightLimitInput = 0;
            var weightLimit = Console.ReadLine();
            if (!Int32.TryParse(weightLimit, out weightLimitInput))
                {
                Console.Beep();
                Console.WriteLine("Hmmm, something went wrong...");
                Console.Clear();
            }

            Console.WriteLine("What floor are you going to? \n");     

            int floorGointToInput = 0;
            var floorGoingTo = Console.ReadLine();

            if (!Int32.TryParse(floorGoingTo, out floorGointToInput))
            {
                Console.WriteLine("You are currently on floor number: \n" + 0);

            }
            else 
            {
                Console.Beep();
                Console.WriteLine("Hmmm, something went wrong...");
            }

            
                

            Console.WriteLine("\nYou are going to floor number: " + floorGointToInput);
             


            

            
        }


        public void CallElevatorToYourFloor(Elevator elevator)
        {


        }

        public void GetCurrentFloor()
        {

        }
        public void ElevatorService()
        {

        }
    }
}
