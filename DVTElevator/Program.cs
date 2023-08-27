using ElevatorSystem.Domain;
using System;


namespace ElevatorSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            
                
                    Elevator elevator = new Elevator { FloorId = 1, CurrentFloor = 1, IsAvailable = true , NumberOfPeopleInElevator = 0};


                    Console.WriteLine("Hello, welcome to the DVT Elevator System! Press Escape at eny time to exit.\n.\n.\n.");
                    Console.WriteLine("How many people does one elevator allow?\n.\n.\n.");

                    int weightLimitInput = 0;
                    var weightLimit = Console.ReadLine();
                    if (Int32.TryParse(weightLimit, out weightLimitInput))
                    {
                        Console.WriteLine("Thank you for your input.\n.\n.\n.");
                        elevator.WeightLimit = weightLimitInput;

                    }
                    else
                    {
                        Console.Beep();
                        Console.WriteLine("Hmmm, something went wrong...");
                        Console.Clear();
                    }

            do
            {

                Console.WriteLine("What floor are you going to? \t");

                int floorGoingToInput = 0;
                var floorGoingTo = Console.ReadLine();

                if (Int32.TryParse(floorGoingTo, out floorGoingToInput))
                {
                    elevator.RequestedFloor = floorGoingToInput;
                    Console.WriteLine("You are currently on floor number: \n" + elevator.CurrentFloor);
                    // add logic here
                    if (elevator.RequestedFloor > elevator.CurrentFloor && elevator.IsAvailable && elevator.NumberOfPeopleInElevator <= elevator.WeightLimit)
                    {
                        elevator.IsAvailable = false;
                        Console.WriteLine("\n.\n.\n.\nPlease enter the elevator. You are going to floor number: " + floorGoingToInput);
                        var currentFloor = elevator.CurrentFloor;
                        var numberOfFloorsToGoUp = elevator.RequestedFloor - currentFloor;
                        Console.ForegroundColor = ConsoleColor.Green;
                        elevator.NumberOfPeopleInElevator++;

                        while (numberOfFloorsToGoUp > 0)
                        {
                            currentFloor++;
                            Console.WriteLine("Going Up...Now On Floor: " + currentFloor);
                            //Console.Beep();
                            numberOfFloorsToGoUp--;



                        }
                        
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Arrived, Doors Opening. Please Exit.\n");

                        elevator.CurrentFloor = currentFloor;
                        elevator.IsAvailable = true;
                        
                        Console.WriteLine("Press Enter To Continue.  \n");


                    }
                    else if (elevator.RequestedFloor < elevator.CurrentFloor && elevator.IsAvailable)
                    {
                        elevator.IsAvailable = false;
                        Console.WriteLine("\n.\n.\n.\nYou are going to floor number: " + floorGoingToInput);
                            var currentFloor = elevator.CurrentFloor;
                            var numberOfFloorsToGoUp = currentFloor - elevator.RequestedFloor;
                            Console.ForegroundColor = ConsoleColor.Green;


                            while (numberOfFloorsToGoUp > 0)
                            {
                                currentFloor--;
                                Console.WriteLine("Going Down...Now On Floor: " + currentFloor);
                                //Console.Beep();
                                numberOfFloorsToGoUp--;



                            }
                            elevator.CurrentFloor = currentFloor;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Arrived, Doors Opening. Please Exit. \n");
                            elevator.IsAvailable = true;
                        Console.WriteLine("Press Enter To Continue.  \n");

                        


                    }
                    else if(elevator.RequestedFloor == elevator.CurrentFloor)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n.\n.\n.\nYou are already on floor number: " + floorGoingToInput);
                        Console.WriteLine("Press Enter To Continue.  \n");
                    }

                }
            
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
 




