using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoPlaces : MonoBehaviour
{
    private float _float;
    private Transform _allPlacespoint;
    private Transform[] _arrayPlaces;
    private int _numberOfPlaceInArrayPlaces;

    private void Start()
    {
        _arrayPlaces = new Transform[_allPlacespoint.childCount];

        for (int i = 0; i < _allPlacespoint.childCount; i++)
        {
            _arrayPlaces[i] = _allPlacespoint.GetChild(i).GetComponent<Transform>();
        }
    }

    public void Update()
    {
        var pointByNumberInArray = _arrayPlaces[_numberOfPlaceInArrayPlaces];
        transform.position = Vector3.MoveTowards(transform.position, pointByNumberInArray.position, _float * Time.deltaTime);

        if (transform.position == pointByNumberInArray.position)
        {
            NextPlaceTakerLogic();
        }
    }

    private Vector3 NextPlaceTakerLogic()
    {
        _numberOfPlaceInArrayPlaces++;

        if (_numberOfPlaceInArrayPlaces == _arrayPlaces.Length)
            _numberOfPlaceInArrayPlaces = 0;

        var thisPointVector = _arrayPlaces[_numberOfPlaceInArrayPlaces].transform.position;
        transform.forward = thisPointVector - transform.position;
        return thisPointVector;
    }
}