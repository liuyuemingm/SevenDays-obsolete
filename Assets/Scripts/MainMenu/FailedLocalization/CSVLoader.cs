using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class CSVLoader
{
    // Reference file
    private TextAsset csvFile;
    private char lineSeperator = '\n';
    private char surround = '"';
    private string[] fieldSeperator = { "\",\"" };

    public void LoadCSV()
    {
        csvFile = Resources.Load<TextAsset>("Localization(CSV)");
    }

    public Dictionary<string, string> GetDictionaryValues(string attributedId)
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        string[] lines = csvFile.text.Split(lineSeperator);
        int attributedIndex = -1;
        string[] headers = lines[0].Split(fieldSeperator, System.StringSplitOptions.None);

        for (int i=0; i<headers.Length; i++)
        {
            if (headers[i].Contains(attributedId))
            {
                attributedIndex = i;
                break;
            }
        }
        Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"'))");
        for (int i=1; i<lines.Length; i++)
        {
            string line = lines[i];
            string[] fields = CSVParser.Split(line);
            for(int f=0; f<fields.Length; f++)
            {
                fields[f] = fields[f].TrimStart(' ', surround);
                fields[f] = fields[f].TrimEnd(surround);
            }

            if (fields.Length > attributedIndex)
            {
                var key = fields[0];
                if (dictionary.ContainsKey(key)) { continue; }
                var value = fields[attributedIndex];
                dictionary.Add(key, value);
            }
        }

        return dictionary;
    }
}
