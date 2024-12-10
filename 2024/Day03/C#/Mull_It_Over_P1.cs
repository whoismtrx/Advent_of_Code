class Mull_it_Over_P1{

	static bool IsInstructionHead(string Text, int Index)
	{
		string Reference = "mul(";
		int RefIndex = 0;
		while (RefIndex < Reference.Length)
		{
			if (Text[Index] != Reference[RefIndex])
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
		if (!File.Exists(FileName))
			return 1;
		string Text = File.ReadAllText(FileName);
		for (int i = 0 ; i < Text.Length;i++)
		{
			if (IsInstructionHead(Text, i))
			{
				i += 4;
				Result += ParseParams(Text, i);
			}
		}
		Console.WriteLine(Result);
		return 0;
	}
}