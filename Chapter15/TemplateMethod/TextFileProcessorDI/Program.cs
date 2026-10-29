using TextFileProcessorDI;

var service = new LineCounterService();
var processer = new TextFileProcessor(service);
string fileName = @"C:\Users\infosys\source\repos\OOP2026\Chapter14\演習問題\Exercise01_WPF\走れメロス.txt";
    processer.Run(fileName);