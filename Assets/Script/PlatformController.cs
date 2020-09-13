using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float force = 5;
    private bool firstPlayer = true;

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform && hit.transform.GetComponent<SquareController>())
                {
                    //PrintName(hit.transform.gameObject);
                    if (hit.transform.GetComponent<SquareController>()){
                        if (hit.transform.GetComponent<SquareController>().selected)
                            return;
                        else
                            hit.transform.GetComponent<SquareController>().selected = true;
                    }

                    if (firstPlayer){
                        hit.transform.GetComponent<Renderer>().material.color = Color.blue;// Color.HSVToRGB(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                        firstPlayer = false;
                    } else{
                        hit.transform.GetComponent<Renderer>().material.color = Color.green;// Color.HSVToRGB(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                        firstPlayer = true;
                    }

                    Rigidbody rb;
                    if (rb = hit.transform.GetComponent<Rigidbody>())
                    {
                        hit.transform.GetComponent<Animator>().SetTrigger("StartScale");
                        //PushObject(rb);
                    }
                }
            }
        }
    }

    private void PrintName(GameObject go)
    {
        print(go.name);
    }

    private void PushObject(Rigidbody rb)
    {
        
        // Vector3 originalPosition = rb.position;
        // rb.useGravity = true;
        //ExecuteAfterTime(rb);
    }

    //  IEnumerator ExecuteAfterTime(Rigidbody rb)
    //  {
    //      yield return new WaitForSeconds(2f);
    //      rb.useGravity = false;
    //      rb.position = position;
    //  }

}