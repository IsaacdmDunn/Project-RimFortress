using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridBuildingSystem : MonoBehaviour
{
    public Material AllowedPlacementMaterial;
    public Material DisallowedPlacementMaterial;
    RaycastHit hit;
    Vector3 offsetMovePoint;
    public GameObject prefab;
    public GameObject ParentOBJ;
    bool placable = true;

    void Start()
    {
        
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 50000.0f, 1 << 7))
        {
            transform.position = new Vector3(Mathf.Round(hit.point.x),
                                            1 + offsetMovePoint.y + offsetMovePoint.y,
                                            Mathf.Round(hit.point.z));
            placable = false;
            GetComponent<MeshRenderer>().material = DisallowedPlacementMaterial;
        }
        else if (Physics.Raycast(ray, out hit, 50000.0f, 1 << 8))
        {
            transform.position = new Vector3(Mathf.Round(hit.point.x),
                                            1+offsetMovePoint.y,
                                            Mathf.Round(hit.point.z));

            GetComponent<MeshRenderer>().material = AllowedPlacementMaterial;
        } 

        if (Input.GetMouseButton(0) && placable)
        {
            Instantiate(prefab, transform.position, transform.rotation, GameObject.FindWithTag("Blocks").transform);

        }
        else if (Input.GetMouseButtonDown(1))
        {
            Destroy(gameObject);
            
        }
        offsetMovePoint.y += Input.mouseScrollDelta.y;

        placable = true;
    }

}