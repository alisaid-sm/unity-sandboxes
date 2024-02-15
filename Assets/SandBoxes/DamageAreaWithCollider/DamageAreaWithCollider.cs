using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DamageAreaWithCollider : MonoBehaviour
{
    public float _delay = 1f;
    private float _cdCounter;
    private Dictionary<int, float> _damages = new();
    private bool _isDamaged = false;

    // Start is called before the first frame update
    void Start()
    {
        _cdCounter = _delay;
    }

    // Update is called once per frame
    void Update()
    {
        if (_cdCounter > 0)
        {
            _cdCounter -= Time.deltaTime;
        }

        if (_isDamaged)
        {
            _cdCounter = _delay;
            _isDamaged = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy" && _cdCounter <= 0)
        {
            try
            {
                _damages.Add(other.transform.GetInstanceID(), 1);
            }
            catch (System.Exception)
            {
                _damages[other.transform.GetInstanceID()] = _damages[other.transform.GetInstanceID()] + 1;
            }

            DamageAreaWithColliderEnemy enemyFunc = other.GetComponent<DamageAreaWithColliderEnemy>();

            enemyFunc.enemyDamageUI.text = _damages[other.transform.GetInstanceID()].ToString();

            _isDamaged = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            DamageAreaWithColliderEnemy enemyFunc = other.GetComponent<DamageAreaWithColliderEnemy>();

            _damages.Remove(other.transform.GetInstanceID());

            enemyFunc.enemyDamageUI.text = "";
        }
    }
}
