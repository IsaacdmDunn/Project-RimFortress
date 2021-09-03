using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 50000.0f, 1 << 7) && Input.GetMouseButton(0))
        {
            transform.position = new Vector3(Mathf.Round(hit.point.x),
                                            1,
                                            Mathf.Round(hit.point.z));
            Destroy(hit.transform.gameObject);
        }
        else if (Physics.Raycast(ray, out hit, 50000.0f, 1 << 8))
        {
            transform.position = new Vector3(Mathf.Round(hit.point.x),1,
                                            Mathf.Round(hit.point.z));
        }
        if (Input.GetMouseButtonDown(1))
        {
            Destroy(gameObject);

        }
    }
}
