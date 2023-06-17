using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Humano : Unidade
{
    int sp, physEXP, magEXP;
    string classe;

    float hpGr, mpGr, strGr, magGr, dexGr, spdGr, luckGr, defGr, resGr, movGr;

    public delegate void KillExp(int eLvl);

    int lvl = 10; //nota: resolver heran�a ou arrumar o visual studio
    int exp = 40;

    public void ExpOnKill(int enemyLvl)
    {
        if ((lvl - enemyLvl) >= 15)
            exp += 1; 
        else
        {
            exp += 30 + (enemyLvl - lvl) * 2; //f�rmula de FE4. Ap�s a implementa��o de mais m�todos, trocar para f�rmula de FE6/7/8.
        }
        
        Debug.Log($"EXP: {exp}");

        if(exp >= 100)
        {
            lvl++;
            //OnLvlUp();
            exp -= 100;
            Debug.Log($"EXP: {exp}");
        }
    }

    private void Start()
    {
        KillExp delegateObject = new KillExp(ExpOnKill);
        delegateObject?.Invoke(12);
    }
}
