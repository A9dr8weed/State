namespace State
{
    /// <summary>
    /// The State abstract class.
    /// </summary>
    public abstract class Doneness
    {
        /// <summary>
        /// This backreference can be used by States to  transition the Context to another State.
        /// </summary>
        protected Steak _steak;

        /// <summary>
        /// Current temperature.
        /// </summary>
        protected double _currentTemp;

        /// <summary>
        /// Lower temperature.
        /// </summary>
        protected double _lowerTemp;

        /// <summary>
        /// Upper temperature.
        /// </summary>
        protected double _upperTemp;

        /// <summary>
        /// Can eat.
        /// </summary>
        protected bool _canEat;

        /// <summary>
        /// Provides a backreference to the Context object, associated with the State.
        /// </summary>
        public Steak Steak
        {
            get => _steak;
            set => _steak = value;
        }

        public double CurrentTemp
        {
            get => _currentTemp;
            set => _currentTemp = value;
        }

        /// <summary>
        /// Add cook temperature.
        /// </summary>
        /// <param name="temp"> Temperature. </param>
        public abstract void AddTemp(double temp);

        /// <summary>
        /// Remove cook temperature.
        /// </summary>
        /// <param name="temp"> Temperature. </param>
        public abstract void RemoveTemp(double temp);

        /// <summary>
        /// Determines whether or not the internal temperature of the steak is sufficiently high enough,
        /// to allow it to move to another state.
        /// </summary>
        public abstract void DonenessCheck();
    }
}