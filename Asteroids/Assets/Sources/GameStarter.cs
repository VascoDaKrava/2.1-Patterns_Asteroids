using System;
using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{

    public sealed class GameStarter : MonoBehaviour, IDisposable
    {

        #region Fields

        private List<IUpdatable> _updatables;
        private List<IUpdatable> _candidatsForAddingToUpdatables;
        private CreateUpdatableObjectEvent _createUpdatableObjectEvent;
        private DestroyUpdatableObjectEvent _destroyUpdatableObjectEvent;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _updatables = new List<IUpdatable>();
            _candidatsForAddingToUpdatables = new List<IUpdatable>();

            _createUpdatableObjectEvent = new CreateUpdatableObjectEvent();
            _destroyUpdatableObjectEvent = new DestroyUpdatableObjectEvent();

            _createUpdatableObjectEvent.CreateUpdatableObject += AddToUpdateList;
            _destroyUpdatableObjectEvent.DestroyUpdatableObject += RemoveFromUpdateList;

            new RootStarter(this, _createUpdatableObjectEvent, _destroyUpdatableObjectEvent);
        }

        private void Update()
        {
            foreach (IUpdatable item in _updatables)
            {
                item.LetUpdate();
            }
        }

        private void LateUpdate()
        {
            if (_candidatsForAddingToUpdatables.Count > 0)
            {
                _updatables.AddRange(_candidatsForAddingToUpdatables);
                _candidatsForAddingToUpdatables.Clear();
            }
        }

        #endregion


        #region Methods

        /// <summary>
        /// Add item to list for Update (in the current LateUpdate)
        /// </summary>
        /// <param name="updatableObject"></param>
        public void AddToUpdateList(IUpdatable updatableObject)
        {
            _candidatsForAddingToUpdatables.Add(updatableObject);
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


        #region IDisposable

        public void Dispose()
        {
            _createUpdatableObjectEvent.CreateUpdatableObject -= AddToUpdateList;
            _destroyUpdatableObjectEvent.DestroyUpdatableObject -= RemoveFromUpdateList;
        }

        #endregion

    }
}