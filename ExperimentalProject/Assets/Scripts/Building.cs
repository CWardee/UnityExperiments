using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public GameObject buildingBlock;
    bool enableBuilding = false;

    public void toggleBuilding()
    {
        if (enableBuilding)
        {
            enableBuilding = false;
            buildingBlock.SetActive(false);
        }

        else
        {
            enableBuilding = true;
            buildingBlock.SetActive(true);
        }
    }

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(enableBuilding)
            {
                enableBuilding = false;
                buildingBlock.SetActive(false);
            }

            else
            {
                enableBuilding = true;
                buildingBlock.SetActive(true);
            }
        }

        if(enableBuilding)
        {

            // Bit shift the index of the layer (8) to get a bit mask
            int layerMask = 1 << 8;

            // This would cast rays only against colliders in layer 8.
            // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
            layerMask = ~layerMask;

            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Did Hit");

         
                Vector3 hitPos = hit.point;
                //Instantiate(buildingBlock, new Vector3(hitPos.x, hitPos.y, hitPos.z), Quaternion.identity);

                buildingBlock.transform.position = new Vector3(hitPos.x, hitPos.y, hitPos.z);

                if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
                {
                    buildingBlock.transform.eulerAngles += new Vector3(0.0f, 5, 0.0f);
                }

                else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
                {
                    buildingBlock.transform.eulerAngles += new Vector3(0.0f, -5, 0.0f);
                }

                if (hit.collider.gameObject.tag == "Block")
                {
                    Debug.Log("Hit Cube");
                }

                if (Input.GetMouseButtonDown(0))
                {
                    Instantiate(buildingBlock, new Vector3(hitPos.x, hitPos.y, hitPos.z), buildingBlock.transform.rotation);
                    Debug.Log("Held");
                }
            }

            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                Debug.Log("Did not Hit");
            }

        }
    }
}
