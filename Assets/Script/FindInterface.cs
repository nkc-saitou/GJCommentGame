using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindInterface : MonoBehaviour {

    public static T FindObjectOfInterfaces<T>() where T : class
    {
        List<T> list = new List<T>();

        foreach (var n in FindObjectsOfType<Component>())
        {
            var component = n as T;

            if (component != null)
            {
                return component;
            }
        }

        return null;
    }
}
