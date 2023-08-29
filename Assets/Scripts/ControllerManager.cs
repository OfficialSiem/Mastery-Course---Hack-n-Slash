using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    private List<Controller> controllers;

    private void Awake()
    {
        //Find all the controllers available
        controllers = FindObjectsOfType<Controller>().ToList();

        //Starting with the first, assign each controller a number (so Controller 1, Controller 2..3..4... etc.)
        int index = 1;
        foreach (var controller in controllers)
        {
            controller.SetIndex(index);
            index++;
        }
    }

    private void Update()
    {
        foreach (var controller in controllers)
        {
            if(controller.IsAssigned == false && controller.AnyButtonDown())
            {
                AsignControler(controller);
            }
        }
    }

    private void AsignControler(Controller controller)
    {
        controller.IsAssigned = true;
        Debug.Log("Assigned Controller: " + controller.gameObject.name);

        FindObjectOfType<PlayerManager>().AddPlayerToGame(controller);
    }
}
