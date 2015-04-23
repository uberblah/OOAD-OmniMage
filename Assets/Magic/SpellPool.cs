using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SpellPool : MonoBehaviour
{
    public Text text = null;

    private List<Spell> spells = new List<Spell>();
    public int nspells = 0;

    //all new spells will be initialized with this userdata
    private Object iuserdata = null;

    void Start()
    {
        setNSpells(nspells);
    }

    public int getNSpells() { return nspells; }
    //adds a spell to the pool without affecting other spells
    public void addSpell()
    {
        Spell newspell = new Spell();
        newspell.SetScroll(null); //no scroll, initially
        newspell.onFinish = this.notifyFinish;
        newspell.userdata = iuserdata;
        spells.Add(newspell);
    }
    //removes an unused or the last-index spell without affecting other spells
    public void removeSpell()
    {
        if (spells.Count < 1) return;
        foreach (Spell s in spells)
        {
            if (!s.IsRunning())
            {
                spells.Remove(s);
                return;
            }
        }
        spells.RemoveAt(spells.Count - 1);
    }
    //attempts to cast a given spell using spells in the pool
    public bool castSpell(Scroll scroll)
    {
        if (spells.Count < 1) return false;
        foreach (Spell s in spells)
        {
            if (!s.IsRunning())
            {
                s.SetScroll(scroll);
                s.onFinish = this.notifyFinish;
                s.Run();
                return true;
            }
        }
        return false;
    }
    //sets the number of spells in the pool, resetting all of them
    public void setNSpells(int newnspells)
    {
        nspells = newnspells;
        foreach (Spell s in spells)
        {
            s.onFinish = destroySpell; //the spell will self-destruct
        }
        spells = new List<Spell>();
        for (int i = 0; i < nspells; i++)
        {
            addSpell();
        }
    }

    private static void destroySpell(Spell s)
    {

    }

    private void notifyFinish(Spell s)
    {
        s.userdata = iuserdata;
    }

    private int getAvailable()
    {
        int available = 0;
        foreach (Spell s in spells)
        {
            if (!s.IsRunning()) available++;
        }
        return available;
    }
    //warning: overwrites all userdata!
    public void setInitUserData(Object newIUserData)
    {
        iuserdata = newIUserData;
        foreach (Spell s in spells)
        {
            s.userdata = iuserdata;
        }
    }

    void Update()
    {
        if (text != null)
        {
            string hud = "<<<Spells>>>\n";
            int i = 1;
            foreach (Spell s in spells)
            {
                hud += i.ToString() + " -- " + s.ToString() + "\n";
                i++;
            }
            text.text = hud;
        }
    }
}
