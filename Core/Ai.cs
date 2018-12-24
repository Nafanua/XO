using System;
using System.Collections.Generic;
using XO.Core.Abstracts;
using XO.Core.Enums;
using XO.Forms;

namespace XO.Core
{
    public class Ai : IAi
    {
        private readonly Random _random;
        private readonly List<int> _aiMoves;
        private readonly List<int> _enemyMoves;
        private readonly Complexity _complexity;
        public Complexity Complexity => _complexity;

        public Ai(Complexity complexity)
        {
            _complexity = complexity;
            _random = new Random();
            _aiMoves = new List<int>(5);
            _enemyMoves = new List<int>(4);
        }

        public int Move(string[] field)
        {
            switch (_complexity)
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

            _aiMoves.Add(pos);

            return pos;
        }

        private int SearchHardMove(IList<string> field, bool isHard)
        {
            _enemyMoves.Clear();

            for (var i = 0; i < field.Count; i++)
            {
                if (field[i] == GameField.O)
                {
                    _enemyMoves.Add(i);
                }
            }

            var winMove = FindMove(field, _aiMoves);

            if (winMove.HasValue)
            {
                _aiMoves.Add(winMove.Value);
                return winMove.Value;
            }

            var defMove = FindMove(field, _enemyMoves);

            if (defMove.HasValue)
            {
                _aiMoves.Add(defMove.Value);
                return defMove.Value;
            }

            if (isHard)
            {
                var hardMode = HardMode(field);

                if (hardMode.HasValue)
                {
                    _aiMoves.Add(hardMode.Value);
                    return hardMode.Value;
                }
            }

            return SearchEasyMove(field);
        }

        public void Clear()
        {
            _aiMoves.Clear();
        }

        private int? HardMode(IList<string> field)
        {
            if (field[8] == null)
            {
                return 8;
            }

            if (field[0] == null)
            {
                return 0;
            }

            if (field[6] == null)
            {
                return 6;
            }

            if (field[2] == null)
            {
                return 2;
            }

            return null;
        }

        private int? FindMove(IList<string> field, ICollection<int> moves)
        {
            if (((moves.Contains(0) && moves.Contains(2)) |
                (moves.Contains(7) && moves.Contains(4))) &
                field[1] == null)
            {
                return 1;
            }

            if (((moves.Contains(0) && moves.Contains(6)) |
                 (moves.Contains(4) && moves.Contains(5))) &
                field[3] == null)
            {
                return 3;
            }

            if (((moves.Contains(0) && moves.Contains(8)) |
                 (moves.Contains(2) && moves.Contains(6)) |
                 (moves.Contains(1) && moves.Contains(7)) |
                 (moves.Contains(3) && moves.Contains(5))) &
                field[4] == null)
            {
                return 4;
            }

            if (((moves.Contains(2) && moves.Contains(8)) |
                 (moves.Contains(3) && moves.Contains(4))) &
                field[5] == null)
            {
                return 5;
            }

            if (((moves.Contains(6) && moves.Contains(8)) |
                 (moves.Contains(1) && moves.Contains(4))) &
                field[7] == null)
            {
                return 7;
            }

            if (((moves.Contains(0) && moves.Contains(1)) |
                 (moves.Contains(8) && moves.Contains(5)) |
                 (moves.Contains(4) && moves.Contains(6))) &
                field[2] == null)
            {
                return 2;
            }

            if (((moves.Contains(1) && moves.Contains(2)) |
                 (moves.Contains(6) && moves.Contains(3)) |
                 (moves.Contains(8) && moves.Contains(4))) &
                field[0] == null)
            {
                return 0;
            }

            if (((moves.Contains(2) && moves.Contains(5)) |
                 (moves.Contains(7) && moves.Contains(6)) |
                 (moves.Contains(0) && moves.Contains(4))) &
                field[8] == null)
            {
                return 8;
            }

            if (((moves.Contains(7) && moves.Contains(8)) |
                 (moves.Contains(2) && moves.Contains(4)) |
                 (moves.Contains(0) && moves.Contains(3))) &
                field[6] == null)
            {
                return 6;
            }

            return null;
        }
    }
}
