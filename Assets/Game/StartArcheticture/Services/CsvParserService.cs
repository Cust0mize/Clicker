﻿using System.Linq;
using UnityEngine;

namespace Assets.Game.StartArcheticture.Services {
    public class CsvParserService {
        public static string[,] SplitCsvGrid(string csvText) {
            string[] lines = csvText.Split("\n"[0]);

            int width = 0;
            for (int i = 0; i < lines.Length; i++) {
                string[] row = SplitCsvLine(lines[i]);
                width = Mathf.Max(width, row.Length);
            }

            string[,] outputGrid = new string[width + 1, lines.Length + 1];
            for (int y = 0; y < lines.Length; y++) {
                string[] row = SplitCsvLine(lines[y]);
                for (int x = 0; x < row.Length; x++) {
                    outputGrid[x, y] = row[x];

                    outputGrid[x, y] = outputGrid[x, y].Replace("\"\"", "\"");
                }
            }

            return outputGrid;
        }

        public static string[] SplitCsvLine(string line) {
            return (from System.Text.RegularExpressions.Match m in System.Text.RegularExpressions.Regex.Matches(line,
            @"(((?<x>(?=[,\r\n]+))|""(?<x>([^""]|"""")+)""|(?<x>[^,\r\n]+)),?)",
            System.Text.RegularExpressions.RegexOptions.ExplicitCapture)
                    select m.Groups[1].Value).ToArray();
        }

        public static string TextReplacer(string text) {
            return text.Replace("<zp>", ",");
        }
    }

    public class LocalizationLoaderParceService {
        public static string ReplaceText(string text) {
            return text.Replace(",", "<zp>");
        }
    }
}