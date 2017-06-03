using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster
{

    public enum Action { Tidy, Reset, EndTurn, EndGame, Undefined };

    public static Action NextAction(List<int> rolls)
    {
        Action nextAction = Action.Undefined;

        for (int i = 0; i < rolls.Count; i++)
        { // Step through rolls

            if (i == 20)
            {
                nextAction = Action.EndGame;
            }
            else if (i >= 18 && rolls[i] == 10)
            { // Handle last-frame special cases
                nextAction = Action.Reset;
            }
            else if (i == 19)
            {
                if (rolls[18] == 10 && rolls[19] == 0)
                {
                    nextAction = Action.Tidy;
                }
                else if (rolls[18] + rolls[19] == 10)
                {
                    nextAction = Action.Reset;
                }
                else if (rolls[18] + rolls[19] >= 10)
                {  // Roll 21 awarded
                    nextAction = Action.Tidy;
                }
                else
                {
                    nextAction = Action.EndGame;
                }
            }
            else if (i % 2 == 0)
            { // First bowl of frame
                if (rolls[i] == 10)
                {
                    rolls.Insert(i, 0); // Insert virtual 0 after strike
                    nextAction = Action.EndTurn;
                }
                else
                {
                    nextAction = Action.Tidy;
                }
            }
            else
            { // Second bowl of frame
                nextAction = Action.EndTurn;
            }
        }

        return nextAction;
    }



    //public enum Action
    //{
    //    None,
    //    Tidy,
    //    Reset,
    //    EndTurn,
    //    EndGame
    //}

    //private int[] bowls = new int[21];
    //private int bowl = 1;



    //public static Action NextAction(List<int> pinFalls)
    //{
    //    ActionMaster master = new ActionMaster();
    //    Action curretnAction = Action.None;

    //    foreach (var pinFall in pinFalls)
    //    {
    //        curretnAction = master.Bowl(pinFall);
    //    }

    //    return curretnAction;
    //}


    //private Action Bowl(int pins)
    //{
    //    if (pins < 0 || pins > 10)
    //    {
    //        throw new UnityException("Invalid pins!");
    //    }

    //    bowls[bowl - 1] = pins;

    //    if (bowl == 21)
    //    {
    //        return Action.EndGame;
    //    }

    //    // last frame special cases.
    //    if (bowl >= 19 && pins == 10)
    //    {
    //        bowl += 1;
    //        return Action.Reset;
    //    }
    //    else if (bowl == 20)
    //    {
    //        bowl += 1;
    //        if (bowls[19 - 1] == 10 && bowls[20 - 1] == 0)
    //        {
    //            return Action.Tidy;
    //        }
    //        else if (bowls[19 - 1] + bowls[20 - 1] == 10)
    //        {
    //            return Action.Reset;
    //        }
    //        else if (Bowl21Awarded())
    //        {
    //            return Action.Tidy;
    //        }
    //        else
    //        {
    //            return Action.EndGame;
    //        }
    //    }



    //    if (bowl % 2 != 0) // first bawl of frame (or end)
    //    {
    //        if (pins == 10)
    //        {
    //            bowl += 2;
    //            return Action.EndTurn;
    //        }
    //        bowl += 1;
    //        return Action.Tidy;
    //    }
    //    else if (bowl % 2 == 0) //  last bowl of frame
    //    {
    //        bowl += 1;
    //        return Action.EndTurn;
    //    }

    //    throw new UnityException("Don'r know what to return!");
    //}

    //private bool Bowl21Awarded()
    //{
    //    return bowls[18] + bowls[19] >= 10;
    //}


}
