using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        public lastprakEntities1 db = new lastprakEntities1();

        int selectedTopicId;
        Event selectedEvent;

        public class EventList
        {
            public int id { get; set; }
            public string TopicName { get; set; }
            public DateTime StartDate { get; set; }
            public string EventName { get; set; }
            public string GetPhoto
            {
                get
                {
                    string imagePath = Directory.GetCurrentDirectory() + @"\Images\" + id + ".jpeg";
                    if (File.Exists(imagePath))
                    {
                        return imagePath;
                    }
                    else
                    {
                        string[] extensions = { ".png", ".jpg", ".gif" };
                        foreach (var ext in extensions)
                        {
                            imagePath = Directory.GetCurrentDirectory() + @"\Images\" + id + ext;
                            if (File.Exists(imagePath))
                            {
                                return imagePath;
                            }
                        }
                    }
                    return string.Empty;
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            LoadTopics();
            LoadEvents();
        }

        private void LoadTopics()
        {
            List<ComboBoxItem> TopicList = new List<ComboBoxItem>();
            foreach (Topic topic in db.Topic.ToList())
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Content = topic.topic1;
                cbi.Tag = topic.Idtopic; // Сохраняем Idtopic в Tag
                cbi.Selected += (ss, ee) =>
                {
                    selectedTopicId = (int)cbi.Tag; // Получаем Idtopic из Tag
                    LoadEvents(); // Перезагружаем список событий при выборе темы
                };
                TopicList.Add(cbi);
            }
            CmbTopic.ItemsSource = TopicList;
        }

        private void LoadEvents()
        {
            List<Event> events = db.Event.ToList();
            CmbData.ItemsSource = events;

            var query = db.Event.Join(
                db.Topic,
                @event => @event.topicID,
                topic => topic.Idtopic,
                (@event, topic) => new EventList
                {
                    id = @event.Idevent,
                    TopicName = topic.topic1,
                    StartDate = (DateTime)@event.DATE,
                    EventName = @event.event1,
                });

            if (selectedTopicId != 0)
            {
                query = query.Where(e => e.id == selectedTopicId);
            }

            if (selectedEvent != null)
            {
                query = query.Where(e => e.StartDate == selectedEvent.DATE);
            }

            Lucas.ItemsSource = query.ToList();
        }

        private void authorization_Click(object sender, RoutedEventArgs e)
        {
            Authorization auth = new Authorization();
            auth.Show();
            this.Close();
        }

        private void CmbTopic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Метод LoadEvents() вызывается из обработчика события Selected для комбобокса CmbTopic
        }

        private void CmbData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedEvent = CmbData.SelectedItem as Event;
            LoadEvents();
        }

        private void Reset_Filters(object sender, RoutedEventArgs e)
        {
            // Сбрасываем значения фильтров
            selectedTopicId = 0;
            selectedEvent = null;

            // Повторно загружаем события
            LoadEvents();
        }
    }
}
