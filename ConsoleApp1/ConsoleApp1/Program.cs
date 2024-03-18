using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] results = { "3:1", "2:2", "0:1", "4:2", "3:a", "3- 12" };
        Dictionary<string, uint> teamPoints = new Dictionary<string, uint>();

        foreach (var result in results)
        {
            string[] parts = result.Split(':');

            if (parts.Length != 2 || !uint.TryParse(parts[0], out uint team1Score) || !uint.TryParse(parts[1], out uint team2Score))
            {
                Console.WriteLine($"Ошибка в результате матча: {result}");
                continue;
            }

            string team1 = "Команда №1";
            string team2 = "Команда №2";

            if (team1Score > team2Score)
            {
                teamPoints.TryGetValue(team1, out uint currentPoints);
                teamPoints[team1] = currentPoints + 3;
            }
            else if (team1Score < team2Score)
            {
                teamPoints.TryGetValue(team2, out uint currentPoints);
                teamPoints[team2] = currentPoints + 3;
            }
            else
            {
                teamPoints.TryGetValue(team1, out uint team1CurrentPoints);
                teamPoints.TryGetValue(team2, out uint team2CurrentPoints);

                teamPoints[team1] = team1CurrentPoints + 1;
                teamPoints[team2] = team2CurrentPoints + 1;
            }
        }

        foreach (var pair in teamPoints)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value} очков");
        }
    }
}