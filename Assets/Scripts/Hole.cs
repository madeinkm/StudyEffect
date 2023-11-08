using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    private SpriteRenderer sr;

    void Start()
    {        
        Destroy(gameObject, 1.0f);
    }

    public void SetSorting(int _value)
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sortingOrder = _value;
    }
}
