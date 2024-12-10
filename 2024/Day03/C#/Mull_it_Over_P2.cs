class Mull_it_Over_P2{

	static bool IsInstruction(string Text, String InstructionName ,int Index)
	{
		int RefIndex = 0;
		while (RefIndex < InstructionName.Length)
		{
			if (Text[Index] != InstructionName[RefIndex])
				return false;
			Index++;
			RefIndex++;
		}
		return true;
	}

	static int SetParams(String Text, ref int Index, char Limiter)
	{
		int tmp = Index;
		while (Index < Text.Length)
		{
			if (Text[Index] == Limiter)
				break;
			if (!char.IsDigit(Text[Index]))
				return 0;
			Index++;
		}
		if (tmp == Index)
			return 0;
		return Convert.ToInt32(Text[tmp..Index]);
	}

	static int ParseParams(string Text, int Index)
	{
		int FirstParam = 0;
		int LastParam = 0;
		FirstParam = SetParams(Text, ref Index, ',');
		Index+=1;
		LastParam = SetParams(Text, ref Index, ')');
		return LastParam * FirstParam;
	}

	static int Main()
	{
		string FileName = "input.txt";
		int Result = 0;
		bool state = true;
		if (!File.Exists(FileName))
			return 1;
		string Text = File.ReadAllText(FileName);
		for (int i = 0 ; i < Text.Length;i++)
		{
			if (IsInstruction(Text, "don't()", i))
			{
				i += 6;
				state = false;
			}
			if (IsInstruction(Text, "do()", i))
			{
				i += 4;
				state = true;
			}
			if (IsInstruction(Text, "mul(", i))
			{
				i += 4;
				if (state)
					Result += ParseParams(Text, i);
			}
		}
		Console.WriteLine(Result);
		return 0;
	}
}