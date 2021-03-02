namespace State
{
    /// <summary>
    /// A Concrete State class.
    /// Well done doneness.
    /// Edible state, Well done.
    /// </summary>
    public class WellDone : Doneness
    {
        public WellDone(Doneness state) : this(state.CurrentTemp, state.Steak) { }

        public WellDone(double currentTemp, Steak steak)
        {
            _currentTemp = currentTemp;
            _steak = steak;
            _canEat = true;
            Initialize();
        }

        /// <summary>
        /// Initialization when steak is well done doneness.
        /// </summary>
        private void Initialize()
        {
            _lowerTemp = 170;
            _upperTemp = 230;
        }

        /// <summary>
        /// Add cook temperature.
        /// </summary>
        /// <param name="amount"> Amount of temperature. </param>
        public override void AddTemp(double amount)
        {
            _currentTemp += amount;
            DonenessCheck();
        }

        /// <summary>
        /// Remove cook temperature.
        /// </summary>
        /// <param name="amount"> Amount of temperature. </param>
        public override void RemoveTemp(double amount)
        {
            _currentTemp -= amount;
            DonenessCheck();
        }

        /// <summary>
        /// Determines whether or not the internal temperature of the steak is sufficiently high enough,
        /// to allow it to move to another state.
        /// </summary>
        public override void DonenessCheck()
        {
            if (_currentTemp < 0)
            {
                _steak.State = new Uncooked(this);
            }
            else if (_currentTemp < _lowerTemp)
            {
                _steak.State = new Medium(this);
            }
        }
    }
}