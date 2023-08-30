var testCases = new List<(int N, List<string> result)>
{
  (1, new(){ "()" }),
  (2, new(){ "(())",
        "()()" } ),
  (3, new(){ "((()))",
        "()()()",
        "()(())",
        "(())()",
        "(()())" })
};

foreach (var testCase in testCases)
{
  var result = GetCorrectBracketSequences(testCase.N);
  if (!Equal(result, testCase.result))
  {
    Console.WriteLine();
    Console.WriteLine("Error:");
    Console.WriteLine("N=" + testCase.N);
    Console.WriteLine(string.Join(":", result));
    Console.WriteLine(); 
  }
}

List<string> GetCorrectBracketSequences(int n)
{
  string s = "";
  List<string> result = new();
  GetSequence(n *2, 0, 0, 0, s, result);
  return result;
}

void GetSequence(int length, int open, int closed, int index, string s, List<string> result)
{
  if (index == length)
  {
    result.Add(s);
    return;
  }

  if (open == length / 2)
  {
    GetSequence(length, open, closed + 1, index + 1, s + ")", result);
    return;
  }

  if (open > 0 && closed > 0 && open == closed)
  {
    GetSequence(length, open + 1, closed, index + 1, s + "(", result);
    return;
  }

  if (open > 0 && open > closed && open < length / 2)
  {
    GetSequence(length, open, closed + 1, index + 1, s + ")", result);
    GetSequence(length, open + 1, closed, index + 1, s + "(", result);
    return;
  }

  GetSequence(length, open + 1, closed, index + 1, s + "(", result);
  return;

}

bool Equal(List<string> a, List<string> b)
{
  if (a.Count != b.Count)
    return false;

  foreach(string s in a)
  {
    if (!b.Contains(s)) return false;
  }

  return true;
}