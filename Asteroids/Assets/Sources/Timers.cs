using UnityEngine;


namespace Asteroids
{
    public sealed class Timers : UpdatableObject
    {

        #region Fields

        private float _secondsElapsed;

        #endregion


        #region Properties

        public bool isTimerOn { get; private set; } = false;

        #endregion


        #region ClassLifeCycles

        public Timers(
            CreateUpdatableObjectEvent createUpdatableObject,
            DestroyUpdatableObjectEvent destroyUpdatableObject) : base
            (createUpdatableObject, destroyUpdatableObject)
        {
        }

        #endregion


        #region Methods

        public void StartTimer(float seconds)
        {
            if (!isTimerOn)
            {
                _secondsElapsed = seconds;
                isTimerOn = true;
            }
            else
            {
                if (_secondsElapsed > 0)
                {
                    _secondsElapsed -= Time.deltaTime;
                } 
                else
                {
                    _secondsElapsed = 0;
                    isTimerOn = false;
                }
            }
        }

        #endregion


        #region UpdatableObject / IUpdatable

        public override void LetUpdate()
        {
            StartTimer(_secondsElapsed);
        }

        #endregion

    }
}
