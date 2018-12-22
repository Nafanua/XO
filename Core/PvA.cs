using System;
using System.Collections.Generic;
using System.Linq;
using XO.Core.Abstracts;

namespace XO.Core
{
    public class PvA : IGame
    {
        private readonly Random _random;

        private readonly List<int> _aiMoves;

        private readonly List<int> _playerMoves;

        private readonly int _complexity;

        public PvA(int complexity)
        {
            _complexity = complexity;
            _random = new Random();
            _aiMoves = new List<int>(5);
            _playerMoves = new List<int>(5);
        }

        public int Game(string[] field)
        {
            switch (_complexity)
            {
                case 0:
                    return SearchEasyMove(field);
                case 1:
                    return SearchHardMove(field, false);
                default:
                    return SearchHardMove(field, true);
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

            field[pos] = "X";

            return pos;
        }

        private int SearchHardMove(IList<string> field, bool isHard)
        {
            if (field.All(i => i == null) && isHard)
            {
                field[8] = "X";

                _aiMoves.Add(8);

                return 8;
            }

            for (var i = 0; i < field.Count; i++)
            {
                if (field[i] == "O")
                {
                    _playerMoves.Add(i);
                }
            }

            var winMove = FindMove(field, _aiMoves);

            if (winMove.HasValue)
            {
                _aiMoves.Add(winMove.Value);
                return winMove.Value;
            }

            var defMove = FindMove(field, _playerMoves);

            if (defMove.HasValue)
            {
                _aiMoves.Add(defMove.Value);
                return defMove.Value;
            }

            if (field[0] == null && isHard)
            {
                field[0] = "X";
                _aiMoves.Add(0);
                return 0;
            }

            if (field[6] == null && isHard)
            {
                field[6] = "X";
                _aiMoves.Add(6);
                return 6;
            }

            if (field[2] == null && isHard)
            {
                field[2] = "X";
                _aiMoves.Add(2);
                return 2;
            }

            return SearchEasyMove(field);
        }

        public void Clear()
        {
            _playerMoves.Clear();
            _aiMoves.Clear();
        }

        private int? FindMove(IList<string> field, ICollection<int> moves)
        {
            if (((moves.Contains(0) && moves.Contains(2)) |
                (moves.Contains(7) && moves.Contains(4))) &
                field[1] == null)
            {
                field[1] = "X";
                return 1;
            }

            if (((moves.Contains(0) && moves.Contains(6)) |
                 (moves.Contains(4) && moves.Contains(5))) &
                field[3] == null)
            {
                field[3] = "X";
                return 3;
            }

            if (((moves.Contains(0) && moves.Contains(8)) |
                 (moves.Contains(2) && moves.Contains(6)) |
                 (moves.Contains(1) && moves.Contains(7)) |
                 (moves.Contains(3) && moves.Contains(5))) &
                field[4] == null)
            {
                field[4] = "X";
                return 4;
            }

            if (((moves.Contains(2) && moves.Contains(8)) |
                 (moves.Contains(3) && moves.Contains(4))) &
                field[5] == null)
            {
                field[5] = "X";
                return 5;
            }

            if (((moves.Contains(6) && moves.Contains(8)) |
                 (moves.Contains(1) && moves.Contains(4))) &
                field[7] == null)
            {
                field[7] = "X";
                return 7;
            }

            if (((moves.Contains(0) && moves.Contains(1)) |
                 (moves.Contains(8) && moves.Contains(5)) |
                 (moves.Contains(4) && moves.Contains(6))) &
                field[2] == null)
            {
                field[2] = "X";
                return 2;
            }

            if (((moves.Contains(1) && moves.Contains(2)) |
                 (moves.Contains(6) && moves.Contains(3)) |
                 (moves.Contains(8) && moves.Contains(4))) &
                field[0] == null)
            {
                field[0] = "X";
                return 0;
            }

            if (((moves.Contains(2) && moves.Contains(5)) |
                 (moves.Contains(7) && moves.Contains(6)) |
                 (moves.Contains(0) && moves.Contains(4))) &
                field[8] == null)
            {
                field[8] = "X";
                return 8;
            }

            if (((moves.Contains(7) && moves.Contains(8)) |
                 (moves.Contains(2) && moves.Contains(4)) |
                 (moves.Contains(0) && moves.Contains(3))) &
                field[6] == null)
            {
                field[6] = "X";
                return 6;
            }

            return null;
        }
    }
}
