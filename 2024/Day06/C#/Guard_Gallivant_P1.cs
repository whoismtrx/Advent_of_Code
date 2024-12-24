using System;

class Guard_Gallivant_P1 {

	static char SetGuardPointOfView(char CurrentPointOfView)
	{
		string reference = "<>^v";
		string results = "^v><";
		for(int i =0; i < 4;i++)
			if (CurrentPointOfView == reference[i])
				return (results[i]);
		return CurrentPointOfView;
	}

	static void SetPointModifiers(char GuardCharacter, ref int xModifier, ref int yModifier)
	{
		if (GuardCharacter == 'v')
			yModifier = 1;
		else if (GuardCharacter == '^')
			yModifier = -1;
		else if (GuardCharacter == '>')
			xModifier = 1;
		else if (GuardCharacter == '<')
			xModifier = -1;
	}

	static bool IsInRange(char[][] Lines, int y, int x)
	{
		if (y < 0 || y >= Lines.Length)
			return false;
		if (x < 0 || x >= Lines[y].Length)
			return false;
		return true;
	}

	static int CountPatrolPathPoints(char[][] lines)
	{
		int result = 0;
		for (int y = 0; y < lines.Length; y++)
			for (int x = 0; x <lines[y].Length; x++)
				if (lines[y][x] == 'X')
					result++;
		return result;
	}

	static void PredictGuardRoute(char[][] lines, int x, int y, bool firstCallFlag)
	{
		int xModifier = 0;
		int yModifier = 0;
		if (!firstCallFlag)
			lines[y][x] = SetGuardPointOfView(lines[y][x]);
		SetPointModifiers(lines[y][x], ref xModifier, ref yModifier);
		char tmp = lines[y][x];
		while (IsInRange(lines, y, x))
		{
			if (IsInRange(lines, y + yModifier, x + xModifier) && lines[y + yModifier][x + xModifier] == '#')
			{
				PredictGuardRoute(lines, x, y, false);
				return ;
			}
			lines[y][x] = 'X';
			y += yModifier;
			x += xModifier;
			if (IsInRange(lines, y, x))
				lines[y][x] = tmp;
		}
	}

	static int Main()
	{
		string fileName = "test.txt";
		if (!File.Exists(fileName))
			return 1;
		string[] text = File.ReadAllLines(fileName);
		char[][] lines = new char[text.Length][];
		for (int iter = 0; iter < lines.Length;iter++)
		{
			lines[iter] = new char[text[iter].Length];
			for(int i = 0; i < text[iter].Length;i++)
				lines[iter][i] = text[iter][i];
		}
		for (int y = 0; y < lines.Length;y++)
			for (int x = 0;x < lines[y].Length;x++)
				if (lines[y][x] == '^')
					PredictGuardRoute(lines, x, y, true);
		Console.WriteLine(CountPatrolPathPoints(lines));			
		return 0;
	}
}
