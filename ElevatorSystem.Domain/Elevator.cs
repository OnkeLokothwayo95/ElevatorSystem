using System;

namespace ElevatorSystem.Domain
{
    public class Elevator
    {

        public int FloorId { get; set; }
        public int CurrentFloor { get; set; }

        public bool isAvailable { get; set;  }        

    }
}
