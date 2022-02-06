using UnityEngine;


namespace Asteroids
{
    public sealed class ExplosionController
    {

        #region Fields

        private CollisionDetectorEvent _collisionDetectorEvent;
        private GameObject _explosionGameObject;
        private ParticleSystem _explosion;
        private ResourceManager _resourceManager;

        #endregion


        #region ClassLifeCycles

        public ExplosionController(CollisionDetectorEvent collisionDetectorEvent, ResourceManager resourceManager)
        {
            _collisionDetectorEvent = collisionDetectorEvent;
            _resourceManager = resourceManager;

            _collisionDetectorEvent.CollisionDetector += CollisionHandeler;
        }

        ~ExplosionController()
        {
            _collisionDetectorEvent.CollisionDetector -= CollisionHandeler;
        }

        #endregion


        #region Methods

        private void CollisionHandeler(Transform transformA, Transform transformB)
        {
            if (transformA.GetComponent<MissileView>())
            {
                MakeExplosion(transformA);
            }

            if (transformB.GetComponent<MissileView>())
            {
                MakeExplosion(transformB);
            }
        }

        private void MakeExplosion(Transform point)
        {
            _explosionGameObject = GameObject.Instantiate(_resourceManager.Explosion, point.position, point.rotation);
            _explosion = _explosionGameObject.GetComponent<ParticleSystem>();
            Object.Destroy(_explosionGameObject, _explosion.main.duration);
            _explosion.Play();
        }

        #endregion

    }
}
