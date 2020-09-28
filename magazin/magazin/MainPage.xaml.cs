using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Forms;
using System.Threading;
using System.Text.Json;

namespace magazin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            gridShowText.IsVisible = false;//Скрытие надписи и кнопки
        }

        Dictionary<string, object> offers;//Список отображаемый на экране, object используется для добавления разных классов

        private async Task GetData()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);//Регистрация кодировки системы для нормального отображения данных при парсинге XML

            offers = new Dictionary<string, object>();

            using (HttpClient ht = new HttpClient())
            {
                string res = await ht.GetStringAsync(@"https://partner.market.yandex.ru/pages/help/YML.xml");//Получаем файл виде строки
                
                //Объявления класса для парсинга XML
                XDocument xdoc = XDocument.Parse(res.Replace("<!DOCTYPE yml_catalog SYSTEM \"shops.dtd\">", ""));

                //Заполнения offers данными
                foreach (var item in xdoc.Element("yml_catalog").Element("shop").Element("offers").Elements("offer"))//Спуск до элементов offer
                {
                    //Условия проверки типа элемента offer 
                    if (item.Attribute("type").Value == Book.Type)
                    {
                        offers.Add(item.Attribute("id").Value, new Book
                        {
                            id = item.Attribute("id")?.Value,
                            url = item.Element("url")?.Value,
                            price = item.Element("price")?.Value,
                            currencyId = item.Element("currencyId")?.Value,
                            picture = item.Element("picture")?.Value,
                            delivery = item.Element("delivery")?.Value ?? "false",
                            local_delivery_cost = item.Element("local_delivery_cost")?.Value,
                            category = new Category
                            {
                                categoryType = item.Element("categoryId").Attribute("type")?.Value,
                                categoryId = item.Element("categoryId")?.Value
                            },
                            author = item.Element("author")?.Value,
                            binding = item.Element("binding")?.Value,
                            description = item.Element("description")?.Value,
                            downloadable = item.Element("downloadable")?.Value,
                            ISBN = item.Element("ISBN")?.Value,
                            language = item.Element("language")?.Value,
                            name = item.Element("name")?.Value,
                            page_extent = item.Element("page_extent")?.Value,
                            part = item.Element("part")?.Value,
                            publisher = item.Element("publisher")?.Value,
                            series = item.Element("series")?.Value,
                            volume = item.Element("volume")?.Value,
                            year = item.Element("year")?.Value
                        });
                    }
                    else if (item.Attribute("type").Value == VendorModel.Type)
                    {
                        offers.Add(item.Attribute("id").Value, new VendorModel
                        {
                            id = item.Attribute("id")?.Value,
                            url = item.Element("url")?.Value,
                            price = item.Element("price")?.Value,
                            currencyId = item.Element("currencyId")?.Value,
                            picture = item.Element("picture")?.Value,
                            delivery = item.Element("delivery")?.Value ?? "false",
                            local_delivery_cost = item.Element("local_delivery_cost")?.Value,
                            category = new Category
                            {
                                categoryType = item.Element("categoryId").Attribute("type")?.Value,
                                categoryId = item.Element("categoryId")?.Value
                            },
                            country_of_origin = item.Element("country_of_origin")?.Value,
                            description = item.Element("description")?.Value,
                            manufacturer_warranty = item.Element("manufacturer_warranty")?.Value,
                            model = item.Element("model")?.Value,
                            typePrefix = item.Element("typePrefix")?.Value,
                            vendor = item.Element("vendor")?.Value,
                            vendorCode = item.Element("vendorCode")?.Value
                        });
                    }
                    else if (item.Attribute("type").Value == Audiobook.Type)
                    {
                        offers.Add(item.Attribute("id").Value, new Audiobook
                        {
                            id = item.Attribute("id")?.Value,
                            url = item.Element("url")?.Value,
                            price = item.Element("price")?.Value,
                            currencyId = item.Element("currencyId")?.Value,
                            picture = item.Element("picture")?.Value,
                            delivery = item.Element("delivery")?.Value ?? "false",
                            category = new Category
                            {
                                categoryType = item.Element("categoryId").Attribute("type")?.Value,
                                categoryId = item.Element("categoryId")?.Value
                            },
                            author = item.Element("author")?.Value,
                            description = item.Element("description")?.Value,
                            downloadable = item.Element("downloadable")?.Value,
                            format = item.Element("format")?.Value,
                            ISBN = item.Element("ISBN")?.Value,
                            language = item.Element("language")?.Value,
                            name = item.Element("name")?.Value,
                            performance_type = item.Element("performance_type")?.Value,
                            performed_by = item.Element("performed_by")?.Value,
                            publisher = item.Element("publisher")?.Value,
                            recording_length = item.Element("recording_length")?.Value,
                            storage = item.Element("storage")?.Value,
                            year = item.Element("year")?.Value
                        });
                    }
                    else if (item.Attribute("type").Value == ArtistTitle.Type)
                    {
                        offers.Add(item.Attribute("id").Value, new ArtistTitle
                        {
                            id = item.Attribute("id")?.Value,
                            url = item.Element("url")?.Value,
                            price = item.Element("price")?.Value,
                            currencyId = item.Element("currencyId")?.Value,
                            picture = item.Element("picture")?.Value,
                            delivery = item.Element("delivery")?.Value ?? "false",
                            category = new Category
                            {
                                categoryType = item.Element("categoryId").Attribute("type")?.Value,
                                categoryId = item.Element("categoryId")?.Value
                            },
                            artist = item.Element("artist")?.Value,
                            country = item.Element("country")?.Value,
                            description = item.Element("description")?.Value,
                            director = item.Element("director")?.Value,
                            media = item.Element("media")?.Value,
                            originalName = item.Element("originalName")?.Value,
                            starring = item.Element("starring")?.Value,
                            title = item.Element("title")?.Value,
                            year = item.Element("year")?.Value
                        });
                    }
                    else if (item.Attribute("type").Value == Tour.Type)
                    {
                        offers.Add(item.Attribute("id").Value, new Tour
                        {
                            id = item.Attribute("id")?.Value,
                            url = item.Element("url")?.Value,
                            price = item.Element("price")?.Value,
                            currencyId = item.Element("currencyId")?.Value,
                            picture = item.Element("picture")?.Value,
                            delivery = item.Element("delivery")?.Value ?? "false",
                            category = new Category
                            {
                                categoryType = item.Element("categoryId").Attribute("type")?.Value,
                                categoryId = item.Element("categoryId")?.Value
                            },
                            artist = item.Element("artist")?.Value,
                            country = item.Element("country")?.Value,
                            dataTour = item.Element("dataTour")?.Value,
                            days = item.Element("days")?.Value,
                            description = item.Element("description")?.Value,
                            hotel_stars = item.Element("hotel_stars")?.Value,
                            included = item.Element("included")?.Value,
                            meal = item.Element("meal")?.Value,
                            name = item.Element("name")?.Value,
                            region = item.Element("region")?.Value,
                            room = item.Element("room")?.Value,
                            transport = item.Element("transport")?.Value,
                            worldRegion = item.Element("worldRegion")?.Value
                        });
                    }
                    else if (item.Attribute("type").Value == EventTicket.Type)
                    {
                        offers.Add(item.Attribute("id").Value, new EventTicket
                        {
                            id = item.Attribute("id")?.Value,
                            url = item.Element("url")?.Value,
                            price = item.Element("price")?.Value,
                            currencyId = item.Element("currencyId")?.Value,
                            picture = item.Element("picture")?.Value,
                            delivery = item.Element("delivery")?.Value ?? "false",
                            category = new Category
                            {
                                categoryType = item.Element("categoryId").Attribute("type")?.Value,
                                categoryId = item.Element("categoryId")?.Value
                            },
                            date = item.Element("date")?.Value,
                            description = item.Element("description")?.Value,
                            hall = new Hall { hall = item.Element("hall")?.Value, plan = item.Element("hall").Attribute("plan")?.Value },
                            hall_part = item.Element("hall_part")?.Value,
                            is_kids = item.Element("is_kids")?.Value,
                            is_premiere = item.Element("is_premiere")?.Value,
                            name = item.Element("name")?.Value,
                            place = item.Element("place")?.Value
                        });
                    }

                }

            }

            //Источник данных Списка отображается виде Id offer
            CollOffer.ItemsSource = offers.Keys;
        }

        private void ContentPage_LayoutChanged(object sender, EventArgs e)//События загрузки формы 
        {
            Task task = Task.Run(GetData);//Запуск потока для выполнения асинхронных задач
            task.Wait();//Ожидания выполнения потока
        }

        //События когда пользователь нажимает по элементу внутри списка
        private void CollOffer_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            gridListView.IsVisible = false;//Скрываем Список для вывода текста в Json формате
            gridShowText.IsVisible = true;//Показываем Надпись для вывода Json формата

            string resultJson = JsonSerializer.Serialize(offers[CollOffer.SelectedItem.ToString()]);//Сериализация данных выбранного элемента 

            dispalyText.Text = resultJson;//Заменяет текст надписи Json данными
        }

        private void Button_Clicked(object sender, EventArgs e)//Кнопка принять для скрытия Надписи и визуализации Списка
        {
            gridListView.IsVisible = true;
            gridShowText.IsVisible = false;
        }
    }
}
