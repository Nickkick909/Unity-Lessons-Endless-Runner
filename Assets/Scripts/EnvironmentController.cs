using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentController : MonoBehaviour
{

    [SerializeField] GameObject[] environmentElement;
    [SerializeField] Transform referencePoint;
    [SerializeField] float spawnSecondsMin;
    [SerializeField] float spawnSecondsMax;
    void Start()
    {
        StartCoroutine(CreateEnvironmentElements());
    }

    IEnumerator CreateEnvironmentElements()
    {
        int rndIndex = Random.Range(0, environmentElement.Length);
        Instantiate(environmentElement[rndIndex], referencePoint.position, Quaternion.identity);

        float rndTime = Random.Range(spawnSecondsMin, spawnSecondsMax);
        yield return new WaitForSeconds(rndTime);

        StartCoroutine(CreateEnvironmentElements());
    }
}
