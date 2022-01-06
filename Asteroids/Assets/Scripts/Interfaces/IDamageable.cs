namespace Asteroids
{
   public interface IDamageable
    {
        /// <summary>
        /// Take damage from enemy or bullet
        /// </summary>
        /// <param name="damage"></param>
        /// <returns></returns>
        public int GetDamage(int damage);
    }
}

