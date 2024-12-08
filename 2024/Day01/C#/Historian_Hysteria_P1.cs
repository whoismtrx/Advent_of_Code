using System;

class Historian_Hysteria_P1
{
	static int	Abs(int number)
	{
		if (number < 0)
			number *= -1;
		return (number);
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
		CreateArrayFromString(Lines, LeftArray, RightArray);
		Array.Sort(LeftArray);
		Array.Sort(RightArray);
		for(int i = 0; i < RightArray.Length;i++)
			result += Abs(LeftArray[i] - RightArray[i]);
		Console.WriteLine(result);
		return 0;
	}
}
