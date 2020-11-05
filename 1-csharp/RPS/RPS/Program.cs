using System;
using System.Collections.Generic;

namespace RPS
{
    public class Program
    {
        static void Main(string[] args)
        {
            // in a .net program, paths will be relative to the location of the application dll (probably down in bin/Debug/(etc)).
            string filePath = "../../../data.json"; // should be next to this file.
            var persistence = new JsonFilePersistence(filePath);
            Console.WriteLine("Let's Play Rock Paper Scissors!");
            // Creates new instances of game and score
            var playerGame = new RPSgame();
            var playerScore = persistence.Read();
            playerScore.WinHappened += () => { Console.WriteLine("(win via event)"); };

            List<IAI> ais = GetAllAIs();
            var random = new Random();

            // Sets initial last user choice to null so AI knows not to consider
            string lastPlay = null;
            //Gather's user's initial choiuce
            Console.WriteLine("Choose rock (r), paper (p), or scissors(s). Enter x to quit.");
            string playerChoice = Console.ReadLine();
            // Loops through game until player chooses to quit.
            while (playerChoice != "x")
            {
                // randomly choose an AI to respond with
                IAI whichAi = ais[random.Next(ais.Count)];
                // Sends info to AI to choose play
                string comChoice = whichAi.ChooseRPS(lastPlay);
                // Sends player and AI choice to RPSgame to resolve win/loss
                playerGame.Play(playerChoice, comChoice, playerScore);
                // Updates last play for AI decision making
                lastPlay = playerChoice;
                // Prompts for more input/exiting game
                Console.WriteLine($"Your current record is: {playerScore.winCount} Wins - {playerScore.lossCount} Losses - {playerScore.tieCount} Ties ");
                Console.WriteLine("Play again? Choose r, p, s, or x to quit.");
                playerChoice = Console.ReadLine();
            }
            persistence.Write(playerScore);
        }

        static List<IAI> GetAllAIs()
        {
            //DelegateBasedAi.MoveChooser chooser;
            //chooser = AlwaysRock;
            //chooser = (string lastPlay) => { return "r"; };
            //chooser = x => "r";

            return new List<IAI>
            {
                new RandomAI(),
                new BeatPreviousAI(),
                new DelegateBasedAi(x => "r"), // always throws rock
                new DelegateBasedAi(x => x ?? "r") // always copies the player, unless null, then "r"
            };
        }

        //static string AlwaysRock(string lastPlay)
        //{
        //    return "r";
        //}
    }
}
