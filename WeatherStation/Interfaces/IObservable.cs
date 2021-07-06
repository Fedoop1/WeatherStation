using System;

namespace WeatherStation.Interfaces
{
    /// <summary>
    /// An interface that declares the base behavior of all classes that want to implement this interface and be an observable object.
    /// </summary>
    public interface IObservable
    {
        /// <summary>
        /// Registers new observer.
        /// </summary>
        /// <param name="observer">The observer.</param>
        public void Register(IObserver observer);

        /// <summary>
        /// Unregisters the observer.
        /// </summary>
        /// <param name="observer">The observer.</param>
        public void Unregister(IObserver observer);

        /// <summary>
        /// Notifies all observers about new state.
        /// </summary>
        public void Notify();
    }
}
