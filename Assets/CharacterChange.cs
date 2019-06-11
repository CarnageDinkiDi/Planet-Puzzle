using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharacterChange : MonoBehaviour
{
   public bool Characterone;
    public bool CharacterTwo;

    public PlayerController one;
    public PlayerController two;

    public Camera FirstCamera;
    public Camera SecondCamera;

    public Camera TransitionCamera;

    private void Awake()
    {
        FirstCamera.gameObject.SetActive(true);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Joystick Change"))
        {
            if (Characterone == true)
            {
                one.canMove = false;
                two.canMove = true;
                // SecondCamera.tag="MainCamera";
                // FirstCamera.tag = "Untagged";
                TransitionCamera.transform.position = SecondCamera.transform.position;
                TransitionCamera.transform.eulerAngles = SecondCamera.transform.eulerAngles;

                FirstCamera.gameObject.SetActive(false);
                TransitionCamera.transform.DOMove(SecondCamera.transform.position, 0.5f);
                StartCoroutine(waits(FirstCamera.gameObject,SecondCamera.gameObject,false));

                //SecondCamera.gameObject.SetActive(true);
               // FirstCamera.gameObject.SetActive(false);
                //Characterone = false;
            }
            else if (Characterone == false)
            {
                one.canMove = true;
                two.canMove = false;
                //FirstCamera.tag = "MainCamera";
                // SecondCamera.tag ="Untagged";
                TransitionCamera.transform.position = FirstCamera.transform.position;
                TransitionCamera.transform.eulerAngles = FirstCamera.transform.eulerAngles;

                SecondCamera.gameObject.SetActive(false);
                TransitionCamera.transform.DOMove(FirstCamera.transform.position, 0.5f);
                StartCoroutine(waits(SecondCamera.gameObject, FirstCamera.gameObject, true));

                //FirstCamera.gameObject.SetActive(true);
               // SecondCamera.gameObject.SetActive(false);

               // Characterone = true;
            }
        }
    }

    IEnumerator waits(GameObject OneCamera,GameObject TwoCamera,bool WhichCharacter)
    {
        yield return new WaitForSeconds(2f);
      //  OneCamera.SetActive(false);
        TwoCamera.SetActive(true);

        Characterone = WhichCharacter;
    }
}
