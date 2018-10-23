using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeNews.Model
{
    public class NewsItem
    {
        public int Id { get; set; }

        public string Category { get; set; }

        public string Headline { get; set; }

        public string Subhead { get; set; }

        public string DateLine { get; set; }

        public string Image { get; set; }
    }

    public class NewManager
    {
        public static void GetNews(string category, ObservableCollection<NewsItem> newsItems)
        {
            var allItem = getNewsItems();
            var filteredNewsItems = allItem.Where(p => p.Category == category).ToList();
            newsItems.Clear();
            filteredNewsItems.ForEach(p => newsItems.Add(p));
        }

        private static List<NewsItem> getNewsItems()
        {
            var items = new List<NewsItem>();

            items.Add(new NewsItem()
            {
                Id = 1,
                Category = "Financial",
                Headline = "Lorem",
                Subhead = "Doro sit amet",
                DateLine = "Nunc tristique nec",
                Image = "Assets/Financial.png"
            });

            items.Add(new NewsItem()
            {
                Id = 2,
                Category = "Financial",
                Headline = "Etiam ac felis viverra",
                Subhead = "vulputate nisl ac,aliquet nisi",
                DateLine = "tortor porttitor, eu fermentun ante congue",
                Image = "Assets/Financial2.jpg"
            });

            items.Add(new NewsItem()
            {
                Id = 3,
                Category = "Financial",
                Headline = "Integer sed turpits erat",
                Subhead = "Sed quis hendreit lorem, quis interdunm dolor",
                DateLine = "in viverra metus facilisis sed",
                Image = "Assets/Financial3.png"
            });

            items.Add(new NewsItem()
            {
                Id = 4,
                Category = "Financial",
                Headline = "Proin sem neque",
                Subhead = "aliquet quis ipsum tincidunt",
                DateLine = "Integer eleifend",
                Image = "Assets/Financial4.png"
            });

            items.Add(new NewsItem()
            {
                Id = 5,
                Category = "Financial",
                Headline = "Mauris dictum non leo vitae tempor",
                Subhead = "In nisl tortor, enelifend sed ipsum eget",
                DateLine = "Curabitur dictum auge vitae element ulrices",
                Image = "Assets/Financial5.png"
            });
            items.Add(new NewsItem()
            {
                Id = 6,
                Category = "Food",
                Headline = "Lorem ipsum",
                Subhead = "Doro sit amet",
                DateLine = "Nunc tristique nec",
                Image = "Assets/Food1.png"
            });
            items.Add(new NewsItem()
            {
                Id = 7,
                Category = "Food",
                Headline = "Etiam ac felis viverra",
                Subhead = "vulputate nisl ac,aliquet nisi",
                DateLine = "tortor porttitor, eu fermentun ante congue",
                Image = "Assets/Food2.png"
            });
            items.Add(new NewsItem()
            {
                Id = 8,
                Category = "Food",
                Headline = "Integer sed turpits erat",
                Subhead = "Sed quis hendreit lorem, quis interdunm dolor",
                DateLine = "in viverra metus facilisis sed",
                Image = "Assets/Food3.png"
            });
            items.Add(new NewsItem()
            {
                Id = 9,
                Category = "Food",
                Headline = "Proin sem neque",
                Subhead = "aliquet quis ipsum tincidunt",
                DateLine = "Integer eleifend",
                Image = "Assets/Food4.png"
            });
            items.Add(new NewsItem()
            {
                Id = 10,
                Category = "Food",
                Headline = "Mauris dictum non leo vitae tempor",
                Subhead = "In nisl tortor, enelifend sed ipsum eget",
                DateLine = "Curabitur dictum auge vitae element ulrices",
                Image = "Assets/Food5.png"
            });


            return items;
        }

    }
}
