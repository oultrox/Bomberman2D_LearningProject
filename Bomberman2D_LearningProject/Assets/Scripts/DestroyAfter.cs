using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour {

    [SerializeField] private float timer = 3f;
	// Use this for initialization
	void Start ()
    {
        Destroy(gameObject, timer);
	}
	
}
