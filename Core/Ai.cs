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

        private int SearchHardMove(IList<string> field, bool isUnreal)
        {
            var winMove = FindMove(field, GameField.X);

            if (winMove.HasValue)
            {
                return winMove.Value;
            }

            var defMove = FindMove(field, GameField.O);

            if (defMove.HasValue)
            {
                return defMove.Value;
            }

            if (isUnreal)
            {
                var unrealMove = UnrealMode(field);

                if (unrealMove.HasValue)
                {
                    return unrealMove.Value;
                }
            }

            return SearchEasyMove(field);
        }

        private int? UnrealMode(IList<string> field)
        {
            var corners = new int? [] {8, 2, 6, 0};

            return corners.FirstOrDefault(i => i != null && field[i.Value] == null);
        }

        private int? FindMove(IList<string> field, string turn)
        {
            for (var i = 0; i < field.Count; i++)
            {
                if (field[i] != null) continue;

                field[i] = turn;

                if (GameField.IsWin(field))
                {
                    field[i] = null;
                    return i;
                }

                field[i] = null;
            }

            return null;
        }
    }
}
