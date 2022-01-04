using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField]
    private Text levelText;
    [SerializeField]
    private Text statPointText;
    [SerializeField]
    private Text expText;
    [SerializeField]
    private Text statHpText;
    [SerializeField]
    private Text statDefText;
    [SerializeField]
    private Text statSpeedText;
    [SerializeField]
    private Text statAtkText;
    [SerializeField]
    private Text statRegenerationText;
    [SerializeField]
    private GameObject statHpButton;
    [SerializeField]
    private GameObject statDefButton;
    [SerializeField]
    private GameObject statSpeedButton;
    [SerializeField]
    private GameObject statAtkButton;
    [SerializeField]
    private GameObject statRegenerationButton;

    [SerializeField] private int level;
    [SerializeField] private int exp;
    private int maxExp;
    private int hp;
    private int statPoint;
    private int statHp;
    private int maxHp;
    private int statDef;
    private int def;
    private int statSpeed;
    private int speed;
    private int statAtk;
    private int damage;
    private int statRegeneration;
    private int regeneration;
    void Update()
    {
        CheckLevelUp();
        TextUpdate();
        CheckStatPoint();
    }
    void LevelUp()
    {
        level++;
        statPoint++;
    }
    void CheckLevelUp()
    {
        if(exp >= maxExp)
        {
            exp -= maxExp;
            maxExp++;
            LevelUp();
        }
    }
    void CheckStatPoint()
    {
        if(statPoint > 0)
        {
            statHpButton.SetActive(true);
            statDefButton.SetActive(true);
            statSpeedButton.SetActive(true);
            statAtkButton.SetActive(true);
            statRegenerationButton.SetActive(true);
        }
        else
        {
            statHpButton.SetActive(false);
            statDefButton.SetActive(false);
            statSpeedButton.SetActive(false);
            statAtkButton.SetActive(false);
            statRegenerationButton.SetActive(false);
        }
    }
    public void ExpUp(int addExp)
    {
        exp += addExp;
    }
    void TextUpdate()
    {
        levelText.text = string.Format("LV. {0}", level);
        statPointText.text = string.Format("SP. {0}", statPoint);
        expText.text = exp.ToString() + " / " + maxExp.ToString();
        statHpText.text = string.Format("HP Stat. {0}", statHp);
        statDefText.text = string.Format("DEF Stat. {0}", statDef);
        statSpeedText.text = string.Format("SPD Stat. {0}", statSpeed);
        statAtkText.text = string.Format("ATK Stat. {0}", statAtk);
        statRegenerationText.text = string.Format("REGEN Stat. {0}", statRegeneration);
    }
    public void UpStatHp()
    {
        if (statPoint <= 0) return;
        statPoint--;
        statHp++;
    }
    public void UpStatDef()
    {
        if (statPoint <= 0) return;
        statPoint--;
        statDef++;
    }
    public void UpStatSpeed()
    {
        if (statPoint <= 0) return;
        statPoint--;
        statSpeed++;
    }
    public void UpStatAtk()
    {
        if (statPoint <= 0) return;
        statPoint--;
        statAtk++;
    }
    public void UpStatRegeneration()
    {
        if (statPoint <= 0) return;
        statPoint--;
        statRegeneration++;
    }
    public void Damage(Level other)
    {
        hp -= other.damage; // ��ĳ����¡
    }
}
