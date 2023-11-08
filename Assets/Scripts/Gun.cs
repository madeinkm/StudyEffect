using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    ////Ʃ�� c++, c#  ������ Ʃ���� �ٸ��� 11��2�� ���Ǻ� ���� ��
    //public (int plus, int minus, int multy, int div, int remain) function(int _a, int _b)
    //{
    //    return (_a + _b, _a - _b, _a * _b, _a / _b, _a % _b);
    //}

    ////var value = function(1, 2); -> �̷��� function�� ��� ���� �� ����
    

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
            // z fighting�� ���ֱ� ���� hit.point�� hit.normal���� �۾�������
            // �밢������ ������ �Ѿ��� fromtorot�� �̿��� �����ϰ� ������ �ٲ���
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
