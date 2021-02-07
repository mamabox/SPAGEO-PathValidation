using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathValidation : MonoBehaviour
{


    public List<GameObject> allItems = new List<GameObject>();
    public List<GameObject> gameObjetsCollected = new List<GameObject>();
    public GameObject itemPrefab;

    public List<float[]> path01 = new List<float[]>
    {
        new float[] {0,0},
        new float[] {0,1},
        new float[] {0,2}
    };

    public List<float[]> path02 = new List<float[]>
    {
        new float[] {0,0},
        new float[] {0,1},
        new float[] {0,2}
    };

    public float[,] path03 = { { 0, 0 }, { 0, 1 }, { 0, 2 } };

    public List<float[]> itemsCollectedID = new List<float[]>();


    // Start is called before the first frame update
    void Start()
    {

        foreach (GameObject item in GameObject.FindGameObjectsWithTag("collection"))
        {
            allItems.Add(item);
            item.GetComponent<IntersectionTracker>().instanceID = item.GetInstanceID();
        }
        ListAllItems();
        GenerateIntersections();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void ListAllItems()
    {
        int i = 1;

        foreach (GameObject item in allItems)
        {
            Debug.Log("Item " + i + " of " + allItems.Count + ": " + item.name + " at (" + item.transform.position.x + "," + item.transform.position.y + ")");
        }
    }

    private void GenerateIntersections()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Instantiate(itemPrefab, new Vector3(i * 10, 1, j * 10), itemPrefab.transform.rotation);
               
            }
        }
    }

    public void ValidatePath()
    {


        Debug.Log("Inside ValidatePath()");
        Debug.Log("Path 01: ");
        foreach (float[] itemID in path01)
        {
            Debug.Log("(" + itemID[0] + "," + itemID[1] + ")");
        }
        Debug.Log("Items collected: ");
        foreach (GameObject item in gameObjetsCollected)
        {
            Debug.Log("(" + item.GetComponent<IntersectionTracker>().intersectionID[0] + "," + item.GetComponent<IntersectionTracker>().intersectionID[1] + ")");
            itemsCollectedID.Add(new float[] { item.GetComponent<IntersectionTracker>().intersectionID[0], item.GetComponent<IntersectionTracker>().intersectionID[1] });

        }
        Debug.Log("Items collected ID: ");
        foreach (float[] item2 in itemsCollectedID)
        {
            Debug.Log("(" + item2[0] + "," + item2[1] + ")");
        }
        //Debug.Log ("Path validated? "+ CompareLists(path01, path02));
        Debug.Log ("Path validated? "+ CompareWithPath(gameObjetsCollected, path03));
    }

    public bool CompareWithPath(List<GameObject> collected, float[,] path)
    {
        Debug.Log(path03.GetLength(0));
        if (collected.Count != path.GetLength(0))
            return false;
        for (int i = 0; i < collected.Count; i++)
        {
            Debug.Log("list comparaison: " + "(" + collected[i].GetComponent<IntersectionTracker>().intersectionID[0] + "," + collected[i].GetComponent<IntersectionTracker>().intersectionID[1] + ") and (" + path[i,0] + "," + path[i,1]+ ")") ;
            if ((collected[i].GetComponent<IntersectionTracker>().intersectionID[0] != path[i, 0]) || (collected[i].GetComponent<IntersectionTracker>().intersectionID[1] != path[i, 1]))
                return false;
        }

        return true;
    }

    //public bool CompareLists(List<float[]> list1, List<float[]> list2)
    //{
    //    if (list1.Count != list2.Count)
    //        return false;
    //    for (int i = 0; i < list1.Count; i++)
    //    {
    //        Debug.Log("list comparaison: " + list1[i] + " and " + list2[i]);
    //            if (list1[i] != list2[i])
    //                return false;


    //    }

    //    return true;
    //}
}
