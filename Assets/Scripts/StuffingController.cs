using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffingController : MonoBehaviour
{
    private ParticleSystem particleSystemComponent;

    // Start is called before the first frame update
    void Start()
    {
        particleSystemComponent = GetComponent<ParticleSystem>();
        particleSystemComponent.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
