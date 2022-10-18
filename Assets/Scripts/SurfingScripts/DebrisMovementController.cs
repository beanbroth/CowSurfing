using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DebrisMovementController : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        yield return new WaitForSecondsRealtime(_lifeTime);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * _speed * Time.deltaTime;
    }
}
