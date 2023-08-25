var testCases = new List<(uint[]? array, uint result)>
{
  (array: new uint[] { 1, 1, 0, 1, 1, 1, 0, 0, 0, 0 }, result: 3),
  (array: new uint[] { 1, 0, 1, 0 }, result: 1),
  (array: new uint[] { 0, 0 }, result: 0),
  (array: null, result: 0),
  (array: new uint[] { }, result: 0),
  (array: new uint[] { 1, 1, 1 }, result: 3),
  (array: new uint[] { 1 }, result: 1),
  (array: new uint[] { 0 }, result: 0),
};

foreach(var testCase in testCases)
{
  uint result = GetLengthOfLongestOneSequence(testCase.array);
  if (testCase.result != result)
  {
    Console.WriteLine("Error " + string.Join(',', testCase.array));
  }
  else
  {
    Console.WriteLine("Success!");
  }
}


static uint GetLengthOfLongestOneSequence(uint[]? array)
{
  if (array is null)
    return 0;

  if (array.Length == 0)
    return 0;

  uint result = 0;
  uint counter = 0;
  for(int i = 0; i < array.Length; i++)
  {
    if (array[i] == 1)
    {
      counter++;
      continue;
    }

    if (array[i] == 0)
    {
      if (counter > result)
        result = counter;

      counter = 0;
      continue;
    }
  }

  if (counter > result)
    result = counter;

  return result;
}
