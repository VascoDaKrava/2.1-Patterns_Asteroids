using UnityEngine;


namespace Asteroids
{

    public sealed class MissileView : MonoBehaviour
    {

        #region Fields

        private int _damage;
        private MissileController _missileController;

        #endregion


        #region Properties

        public int Damage
        {
            set { _damage = value; }
        }

        public MissileController MissileController 
        {
            set { _missileController = value; }
        }

        #endregion


        #region UnityMethods

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<IDamageable>(out IDamageable damageable))
            {
                damageable.GetDamage(_damage);
            }

            DestroyMissile();
        }

        #endregion


        #region Methods

        private void DestroyMissile()
        {
            _missileController.Dispose();
            Destroy(gameObject);
        }

        #endregion

    }
}
