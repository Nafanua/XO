using System;
using System.Collections.Generic;
using System.Linq;
using XO.Core.Abstracts;
using XO.Core.Enums;
using XO.Forms;

namespace XO.Core
{
    public class Ai : IAi
    {
        private readonly Random _random;
        public Complexity Complexity { get; }

        public Ai(Complexity complexity)
        {
            Complexity = complexity;
            _random = new Random();
        }

        public int Move(string[] field)
        {
            switch (Complexity)
            {
                case Complexity.Easy:
                    return SearchEasyMove(field);
                case Complexity.Normal:
                    return SearchHardMove(field, false);
                case Complexity.Unreal:
                    return SearchHardMove(field, true);
                default:
                    throw new ArgumentOutOfRangeException($"Ai complexity not set");
            }
        }

        private int SearchEasyMove(IList<string> field)
        {
            int pos;

            do
            {
                pos = _random.Next(0, 9);
            }
            while (field[pos] != null);

            return pos;
        }

        private int SearchHardMove(IList<string> field, bool isHard)
        {
            var possibleMoves = new List<int>(9);

            for (var i = 0; i < field.Count; i++)
            {
                if (field[i] == null)
                {
                    possibleMoves.Add(i);
                }
            }

            var winMove = FindMove(field, possibleMoves, GameField.X);

            if (winMove.HasValue)
            {
                return winMove.Value;
            }

            var defMove = FindMove(field, possibleMoves, GameField.O);

            if (defMove.HasValue)
            {
                return defMove.Value;
            }

            if (isHard)
            {
                var hardMode = HardMode(field);

                if (hardMode.HasValue)
                {
                    return hardMode.Value;
                }
            }

            return SearchEasyMove(field);
        }

        private int? HardMode(IList<string> field)
        {
            var corners = new int? [] {8, 2, 6, 0};

            return corners.FirstOrDefault(i => i != null && field[i.Value] == null);
        }

        private int? FindMove(IList<string> field, IEnumerable<int> possibleMoves, string turn)
        {
            foreach (var t in possibleMoves)
            {
                field[t] = turn;

                if (GameField.Win(field))
                {
                    field[t] = null;
                    return t;
                }

                field[t] = null;
            }

            return null;
        }
    }
}
