using System;

class Red_Nosed_Reports_P1
{
	static bool CheckerHelper(int[] Arr, int Index, int ChangeRate)
	{
		if (Index == 0)
			return true;
		if (ChangeRate == -1)
		{
			if (Arr[Index] - Arr[Index - 1] <= -1 && Arr[Index] - Arr[Index - 1] >= -3)
				return true;
		}
		else 
		{
			if (Arr[Index] - Arr[Index - 1] <= 3 && Arr[Index] - Arr[Index - 1] >= 1)
				return true;
		}
		return false;
	}

	static int CheackReportSafty(string Line)
	{
		int ChangeRate = 1;
		int Index = 0;
		string[] Splited = Line.Split(" ");
		if (Convert.ToInt32(Splited[0]) > Convert.ToInt32(Splited[1]))
			ChangeRate = -1;
		int[] Levels = new int[Splited.Length];
		foreach(var Element in Levels)
		{
			Levels[Index] = Convert.ToInt32(Splited[Index]);
			if (!CheckerHelper(Levels, Index, ChangeRate))
				return 0;
			Index++;
		}
		return 1;
	}
	static int Main(string[] Args)
	{
		int Result = 0;

		string FileName = "input.txt";
		if (!File.Exists(FileName))
			return 1;
		string[] Lines = File.ReadAllLines(FileName);
		foreach(var Element in Lines)
			Result += CheackReportSafty(Element);
		Console.WriteLine(Result);
		return 0;
	}
}
