﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Data  {
    public static string SkinName = "小篮";
    public const int SnakeLength=18;
    public const int SnakeKill = 0;
    public const string _Head = "SnakeHead";
    public const string obs = "obs";

    public static bool isGameOver = false;

    public const string _Food = "Food";
    public static int MySnakeLength;
    public static int MySnakeKill;
    public static bool isSpeedUp=false;
    public static void ResetData()
    {
        isGameOver = false;
        MySnakeLength=0;
        MySnakeKill = 0;
        isSpeedUp = false;
        Ranking.SnakeLength = new int[7];
    }

}
