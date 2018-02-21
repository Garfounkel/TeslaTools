using System;
using System.Collections.Generic;
using System.Linq;

namespace TeslaTools
{
    class Bingo
    {
        private Random rand;

        public string StringSeed;
        public int IntSeed;
        public List<int> ScrollsList;
        public List<int>[,] BingoCard;


        public Bingo() { }

        public string GetRandomSeed()
        {
            Random randSeed = new Random();
            return (randSeed.Next() % 100000).ToString();
        }

        public void SetSeed()
        {
            IntSeed = 0;
            foreach (char c in StringSeed)
            {
                IntSeed += (c * c);
            }

            rand = new Random(IntSeed);
        }

        public List<int> GetRandomScrollList(int scrollNumber, List<int> AlreadyPickedScrolls)
        {
            ScrollsList = new List<int>();
            for (int i = 0; i < scrollNumber; i++)
            {
                int scroll = rand.Next(1, 37);
                if (ScrollsList.Contains(scroll) || AlreadyPickedScrolls.Contains(scroll))
                {
                    i--;
                }
                else
                {
                    ScrollsList.Add(scroll);
                }
            }

            return ScrollsList;
        }

        public string PrintList(List<int> list)
        {
            string s = "";
            foreach (int i in list)
            {
                if (i < 10)
                {
                    s += "  ";
                }
                s += (i) + ", ";
            }
            try
            {
                s = s.Remove(s.Length - 2);
            }
            catch (Exception) { }


            return s;
        }

        public void GenerateBingoCard()
        {
            BingoCard = new List<int>[5, 5];
            for (int i = 0; i < BingoCard.GetLength(0); i++)
            {
                for (int j = 0; j < BingoCard.GetLength(1); j++)
                {
                    if (IsDiagonal(i, j))
                    {
                        BingoCard[i, j] = GetRandomScrollList(3,
                            NotAvailableScrollsNormal(i, j).Concat(NotAvailableScrollsDiagonal(i, j)).ToList());
                    }
                    else
                    {
                        BingoCard[i, j] = GetRandomScrollList(3, NotAvailableScrollsNormal(i, j));
                    }
                }
            }
        }

        private bool IsDiagonal(int i, int j)
        {
            return i == j || i + j == 4;
        }

        private List<int> NotAvailableScrollsNormal(int i, int j)
        {
            List<int> NotAvailableScrollsList = new List<int>();
            for (int k = 0; k < BingoCard.GetLength(0); k++)
            {
                if (BingoCard[i, k] != null)
                {
                    NotAvailableScrollsList = NotAvailableScrollsList.Concat(BingoCard[i, k]).ToList();
                }
                if (BingoCard[k, j] != null)
                {
                    NotAvailableScrollsList = NotAvailableScrollsList.Concat(BingoCard[k, j]).ToList();
                }
            }

            return NotAvailableScrollsList;
        }

        private List<int> NotAvailableScrollsDiagonal(int i, int j)
        {
            List<int> NotAvailableScrollsList = new List<int>();
            if (i == j)
            {
                for (int k = 0; k < BingoCard.GetLength(0); k++)
                {
                    if (BingoCard[k, k] != null)
                    {
                        NotAvailableScrollsList = NotAvailableScrollsList.Concat(BingoCard[k, k]).ToList();
                    }
                }
            }
            if (i + j == 4)
            {
                int l = 4;
                for (int k = 0; k < BingoCard.GetLength(0); k++)
                {
                    if (BingoCard[k, l] != null)
                    {
                        NotAvailableScrollsList = NotAvailableScrollsList.Concat(BingoCard[k, l]).ToList();
                    }
                    l--;
                }
            }

            return NotAvailableScrollsList;
        }

        public string PrintBingoCard(List<int>[,] card)
        {
            string s = "";
            for (int i = 0; i < card.GetLength(0); i++)
            {
                for (int j = 0; j < card.GetLength(1); j++)
                {
                    s += " [" + PrintList(card[i, j]) + "] ";
                }
                s += Environment.NewLine;
            }

            return s;
        }

        public string GetScrollsAt(int i, int j)
        {
            string s = "";
            s += BingoCard[i, j][0] + ", ";
            s += BingoCard[i, j][1] + ", ";
            s += BingoCard[i, j][2];
            return s;
        }
    }
}
