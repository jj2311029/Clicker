using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Monster : MonoBehaviour
{
    [SerializeField] private float maxHp;
    [SerializeField] private HpBar hpBar;
    private float curHp;
    [SerializeField] private Text MonsterName;
    [SerializeField] private string Name;


    private Animator animator;
    private bool isDead = false;

    private void Awake()
    {
        curHp = maxHp;
        MonsterName.text = Name;
        animator = GetComponent<Animator>();

    }

    public void OnHit(float damage)
    {
        curHp -= damage;
        animator.SetTrigger("Hit");
        hpBar.ChangeHpBarAmount(curHp/maxHp);
        if(isDead) return;
        if (curHp<=0)
        {
            curHp = 0;
            isDead = true;
            animator.SetTrigger("Death");
            GameManager gameManager= FindObjectOfType<GameManager>();
            if(Name=="red slime")
            {
                gameManager.GetGold(5);
            }
            else if(Name == "green slime")
            {
                gameManager.GetGold(1);
            }
            else
            {
                gameManager.GetGold(3);
            }
            gameManager.ChangeGoldAmount();
            
        }
        Debug.Log("Slime Hit!, Current Hp : " + curHp);

        if (isDead)
        {
            Debug.Log("Slime is Dead");
            Destroy(gameObject, 1.5f);
        }

    }
}
