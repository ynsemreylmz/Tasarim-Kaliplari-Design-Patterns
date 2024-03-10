ScoringAlgorithm scoringAlgorithm;

Console.WriteLine("Mans");
scoringAlgorithm = new MensScoringAlgorithm();
Console.WriteLine(scoringAlgorithm.GenerateScore(8, new TimeSpan(0, 2, 34)));

Console.WriteLine("Womans");
scoringAlgorithm = new WomansScoringAlgorithm();
Console.WriteLine(scoringAlgorithm.GenerateScore(8, new TimeSpan(0, 2, 34)));

Console.WriteLine("Childrens");
scoringAlgorithm = new ChildrensScoringAlgorithm();
Console.WriteLine(scoringAlgorithm.GenerateScore(8, new TimeSpan(0, 2, 34)));
abstract class ScoringAlgorithm
{
	public int GenerateScore(int hits, TimeSpan time)
	{
		int score = CalculateBaseScore(hits);
		int reduction = CalculateReduction(time);
		return CalulateOverallScore(score, reduction);
	}

	public abstract int CalulateOverallScore(int score, int reduction);

	public abstract int CalculateReduction(TimeSpan time);

	public abstract int CalculateBaseScore(int hits);
	
}


class MensScoringAlgorithm : ScoringAlgorithm
{
	public override int CalculateBaseScore(int hits)
	{
		return hits * 100;
	}

	public override int CalculateReduction(TimeSpan time)
	{
		return (int)time.TotalSeconds / 5;
	}

	public override int CalulateOverallScore(int score, int reduction)
	{
		return score - reduction;
	}
}

class WomansScoringAlgorithm : ScoringAlgorithm
{
	public override int CalculateBaseScore(int hits)
	{
		return hits * 100;
	}

	public override int CalculateReduction(TimeSpan time)
	{
		return (int)time.TotalSeconds / 3;
	}

	public override int CalulateOverallScore(int score, int reduction)
	{
		return score - reduction;
	}
}

class ChildrensScoringAlgorithm : ScoringAlgorithm
{
	public override int CalculateBaseScore(int hits)
	{
		return hits * 100;
	}

	public override int CalculateReduction(TimeSpan time)
	{
		return (int)time.TotalSeconds / 2;
	}

	public override int CalulateOverallScore(int score, int reduction)
	{
		return score - reduction;
	}
}