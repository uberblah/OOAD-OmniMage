using UnityEngine;
using System.Collections;

public struct Symbol
{
    public Sprite glyph;
    public Spell.Operation op;

    public Symbol(Sprite glyph, Spell.Operation op)
    {
        this.glyph = glyph;
        this.op = op;
    }
}
