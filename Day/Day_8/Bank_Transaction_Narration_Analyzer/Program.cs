using System;

class Program
{
    static void Main(string[] args)
    {
        string input= Console.ReadLine();

        string[] parts=input.Split('#');

        string transactionId = parts[0];
        string accountHolder = parts[1];
        string narration = parts[2];

        //--------Narration Normalization--------
        narration=narration.Trim(); //trim spaces

        while (narration.Contains("  "))       // replace multiple spaces with single
        {
            narration = narration.Replace("  ", " ");
        }
            
        narration = narration.ToLower();   

        //------keyword Identification------
        bool hasDeposit = narration.Contains("deposit");
        bool hasWithdrawal = narration.Contains("withdrawal");
        bool hasTransfer = narration.Contains("transfer");

        bool hasKeyword = hasDeposit || hasWithdrawal || hasTransfer;

        //------Narration Comaprison------
        string standardNarration = "cash deposit successful";
        bool isStandard = narration.Equals(standardNarration);

        //------Categorization------
        string category;

        if (!hasKeyword)
        {
            category="NON-FINANCIAL TRANSACTION";
        }
        else if (hasKeyword && isStandard)
        {
            category="STANDARD TRANSACTION";
        }
        else
        {
            category="CUSTOM TRANSACTION";
        }

        Console.WriteLine($"Transaction ID : {transactionId}");
        Console.WriteLine($"Account Holder : {accountHolder}");
        Console.WriteLine($"Narration      : {narration}");
        Console.WriteLine($"Category       : {category}");

    }
}
