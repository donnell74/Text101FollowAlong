using System;
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
            case States.stairs_0:
                Stairs_0();
                break;
            case States.closet_door:
                Closet_Door();
                break;
            case States.floor:
                Floor();
                break;
            case States.corridor_1:
                Corridor_1();
                break;
            case States.stairs_1:
                Stairs_1();
                break;
            case States.in_closet:
                In_Closet();
                break;
            case States.corridor_2:
                Corridor_2();
                break;
            case States.stairs_2:
                Stairs_2();
                break;
            case States.corridor_3:
                Corridor_3();
                break;
            case States.courtyard:
                Courtyard();
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

    private void Stairs_0()
    {
        text.text = "I am mid way up the stairs I can see a guard at the top.  This " + 
            "way isn't an option if I want this story to end in freedom.\n\n" +
            "Press R to Return to the corridor";
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentState = States.corridor_0;
        }
    }

    private void Closet_Door()
    {
        text.text = "A locked closest, wonder what is so important in there to lock it?\n\n" +
            "Press R to Return to the corridor";
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentState = States.corridor_0;
        }
    }

    private void Floor()
    {
        text.text = "What a gross floor.  Looks like there is a hairclip on the floor. " + 
            "I guess another man's trash is another's treasure!\n\n" +
            "Press R to Return to the corridor, H for Hairclip";
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentState = States.corridor_0;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            currentState = States.corridor_1;
        }
    }

    private void Corridor_1()
    {
        text.text = "You are in a corridor.  There is stairs to your right that leads " +
            "up to where the guards are and freedom.  To your left is a closet with a " +
            "locked door that you could pick with your hairpin.\n\n" +
            "Press S for Stairs, P for Picking the closet";
        if (Input.GetKeyDown(KeyCode.S))
        {
            currentState = States.stairs_1;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            currentState = States.in_closet;
        }
    }

    private void Stairs_1()
    {
        text.text = "I am mid way up the stairs I can see a guard at the top.  This " +
            "way isn't an option if I want this story to end in freedom.\n\n" +
            "Press R to Return to the corridor";
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentState = States.corridor_1;
        }
    }

    private void In_Closet()
    {
        text.text = "You are no in the closet, you see that there is guard uniforms " +
            "of all shapes and sizes.\n\n" + 
            "Press R to Return to the corridor, D to Dress up as a guard";
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentState = States.corridor_2;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            currentState = States.corridor_3;
        }
    }

    private void Corridor_2()
    {
        text.text = "You are in a corridor.  There is stairs to your right that leads " +
            "up to where the guards are and freedom.  To your left is the closet.\n\n" +
            "Press S for Stairs, C to go back into the Closet";
        if (Input.GetKeyDown(KeyCode.S))
        {
            currentState = States.stairs_2;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            currentState = States.in_closet;
        }
    }

    private void Stairs_2()
    {
        text.text = "I am mid way up the stairs I can see a guard at the top.  This " +
            "way isn't an option if I want this story to end in freedom.\n\n" +
            "Press R to Return to the corridor";
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentState = States.corridor_2;
        }
    }

    private void Corridor_3()
    {
        text.text = "You are in a corridor looking pretty spiffy as a guard, maybe " + 
            "that should be your job afterwards, that would be ironic.  Time to see " + 
            "if the guards are fooled by the dress up.\n\n" +
            "Press S for Stairs, U to Undress back to prison garb";
        if (Input.GetKeyDown(KeyCode.S))
        {
            currentState = States.courtyard;
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            currentState = States.in_closet;
        }
    }

    private void Courtyard()
    {
        text.text = "You walk right past the guards to freedom!  Press P to Play again.\n\n";
        if (Input.GetKeyDown(KeyCode.P))
        {
            currentState = States.cell;
        }
    }
}
