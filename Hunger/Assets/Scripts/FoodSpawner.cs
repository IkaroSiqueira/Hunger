using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _food = null;
    [SerializeField] private GameObject _lethalFood = null;
    [SerializeField] private float _spawnFrequency = 2.0f; //the amount of seconds before the next item is spawned.
    [SerializeField] private float _lethalRarityPercent = 10; //the chance of a lethal food item spawning, 0-100%.

    private float _timeBeforeSpawn = 0;

    private void Update()
    {
        _timeBeforeSpawn += Time.deltaTime;

        if(_timeBeforeSpawn >= _spawnFrequency)
        {
            _timeBeforeSpawn = 0;
            if(Random.Range(0, 101) <= _lethalRarityPercent)
            {
                Instantiate(_lethalFood, transform.position, transform.rotation); //spawns the lethal food
            }
            else
            {
                Instantiate(_food, transform.position, transform.rotation); //spawns the normal food
            }
        }
    }
}
