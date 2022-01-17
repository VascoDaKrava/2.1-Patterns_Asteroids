using UnityEngine;


namespace Asteroids
{

    public sealed class MissileView : MonoBehaviour
    {

        #region Fields

        private int _damage;

        #endregion


        #region Properties

        public int Damage
        {
            set { _damage = value; }
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
            Destroy(gameObject);
        }

        #endregion

    }
}
