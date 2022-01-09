using System;


namespace Asteroids
{

    public sealed class MissileModel : IDisposable
    {

        #region Fields

        private int _damage = 10;

        #endregion


        #region Properties

        public int Damage { get; } = 10;


        #endregion


        #region IDisposable

        public void Dispose()
        {
        }

        #endregion

    }
}
