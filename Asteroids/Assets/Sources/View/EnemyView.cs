using UnityEngine;


namespace Asteroids
{
    public sealed class EnemyView : MonoBehaviour
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
            // If enter to the FLYING_AREA do nothing
            if (!other.CompareTag(TagsAndLayers.FLYING_AREA_TAG))
            {
                _collisionDetectorEvent.Invoke(gameObject.transform, other.transform);
            }
                
        }

        #endregion

    }
}
