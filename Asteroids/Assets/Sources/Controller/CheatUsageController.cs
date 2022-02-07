using UnityEngine;


namespace Asteroids
{
    public sealed class CheatUsageController : UpdatableObject
    {

        #region ClassLifeCycles

        public CheatUsageController(
            CreateUpdatableObjectEvent createUpdatableObject,
            DestroyUpdatableObjectEvent destroyUpdatableObject) : base(createUpdatableObject, destroyUpdatableObject)
        {
        }

        #endregion


        #region Methods

        private void CheckCheat()
        {
            if (InputManager.isCheat)
            {
                Debug.Log("CHEAT");
            }
        }

        #endregion


        #region IUpdatable

        public override void LetUpdate()
        {
            CheckCheat();
        }

        #endregion

    }
}
