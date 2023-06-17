using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demonio : Unidade
{
    char atkType;
    bool canHoldWeapon, canWhisper;
    int skillCap, physAff, magAff, atkRng;
    string race;
    float sklMutRate;

    public delegate void KillExp(int eLvl);

    int lvl = 4; 
    int exp = 10;

    public void ExpOnKill(int enemyLvl)
    {
        if ((lvl - enemyLvl) >= 0)
            exp += 15;
        else
            exp += 20 + (enemyLvl - lvl) * 4; //Demonios ganharão mais exp da diferença de nível do que da base

        Debug.Log($"Demonio EXP: {exp}");

        if (exp >= 100)
        {
            lvl++;
            //OnLvlUp();
            exp -= 100;
            Debug.Log($"Demonio EXP: {exp}");
        }
    }

    private void Start()
    {
        KillExp delegateObject = new KillExp(ExpOnKill);
        delegateObject?.Invoke(10);
    }
}
