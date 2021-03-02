namespace State
{
    /// <summary>
    /// A Concrete State class.
    /// Medium rare doneness.
    /// Edible state, Medium rare.
    /// </summary>
    public class MediumRare : Doneness
    {
        public MediumRare(Doneness state) : this(state.CurrentTemp, state.Steak) { }

        public MediumRare(double currentTemp, Steak steak)
        {
            _currentTemp = currentTemp;
            _steak = steak;
            _canEat = true;
            Initialize();
        }

        /// <summary>
        /// Initialization when steak is madium rare doneness.
        /// </summary>
        private void Initialize()
        {
            _lowerTemp = 140;
            _upperTemp = 154.9999999999;
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
            if (_currentTemp <= 0.0)
            {
                _steak.State = new Uncooked(this);
            }
            else if (_currentTemp < _lowerTemp)
            {
                _steak.State = new Rare(this);
            }
            else if (_currentTemp > _upperTemp)
            {
                _steak.State = new Medium(this);
            }
        }
    }
}