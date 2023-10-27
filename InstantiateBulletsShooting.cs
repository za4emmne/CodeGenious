using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class InstantiateBulletsShooting : MonoBehaviour
{
    [SerializeField] private float _number;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _timeWaitShooting;

    private Transform _objectToShoot;

    private void Start()
    {
        StartCoroutine(ShootingWorker());
    }

    private IEnumerator ShootingWorker()
    {
        bool isWork = enabled;

        while (isWork)
        {
            var _vector3direction = (ObjectToShoot.position - transform.position).normalized;
            var NewBullet = Instantiate(_prefab, transform.position + _vector3direction, Quaternion.identity);
            NewBullet.GetComponent<Rigidbody>().transform.up = _vector3direction;
            NewBullet.GetComponent<Rigidbody>().velocity = _vector3direction * _number;
            yield return new WaitForSeconds(_timeWaitShooting);
        }
    }
}