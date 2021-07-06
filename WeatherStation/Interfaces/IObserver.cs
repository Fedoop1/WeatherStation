using System;

namespace WeatherStation.Interfaces
{
    /// <summary>
    /// An interface which declare base behavior of all classes that want to be observer of some <see cref="IObservable"/> classes.
    /// </summary>
    public interface IObserver
    {
        /// <summary>
        /// Called after <see cref="IObservable"/> class call it's Notify() method.
        /// </summary>
        /// <param name="sender">The object sender.</param>
        /// <param name="info">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void Update(object sender, EventArgs info);
    }
}
