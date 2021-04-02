using UnityEngine;

namespace TowerDefense.Attack
{
    [CreateAssetMenu(fileName = "Data", menuName = "Projectile/CreateProjectileSettings", order = 1)]
    public class ProjectileSettings : ScriptableObject
    {
        public float speed;
        public float damage;
    }
}
