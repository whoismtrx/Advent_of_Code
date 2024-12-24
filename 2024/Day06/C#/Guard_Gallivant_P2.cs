using System;

class Guard_Gallivant_P2 {
	
	public static int TurnsNumber = 0;
	public static bool LockCount = false;
	
	static char SetGuardPointOfView(char CurrentPointOfView)
	{
		string reference = "<>^v";
		string results = "^v><";
		for(int i = 0; i < 4;i++)
			if (CurrentPointOfView == reference[i])
				return results[i];
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

	static int IsGuardStuckInLoop(char[][] lines, int x, int y)
	{
		int localTurnsNumber = 0;
		int xModifier = 0;
		int yModifier = 0;
		SetPointModifiers(lines[y][x], ref xModifier, ref yModifier);
		char tmp = lines[y][x];
		int count;
		while (IsInRange(lines, y, x))
		{
			count = 0;
			while (IsInRange(lines, y + yModifier, x + xModifier) && lines[y + yModifier][x + xModifier] == '#')
			{
				count++;
				lines[y][x] = SetGuardPointOfView(lines[y][x]);
				xModifier = 0;
				yModifier = 0;
				SetPointModifiers(lines[y][x], ref xModifier, ref yModifier);
				tmp = lines[y][x];
				if (count == 1)
					localTurnsNumber += 1;
				if (!LockCount)
					TurnsNumber += 1;
			}
			lines[y][x] = '.';
			y += yModifier;
			x += xModifier;
			if (IsInRange(lines, y, x))
				lines[y][x] = tmp;
			if (LockCount && localTurnsNumber > TurnsNumber * 2)
				return 1;
		}
		LockCount = true;
		return 0;
	}

	static void ResetLines(char [][]lines)
	{
		for (int j = 0; j < lines.Length;j++)
		{
			for (int i = 0; i< lines[j].Length; i++)
			{
				if ("<>^v".Contains(lines[j][i]))
					lines[j][i] = '.';
			}
		}
	}
	
	static int CountPatrolLoops(char [][]lines, int GuardX, int GuardY, char GuardCharacter)
	{
		int result = 0;
		int x = 0;
		int y = 0;
		while (y < lines.Length)
		{
			x = 0;
			while (x < lines[y].Length)
			{
				if (lines[y][x] == '.')
				{
					lines[y][x] = '#';
					if (!LockCount)
						TurnsNumber = 0;
					result += IsGuardStuckInLoop(lines, GuardX, GuardY);
					ResetLines(lines);
					lines[y][x] = '.';
					lines[GuardY][GuardX] = GuardCharacter;
				}
				x++;
			}
			y++;
		}
		return result;
	}
	static int Main()
	{
		string fileName = "input.txt";
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
		for (int j = 0; j < lines.Length;j++)
			for (int i = 0;i < lines[j].Length;i++)
				if ("<>^v".Contains(lines[j][i]))
					Console.WriteLine(CountPatrolLoops(lines, i, j, lines[j][i]));
		return 0;
	}
}