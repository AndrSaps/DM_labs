using System.Collections.Generic;
using System.Linq;

namespace Labs_DM.Lab1
{
    public class Edge
    {
        public readonly int Weight;
        public readonly string Name;

        public bool Selected { get; set; } = false;
        public readonly bool Searchable;

        public Edge(int weidth, string name, bool searchable)
        {
            Weight = weidth;
            Name = name;
            Searchable = searchable;
        }

        public bool IsNeeded(List<Edge> usedNodes)
        {
            List<string> names = usedNodes.Select(x => x.Name).ToList();
            string set = Name;

            foreach (string name in names)
            {
                string newSet = new string((set + name).Distinct().ToArray());
                if (newSet == set)
                {
                    return false;
                }
            }

            return true;
        }
    }

    public static class EdgeExtension
    {
        public static List<Edge> GetSelected(this List<List<Edge>> array)
        {
            return array
                .SelectMany(row => row.Select(x => x))
                .Where(edge => edge.Selected)
                .ToList();
        }
    }
}
