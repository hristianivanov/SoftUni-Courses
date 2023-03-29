namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Text;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albumsInfo = context.Albums
                .Where(a => a.ProducerId.HasValue && a.ProducerId == producerId)
                .AsEnumerable()
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = a.Producer?.Name,
                    Songs = a.Songs.Select(s => new
                    {
                        SongName = s.Name,
                        SongPrice = s.Price,
                        WriterName = s.Writer.Name,
                    })
                    .OrderByDescending(s => s.SongName)
                    .ThenBy(s => s.WriterName)
                    .ToArray(),
                    TotalPrice = a.Price
                })
                .OrderByDescending(a => a.TotalPrice)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var album in albumsInfo)
            {
                sb
                    .AppendLine($"-AlbumName: {album.AlbumName}")
                    .AppendLine($"-ReleaseDate: {album.ReleaseDate}")
                    .AppendLine($"-ProducerName: {album.ProducerName}")
                    .AppendLine($"-Songs:");
                int count = 1;
                foreach (var song in album.Songs)
                {
                    sb
                        .AppendLine($"---#{count}")
                        .AppendLine($"---SongName: {song.SongName}")
                        .AppendLine($"---Price: {song.SongPrice:f2}")
                        .AppendLine($"---Writer: {song.WriterName}");
                    count++;
                }
                sb.AppendLine($"-AlbumPrice: {album.TotalPrice:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songsInfo = context.Songs
                .AsEnumerable()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    SongName = s.Name,
                    Performers = s.SongPerformers
                        .Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}")
                        .OrderBy(p => p)
                        .ToArray(),
                    WriterName = s.Writer.Name,
                    AlbumProducer = s.Album!.Producer!.Name,
                    Duration = s.Duration.ToString("c")
                })
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.WriterName)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            int count = 1;
            foreach (var song in songsInfo)
            {
                sb
                    .AppendLine($"-Song #{count}")
                    .AppendLine($"---SongName: {song.SongName}")
                    .AppendLine($"---Writer: {song.WriterName}");

                foreach (var performer in song.Performers)
                {
                    sb
                        .AppendLine($"---Performer: {performer}");
                }
                sb
                    .AppendLine($"---AlbumProducer: {song.AlbumProducer}")
                    .AppendLine($"---Duration: {song.Duration}");

                count++;
            }

            return sb.ToString().TrimEnd();
        }
    }
}
