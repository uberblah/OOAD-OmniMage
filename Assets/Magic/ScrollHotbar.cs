using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScrollHotbar : MonoBehaviour
{
    private const int scrollcap = 9;
    private Scroll[] scrolls = new Scroll[scrollcap];
    private int selected = 0;

    public Text text = null;

    void Start()
    {
        for (int i = 0; i < scrollcap; i++)
        {
            scrolls[i] = new Scroll();
        }
        //write the first default script
        scrolls[0].Add(new Symbol(null, Spell.OpLaunch));
        //write the second default script

    }

    public void select(int idx)
    {
        if (idx >= scrollcap || idx < 0) return;
        selected = idx;
    }

    public int getIndex()
    {
        return selected;
    }

    public void set(Scroll newScroll)
    {
        scrolls[selected] = newScroll;
    }

    public Scroll get()
    {
        return scrolls[selected];
    }

    void Update()
    {
        if (text != null)
        {
            string hud = "<<<Scrolls>>>\n";
            int i = 1;
            foreach (Scroll s in scrolls)
            {
                if (i - 1 == selected) hud += "Selected: ";
                hud += s.ToString() + " -- " + i.ToString() + "\n";
                i++;
            }
            text.text = hud;
        }
    }
}
