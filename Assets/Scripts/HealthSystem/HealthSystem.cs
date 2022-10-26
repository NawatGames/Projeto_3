using EventSystem;
using UnityEngine;

namespace HealthSystem {
    public class HealthSystem : GameEventEmitter, IHealthSystem {
        [SerializeField] private int _currentHealth;
        [SerializeField] private int _maxHealth;
        public bool canTakeDamage = true;

        [Header("Events")]
        [SerializeField] private GameEventSO _damageAppliedEvent;
        [SerializeField] private GameEventSO _diedEvent;
        [SerializeField] private GameEventSO _healthCuredEvent;
        
        private void Awake() {
            _currentHealth = _maxHealth;
        }

        public void SetCurrentHealth(int newValue) {
            _currentHealth = newValue;
            _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        }

        public void CureHealth(int cureAmount) {        
            SetCurrentHealth(_currentHealth + cureAmount);
            InvokeGameEvent(_healthCuredEvent);
        }

        public void ApplyDamage(int damageToApply) {
            if (canTakeDamage)
            {
                SetCurrentHealth(_currentHealth - damageToApply);

                if (_currentHealth <= 0) {
                    InvokeGameEvent(_diedEvent);
                    return;
                }
                InvokeGameEvent(_damageAppliedEvent);
            }
        }

        public int CurrentHealth => _currentHealth;

        public int MaxHealth => _maxHealth;
    }
}