using UnityEngine;
using System.Collections;

public class Spell
{
    public delegate void Operation(Spell vm);

    protected Stack stack = new Stack();
    protected Scroll scroll = null;
    protected Scroll.Enumerator ip;
    public Operation onFailure = DefaultFailure;
    public Operation onFinish = DefaultFinish;

    public Object userdata;

    static void DefaultFailure(Spell vm)
    {
        Debug.Log(vm.Pop());
    }

    static void DefaultFinish(Spell vm)
    {
        Debug.Log(vm.ToString() + " has finished!\n");
    }

    public void SetScroll(Scroll newScroll)
    {
        scroll = newScroll;
        if (scroll == null) return;
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

    public int Size()
    {
        return stack.Count;
    }

    public static void Execute(Spell vm)
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

    public void Run()
    {
        if (scroll != null)
        {
            while (ip.MoveNext())
            {
                ip.Current.op(this);
            }
            scroll = null;
            onFinish(this);
        }
    }

    public bool IsRunning()
    {
        return scroll != null;
    }

    public override string ToString()
    {
        return "<Spell: " + (IsRunning() ? "Running " + scroll.ToString() : "Waiting") + ">";
    }

    public static void OpPushUserData(Spell s)
    {
        s.Push(s.userdata);
    }

    public static void OpPrintTop(Spell s)
    {
        Debug.Log(s.Pop());
    }

    public static void OpNop(Spell s)
    {
        
    }

    public static void OpLaunch(Spell s)
    {
        if (s.Size() < 1) return;
        object obj = s.Pop();
        if (obj == null) return;
        PlayerMove p = obj as PlayerMove;
        if (p == null) //if this isn't cast on a player
        {
            GameObject o = obj as GameObject;
            Rigidbody2D rb = o.GetComponent<Rigidbody2D>();
            if (rb == null) return;
            Vector3 targetpos = o.GetComponent<Transform>().position;
            targetpos.z = 0.0f;
            Vector3 bodypos = p.gameObject.GetComponent<Transform>().position;
            bodypos.z = 0.0f;
            rb.velocity = (targetpos - bodypos).normalized * 10.0f;
        }
        else
        {
            Rigidbody2D rb = p.gameObject.GetComponent<Rigidbody2D>();
            if (rb == null) return;
            Vector3 mousepos = Input.mousePosition;
            mousepos.z = 0.0f;
            Vector3 bodypos = p.gameObject.GetComponent<Transform>().position;
            bodypos.z = 0.0f;
            bodypos = Camera.main.WorldToScreenPoint(bodypos);
            rb.velocity = (mousepos - bodypos).normalized * 10.0f;
        }
    }
    //push the object the cursor is over
    public static void OpPushPointed(Spell s)
    {
        PlayerMove p = s.userdata as PlayerMove;
        Rigidbody2D rb = p.gameObject.GetComponent<Rigidbody2D>();
        Vector3 mousepos = Input.mousePosition;
        mousepos.z = 0.0f;
        mousepos = Camera.main.ScreenToWorldPoint(mousepos);
        Vector3 bodypos = p.gameObject.GetComponent<Transform>().position;
        bodypos.z = 0.0f;
        Vector2 dir = (mousepos - bodypos).normalized;
        RaycastHit2D[] hits = Physics2D.RaycastAll(new Vector2(bodypos.x, bodypos.y), dir, 1000.0f);
        if (hits == null) return;
        if (hits.Length < 1) return;
        RaycastHit2D hit = hits[0];
        s.Push(hit.collider.gameObject);
    }
}
