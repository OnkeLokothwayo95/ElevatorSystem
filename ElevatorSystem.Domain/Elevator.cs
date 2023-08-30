using System;

namespace ElevatorSystem.Domain
{
    public class Elevator
    {

        public int ElevatorId { get; set; }
        //public Floor Floor { get; set;  }
        public int CurrentFloor { get; set; }
        public int RequestedFloor { get; set; }
        public bool IsAvailable { get; set;  }
        public int NumberOfPeopleInElevator { get; set; }
        public int WeightLimit { get; set; }
        public ElevatorState State { get; set; }

    }
}
