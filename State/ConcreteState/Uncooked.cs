namespace State
{
    /// <summary>
    /// A Concrete State class.
    /// Uncooked doneness
    /// </summary>
    public class Uncooked : Doneness
    {
        public Uncooked(Doneness state)
        {
            _currentTemp = state.CurrentTemp;
            _steak = state.Steak;
            // Can't eat.
            _canEat = false;
            Initialize();
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
            // If current temp > upper temp, go to another state.
            if (_currentTemp > _upperTemp)
            {
                _steak.State = new Rare(this);
            }
        }

        /// <summary>
        /// Initialization when the steak is not ready.
        /// </summary>
        private void Initialize()
        {
            _lowerTemp = 0;
            _upperTemp = 130;
        }
    }
}