using NaughtyAttributes;
using NUnit.Framework;
using System;
using System.Collections;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Random = System.Random;

public class Health : MonoBehaviour
{
    static int _globalLife;

    [SerializeField, ValidateInput(nameof(ValidateMaxHealth), "incorrect")] int _maxHealth;

    [ShowNonSerializedField] int _currentHealth;

    [SerializeField] public UnityEvent _onTakeDamage;
    [SerializeField] UnityEvent _onDie;

    public Animator _animator;

    public event Action OnTakeDamage;

    public int CurrentHealth
    {
        get => _currentHealth;
        private set => _currentHealth = value;
    }
    public int Bidule {  get; private set; }

    public bool IsDead => CurrentHealth <= 0;

    #region ValidateMaxHealth

    bool ValidateMaxHealth()
    {
        if (_maxHealth <= 0) return false;
        else return true;
    }

    #endregion

    #region Reset

    void Reset()
    {
        _maxHealth = 100;
    }


    private void OnValidate()
    {
        if (_maxHealth <= 0)
        {
            Debug.Log("Nop");
            _maxHealth = 100;

        }
    }

    #endregion

    #region TestTakeDamage

    [Button]
    public void TestTakeDamage()
    {
        TakeDamage(10);
    }

    [Button]
    public void TestTakeDamageError()
    {
        TakeDamage(-10);
    }

    #endregion

    public enum PlayerState
    {
        IDLE,
        WALK,
        JUMP,
        SWIM
    }

    #region Awake

    void Awake()
    {
        _currentHealth = _maxHealth;

        PlayerState ps = PlayerState.IDLE;

        Debug.Log("fini");



        MyVector3 v = new MyVector3(1, 2, 3);
        var length = v.SqrtMagnitude;

        MyVector3 v2 = new MyVector3(4, 5, 6);

        var result = v + v2;
    }

    #endregion

    #region TakeDamage
    public void TakeDamage (int damage)
    {
        Input.GetKeyDown(KeyCode.Space);

        Application.targetFrameRate = 50;

        if(damage <= 0)
        {
            Debug.Log("damage must be positive");
            return;
        }

        _currentHealth = Mathf.Clamp( _currentHealth-damage, 0, _maxHealth );

        _onTakeDamage.Invoke();
        OnTakeDamage?.Invoke();

        if (IsDead)
        {
            Die();
        }
    }
    #endregion

    #region Die
    void Die()
    {
            _animator.SetTrigger("Die");


        Coroutine c1 = StartCoroutine(DieRoutine());
        IEnumerator DieRoutine()
        {
            _onDie.Invoke();
            Debug.Log("Dying");

            yield return new WaitForSeconds(2f);

            Destroy(gameObject);
        }
    }
    #endregion
}
