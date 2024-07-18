using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Monster[] slimes;
    [SerializeField] private float damage;
    private Monster curSlime;

    [SerializeField] float criticalPercent;
    [SerializeField] float criticalProduct;

    static private int Gold = 0;

    [SerializeField] private Text CurGold;
    [SerializeField] private Text CurCriticalPercent;
    [SerializeField] private Text CurCriticalProduct;

    public void SpawnSlime()
    {
        int spawnIndex =UnityEngine.Random.Range(0, slimes.Length);
        GameObject newSlime = Instantiate(slimes[spawnIndex].gameObject);
        curSlime = newSlime.GetComponent<Monster>();
    }

    private void Update()
    {
        if (curSlime == null)
        {
            SpawnSlime();
        }
        CurGold.text = "Gold: "+Gold.ToString();

        CurCriticalPercent.text = "Critical Percent: " + criticalPercent.ToString();

        CurCriticalProduct.text = "Critical Product: " + criticalProduct.ToString();

    }
    public void HitSlime()
    {
        if (curSlime != null)
        {
            curSlime.OnHit(Critical());
        }
    }

    public void GetGold(int n)
    {
        Gold += n;
        Debug.Log("Gold: "+Gold);
    }

    private float Critical()
    {
        if(UnityEngine.Random.Range(0, 100)<= criticalPercent)
        {
            Debug.Log("Critical!");
            return damage*criticalProduct;
        }
        else
            return damage;
    }


}
