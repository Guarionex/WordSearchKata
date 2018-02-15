using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverProject
{
    public class WordSearchPuzzle
    {
        public List<String> WordsList { get; }
        public Dictionary<Vector2, Char> LettersMap { get;}
        private Dictionary<String, List<Vector2>> wordMap;

        public WordSearchPuzzle()
        {
            WordsList = new List<String>();
            LettersMap = new Dictionary<Vector2, Char>();
            wordMap = new Dictionary<string, List<Vector2>>();
        }

        public void AddWord(String word)
        {
            WordsList.Add(word);
        }

        public void AddLetterAt(Char letter, int x, int y)
        {
            LettersMap.Add(new Vector2(x, y), letter);
        }

        public List<Vector2> GetAllLocationsOfLetter(Char letter)
        {
            List<Vector2> positions = LettersMap.Where(kvp => kvp.Value == letter).Select(kvp => kvp.Key).ToList();
            return positions;
        }

        public String GetStringFromLocationList(List<Vector2> locations)
        {
            throw new NotImplementedException();
        }
    }
}
