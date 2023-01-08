
using System.Text;

var sb = new StringBuilder();

/*
Adding at least 3 double quotes, you can add normally the double quote inside the string
*/
var jsonText1 = """{ "name": "Rodrigo", "age": 30 }""";

/*
If necessary, you can add multiple new lines in the raw string literal (However, the string literal delimitation ["""] should end on it's own line, alone)
*/
var jsonText2 = """
    {
        "name": "Rodrigo", 
        "age": 30 
    }
    """;

/* 
You can also add string interpolation, by adding the dolar sign ($) on the string's start, and if you need to escape more 
than one curly brace ({}), you just need to add one more dolar sign:
*/
var name = "Rodrigo Martins";
var jsonText3 = $$"""
    {
        "name": "{{name}}", 
        "age": 30 
    }
    """;

sb.AppendFormat("Example 1: {0}\n", jsonText1);
sb.AppendFormat("Example 2: {0}\n", jsonText2);
sb.AppendFormat("Example 3: {0}\n", jsonText3);
Console.WriteLine(sb.ToString());
