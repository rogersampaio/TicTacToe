using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float force = 5;
    private bool firstPlayer = true;
    private GameObject A1_gameobject, A2_gameobject, A3_gameobject, B1_gameobject, B2_gameobject, B3_gameobject, C1_gameobject, C2_gameobject, C3_gameobject;
    private Rigidbody A1_rigibody, A2_rigibody, A3_rigibody, B1_rigibody, B2_rigibody, B3_rigibody, C1_rigibody, C2_rigibody, C3_rigibody;
    private SquareController A1, A2, A3, B1, B2, B3, C1, C2, C3;
    private Renderer A1_renderer, A2_renderer, A3_renderer, B1_renderer, B2_renderer, B3_renderer, C1_renderer, C2_renderer, C3_renderer;

    void Awake()
    {
        A1_gameobject = GameObject.Find("A1"); A2_gameobject = GameObject.Find("A2"); A3_gameobject = GameObject.Find("A3");
        B1_gameobject = GameObject.Find("B1"); B2_gameobject = GameObject.Find("B2"); B3_gameobject = GameObject.Find("B3");
        C1_gameobject = GameObject.Find("C1"); C2_gameobject = GameObject.Find("C2"); C3_gameobject = GameObject.Find("C3");

        A1_rigibody = GameObject.Find("A1").GetComponent<Rigidbody>();
        A1 = GameObject.Find("A1").GetComponent<SquareController>();
        A1_renderer = GameObject.Find("A1").GetComponent<Renderer>();
        A2_rigibody = GameObject.Find("A2").GetComponent<Rigidbody>();
        A2 = GameObject.Find("A2").GetComponent<SquareController>();
        A2_renderer = GameObject.Find("A2").GetComponent<Renderer>();
        A3_rigibody = GameObject.Find("A3").GetComponent<Rigidbody>();
        A3 = GameObject.Find("A3").GetComponent<SquareController>();
        A3_renderer = GameObject.Find("A3").GetComponent<Renderer>();

        B1_rigibody = GameObject.Find("B1").GetComponent<Rigidbody>();
        B1 = GameObject.Find("B1").GetComponent<SquareController>();
        B1_renderer = GameObject.Find("B1").GetComponent<Renderer>();
        B2_rigibody = GameObject.Find("B2").GetComponent<Rigidbody>();
        B2 = GameObject.Find("B2").GetComponent<SquareController>();
        B2_renderer = GameObject.Find("B2").GetComponent<Renderer>();
        B3_rigibody = GameObject.Find("B3").GetComponent<Rigidbody>();
        B3 = GameObject.Find("B3").GetComponent<SquareController>();
        B3_renderer = GameObject.Find("B3").GetComponent<Renderer>();

        C1_rigibody = GameObject.Find("C1").GetComponent<Rigidbody>();
        C1 = GameObject.Find("C1").GetComponent<SquareController>();
        C1_renderer = GameObject.Find("C1").GetComponent<Renderer>();
        C2_rigibody = GameObject.Find("C2").GetComponent<Rigidbody>();
        C2 = GameObject.Find("C2").GetComponent<SquareController>();
        C2_renderer = GameObject.Find("C2").GetComponent<Renderer>();
        C3_rigibody = GameObject.Find("C3").GetComponent<Rigidbody>();
        C3 = GameObject.Find("C3").GetComponent<SquareController>();
        C3_renderer = GameObject.Find("C3").GetComponent<Renderer>();
    }

    void Update()
    {
        SelectItem();
        VerifyWinner();
    }

    private void VerifyWinner()
    {
        //first row
        if ((A1.selected_X && A2.selected_X && A3.selected_X) || (A1.selected_Y && A2.selected_Y && A3.selected_Y))
        {
            ActiveFlare(A1_gameobject); ActiveFlare(A2_gameobject); ActiveFlare(A3_gameobject);
            PushObject(B1_rigibody, B1_renderer); PushObject(B2_rigibody, B2_renderer); PushObject(B3_rigibody, B3_renderer);
            PushObject(C1_rigibody, C1_renderer); PushObject(C2_rigibody, C2_renderer); PushObject(C3_rigibody, C3_renderer);
        }
        //second row
        if ((B1.selected_X && B2.selected_X && B3.selected_X) || (B1.selected_Y && B2.selected_Y && B3.selected_Y))
        {
            ActiveFlare(B1_gameobject); ActiveFlare(B2_gameobject); ActiveFlare(B3_gameobject);
            PushObject(A1_rigibody, A1_renderer); PushObject(A2_rigibody, A2_renderer); PushObject(A3_rigibody, A3_renderer);
            PushObject(C1_rigibody, C1_renderer); PushObject(C2_rigibody, C2_renderer); PushObject(C3_rigibody, C3_renderer);
        }
        //third row
        if ((C1.selected_X && C2.selected_X && C3.selected_X) || (C1.selected_Y && C2.selected_Y && C3.selected_Y))
        {
            ActiveFlare(C1_gameobject); ActiveFlare(C2_gameobject); ActiveFlare(C3_gameobject);
            PushObject(A1_rigibody, A1_renderer); PushObject(A2_rigibody, A2_renderer); PushObject(A3_rigibody, A3_renderer);
            PushObject(B1_rigibody, B1_renderer); PushObject(B2_rigibody, B2_renderer); PushObject(B3_rigibody, B3_renderer);
        }
        //first line
        if ((A1.selected_X && B1.selected_X && C1.selected_X) || (A1.selected_Y && B1.selected_Y && C1.selected_Y))
        {
            ActiveFlare(A1_gameobject); ActiveFlare(B1_gameobject); ActiveFlare(C1_gameobject);
            PushObject(A2_rigibody, A2_renderer); PushObject(B2_rigibody, B2_renderer); PushObject(C2_rigibody, C2_renderer);
            PushObject(A3_rigibody, A3_renderer); PushObject(B3_rigibody, B3_renderer); PushObject(C3_rigibody, C3_renderer);
        }
        //second line
        if ((A2.selected_X && B2.selected_X && C2.selected_X) || (A2.selected_Y && B2.selected_Y && C2.selected_Y))
        {
            ActiveFlare(A2_gameobject); ActiveFlare(B2_gameobject); ActiveFlare(C2_gameobject);
            PushObject(A1_rigibody, A1_renderer); PushObject(B1_rigibody, B1_renderer); PushObject(C1_rigibody, C1_renderer);
            PushObject(A3_rigibody, A3_renderer); PushObject(B3_rigibody, B3_renderer); PushObject(C3_rigibody, C3_renderer);
        }
        //third line
        if ((A3.selected_X && B3.selected_X && C3.selected_X) || (A3.selected_Y && B3.selected_Y && C3.selected_Y))
        {
            ActiveFlare(A3_gameobject); ActiveFlare(B3_gameobject); ActiveFlare(C3_gameobject);
            PushObject(A1_rigibody, A1_renderer); PushObject(B1_rigibody, B1_renderer); PushObject(C1_rigibody, C1_renderer);
            PushObject(A2_rigibody, A2_renderer); PushObject(B2_rigibody, B2_renderer); PushObject(C2_rigibody, C1_renderer);
        }
        //one diagonal
        if ((A1.selected_X && B2.selected_X && C3.selected_X) || (A1.selected_Y && B2.selected_Y && C3.selected_Y))
        {
            ActiveFlare(A1_gameobject); ActiveFlare(B2_gameobject); ActiveFlare(C3_gameobject);
            PushObject(A2_rigibody, A2_renderer); PushObject(A3_rigibody, A3_renderer);
            PushObject(B1_rigibody, B1_renderer); PushObject(B3_rigibody, B3_renderer);
            PushObject(C1_rigibody, C1_renderer); PushObject(C2_rigibody, C2_renderer);
        }
        //other diagonal
        if ((A3.selected_X && B2.selected_X && C1.selected_X) || (A3.selected_Y && B2.selected_Y && C1.selected_Y))
        {
            ActiveFlare(A3_gameobject); ActiveFlare(B2_gameobject); ActiveFlare(C1_gameobject);
            PushObject(A1_rigibody, A1_renderer); PushObject(A2_rigibody, A2_renderer);
            PushObject(B1_rigibody, B1_renderer); PushObject(B3_rigibody, B3_renderer);
            PushObject(C2_rigibody, C2_renderer); PushObject(C3_rigibody, C3_renderer);
        }
    }

    private void ActiveFlare(GameObject _gameobject)
    {
        _gameobject.transform.Find("Flare").gameObject.SetActive(true);
    }

    //First Item is always the X
    private void SelectItem()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (PauseMenu.GameIsPaused)
                return;

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform && hit.transform.GetComponent<SquareController>())
                {
                    //PrintName(hit.transform.gameObject);

                    Rigidbody rb;
                    if (rb = hit.transform.GetComponent<Rigidbody>())
                    {
                        //Avoid selection
                        if (hit.transform.GetComponent<SquareController>().selected_X || hit.transform.GetComponent<SquareController>().selected_Y)
                            return;
                        if (rb.position.y < 0)
                            return;
                        //Avoid selection

                        hit.transform.GetComponent<Animator>().SetTrigger("StartScale");

                        if (firstPlayer)
                        {
                            //hit.transform.GetComponent<Renderer>().material.color = Color.blue;// Color.HSVToRGB(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                            //Get Cross
                            hit.transform.GetChild(1).GetComponent<Animator>().SetTrigger("StartPopup");
                            hit.transform.GetComponent<SquareController>().selected_X = true;
                            firstPlayer = false;
                        }
                        else
                        {
                            //hit.transform.GetComponent<Renderer>().material.color = Color.green;// Color.HSVToRGB(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                            //Get Cylinder
                            hit.transform.GetChild(0).GetComponent<Animator>().SetTrigger("StartPopup");
                            hit.transform.GetComponent<SquareController>().selected_Y = true;
                            firstPlayer = true;
                        }
                    }

                }
            }
        }
    }

    private void PrintName(GameObject go)
    {
        print(go.name);
    }

    private void PushObject(Rigidbody rb, Renderer renderer)
    {

        Vector3 originalPosition = rb.position;
        //hit.transform.GetComponent<Renderer>().material.color = Color.blue;// Color.HSVToRGB(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        renderer.material.color = Color.gray;// Color.HSVToRGB(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        rb.useGravity = true;
        //ExecuteAfterTime(rb);
    }

    //  IEnumerator ExecuteAfterTime(Rigidbody rb)
    //  {
    //      yield return new WaitForSeconds(2f);
    //      rb.useGravity = false;
    //      rb.position = position;
    //  }

}