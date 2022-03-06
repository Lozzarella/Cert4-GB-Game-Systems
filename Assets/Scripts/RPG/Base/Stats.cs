using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Stats : Attributes
{
    [Serializable]//to bite down size to proccessed/saved + understands what is in a struct
    public struct BaseStat
    {
        public string name;
        public int value;
        public int modifier;
        public int tempValue;
    }
    public BaseStat[] baseStats = new BaseStat[6];
    public override void Start()//virtual is the base that you want to override, override to tweak what is in the base
    {
        base.Start();
        baseStats[0].name = "Strength";
        baseStats[1].name = "Dexterity";
        baseStats[2].name = "Constitution";
        baseStats[3].name = "Wisdom";
        baseStats[4].name = "Intelligence";
        baseStats[5].name = "Charisma";

    }
}
