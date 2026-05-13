namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {

            var songs = new List<Song>();

            while (true) {
                Console.Write("曲名:");
                string? inputTitle = Console.ReadLine();
                if (inputTitle.ToLower() == "end") {
                    break;
                }
                Console.Write("アーティスト名:");
                string? inputArtistName = Console.ReadLine();
                Console.Write("曲の長さ");
                int inputLength = int.Parse(Console.ReadLine());
                Song song = new Song(inputTitle, inputArtistName, inputLength);
                songs.Add(song);
            }

            PrintSongs(songs);

        }
        //2.1.4
        private static void PrintSongs(IEnumerable<Song> songs) {
            foreach (var song in songs) {
                Console.WriteLine($"{song.Title},{song.ArtistName},{song.Length / 60}:{song.Length % 60:00}");
            }
        }
    }
}
