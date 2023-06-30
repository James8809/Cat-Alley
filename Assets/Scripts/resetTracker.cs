using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetTracker : MonoBehaviour
{
    public List<GameObject> Alleys;
    private GameObject newAlley;
    public GameObject currentAlley;

    public void Spawn(){
        //selecting which alley to reset
        Debug.Log("Spawned");
        int alleySelected = Random.Range(0, Alleys.Count);
        Alleys[alleySelected].transform.position = currentAlley.GetComponent<AlleyMovement>().End.transform.position;
        Alleys[alleySelected].GetComponent<AlleyMovement>().enabled = true;
        foreach(GameObject cat in  Alleys[alleySelected].GetComponent<AlleyMovement>().Cats){
            cat.SetActive(true);
            var catCheck = cat.GetComponent<CatScript>();
            catCheck.enabled = true;
        }
        currentAlley = Alleys[alleySelected];
        Alleys.Remove(Alleys[alleySelected]);
    }
}
