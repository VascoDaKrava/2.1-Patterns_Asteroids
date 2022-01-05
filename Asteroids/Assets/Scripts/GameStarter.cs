using UnityEngine;
using System.Collections.Generic;


namespace Asteroids
{

    public sealed class GameStarter : MonoBehaviour
    {
        #region Fields

        private Links _links;
        private List<IUpdatable> _updatables;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _links = new Links(this);

            _updatables = new List<IUpdatable>();
        }

        private void Update()
        {
            foreach (IUpdatable item in _updatables)
            {
                item.LetUpdate();
            }
        }

        #endregion


        #region Methods

        /// <summary>
        /// Add item to list for Update
        /// </summary>
        /// <param name="updatableObject"></param>
        public void AddToUpdateList(IUpdatable updatableObject)
        {
            _updatables.Add(updatableObject);
        }

        /// <summary>
        /// Remove item from list for Update
        /// </summary>
        /// <param name="updatableObject"></param>
        public void RemoveFromUpdateList(IUpdatable updatableObject)
        {
            _updatables.Remove(updatableObject);
        }

        #endregion
    }
}