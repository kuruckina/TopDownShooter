using System;
using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _bulletSpawnPointTransform;
        [SerializeField] private float _fireDelay = 0.3f;

        private Transform _cachedTransform;
        private float _timer;

        private void Awake()
        {
            _cachedTransform = transform;
        }

        private void Update()
        {
            if (CanAttack())
            {
                Attack();
            }

            TickTimer();
        }

        

        private bool CanAttack()
        {
            return Input.GetButton("Fire1") && _timer <= 0;
        }

        private void Attack()
        {
            Instantiate(_bulletPrefab, _bulletSpawnPointTransform.position, _cachedTransform.rotation);
            _timer = _fireDelay;
        }
        
        private void TickTimer()
        {
            _timer -= Time.deltaTime;
        }
    }
}