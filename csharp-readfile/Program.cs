using System;
using System.IO;
using System.Collections.Generic;

namespace csharp_readfile
{
    class Program
    {
        static void Main(string[] args)
        {
            string delim = "+";
            List<Team> teams = new List<Team>();
            string filename = "top3list.csv";

            using (var file = File.OpenRead(filename))
            {
                Console.WriteLine("Filename: {0}", filename);
                Console.WriteLine("Modified At: {0}", File.GetLastWriteTime(filename));
                Console.WriteLine();
				using (var reader = new StreamReader(file))
				{
					while (!reader.EndOfStream)
					{
						var line = reader.ReadLine();
						var values = line.Split(',');
                        Team t = new Team { name = values[0], super_bowl_wins = Convert.ToInt32(values[1]) };
                        teams.Add(t);
					}
				}
            }

            foreach (Team team in teams) 
            {
                int row_cnt = ("| Team: " + team.name + " |").Length - 2;
                string border = new string('-', row_cnt);
                Console.WriteLine("{0}{1}{0}", delim, border);
                Console.WriteLine("| Team: {0} |", team.name);
                int whitespace = ("| Super Bowl Wins: " + team.super_bowl_wins).Length;
                string str = new string(' ', row_cnt - whitespace);
                Console.WriteLine("| Super Bowl Wins: {0}{1} |", team.super_bowl_wins, str); 
                Console.WriteLine("{0}{1}{0}", delim, border);
                Console.WriteLine();
            }
        }
    }
}
