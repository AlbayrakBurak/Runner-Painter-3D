using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{

     public List<GameObject> Players = new List<GameObject>();
     public List<Text> Rank = new List<Text>(11);

    void Update(){
        int SortByDistanceToMe(GameObject a, GameObject b) {
            float squaredRangeA = (a.transform.position - transform.position).sqrMagnitude;
            float squaredRangeB = (b.transform.position - transform.position).sqrMagnitude;
            return squaredRangeA.CompareTo(squaredRangeB);
        }
        Players.Sort(SortByDistanceToMe);
        for(int i=0; i<11;i++){
            Rank[i].text=Players[i].name;
        }
    if(Input.GetKey("escape")){
        Application.Quit();
    }
    }
}

