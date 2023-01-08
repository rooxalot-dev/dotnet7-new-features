int[] numbers = { 1, 2, 3, 4 };

//Now you can check if a list follows a specific pattern
Console.WriteLine("Validation 1: {0}", numbers is [1, 2, 3, 4]);
Console.WriteLine("Validation 2: {0}", numbers is [1, .., 4]);
Console.WriteLine("Validation 3: {0}", numbers is [> 0, _, <= 4, _]);
Console.WriteLine("Validation 4: {0}", numbers is [> 0, > 2, <= 4, _]);

/*
Another thing that you can do is "desconstruct" the collection, so you can get an specific session and use it as a scoped variable.
In the example below, the variables "first" and "rest" can only be accesed inside the IF statement.
*/
if (numbers is [var first, .. var rest, 4])
{
    Console.WriteLine("First Value: {0}", first);
    Console.WriteLine("Rest value: {0}", string.Join(",", rest));
};


/*
One other thing that could be done is the validation of a specific value (in the example below, the DEPOSIT, WITHDRAWAL, etc values)
to do a specific operation in a list, using the short switch syntax.
*/
foreach (string[] transaction in GetTransactions())
{
    var message = transaction switch
    {
        [var date, "DEPOSIT", .., var amount] => string.Format("Deposit of {0} in {1}", amount, date),
        [var date, "WITHDRAWAL", .., var amount] => string.Format("Withdrawal of {0} in {1}", amount, date),
        [var date, "INTEREST", .., var amount] => string.Format("Interest of {0} in {1}", amount, date),
        [var date, "FEE", .., var amount] => string.Format("Fee of {0} in {1}", amount, date),
        _ => string.Format($"Record {string.Join(", ", transaction)} is not in the expected format!"), // Checks the default value
    };

    Console.WriteLine(message);
}

List<string[]> GetTransactions()
{
    var inMemoryCSV =
    """
    04-01-2020, DEPOSIT,    Initial deposit,            2250.00
    04-15-2020, DEPOSIT,    Refund,                      125.65
    04-18-2020, DEPOSIT,    Paycheck,                    825.65
    04-22-2020, WITHDRAWAL, Debit,           Groceries,  255.73
    05-01-2020, WITHDRAWAL, #1102,           Rent, apt, 2100.00
    05-02-2020, INTEREST,                                  0.65
    05-07-2020, WITHDRAWAL, Debit,           Movies,      12.57
    04-15-2020, FEE,                                       5.55
    """;

    var transactionRows = inMemoryCSV.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
    var rowColumns = transactionRows
        .Select(row =>
        {
            var splitedColumns = row
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(splitedColumn => splitedColumn.Trim());

            return splitedColumns.ToArray();
        })
        .ToList();

    return rowColumns.ToList();
}
