using Exercise03;

var service = new Take20Service();
var processer = new TextFileProcessor(service);
string fileName = @"C:\Users\infosys\source\repos\OOP2026\Chapter15\演習問題\Exercise03\枕草子.txt";
processer.Run(fileName);