namespace State
{
    /// <summary>
    /// A Concrete State class.
    /// Rare doneness.
    /// Edible state, Rare.
    /// </summary>
    public class Rare : Doneness
    {
        public Rare(Doneness state) : this(state.CurrentTemp, state.Steak) { }

        public Rare(double currentTemp, Steak steak)
        {
            _currentTemp = currentTemp;
            _steak = steak;
            //We can now eat the steak
            _canEat = true;

            Initialize();
        }

        /// <summary>
        /// Initialization when steak is rare doneness.
        /// </summary>
        private void Initialize()
        {
            _lowerTemp = 130;
            _upperTemp = 139.999999999999;
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
            // If current temp < lower temp, than change state to Uncooked.
            if (_currentTemp < _lowerTemp)
            {
                _steak.State = new Uncooked(this);
            }
            // If current temp > upper temp, go to another state.
            else if (_currentTemp > _upperTemp)
            {
                _steak.State = new MediumRare(this);
            }
        }
    }
}