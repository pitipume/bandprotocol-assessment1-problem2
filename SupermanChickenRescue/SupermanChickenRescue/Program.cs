public class Program
{
    public static void Main()
    {
        // n = Number of chickens
        Console.Write("Input n (number of chickens): ");
        int n = int.Parse(Console.ReadLine());

        // k = Length of roof that Superman can carry to cover chickens
        Console.Write("Input k (length of the roof): ");
        int k = int.Parse(Console.ReadLine());

        // Hash of chicken positions (unique position -> no duplicate) 
        HashSet<int> hashChickenPositions = new HashSet<int>();

        // Array of chicken positions
        int[] chickenPositions = new int[n];

        for (int i = 0; i < n; i++)
        {
            int chickenPosition;
            while (true)
            {
                Console.Write($"Input chickenPosition of {i + 1}st chicken: ");
                chickenPosition = int.Parse(Console.ReadLine());

                // Check duplicate position
                if (hashChickenPositions.Contains(chickenPosition))
                {
                    Console.WriteLine("The seat is already taken by some previous chick -> please select a new one please.");
                }
                // Check number not exceed
                else if (chickenPosition < 1 || chickenPosition > 1000000)
                {
                    Console.WriteLine("Please put the number between 1 to 1,000,000 only!");
                }
                else
                {
                    break;
                }
            }
            chickenPositions[i] = chickenPosition;
            hashChickenPositions.Add(chickenPosition);
        }

        Array.Sort(chickenPositions);

        int maxChickens = 0;
        int left = 0;
        int right = 0;

        // Validate logic from Left to Right (Like PointA to PointB)
        for (right = 0; right < n; right++)
        {
            while (chickenPositions[right] - chickenPositions[left] >= k)
            {
                left++;
            }
            maxChickens = Math.Max(maxChickens, (right - left) + 1); // The reason to +1 is because to include the 1st chicken that can be covered itself
        }

        Console.WriteLine($"Maximum number of chickens that Superman can protect within the carried roof = {maxChickens}");
    }
}
