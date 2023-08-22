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
            /*public static int floorId = 1;
            private static int currentFloor = 1;
            private static bool isAvailable ;*/

            Elevator elevator = new Elevator { FloorId = 1, CurrentFloor = 1, isAvailable = true };


            Console.WriteLine("Hello, welcome to the DVT Elevator Simulator!\n.\n.\n.");
            Console.WriteLine("How many people does one elevator allow?\n.\n.\n.");

            int weightLimitInput = 0;
            var weightLimit = Console.ReadLine();
            if (Int32.TryParse(weightLimit, out weightLimitInput))
            {
                Console.WriteLine("Thank you for your input.\n.\n.\n.");

            }
            else
            {
                Console.Beep();
                Console.WriteLine("Hmmm, something went wrong...");
                Console.Clear();
            }

            Console.WriteLine("What floor are you going to? \t");

            int floorGoingToInput = 0;
            var floorGoingTo = Console.ReadLine();
            
            if (Int32.TryParse(floorGoingTo, out floorGoingToInput))
            {
                elevator.RequestedFloor = floorGoingToInput;
                Console.WriteLine("You are currently on floor number: \n" + elevator.CurrentFloor);
                // add logic here
                if (elevator.RequestedFloor > elevator.CurrentFloor)
                {
                    Console.WriteLine("\n.\n.\n.\nYou are going to floor number: " + floorGoingToInput);
                    var currentFloor = elevator.CurrentFloor;
                    var numberOfFloorsToGoUp = elevator.RequestedFloor - currentFloor;
                    Console.ForegroundColor = ConsoleColor.Green;
                 

                    while (numberOfFloorsToGoUp > 0)
                    {
                        currentFloor++;
                        Console.WriteLine("Going Up...Now On Floor: " + currentFloor);
                        Console.Beep();
                        numberOfFloorsToGoUp--;



                    }
                }

            }
            else
            {
                Console.Beep();
                Console.WriteLine("Hmmm, something went wrong...");
            }







        }
    }
}

  
 

