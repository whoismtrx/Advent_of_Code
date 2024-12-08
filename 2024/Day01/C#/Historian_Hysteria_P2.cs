class Historian_Hysteria_P2
{
	static bool NotInList(int number, LinkedList<int[]> List)
	{
		foreach(var elem in List)
		{
			if (elem[0] == number)
				return false;
		}
		return true;
	}

	static void CreateListFromArray(int[] LeftArray, LinkedList<int[]> List)
	{
		List.AddLast(new int[] {LeftArray[0], Array.FindAll(LeftArray, elm => elm == LeftArray[0]).Length});
		for (int i = 1; i < LeftArray.Length; i++)
		{
			if (NotInList(LeftArray[i], List))
				List.AddLast(new int[] {LeftArray[i], Array.FindAll(LeftArray, elm => elm == LeftArray[i]).Length});
		}
	}

	static int GetRelevantVal(int ToFind, LinkedList<int[]> RightList)
	{
		foreach (var elm in RightList)
			if (ToFind == elm[0])
				return elm[1];
		return 0;
	}

	static void	CreateArrayFromString(string[] Lines, int[] LeftArray, int[] RightArray)
	{
		int i = 0;
		string[] Current;
		while (i < Lines.Length)
		{
			Current = Lines[i].Split("   ");
			if (Current.Length != 2)
				break ;
			LeftArray[i] = Convert.ToInt32(Current[0]);
			RightArray[i] = Convert.ToInt32(Current[1]);
			i++;
		}
		return;
	}

    static int Main(string[] Args)
    {
		long result = 0;
		if (!File.Exists("input.txt"))
			return 1;
		string Text = File.ReadAllText("input.txt");
		string[] Lines = Text.Split('\n');
		int[] LeftArray = new int[Lines.Length - (Lines[Lines.Length - 1].Length == 0 ? 1 : 0)];
		int[] RightArray = new int[Lines.Length - (Lines[Lines.Length - 1].Length == 0 ? 1 : 0)];
		LinkedList<int[]> LeftOccurrenceList = new LinkedList<int[]>();
		LinkedList<int[]> RightOccurrenceList = new LinkedList<int[]>();
		CreateArrayFromString(Lines, LeftArray, RightArray);
		CreateListFromArray(LeftArray, LeftOccurrenceList);
		CreateListFromArray(RightArray, RightOccurrenceList);
		foreach (var elm in LeftOccurrenceList)
			result += elm[0] * elm[1] * GetRelevantVal(elm[0], RightOccurrenceList);
		Console.WriteLine(result);
		return 0;
	}
}