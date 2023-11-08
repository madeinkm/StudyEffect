using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    ////튜플 c++, c#  에서의 튜플이 다르다 11월2일 강의분 보면 됨
    //public (int plus, int minus, int multy, int div, int remain) function(int _a, int _b)
    //{
    //    return (_a + _b, _a - _b, _a * _b, _a / _b, _a % _b);
    //}

    ////var value = function(1, 2); -> 이러면 function의 모든 값이 다 나옴
    

    [SerializeField] private GameObject fabHole;
    [SerializeField] private Transform trsDynamic;
    [SerializeField] private Transform trsMuzzle;
    [SerializeField] private Light lightHit;
    [SerializeField] private Light lightFire;
    private Camera mainCam;
    private short shootCount = 0;
    private LineRenderer lr;


    
    void Start()
    {
        mainCam = Camera.main;
        lr = GetComponentInChildren<LineRenderer>();
        SetPos0();
        activeFalseLine();
    }
    
    void Update()
    {
        shoot();   
        
    }

    public void SetPos0()
    {
        lr.SetPosition(0, trsMuzzle.position);
    }
    private void shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out RaycastHit hit, 11f))
        {
            activeLine(hit.point);
            lightHit.transform.position = hit.point + hit.normal * 0.1f;

            GameObject obj = Instantiate(fabHole, hit.point + hit.normal * 0.001f, Quaternion.FromToRotation(Vector3.forward, hit.normal), trsDynamic);
            // z fighting을 없애기 위해 hit.point에 hit.normal값을 작업을해줌
            // 대각선으로 박히는 총알을 fromtorot을 이용해 수평하게 박히게 바꿔줌
            Hole sc = obj.GetComponent<Hole>();
            sc.SetSorting(shootCount++);

            if(shootCount >= 32767)
            {
                shootCount = 0;
            }
        }
    }
    private void activeLine(Vector3 _point)
    {
        lightHit.enabled = true;
        lightFire.enabled = true;

        lr.SetPosition(1, _point);
        lr.enabled = true;

        Invoke("activeFalseLine", 0.1f);

    }
    private void activeFalseLine()
    {
        lr.enabled = false;
        lightHit.enabled = false;
        lightFire.enabled = false;
    }
}
