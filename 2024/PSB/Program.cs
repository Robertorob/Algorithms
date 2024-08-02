var testCases = new List<(string? bigString, string? smallString, int expectedResult)>
{
    (null, null, 0),
    ("", null, 0),
    (null, "", 0),
    ("", "", 0),
    ("", "abc", 0),
    ("a", "abc", 0),
    ("ab", "abc", 0),
    ("a____b", "abc", 0),
    ("a____b___c", "abc", 1),
    ("a_b_a_b_b__c__c", "abc", 10),
};

foreach (var testCase in testCases)
{
    int result = CalculateSubstringCount(testCase.bigString, testCase.smallString);

    if (testCase.expectedResult == result)
    {
        Console.WriteLine("Success");
    }
    else
    {
        Console.WriteLine("Error");
        Console.WriteLine($"input: {testCase.bigString}");
        Console.WriteLine($"output: {result}");
    }
}

static int CalculateSubstringCount(string? bigString, string? smallString)
{
    if (string.IsNullOrEmpty(bigString))
        return 0;

    if (string.IsNullOrEmpty(smallString))
        return 0;

    if (smallString.Length > bigString.Length)
        return 0;

    foreach (char c in smallString)
    {
        // int asdf = CalculateSubstringCountRecursive(bigString, c, 0);
    }

    return 777;
}

static int CalculateSubstringCountRecursive(char[] bigString, char charToFind, int index)
{
    return 123;
}
