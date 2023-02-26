using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //The enemy will get the location of the two patrol objects and travel back and forth between them.
    [SerializeField] public GameObject patrolObjectOne = null;
    [SerializeField] public GameObject patrolObjectTwo = null;
    [SerializeField] private float _speed = 10.0f;

    private bool _travelingToObjectOne = true;
    private float _detectionRange = 6;
    private bool _chasingPlayer = false;
    private GameObject _playerReference = null;
    private Rigidbody _rigidBod = null;

    private void Start()
    {
        _rigidBod = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (_chasingPlayer == false)
        {
            if(patrolObjectOne != null && patrolObjectTwo != null)
            {
                _Patrol();
            }
        }
        else if (_playerReference != null)
        {
            _MoveTowardsObject(_playerReference);
        }
    }

    private void _Patrol()
    {
        //Checks if the enemy has reached their current focused patrol object, then moves it towards the right one.
        _CheckReachedPatrolObject();
        if (_travelingToObjectOne)
        {
            _MoveTowardsObject(patrolObjectOne);
        }
        else
        {
            _MoveTowardsObject(patrolObjectTwo);
        }
    }

    private void _CheckReachedPatrolObject()
    {
        //Checks if the enemy has reached a close proximity of the patrol object, if so it tells it to start moving to the opposite one.
        if (_travelingToObjectOne)
        {
            if (Vector3.Distance(patrolObjectOne.transform.position, this.transform.position) < 1.5f)
            {
                _travelingToObjectOne = false;
            }
        }
        else
        {
            if (Vector3.Distance(patrolObjectTwo.transform.position, this.transform.position) < 1.5f)
            {
                _travelingToObjectOne = true;
            }
        }
    }

    private void _MoveTowardsObject(GameObject patrolObject)
    {
        //Gets the direction of the object and removes the y axis from the calculation, this way the enemy won't try and move vertically.
        Vector3 _objectDir = (patrolObject.transform.position - transform.position);
        _objectDir.y = 0;
        _rigidBod.velocity = _objectDir.normalized * _speed * Time.deltaTime * 100;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, (other.gameObject.transform.position - transform.position).normalized, out hit, _detectionRange))
            {
                if (hit.transform.gameObject.tag == "Player")
                {
                    //hit.transform.gameObject;
                    _chasingPlayer = true;
                    _playerReference = other.gameObject;
                }
            }
        }
    }
    
}
