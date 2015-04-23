using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SymbolRegistry
{
    private static Dictionary<string, Symbol> registry = new Dictionary<string, Symbol>();

    public static void register(string name, Symbol symbol)
    {
        registry[name] = symbol;
    }

    public static void unregister(string name)
    {
        registry.Remove(name);
    }

    public static Symbol get(string name)
    {
        return registry[name];
    }

    public static Symbol randomSymbol()
    {
        Symbol[] regcpy = new Symbol[registry.Count];
        int ins = 0;
        foreach(KeyValuePair<string, Symbol> i in registry)
        {
            regcpy[ins] = i.Value;
            ins++;
        }
        int sel = Random.Range(0, registry.Count);
        return regcpy[sel];
    }
}
