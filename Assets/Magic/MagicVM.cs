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

    public bool IsRunning()
    {
        return scroll != null;
    }

    public object Pop()
    {
        return stack.Pop();
    }

    public void Push(object o)
    {
        stack.Push(o);
    }

    void Update()
    {
        if (scroll != null)
        {
            ip.Current.op(this);
            if (!ip.MoveNext()) scroll = null;
        }
    }
}
