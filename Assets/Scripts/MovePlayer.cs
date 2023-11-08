using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float roundingSpeed = 20.0f;
    private Gun gun;

    void Start()
    {
        gun = GetComponentInChildren<Gun>();
        
    }

    
    void Update()
    {
        Moving();
        
    }
    private void Moving()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(Vector3.zero, Vector3.up, roundingSpeed * Time.deltaTime);
            gun.SetPos0();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(Vector3.zero, Vector3.down, roundingSpeed * Time.deltaTime);
            gun.SetPos0();
        }

    }
}
