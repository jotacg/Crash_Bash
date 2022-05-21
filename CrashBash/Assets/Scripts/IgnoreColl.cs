using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreColl : MonoBehaviour
{
    public Transform bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        //Transform bullet = Instantiate(bulletPrefab) as Transform;
        Physics.IgnoreCollision(bulletPrefab.GetComponent<Collider>(), GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
