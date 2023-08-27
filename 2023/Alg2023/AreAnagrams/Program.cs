var testCases = new List<(string? s1, string? s2, bool result)>
{
  (null, "", false),
  ("", "", false),
  ("", "abb", false),
  ("a", "aa", false),
  ("aa", "a", false),
  ("aab", "abb", false),
  ("cacabc", "cccaba", true),
  ("cacabc", "cccabaz", false),
  ("a", "a", true),
};

foreach (var testCase in testCases)
{
  bool result = AreAnagrams(testCase.s1, testCase.s2);
  if (testCase.result != result)
  {
    Console.Write("Error: ");
    Console.WriteLine(testCase.s1 + "|" + testCase.s2);
    continue;
  }

  Console.WriteLine("Success");
}

static bool AreAnagrams(string s1, string s2)
{
  if (s1 is null || s2 is null) return false;

  if (string.IsNullOrWhiteSpace(s1) || string.IsNullOrWhiteSpace(s2)) return false;

  if (s1.Length != s2.Length) return false;

  Dictionary<char, uint> s1Dict = new();
  Dictionary<char, uint> s2Dict = new();

  for(int i = 0; i < s1.Length; i++)
  {
    AddKeyOrIncrementValue(s1Dict, s1[i]);
    AddKeyOrIncrementValue(s2Dict, s2[i]);
  }

  foreach(var key in s1Dict.Keys)
  {
    if (!s2Dict.ContainsKey(key) || s2Dict[key] != s1Dict[key])
    {
      return false;
    }
  }

  return true;
}

static void AddKeyOrIncrementValue(Dictionary<char, uint> dict, char c) 
{
  if (!dict.ContainsKey(c))
  {
    dict.Add(c, 1);
  }
  else
  {
    dict[c]++;
  }
}