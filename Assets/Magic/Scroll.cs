using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Scroll : List<Symbol>
{
    public override string ToString()
    {
        return "<Scroll: " + Count.ToString() + " Symbols>";
    }
}
