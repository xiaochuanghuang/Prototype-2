using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetsManager 
{
    private static Dictionary<int, Sprite> dic;

    static AssetsManager()
    {
        dic = new Dictionary<int, Sprite>();
        Sprite[] arr = Resources.LoadAll<Sprite>("Images");
        foreach(Sprite item in arr)
        {
            int name = int.Parse(item.name);
            dic.Add(name, item);
        }
    }
    public static Sprite getImg(int n)
    {
        return dic[n];
    }
}
