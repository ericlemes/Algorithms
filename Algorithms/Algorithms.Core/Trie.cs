using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Core
{
    public class Trie
    {
        public int words;
        public int Words
        {
            get { return words; }            
        }

        private int prefixes;
        public int Prefixes
        {
            get { return prefixes; }
        }

        private char data;
        public char Data
        {
            get { return data; }
        }

        private List<Trie> edges = new List<Trie>();
        public List<Trie> Edges
        {
            get { return edges; }
        }

        public void Add(string word)
        {
            if (String.IsNullOrEmpty(word))
            {
                words++;
                return;
            }
            prefixes++;

            Trie child = FindChild(word[0]);
            if (child == null)
            {
                child = new Trie(word[0]);
                this.edges.Add(child);
            }
            if (word.Length > 1)
                child.Add(word.Substring(1));                               
        }

        public Trie FindChild(char c)
        {
            foreach (Trie t in this.edges)
                if (t.data == c)
                    return t;
            return null;
        }

        public Trie FindPrefix(string prefix)
        {
            if (String.IsNullOrEmpty(prefix))                            
                return null;

            Trie child = FindChild(prefix[0]);
            if (child == null)
                return null;

            if (prefix.Length > 1)
                return child.FindPrefix(prefix.Substring(1));
            else
                return child;
        }

        public Trie(char data)
        {
            this.data = data;
        }

        public Trie()
        {            
        }

        public List<string> EnumerateWords(string p)
        {
            List<string> result = new List<string>();
            Trie prefix = FindPrefix(p);
            if (prefix == null)
                return result;

            EnumerateWordsRecur(result, p, prefix);            

            return result;
        }

        private List<string> EnumerateWordsRecur(List<string> result, string prefix, Trie t)
        {
            foreach (Trie child in t.edges)
            {
                if (child.edges.Count <= 0)
                    result.Add(prefix + child.Data);
                EnumerateWordsRecur(result, prefix + child.Data, child);
            }
            return null;
        }
    }
}
