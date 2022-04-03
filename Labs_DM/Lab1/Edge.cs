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
            names.Add(Name);
            List<List<char>> sets = new List<List<char>>
            {
                new List<char>()
            };


            foreach (string name in names)
            {
                List<int> concat = new List<int>();
                for (int i = 0; i < sets.Count; i++)
                {
                    List<char> list = sets[i];
                    bool containsFrom = list.Contains(name[0]);
                    bool containsTo = list.Contains(name[1]);
                    if (containsFrom && containsTo)
                    {
                        return false;
                    }

                    if (containsFrom || containsTo)
                    {
                        concat.Add(i);
                        if (containsTo)
                        {
                            list.Add(name[0]);
                        }

                        if (containsFrom)
                        {
                            list.Add(name[1]);
                        }
                        break;
                    }
                }

                if (concat.Count == 0)
                {
                    sets.Add(new List<char>()
                        {
                            name[0], name[1]
                        });
                }
                else
                {
                    for (int i = concat[0]; i < sets.Count; i++)
                    {
                        List<char> list = sets[i];
                        bool containsFrom = list.Contains(name[0]);
                        bool containsTo = list.Contains(name[1]);
                        if (containsFrom || containsTo)
                        {
                            concat.Add(i);
                        }
                    }

                    List<List<char>> newSets = new List<List<char>>();
                    List<char> concatedList = new List<char>();
                    for (int i = 0; i < sets.Count; i++)
                    {
                        if (concat.Contains(i))
                        {
                            concatedList.AddRange(sets[i]);
                        }
                        else
                        {
                            newSets.Add(sets[i]);
                        }
                    }

                    newSets.Add(concatedList);
                    sets = newSets;
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
