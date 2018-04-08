using Mal.XF.Infra.Collections;
using Mal.XF.Infra.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mal.XF.Infra.DevApp.Pages.LazyListView
{
    internal class ImageLoadItemsStrategy : ILoadItemsStrategy<string>
    {
        public Task<IReadOnlyCollection<string>> LoadItemsAsync(int pageNumber, int pageSize)
        {
            return Task.Run(() => this.DownloadImageUrls(pageNumber, pageSize));
        }

        private IReadOnlyCollection<string> DownloadImageUrls(int pageNumber, int pageSize)
        {
            return this.GetAllImages().Skip(pageNumber * pageSize)
                        .Take(pageSize)
                        .ToReadOnlyCollection();
        }

        private IReadOnlyCollection<string> GetAllImages()
        {
            var images = new List<string>();
            using (var webclient = new WebClient())
            {
                var data = webclient.DownloadString(new Uri("http://balades.michaelalbaladejo.com/Visites"));
                var regex = new Regex("/pictures/([^\\\"]*)");

                var matches = regex.Matches(data);

                foreach (Match item in matches)
                {
                    images.Add($"http://balades.michaelalbaladejo.com/{item.Value}");
                }
            }

            return images;
        }
    }

    internal class ImageRowLoadItemsStrategy : ILoadItemsStrategy<ImagesRow>
    {
        public Task<IReadOnlyCollection<ImagesRow>> LoadItemsAsync(int pageNumber, int pageSize)
        {
            return Task.Run(() => this.DownloadImageUrls(pageNumber, pageSize));
        }

        private IReadOnlyCollection<ImagesRow> DownloadImageUrls(int pageNumber, int pageSize)
        {
            var rows = this.GetAllImagesRows(this.GetAllImages());

            return rows.Skip(pageNumber * pageSize)
                        .Take(pageSize)
                        .ToReadOnlyCollection();
        }

        private IReadOnlyCollection<ImagesRow> GetAllImagesRows(IReadOnlyCollection<string> sources)
        {
            var rows = new List<ImagesRow>();
            const int numberOfImagesPerRow = 4;

            var images = new List<string>();
            do
            {
                images = sources.Skip(numberOfImagesPerRow * rows.Count)
                   .Take(numberOfImagesPerRow)
                   .ToList();

                rows.Add(new ImagesRow(images));
            }
            while (images.Count > 0);

            return rows;
        }

        private IReadOnlyCollection<string> GetAllImages()
        {
            var images = new List<string>();
            using (var webclient = new WebClient())
            {
                var data = webclient.DownloadString(new Uri("http://balades.michaelalbaladejo.com/Visites"));
                var regex = new Regex("/pictures/([^\\\"]*)");

                var matches = regex.Matches(data);

                foreach (Match item in matches)
                {
                    images.Add($"http://balades.michaelalbaladejo.com/{item.Value}");
                }
            }

            return images;
        }
    }

    internal class ImagesRow
    {
        public ImagesRow(IReadOnlyList<string> images)
        {
            if (images.Count > 0)
                Image1 = images[0];

            if (images.Count > 1)
                Image2 = images[1];

            if (images.Count > 2)
                Image3 = images[2];

            if (images.Count > 3)
                Image4 = images[3];
        }

        public string Image1 { get; }
        public string Image2 { get; }
        public string Image3 { get; }
        public string Image4 { get; }
    }
}