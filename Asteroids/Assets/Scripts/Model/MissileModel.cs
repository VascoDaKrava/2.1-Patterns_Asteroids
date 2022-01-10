using System;


namespace Asteroids
{

    public sealed class MissileModel : IDisposable
    {

        #region Properties

        public int Damage { get; } = 10;
        public float Speed { get; } = 10.0f;

        #endregion


        #region IDisposable

        public void Dispose()
        {
        }

        #endregion

    }
}
