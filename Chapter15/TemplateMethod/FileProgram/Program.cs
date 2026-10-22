using TextFileProcessor;



string path = @"C:\Users\infosys\source\repos\OOP2026\\Chapter14\演習問題\Exercise01_WPF\吾輩は猫である.txt";
TextProcessor.Run<LineCounterProcessor>(path);
public class LineCounterProcessor : TextProcessor {



    private int _count = 0;
    private string _searchWord = "";

    protected override void Initialize(string fname) {
        _count = 0;
        Console.Write("カウントしたい単語：");
           _searchWord = Console.ReadLine();
    }


    protected override void Execute(string line) =>
        _count += line.Split(_searchWord).Length - 1;
        

    protected override void Terminate() =>
         Console.WriteLine($"「{_searchWord}」は、{_count} 個出現します");
}