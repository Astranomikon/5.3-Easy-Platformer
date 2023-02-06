using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBirdsInPatrol : MonoBehaviour
{
    [SerializeField] private Bird template;

    private float _birdSpeed = 2;

    void Start()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            var newBird = Instantiate(template, gameObject.transform.GetChild(i).GetChild(0));
            newBird.Init(gameObject.transform.GetChild(i), _birdSpeed);
        }
    }
}
