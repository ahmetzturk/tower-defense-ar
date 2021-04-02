using System.Collections;
using System.Collections.Generic;
using TowerDefense.Controller;
using TowerDefense.Core;
using UnityEngine;

namespace TowerDefense.Attack
{   
    public class Attacker : MonoBehaviour
    {
        [SerializeField] private float rangeDistance = 20f;
        [SerializeField] private ParticleSystem fireEffect = null;
        [SerializeField] private float shootInterval = 2.5f;
        [SerializeField] private Transform projectilePoint = null;
        private GameObject target = null;      
        private Rotater rotater;
        private Transform turret;
        private float lastShootTime = Mathf.Infinity;
        private void Awake()
        {
            rotater = GetComponent<Rotater>();
            turret = rotater.Turret;
        }

        private void Update()
        {
            lastShootTime += Time.deltaTime;
            target = GetNearestEnemy(SphereRaycast());
            if (target == null)
            {
                rotater.Rotate();
                return;
            }
            Shoot();
        }

        private RaycastHit[] SphereRaycast()
        {
            int layerMask = LayerMask.GetMask("Raycastable");
            RaycastHit[] hits = Physics.SphereCastAll(transform.position, rangeDistance * transform.lossyScale.x, transform.up, 0, layerMask);            
            return hits;
        }

        private GameObject GetNearestEnemy(RaycastHit[] hits)
        {
            if (hits.Length == 0) return null;
            RaycastHit hitWithMinDistance = hits[0];
            for (int i = 0; i < hits.Length; i++)
            {
                if(hits[i].distance < hitWithMinDistance.distance)
                {
                    hitWithMinDistance = hits[i];
                }
            }
            return hitWithMinDistance.collider.gameObject;
        }

        private void OnDrawGizmosSelected()
        {
            // Draw a yellow sphere at the transform's position
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, rangeDistance);
        }

        private void Shoot()
        {
            rotater.Turret.LookAt(target.transform);
            RaycastHit hit;
            if(Physics.Raycast(turret.position, turret.forward, out hit))
            {
                if (hit.transform.CompareTag("Enemy") && lastShootTime > shootInterval)
                {
                    if(fireEffect != null)
                        fireEffect.Play();
                    lastShootTime = 0;
                    GameObject projectile = GetComponent<PoolProjectile>().GetPooledObject();
                    projectile.transform.SetPositionAndRotation(
                        projectilePoint.position, projectilePoint.rotation);
                }
            }
        }
    }
}
