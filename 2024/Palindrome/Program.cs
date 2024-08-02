var testCases = new List<(string? word, bool result)>
{
    (null, false),
    ("", true),
    ("a", true),
    ("aa", true),
    ("aaaaaaaa", true),
    ("abc", false),
    ("abba", true),
    ("aba", true),
    ("abA", false),
};

foreach (var testCase in testCases)
{
    if (IsPalindrome(testCase.word) != testCase.result)
    {
        Console.WriteLine($"IsPalindrome: wrong answer at: '{testCase.word}'");
    }

    if (IsPalindrome2(testCase.word) != testCase.result)
    {
        Console.WriteLine($"IsPalindrome2: wrong answer at: '{testCase.word}'");
    }
}

// Решение с использованием Reverse
static bool IsPalindrome(string? word)
{
    if (word is null)
    {
        return false;
    }

    if (word == "")
    {
        return true;
    }

    if (word.Length == 1)
    {
        return true;
    }

    string reversedString = new string(word.Reverse().ToArray());
    return word == reversedString;
}

// Решение без Reverse
static bool IsPalindrome2(string? word)
{
    if (word is null)
    {
        return false;
    }

    if (word == "")
    {
        return true;
    }

    if (word.Length == 1)
    {
        return true;
    }

    int j = word.Length - 1;
    for (int i = 0; i< word.Length; i++)
    {
        if (i >= j)
        {
            break;
        }

        if (word[i] != word[j])
        {
            return false;
        }

        j--;
    }

    return true;
}
