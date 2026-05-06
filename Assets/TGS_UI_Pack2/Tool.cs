using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Tool 
{
   /* public class EditorTools : EditorWindow
    {
        [MenuItem("Window/BianJi")]
        static void BianJi()
        {
            Transform[] transforms = Selection.transforms;
            GameObject go= transforms[0].gameObject;

            for (int i = 0; i < 15; i++)
            {
                Vector3 pos = transforms[0].position;

                pos.x += (1.1f) * i;
                for (int j = 0; j < 10; j++)
                {
                    pos.z+= (1.1f) * j;
                    GameObject newGO=GameObject.Instantiate(go, pos,Quaternion.identity,go.transform.parent);
                    newGO.transform.eulerAngles = go.transform.eulerAngles;
                    pos.z = transforms[0].position.z;
                 }
            }
        }
    }*/
}
