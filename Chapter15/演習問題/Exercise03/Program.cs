using Exercise03;

var service = new Take20Service();
var processer = new TextFileProcessor(service);
string fileName = @"C:\Users\infosys\source\repos\OOP2026\Chapter14\演習問題\Exercise01_WPF\bin\Debug\net8.0-windows\吾輩は猫である.txt";
processer.Run(fileName);