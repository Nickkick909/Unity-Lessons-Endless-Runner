using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float platformSpeed = 2f;
    [SerializeField] int leftLimit = -50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-platformSpeed, 0, 0) * Time.deltaTime );

        if (transform.position.x < leftLimit)
        {
            Destroy(gameObject);
        }
    }
}
