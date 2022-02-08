using UnityEngine;


namespace Asteroids
{
    public static class Sonar
    {

        #region Methods

        /// <summary>
        /// Searching enemies in radius of sonarPosition and returning nearest like target
        /// </summary>
        /// <param name="sonarPosition"></param>
        /// <param name="radius"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool StartSonar(Vector3 sonarPosition, float radius, out Transform target)
        {
            target = null;
            float nearestDistance = float.PositiveInfinity;
            float currentDistanceToTarget;

            foreach (Collider item in Physics.OverlapSphere(sonarPosition, radius, TagsAndLayers.ENEMY_LAYER_MASK, QueryTriggerInteraction.Collide))
            {
                currentDistanceToTarget = Vector3.Distance(item.transform.position, sonarPosition);

                if (nearestDistance > currentDistanceToTarget)
                {
                    nearestDistance = currentDistanceToTarget;
                    target = item.transform;
                }
            }

            return target;
        }

        #endregion

    }
}
