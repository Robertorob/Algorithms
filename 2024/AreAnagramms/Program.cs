var testCases = new List<(string? word1, string? word2, bool result)>
{
    (null, null, false),
    ("", null, false),
    (null, "", false),
    ("", "", false),
    (" ", " ", false),
    ("  ", "    ", false),
    ("a", "a", true),
    ("aa", "aa", true),
    ("ab", "ba", true),
    ("aaabbbccc", "abcabcabc", true),
    ("aaabbbcc", "acabcabc", false),
    ("a", "b", false),
    ("ac", "ab", false),
};

bool isAllTestsSuccessful = true;
foreach(var testCase in testCases)
{
    if (AreAnagramms(testCase.word1, testCase.word2) != testCase.result)
    {
        Console.WriteLine($"Error in AreAnagramms: {testCase.word1}, {testCase.word2}");
        isAllTestsSuccessful = false;
    }
}

if (isAllTestsSuccessful)
{
    Console.WriteLine($"all tests are successfully passed");
}

/// Решение O(n)
static bool AreAnagramms(string? word1, string? word2)
{
    if (string.IsNullOrWhiteSpace(word1) || string.IsNullOrWhiteSpace(word2))
    {
        return false;
    }

    if (word1 == word2)
    {
        return true;
    }

    var charsAndCounts1 = new Dictionary<char, int>();
    var charsAndCounts2 = new Dictionary<char, int>();

    foreach (var char1 in word1)
    {
        if (!charsAndCounts1.ContainsKey(char1))
        {
            charsAndCounts1.Add(char1, 1);
            continue;
        }

        charsAndCounts1[char1]++;
    }

    foreach (var char2 in word2)
    {
        if (!charsAndCounts2.ContainsKey(char2))
        {
            charsAndCounts2.Add(char2, 1);
            continue;
        }

        charsAndCounts2[char2]++;
    }

    if (charsAndCounts1.Count != charsAndCounts2.Count)
    {
        return false;
    }

    foreach (var char1 in charsAndCounts1)
    {
        var char2Exists = charsAndCounts2.TryGetValue(char1.Key, out int char2Count);

        if (!char2Exists)
        {
            return false;
        }

        if (char1.Value != char2Count)
        {
            return false;
        }

        continue;
    }

    return true;
}