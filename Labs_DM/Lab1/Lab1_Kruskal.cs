using System;
using System.Collections.Generic;
using System.Linq;
using Labs_DM.Shared;

namespace Labs_DM.Lab1
{
    public class Lab1_Kruskal
    {
        public static void Lab1_Execute()
        {
            int[][] array = FileHelper.ReadFromFile("Lab1/Files/l1_3.txt", true);
            char[] headers = StringHelper.GetNames(array.Length);

            List<List<Edge>> edges = new List<List<Edge>>();

            for (int i = 0; i < array.Length; i++)
            {
                edges.Add(new List<Edge>());
                for (int j = 0; j < array[i].Length; j++)
                {
                    edges[i].Add(new Edge(array[i][j], $"{headers[i]}{headers[j]}", j > i));
                }
            }

            edges.Display(headers);
            Console.WriteLine();
            

            int selectedCount = 0;
            while (selectedCount < edges.Count - 1)
            {
                var usedNodes = edges.GetSelected();

                edges
                    .SelectMany(x => x.Select(i => i))
                    .Where(x => x.Searchable
                        && x.Weight != 0
                        && !x.Selected
                        && x.IsNeeded(usedNodes))
                    .OrderBy(x => x.Weight).First().Selected = true;

                selectedCount = edges.GetSelected().Count();

                List<Edge> stepEdges = edges.GetSelected();

                edges.Display(headers);
                stepEdges.Display();
                Console.WriteLine($"Weidth: {stepEdges.Select(x => x.Weight).Sum()}");
                Console.WriteLine();
            }

        }
    }
}
