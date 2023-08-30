using ElevatorSystem.Domain;
using ElevatorSystem.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ElevatorSystem.Services
{
    public class ElevatorService : IElevatorService
    {

        private int _weightLimit;
        private List<ElevatorRequest> _elevatorRequests;
        public ElevatorService()
        {
            //gather elevator system information
            //in real world elevators will start on floor zero/ground, how do i express this?
            //create list of requests
            //receive requests on click
            //get request
            //ensure request valid
           //execute request 
          // - 
          //once request done, release elevator

        }
        public async Task RunElevatorSystem()
        {
           

            //start elevator system
            // var isRequestValid = ValidateRequest(request);

            
            try
            {

                if (Console.ReadKey().Key == ConsoleKey.Escape)
                    Environment.Exit(-1);

                SetWeightLimit();

                Initialise();

                 ConsoleKeyInfo input;
                //var input = "";
                //while (true) 
                do
                {

                    
                    while(Console.KeyAvailable == false)
                        Thread.Sleep(250);


                     input = Console.ReadKey(true);
                     Console.WriteLine($"You have entered {input.KeyChar}.");

                     /*var input2 = Console.Read();
                     Console.WriteLine($"You have entered {input2}.");*/

                   /* while (Console.KeyAvailable == true)
                    {
                        input = Console.ReadLine();
                        Console.WriteLine($"You have entered {input}.");
                    }*/


                    //int floorGoingToInput = ValidateInput(input.KeyChar.ToString());
                    int floorGoingToInput = ValidateInput(input.KeyChar.ToString());
                    var isThisTheFirstRequest = _elevatorRequests.Count == 0;
                    //var getCurrentFloor = isThisTheFirstRequest ? 0 : GetElevatorCurrentFloor(_elevatorRequests);

                    //TODO - assign seperate elevator if other still busy
                    var freeElevators = _elevatorRequests.Where(x => x.Elevator.IsAvailable == true).Select(y=>y.Elevator).ToList();
                    var noFreeElevator = freeElevators.Count() == 0 ;
                    int newID = 0;
                    if (!isThisTheFirstRequest)
                    {
                        int lastElevatorReqId = _elevatorRequests.Last().Elevator.ElevatorId;
                        newID =lastElevatorReqId + 1  ;
                    }
                    else
                    {
                        newID = 0;
                    }



                    var elevator = new Elevator { RequestedFloor = floorGoingToInput, IsAvailable = true, WeightLimit = _weightLimit, CurrentFloor = 0, ElevatorId = newID};
                    _elevatorRequests.Add(new ElevatorRequest { Elevator = elevator });

                    


                    if (elevator.RequestedFloor > elevator.CurrentFloor /*&& elevator.IsAvailable*/ && elevator.NumberOfPeopleInElevator <= elevator.WeightLimit)
                    {
                        ExecuteUpRequestAsync(elevator);
                    }
                    else if (elevator.RequestedFloor < elevator.CurrentFloor /*&& elevator.IsAvailable*/ && elevator.NumberOfPeopleInElevator <= elevator.WeightLimit)
                    {
                        ExecuteDownRequestAsync(elevator);
                    }
                    else if (elevator.RequestedFloor == elevator.CurrentFloor)
                    {
                        StayStagnant(elevator.RequestedFloor);

                    }


                } while (input.Key != ConsoleKey.Escape);
                



            }
            catch (Exception exception)
            {
                Console.WriteLine("Something went wrong, exiting...");
                Environment.Exit(-1);
            }
        }

        private int GetElevatorCurrentFloor(List<ElevatorRequest> _elevatorRequests)
        {
            //var freeElevators = _elevatorRequests.Where(x=>x.Elevator.IsAvailable) ;
            return _elevatorRequests.Where(x => x.Elevator.IsAvailable).Last().Elevator.CurrentFloor;

           // return _elevatorRequests.Where(x => x.Elevator.IsAvailable &&);
        }
        private int ValidateInput(string floorGoingTo)
        {

            var intFloor = 0;
            if (Int32.TryParse(floorGoingTo, out intFloor))
                return intFloor;
            else
            {
                throw new ArgumentException();
            }
        }

        private void StayStagnant(int requestedFloor)
            {

            Console.WriteLine($"You're already on floor {requestedFloor}." );
            
                

            }

            private async Task ExecuteDownRequestAsync(Elevator elevator)
            {
            Console.WriteLine("You are currently on floor number: " + elevator.CurrentFloor);

            elevator.IsAvailable = false;
            Console.WriteLine($"\n.\n.\n.\nPlease enter Elevator {elevator.ElevatorId}. You are going to floor number: { elevator.RequestedFloor}.");
            var currentFloor = elevator.CurrentFloor;
            var numberOfFloorsToGoDown = currentFloor - elevator.RequestedFloor;
            Console.ForegroundColor = ConsoleColor.Green;
            elevator.NumberOfPeopleInElevator++;

            while (numberOfFloorsToGoDown > 0)
            {
                Task.Delay(1000);
                //Thread.Sleep(1000);
                currentFloor--;
                elevator.State = ElevatorState.GoingDown;
                Console.WriteLine($"Elevator {elevator.ElevatorId} Going Down...Now On Floor: {currentFloor}");
                //Console.Beep();
                numberOfFloorsToGoDown--;
            }

           // Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Elevator {elevator.ElevatorId} arrived, doors opening. ");
            elevator.CurrentFloor = currentFloor;
            elevator.IsAvailable = true;

        }

        private async Task ExecuteUpRequestAsync(Elevator elevator)
        {
                Console.WriteLine("You are currently on floor number: " + elevator.CurrentFloor);

                elevator.IsAvailable = false;
                Console.WriteLine($"\n.\n.\n.\nPlease enter Elevator {elevator.ElevatorId}. You are going to floor number: { elevator.RequestedFloor}.");
                var currentFloor = elevator.CurrentFloor;
                var numberOfFloorsToGoUp = elevator.RequestedFloor - currentFloor;
                Console.ForegroundColor = ConsoleColor.Green;
                elevator.NumberOfPeopleInElevator++;

                while (numberOfFloorsToGoUp > 0)
                {
                await Task.Delay(1000);
                //Thread.Sleep(1000);
                currentFloor++;
                    elevator.State = ElevatorState.GoingUp;
                    Console.WriteLine($"Elevator {elevator.ElevatorId} Going Up...Now On Floor: {currentFloor}");
                    //Console.Beep();
                    numberOfFloorsToGoUp--;
                }

               // Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Elevator {elevator.ElevatorId} arrived, doors opening. ");
                elevator.CurrentFloor = currentFloor;
                elevator.IsAvailable = true;
            
                

            
        }

         

        private void SetWeightLimit ()
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Hello, welcome to the DVT Elevator System!\n");
                Console.WriteLine("How many people does one elevator allow?\n");

                int weightLimitInput = 0;
                var weightLimit = Console.ReadLine();

                if (Int32.TryParse(weightLimit, out weightLimitInput))
                {
                    Console.WriteLine("Thank you for your input. \n...\n...\n...\n");
                }
                else
                {
                    Console.Beep();
                    Console.WriteLine("Hmmm, something went wrong...");
                    
                }
            _weightLimit = weightLimitInput;
            }

        private void Initialise()
        {
            Console.WriteLine("Initialising elevators...\n...\n...\n...\n");
            _elevatorRequests = new List<ElevatorRequest>();
            Thread.Sleep(1000);
            Console.WriteLine("Press FLOOR NUMBER to create an elevator request.\n");
        }

        


    }
}
