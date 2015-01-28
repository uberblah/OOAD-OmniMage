using UnityEngine;
using System.Collections;

public class MagicVM : MonoBehaviour
{
    public delegate void Operation(MagicVM vm);

    protected Stack stack = new Stack();
    protected MagicScroll scroll = null;
    protected MagicScroll.Enumerator ip;
    public Operation onFailure = DefaultFailure;

    static void DefaultFailure(MagicVM vm)
    {
        Debug.Log(vm.Pop());
    }

    public void SetScroll(MagicScroll newScroll)
    {
        scroll = newScroll;
        ip = scroll.GetEnumerator();
    }

    public object Pop()
    {
        return stack.Pop();
    }

    public void Push(object o)
    {
        stack.Push(o);
    }

    public static void Execute(MagicVM vm)
    {
        vm.Execute();
    }

    public void Execute()
    {
        object o = stack.Pop();
        Operation op = o as Operation;
        if (op == null)
        {
            stack.Push("EXECUTE:NOT_AN_OP(" + o.ToString() + ")");
            onFailure(this);
        }
    }

    void Update()
    {
        if (scroll != null)
        {
            ip.Current.op(this);
            if (!ip.MoveNext()) scroll = null;
        }
        else Destroy(this);
    }
}
