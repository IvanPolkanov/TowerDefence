using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



//
//
//   (^≗ω≗^) yea if ur here ur really want check my work

//   glad 2 s ths
//   thank bro
//    i hope this test project will be successful and i get job)))
//   (=^-ω-^=)
//  sorry for my poorly formatted code i was in a hurry with this test    


//   ฅ/ᐠ ‧̫‧ ᐟ\ฅ  hope ur love cats too)))
//
public static class SecretTowerContainer 
{
    private static List<GameObject> towers = new List<GameObject>();

    public static void ClearAll()
    {
        foreach (var temp in towers.ToList())
            GameObject.Destroy(temp);
    }

    public static void AddTower(GameObject tower)
    {
        towers.Add(tower);
    }

}
