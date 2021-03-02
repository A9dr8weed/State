namespace State
{
    /// <summary>
    /// A Concrete State class.
    /// Medium doneness.
    /// Edible state, Medium.
    /// </summary>
    public class Medium : Doneness
    {
        public Medium(Doneness state) : this(state.CurrentTemp, state.Steak) { }

        public Medium(double currentTemp, Steak steak)
        {
            _currentTemp = currentTemp;
            _steak = steak;
            _canEat = true;
            Initialize();
        }

        /// <summary>
        /// Initialization when steak is madium doneness.
        /// </summary>
        private void Initialize()
        {
            _lowerTemp = 155;
            _upperTemp = 169.9999999999;
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
            if (_currentTemp < 130)
            {
                _steak.State = new Uncooked(this);
            }
            else if (_currentTemp < _lowerTemp)
            {
                _steak.State = new MediumRare(this);
            }
            else if (_currentTemp > _upperTemp)
            {
                _steak.State = new WellDone(this);
            }
        }
    }
}