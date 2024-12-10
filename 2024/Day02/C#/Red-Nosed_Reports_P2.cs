using System;

class Red_Nosed_Reports_P2
{
	static bool IndividualCheck(int diff, int ChangeRate)
	{
		if (ChangeRate == -1 && diff <= -1 && diff >= -3)
			return true;
		else if (ChangeRate == 1 && diff >= 1 && diff <= 3)
			return true;
		return false;
	}
	static bool CheckerHelper(int[] Arr)
	{
		int Index = 1;
		int ChangeRate = 0;
		if (Arr[0] > Arr[1])
			ChangeRate = -1;
		else if (Arr[0] < Arr[1])
			ChangeRate = 1;
		if (ChangeRate == 0)
			return false;
		while (Index < Arr.Length)
		{
			if (!IndividualCheck(Arr[Index] - Arr[Index - 1], ChangeRate))
				return false;
			Index++;
		}
		return true;
	}

	static int[] CreatSubArray(int[] Arr, int Index)
	{
		int iter = 0;
		int add = 0;
		int[] Result = new int[Arr.Length - 1];
		while (iter < Result.Length)
		{
			if (iter + add != Index)
			{
				Result[iter] = Arr[iter + add];
				iter++;
			}
			else
				add += 1;
		}
		return Result;
	}

	static int CheckReportSafety(string Line)
	{
		int[] SubArray;
		int Index = 0;
		string[] Splitted = Line.Split(" ");
		int[] Levels = new int[Splitted.Length];
		foreach(string Element in Splitted)
			Levels[Index] = Convert.ToInt32(Splitted[Index++]);
		if (CheckerHelper(Levels))
				return 1;
		Index = 0;
		while(Index < Levels.Length)
		{
			SubArray = CreatSubArray(Levels, Index);
			if (CheckerHelper(SubArray))
				return 1;
			Index++;
		}
		return 0;
	}
	
	static int Main(string[] Args)
	{
		int Result = 0;

		string FileName = "input.txt";
		if (!File.Exists(FileName))
			return 1;
		string[] Lines = File.ReadAllLines(FileName);
		foreach(var Element in Lines)
			Result += CheckReportSafety(Element);
		Console.WriteLine(Result);
		return 0;
	}
}
