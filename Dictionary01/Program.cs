using System;
using System.Collections.Generic;
using System.IO;

namespace Dictionary01 {
    class Program {
        static void Main(string[] args) {
            Dictionary<string, int> Voting = new Dictionary<string, int>();
            try {
                Console.WriteLine("Enter the full path:");
                string path = Console.ReadLine();
                using (StreamReader sr = File.OpenText(path)) {
                    while (!sr.EndOfStream) {
                        string[] lines = sr.ReadLine().Split(',');
                        string candidate = lines[0];
                        int votes = int.Parse(lines[1]);
                        if (Voting.ContainsKey(candidate)) {
                            Voting[candidate] += votes;
                        }
                        else {
                            Voting[candidate] = votes;
                        }
                    }
                }
                foreach (KeyValuePair<string, int> item in Voting) {
                    Console.WriteLine(item.Key + ": " + item.Value);
                }
            }
            catch (IOException e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
