using System.Text;

string text = " This is a test for Middilizer ";
string delimiter = @"~";
string surroundingDelimiter = @"+";
int commentLength = 75;

Console.WriteLine(CommentMiddlizer(text, delimiter, surroundingDelimiter, commentLength));

string CommentMiddlizer(string text, string delimiter = "#", string surroundingDelimiter = "-", int commentLength = 100)
{
	var sb = new StringBuilder();
	var sequence = Enumerable.Range(1, commentLength).Select(e => delimiter).ToArray();
	var sequenceMidPoint = (int)sequence.Count() / 2;
	var textLength = text.Length;
	var textRightHalf = (int)textLength / 2 + (textLength % 2 == 0 ? 0 : 1);
	var textLeftHalf = (int)textLength / 2;

	#region Some arguments check

	if (commentLength== 0)
	{
		commentLength = 100;
	}

	if (string.IsNullOrEmpty(delimiter))
	{
		delimiter = "#";
	}

	if (string.IsNullOrEmpty(surroundingDelimiter))
	{
		surroundingDelimiter = "-";
	}

	if (sequence.Length - textLength <= 0)
	{
		return $"Comment length should be greater than {textLength}";
	}

	#endregion

	for (var position = sequenceMidPoint; position >= sequenceMidPoint - textLeftHalf; position--)
	{
		sequence[position] = "";
	}

	for (var position = sequenceMidPoint; position <= sequenceMidPoint + textRightHalf; position++)
	{
		sequence[position] = "";
	}

	var textPosition = 0;
	for (var position = sequenceMidPoint - textLeftHalf; position < sequenceMidPoint + textRightHalf; position++)
	{
		sequence[position] = text[textPosition].ToString();
		textPosition++;
	}

	var resultText = string.Join("", sequence);
	var surrounding = Enumerable.Range(1, resultText.Length / surroundingDelimiter.Length).Select(e => surroundingDelimiter).ToArray();

	sb.AppendLine($"--{string.Join("", surrounding)}--\r");
	sb.AppendLine($"--{resultText}--\r");
	sb.AppendLine($"--{string.Join("", surrounding)}--");

	return sb.ToString();
}