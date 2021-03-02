using System;

namespace State
{
    /// <summary>
    /// The Context class.
    /// The Context defines an interface of interest to the clients.
    /// It also maintains a reference to an instance of ConcreteState which represents the current state.
    /// </summary>
    public class Steak
    {
        /// <summary>
        /// A reference to the Doneness state.
        /// </summary>
        public Doneness State { get; set; }

        private readonly string _beefCut;

        public Steak(string beefCut)
        {
            _beefCut = beefCut;
            State = new Rare(0.0, this);
        }

        public double CurrentTemp => State.CurrentTemp;

        public void AddTemp(double amount)
        {
            State.AddTemp(amount);
            Console.WriteLine($"Increased temperature by {amount} degrees.");
            Console.WriteLine($"Current temp is {CurrentTemp}");
            Console.WriteLine($"Status is {State.GetType().Name}");
            Console.WriteLine();
        }

        public void RemoveTemp(double amount)
        {
            State.RemoveTemp(amount);
            Console.WriteLine($"Decreased temperature by {amount} degrees.");
            Console.WriteLine($"Current temp is {CurrentTemp}");
            Console.WriteLine($"Status is {State.GetType().Name}");
            Console.WriteLine();
        }
    }
}