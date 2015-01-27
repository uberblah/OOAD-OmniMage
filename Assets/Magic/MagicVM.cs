using UnityEngine;
using System.Collections;

public class MagicVM : MonoBehaviour
{
    public delegate void Operation(MagicVM vm);

    protected Stack stack;
    protected MagicScroll scroll;
    protected MagicScroll.Enumerator ip;

    public void SetScroll(MagicScroll newScroll)
    {
        scroll = newScroll;
        ip = scroll.GetEnumerator();
    }

    protected virtual void Update()
    {
        //TODO: execute a single instruction
    }
}
