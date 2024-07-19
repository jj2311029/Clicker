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
    [SerializeField] private Image criticalImage;

    static private int Gold = 0;

    [SerializeField] private Text CurGold;
    [SerializeField] private Text CurCriticalPercent;
    [SerializeField] private Text CurCriticalProduct;
    [SerializeField] private Text CurDamage;

    [SerializeField] private Image Store;

    public void SpawnSlime()
    {
        int spawnIndex =UnityEngine.Random.Range(0, slimes.Length);
        GameObject newSlime = Instantiate(slimes[spawnIndex].gameObject);
        curSlime = newSlime.GetComponent<Monster>();
    }
    private void Awake()
    {
        CurDamage.text = "Damage: " + damage.ToString();
        CurCriticalProduct.text = "Critical Damage: " + (criticalProduct * damage).ToString();
        CurCriticalPercent.text = "Critical Percent: " + criticalPercent.ToString() + "%";
        CurGold.text = "Gold: " + Gold;
    }
    private void Update()
    {
        if (curSlime == null)
        {
            SpawnSlime();
        }
        
        


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

    public void ChangeGoldAmount()
    {
        CurGold.text = "Gold: " + Gold.ToString();
    }

    private float Critical()
    {
        if(UnityEngine.Random.Range(0, 100)<= criticalPercent)
        {
            Debug.Log("Critical!");
            criticalImage.gameObject.SetActive(true);
            Invoke("HideImage", 0.1f);
            return damage*criticalProduct;
        }
        else
            return damage;
    }
    private void HideImage()
    {
        criticalImage.gameObject.SetActive(false);
    }

    public void OpenStore()
    {
        Store.gameObject.SetActive(true);
    }
    public void CloseStore()
    {
        Store.gameObject.SetActive(false);
    }

    public void UpCriticalPercent()
    {
        if(Gold <= 4) return;
        criticalPercent += 0.5f;
        Gold -= 5;

        CurGold.text = "Gold: " + Gold.ToString();
        CurCriticalPercent.text = "Critical Percent: " + criticalPercent.ToString() + "%";

    }
    public void UpCriticalDamage()
    {
        if (Gold <= 4) return;
        criticalProduct += 0.05f;
        Gold -= 5;

        CurGold.text = "Gold: " + Gold.ToString();
        CurCriticalProduct.text = "Critical Damage: " + (criticalProduct * damage).ToString();
    }
    public void UpDamage()
    {
        if (Gold <= 4) return;
        damage += 0.5f;
        Gold -= 5;

        CurGold.text = "Gold: " + Gold.ToString();
        CurDamage.text="Damage: "+damage.ToString();
        CurCriticalProduct.text = "Critical Damage: " + (criticalProduct * damage).ToString();
    }
    
}
