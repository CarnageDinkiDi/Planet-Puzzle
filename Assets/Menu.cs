using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Menu : MonoBehaviour
{
    public List<Points> PointsList = new List<Points>();
    public GameObject pivotPrefab;
    public Transform planet;
    public float timeToGo;
    [Range (0,2)]
    public int MenuSelect=0;

    private void Start()
    {
        planet = transform.GetChild(0);

        for(int i = 0; i < PointsList.Count; i++)
        {
            GameObject pivot = Instantiate(pivotPrefab, planet);
            pivot.transform.eulerAngles = new Vector3(PointsList[i].points.y,-PointsList[i].points.x,0f);
        }
        CameraLook(0);
    }
    private void Update()
    {

        if (Input.GetButtonDown("R1"))
        {
            MenuSelect++;
            if (MenuSelect <3)
            {
               
                CameraLook(MenuSelect);
            }
            else
            {
                MenuSelect = 0;
                CameraLook(MenuSelect);
            }

        }
        else if (Input.GetButtonDown("L1"))
        {
            MenuSelect--;
            if (MenuSelect>-1)
            {
                CameraLook(MenuSelect);
            }
            else
            {
                MenuSelect = 2;
                CameraLook(MenuSelect);
            }
        }


    }

    void CameraLook(int index)
    {
        Points _points = PointsList[index];
        Vector3 rot = new Vector3(_points.points.y,- _points.points.x,0f);
        Camera.main.transform.parent.DORotate(rot, timeToGo, RotateMode.Fast);
    }
}

[System.Serializable]
public class Points
{
    public string name;
    public Vector2 points;
}
