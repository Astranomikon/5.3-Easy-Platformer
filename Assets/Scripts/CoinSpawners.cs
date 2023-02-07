using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawners : MonoBehaviour
{
    [SerializeField] private Coin _spawnCoin;

    private WaitForSeconds _sleep = new WaitForSeconds(5);

    private Transform[] _spawnPoints;
    private int _currentSpawnPoint = 0;

    private void Start()
    {
        _spawnPoints = new Transform[gameObject.transform.childCount];

        for (int i = 0; i < _spawnPoints.Length; i++)
            _spawnPoints[i] = gameObject.transform.GetChild(i);

        var _spawnCoin = StartCoroutine(StartSpawnPrefabs());
    }

    private IEnumerator StartSpawnPrefabs()
    {
        while (true)
        {
            if (_currentSpawnPoint == _spawnPoints.Length)
                _currentSpawnPoint = 0;

            var spawnedMob = Instantiate(_spawnCoin, _spawnPoints[_currentSpawnPoint].position, Quaternion.identity);
            _currentSpawnPoint++;
            yield return _sleep;
        }
    }
}
