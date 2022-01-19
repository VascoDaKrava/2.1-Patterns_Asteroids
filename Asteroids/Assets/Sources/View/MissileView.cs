using UnityEngine;


namespace Asteroids
{
    public sealed class MissileView : MonoBehaviour
    {

        #region Fields

        private bool _isHit;

        #endregion


        #region Properties

        public bool IsHit
        {
            get => _isHit;

            set => _isHit = value;
        }

        public Collider HittingCollider { get; private set; }

        #endregion


        #region UnityMethods

        private void OnTriggerEnter(Collider other)
        {
            _isHit = true;
            HittingCollider = other;
        }

        #endregion

    }
}
