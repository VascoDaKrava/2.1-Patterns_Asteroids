using System;
using UnityEngine;


namespace Asteroids
{

    public sealed class MissileController : UpdatableObject, IDisposable
    {

        #region Fields

        private MissileModel _missileModel;
        private MissileView _missileView;
        private Rigidbody _missileRigidbody;

        #endregion


        #region ClassLifeCicles

        public MissileController(GameStarter gameStarter, ResourceManager resourceManager, Transform bulletStartPosition) : base(gameStarter)
        {
            _missileModel = new MissileModel();
            
            _missileView = GameObject.Instantiate(
                resourceManager.MissileAIM9 as GameObject,
                bulletStartPosition.position,
                bulletStartPosition.rotation).GetComponent<MissileView>();

            _missileRigidbody = _missileView.gameObject.GetComponent<Rigidbody>();

            _missileView.Damage = _missileModel.Damage;
            _missileView.MissileController = this;


            
        }

        #endregion


        #region Methods

        private void MissileFly()
        {
            _missileRigidbody.velocity = Vector3.forward * 5f;
        }

        #endregion


        #region IDisposable

        public void Dispose()
        {
            _missileModel.Dispose();
        }

        #endregion


        #region IUpdatable

        public override void LetUpdate()
        {
            MissileFly();
        }

        #endregion

    }
}
