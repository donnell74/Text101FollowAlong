﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public Text text;
    private enum States {
        cell, mirror, sheets_0,
        locks_0, sheets_1, cell_mirror,
        lock_1, corridor_0, stairs_0,
        floor, closet_door, corridor_1,
        stairs_1, in_closet, corridor_2,
        stairs_2, corridor_3, courtyard
    };
    private States currentState;

    // Use this for initialization
    void Start()
    {
        currentState = States.cell;
    }

    // Update is called once per frame
    void Update()
    {
        print("Current state: " + currentState);
        switch (currentState)
        {
            // Ordered left to right from state diagram here:
            // https://docs.google.com/document/d/128_lD0Pp31TiKlIKnu8IgeaGWtBlRN_QL6GYvPyYULs/edit
            case States.cell:
                Cell();
                break;
            case States.sheets_0:
                Sheets_0();
                break;
            case States.mirror:
                Mirror();
                break;
            case States.locks_0:
                Lock_0();
                break;
            case States.cell_mirror:
                Cell_Mirror();
                break;
            case States.sheets_1:
                Sheets_1();
                break;
            case States.lock_1:
                Lock_1();
                break;
            case States.corridor_0:
                Corridor_0();
                break;
            default:
                break;
        }
    }

    private void Cell()
    {
        text.text = "You are in a prison cell, and you want to escape.  There are " +
                "some dirty sheets on the bed, a mirror on the wall, and the door" +
                "is locked from the outside.\n\n" +
                "Press S to view Sheets, M to view Mirror, L to view Lock";
        if (Input.GetKeyDown(KeyCode.S))
        {
            currentState = States.sheets_0;
        } else if (Input.GetKeyDown(KeyCode.M))
        {
            currentState = States.mirror;
        } else if (Input.GetKeyDown(KeyCode.L))
        {
            currentState = States.locks_0;
        }
    }

    private void Sheets_0()
    {
        text.text = "You can't believe you sleep in these things.  Surely it's " +
            "time somebody changed them.  The pleasures of prison life " +
            "I guess!\n\n" +
            "Press R to Return to roaming your cell";
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentState = States.cell;
        }
    }

    private void Mirror()
    {
        text.text = "Just a mirror.  Breaking it might make a nice shiv. " + 
                "Thinking about it, I wonder why the guards allow it in the " + 
                "cell.  Looks like I could take it off the wall.\n\n" +
                "Press R to Return to roaming your cell, T to Take the mirror";
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentState = States.cell;
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            currentState = States.cell_mirror;
        }
    }

    private void Lock_0()
    {
        text.text = "A lock on your cell, the only thing between me and freedom! " +
            "Maybe if I had something to see it at a better angle I might find " + 
            "a way to open it.\n\n" +
            "Press R to Return to roaming your cell";
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentState = States.cell;
        }
    }

    private void Cell_Mirror()
    {
        text.text = "I now have the mirror in my hand.\n\n" +
                "Press S to view Sheets, L to view Lock";
        if (Input.GetKeyDown(KeyCode.S))
        {
            currentState = States.sheets_1;
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            currentState = States.lock_1;
        }
    }


    private void Sheets_1()
    {
        text.text = "You can't believe you sleep in these things.  Surely it's " +
            "time somebody changed them.  The pleasures of prison life " +
            "I guess!\n\n" +
            "Press R to Return to roaming your cell";
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentState = States.cell_mirror;
        }
    }

    private void Lock_1()
    {
        text.text = "A lock on your cell, the only thing between you and freedom! " + 
            "With the mirror you can see the lock didn't fully click and can be opened " + 
            "without a key.\n\n" +
            "Press R to Return to roaming your cell, O to Open the lock";
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentState = States.cell_mirror;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            currentState = States.corridor_0;
        }
    }

    private void Corridor_0()
    {
        text.text = "You are in a corridor.  There is stairs to your right that leads " + 
            "up to where the guards are and freedom.  To your left is a closet with a " + 
            "locked door.\n\n" +
            "Press S for Stairs, C for closet, F to scan the Floor";
        if (Input.GetKeyDown(KeyCode.S))
        {
            currentState = States.stairs_0;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            currentState = States.closet_door;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            currentState = States.floor;
        }
    }
}
