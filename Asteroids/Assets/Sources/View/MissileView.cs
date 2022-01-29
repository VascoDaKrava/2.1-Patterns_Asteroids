using UnityEngine;


namespace Asteroids
{
    public sealed class MissileView : MonoBehaviour
    {

        #region Fields

        private CollisionDetectorEvent _collisionDetectorEvent;

        #endregion


        #region Properties

        public CollisionDetectorEvent CollisionDetectorEvent
        {
            set 
            { 
                _collisionDetectorEvent = value; 
            }
        }

        #endregion


        #region UnityMethods

        private void OnTriggerEnter(Collider other)
        {
            _collisionDetectorEvent.Invoke(gameObject.transform, other.transform);
        }

        #endregion


        #region Methods

        public void DestroyMissile()
        {
            Destroy(gameObject);
        }

        #endregion

    }
}
